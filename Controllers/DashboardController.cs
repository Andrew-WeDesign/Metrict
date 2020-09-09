using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metrict.Data;
using Metrict.Models;
using Metrict.Models.ReportViewModels;
using Metrict.Models.CampaignViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Metrict.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
        }

        [BindProperty]
        public Campaign Campaign { get; set; }

        [BindProperty]
        public Report Report { get; set; }

        [BindProperty]
        public EmployeeTask EmployeeTask { get; set; }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Reports()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            return View();
        }

        public async Task<IActionResult> ReportDetails(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            Report = new Report();
            var report = await _context.Reports.FirstOrDefaultAsync(y => y.Id == id);

            if (report.ApplicationUserId == currentUser.Id || report.ManagerId == currentUser.Id)
            {
                CampaignReportData vm = new CampaignReportData()
                {
                    Campaigns = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == report.CampaignId),
                    Reports = await _context.Reports.FirstOrDefaultAsync(y => y.Id == id)
                };

                return View(vm);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> ReportEdit(int id)
        {
            Report = new Report();
            var report = await _context.Reports.FirstOrDefaultAsync(y => y.Id == id);
            var currentUser = await GetCurrentUserAsync();

            if (report.ApplicationUserId != currentUser.Id)
            {
                return NotFound();
            }

            CampaignReportData vm = new CampaignReportData()
            {
                Campaigns = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == report.CampaignId),
                Reports = await _context.Reports.FirstOrDefaultAsync(y => y.Id == id)
            };

            return View(vm);
        }

        public IActionResult ReportStartReport()
        {
            return View();
        }

        public async Task<IActionResult> ReportCreate(int id)
        {
            Report = new Report();

            CampaignReportData vm = new CampaignReportData()
            {
                Campaigns = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id)
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportUpsert(CampaignReportData campaignReportData)
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserActive == false)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignReportData.Reports.CampaignId);
            if (ModelState.IsValid)
            {
                if (campaignReportData.Reports.Id == 0)
                {
                    campaignReportData.Reports.ManagerId = campaign.ManagerId;
                    campaignReportData.Reports.SubmissionDate = DateTime.Now;
                    campaignReportData.Reports.ApplicationUserId = currentUser.Id;
                    campaignReportData.Reports.ApplicationUserName = currentUser.FullName;
                    //campaignReportData.Reports.CampaignId = campaignReportData.Reports.CampaignId;
                    campaignReportData.Reports.CampaignName = campaign.Name;
                    campaignReportData.Reports.CompanyId = currentUser.CompanyId;
                    _context.Reports.Add(campaignReportData.Reports);
                }
                else
                {
                    var report = await _context.Reports.FirstOrDefaultAsync(x => x.Id == campaignReportData.Reports.Id);
                    if (!CorrectAppUser(currentUser.Id, campaignReportData.Reports.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        report.LastEditDate = DateTime.Now;
                        report.DataColumnNumber1 = campaignReportData.Reports.DataColumnNumber1;
                        report.DataColumnNumber2 = campaignReportData.Reports.DataColumnNumber2;
                        report.DataColumnNumber3 = campaignReportData.Reports.DataColumnNumber3;
                        report.DataColumnNumber4 = campaignReportData.Reports.DataColumnNumber4;
                        report.DataColumnNumber5 = campaignReportData.Reports.DataColumnNumber5;
                        report.DataColumnNumber6 = campaignReportData.Reports.DataColumnNumber6;
                        report.DataColumnNumber7 = campaignReportData.Reports.DataColumnNumber7;
                        report.DataColumnNumber8 = campaignReportData.Reports.DataColumnNumber8;
                        report.DataColumnNumber9 = campaignReportData.Reports.DataColumnNumber9;
                        report.DataColumnNumber10 = campaignReportData.Reports.DataColumnNumber10;
                        report.DataColumnTextA = campaignReportData.Reports.DataColumnTextA;
                        report.DataColumnTextB = campaignReportData.Reports.DataColumnTextB;
                        report.DataColumnTextC = campaignReportData.Reports.DataColumnTextC;
                        report.DataColumnTextD = campaignReportData.Reports.DataColumnTextD;
                        report.DataColumnTextE = campaignReportData.Reports.DataColumnTextE;
                        report.DataColumnTextF = campaignReportData.Reports.DataColumnTextF;
                        report.DataColumnTextG = campaignReportData.Reports.DataColumnTextG;
                        report.DataColumnTextH = campaignReportData.Reports.DataColumnTextH;
                        report.DataColumnTextI = campaignReportData.Reports.DataColumnTextI;
                        report.DataColumnTextJ = campaignReportData.Reports.DataColumnTextJ;
                        report.CompanyId = currentUser.CompanyId;
                        _context.Reports.Update(report);
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Report);
        }




        public async Task<IActionResult> Campaigns()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await GetCurrentUserAsync();
                ViewBag.UserId = currentUser.Id;
            }

            return View();
        }

        public async Task<IActionResult> CampaignDashboard(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.idOfCampaign = campaign.Id;

            if (currentUser.Id != campaign.ManagerId)
            {
                return NotFound();
            }

            List<CampaignUser> userCountList = new List<CampaignUser>();
            userCountList = (from x in _context.CampaignUsers
                             .Where(x => x.CampaignId == id)
                             select x)
                             .Where(x => x.Campaign.ManagerId == currentUser.Id)
                             .Where(x => x.ApplicationUser.UserActive == true)
                             .ToList();

            int userCount = userCountList.Count();
            ViewBag.userCount = userCount;

            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            ViewBag.dateTimeWeekStart = dt;

            string[] colNames = new string[10];
            colNames[0] = campaign.DataColumnNumber1Title;
            colNames[1] = campaign.DataColumnNumber2Title;
            colNames[2] = campaign.DataColumnNumber3Title;
            colNames[3] = campaign.DataColumnNumber4Title;
            colNames[4] = campaign.DataColumnNumber5Title;
            colNames[5] = campaign.DataColumnNumber6Title;
            colNames[6] = campaign.DataColumnNumber7Title;
            colNames[7] = campaign.DataColumnNumber8Title;
            colNames[8] = campaign.DataColumnNumber9Title;
            colNames[9] = campaign.DataColumnNumber10Title;
            colNames = colNames.Where(c => c != null).ToArray();
            ViewBag.colNames = colNames;

            List<Report> reportDataList = new List<Report>();
            reportDataList = (from y in _context.Reports
                .Where(y => y.CampaignId == id)
                              select y)
                .Where(y => y.SubmissionDate >= dt)
                .ToList();
            int reportDataCount = reportDataList.Count();
            ViewBag.reportDataCount = reportDataCount;

            int[] reportData = new int[10];
            foreach (Report report in reportDataList)
            {
                reportData[0] += report.DataColumnNumber1;
                reportData[1] += report.DataColumnNumber2;
                reportData[2] += report.DataColumnNumber3;
                reportData[3] += report.DataColumnNumber4;
                reportData[4] += report.DataColumnNumber5;
                reportData[5] += report.DataColumnNumber6;
                reportData[6] += report.DataColumnNumber7;
                reportData[7] += report.DataColumnNumber8;
                reportData[8] += report.DataColumnNumber9;
                reportData[9] += report.DataColumnNumber10;

            }
            ViewBag.reportData = reportData;

            return View(campaign);
        }

        public async Task<IActionResult> CampaignUpsert(int? id)
        {
            Campaign = new Campaign();

            if (id == null)
            {
                //create
                return View(Campaign);
            }

            //update
            Campaign = _context.Campaigns.FirstOrDefault(u => u.Id == id);

            if (Campaign == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            if (Campaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            return View(Campaign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CampaignUpsert()
        {
            var currentUser = await GetCurrentUserAsync();
            //ViewBag.UserId = currentUser.Id;
            if (currentUser.UserActive == false)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (Campaign.Id == 0)
                {
                    Campaign.ManagerId = currentUser.Id;
                    Campaign.StartDate = DateTime.Now;
                    Campaign.CampaignActive = true;
                    Campaign.CompanyId = currentUser.CompanyId;
                    _context.Campaigns.Add(Campaign);
                    //_context.SaveChanges();
                    if (currentUser.UserRole == "NewUser")
                    {
                        var applicationUser = await _context.ApplicationUsers.FindAsync(currentUser.Id);
                        if (!ManagerExists("Manager", currentUser.CompanyId))
                        {
                            applicationUser.UserRole = "Manager";
                            await _userManager.AddToRoleAsync(applicationUser, "Manager");
                            applicationUser.UserActive = true;
                            if (ModelState.IsValid)
                            {
                                try
                                {
                                    _context.Update(applicationUser);
                                    await _context.SaveChangesAsync();
                                }
                                catch (DbUpdateConcurrencyException)
                                {
                                    if (!ApplicationUserExists(applicationUser.Id))
                                    {
                                        return NotFound();
                                    }
                                    else
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Campaign.ManagerId != currentUser.Id)
                    {
                        return NotFound();
                    }
                    else
                    {
                        Campaign.ManagerId = currentUser.Id;
                        Campaign.CampaignActive = true;
                        Campaign.CompanyId = currentUser.CompanyId;
                        _context.Campaigns.Update(Campaign);
                        //_context.SaveChanges();
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Campaign);
        }

        public async Task<IActionResult> CampaignManageCampaignUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id);

            if (campaign == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            if (campaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            ViewBag.nameOfCampaign = campaign.Name;
            CampaignUserData vm = new CampaignUserData();
            var applicationDbContext = _context.CampaignUsers
                .Include(o => o.ApplicationUser)
                .Where(a => a.CampaignId == id);
            vm.CampaignUsers = applicationDbContext;

            return View(vm);
        }

        public async Task<IActionResult> CampaignNewCampaignUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(m => m.Id == id);

            if (campaign == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            if (campaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            ViewBag.IdCampaign = campaign.Id;
            ViewBag.nameOfCampaign = campaign.Name;
            ViewBag.UserId = currentUser.Id;

            //List<Campaign> campaignList = new List<Campaign>();
            //campaignList = (from product in _context.Campaigns.Where(a => a.ManagerId == currentUser.Id) select product).ToList();
            //ViewBag.ListofCampaigns = campaignList;

            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            applicationUserList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId) select product).ToList();
            ViewBag.ListOfUsers = applicationUserList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CampaignNewCampaignUser(int CampaignId, string ApplicationUserId)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == CampaignId);
            var applicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == ApplicationUserId);

            var currentUser = await GetCurrentUserAsync();
            if (campaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            if (applicationUser.UserActive != true)
            {
                applicationUser.UserActive = true;
                _context.ApplicationUsers.Update(applicationUser);
                await _context.SaveChangesAsync();
            }

            CampaignUser campaignUser = new CampaignUser
            {
                Id = applicationUser.Id + campaign.Id,
                CampaignId = campaign.Id,
                CampaignName = campaign.Name,
                ApplicationUserId = applicationUser.Id,
                ApplicationUserFullName = applicationUser.FullName
            };

            if (!CampaignUserExists(campaignUser.Id))
            {
                _context.Add(campaignUser);
                await _context.SaveChangesAsync();
                if (applicationUser.UserRole == "NewUser")
                {
                    applicationUser.UserRole = "Employee";
                    await _userManager.AddToRoleAsync(applicationUser, "Employee");
                    applicationUser.ManagerID = currentUser.Id;
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(applicationUser);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ApplicationUserExists(applicationUser.Id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Dashboard", new { id = CampaignId });
        }

        public async Task<IActionResult> CampaignAddUserToCampaign()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            List<Campaign> campaignList = new List<Campaign>();
            campaignList = (from product in _context.Campaigns.Where(a => a.ManagerId == currentUser.Id) select product).ToList();
            ViewBag.ListofCampaigns = campaignList;

            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            applicationUserList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId) select product).ToList();
            ViewBag.ListofUsers = applicationUserList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CampaignAddUserToCampaign(int CampaignId, string ApplicationUserId)
        {
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == CampaignId);
            var applicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == ApplicationUserId);

            var currentUser = await GetCurrentUserAsync();
            if (campaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            if (applicationUser.UserActive != true)
            {
                applicationUser.UserActive = true;
                _context.ApplicationUsers.Update(applicationUser);
                await _context.SaveChangesAsync();
            }

            CampaignUser campaignUser = new CampaignUser
            {
                Id = applicationUser.Id + campaign.Id,
                CampaignId = campaign.Id,
                CampaignName = campaign.Name,
                ApplicationUserId = applicationUser.Id,
                ApplicationUserFullName = applicationUser.FullName
            };

            if (!CampaignUserExists(campaignUser.Id))
            {
                _context.Add(campaignUser);
                await _context.SaveChangesAsync();
                if (applicationUser.UserRole == "NewUser")
                {
                    applicationUser.UserRole = "Employee";
                    await _userManager.AddToRoleAsync(applicationUser, "Employee");
                    applicationUser.ManagerID = currentUser.Id;
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            _context.Update(applicationUser);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ApplicationUserExists(applicationUser.Id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }



        
        [HttpGet]
        public IActionResult AccountsIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AccountChangeCompany()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationUser = await _context.ApplicationUsers.FindAsync(currentUser.Id);

            List<Company> companyList = new List<Company>();
            companyList = _context.Company.ToList();
            ViewBag.ListofCompanies = companyList;


            return View(applicationUser);
        }

        [HttpPost]
        public async Task<IActionResult> AccountChangeCompany(int companyId)
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationUser = await _context.ApplicationUsers.FindAsync(currentUser.Id);
            var comp = await _context.Company.FirstOrDefaultAsync(x => x.Id == companyId);
            applicationUser.CompanyId = comp.Id;
            applicationUser.UserRole = "Manager";
            await _userManager.AddToRoleAsync(applicationUser, "Manager");
            applicationUser.UserActive = true;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        [HttpGet]
        public IActionResult AccountInviteUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AccountInviteUsers(string email)
        {
            var currentUser = await GetCurrentUserAsync();
            var comp = await _context.Company.FirstOrDefaultAsync(x => x.Id == currentUser.CompanyId);
            if (email != null)
            {
                var callbackUrl = $"https://localhost:44322/Identity/Account/Register?company={comp.Name}";

                await _emailSender.SendEmailAsync(email, "Sign up for Metrict",
                    $"Start using Metrict for {comp.Name} <a href='{callbackUrl}'>clicking here</a>.");

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccountInviteUsersBulk()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AccountInviteUsersBulk(string commaSeparatedEmail)
        {
            var currentUser = await GetCurrentUserAsync();
            var comp = await _context.Company.FirstOrDefaultAsync(x => x.Id == currentUser.CompanyId);
            string commaSepEmail = string.Concat(commaSeparatedEmail.Where(c => !char.IsWhiteSpace(c)));
            string[] emailSplit = commaSepEmail.Split(',');
            foreach (string email in emailSplit)
            {
                var callbackUrl = $"https://localhost:44322/Identity/Account/Register?company={comp.Name}";

                await _emailSender.SendEmailAsync(email, "Sign up for Metrict",
                    $"Start using Metrict for {comp.Name} <a href='{callbackUrl}'>clicking here</a>.");

            }
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> ManagerGetAllEmployeeReports()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.Reports.Where(x => x.ManagerId == currentUser.Id).ToListAsync() });
        }

        [HttpGet]
        public async Task<IActionResult> ManagerNewManager()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            applicationUserList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId) select product).ToList();
            ViewBag.ListofUsers = applicationUserList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ManagerNewManager(string applicationUserId)
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserRole == "NewUser" || currentUser.UserRole == "Employee" || currentUser.UserRole == "TeamLead")
            {
                return Json(new { success = false, message = "Error During Promotion" });
            }

            var applicationUser = await _context.ApplicationUsers.FindAsync(applicationUserId);
            if (applicationUser.UserActive != true)
            {
                applicationUser.UserActive = true;
                _context.ApplicationUsers.Update(applicationUser);
                await _context.SaveChangesAsync();
            }

            applicationUser.UserRole = "Manager";
            await _userManager.AddToRoleAsync(applicationUser, "Manager");
            if (currentUser.UserRole == "Executive" || currentUser.UserRole == "Administrator")
            {
                applicationUser.ManagerID = currentUser.Id;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }


            return Json(new { success = true, message = "Manager Promotion Successful" });
        }

        [HttpGet]
        public async Task<IActionResult> ManagerReassignEmployeeManager()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            applicationUserList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId) select product).ToList();
            ViewBag.ListofUsers = applicationUserList;

            List<ApplicationUser> managerList = new List<ApplicationUser>();
            managerList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId).Where(x => x.UserRole == "Manager") select product).ToList();
            ViewBag.ManagerList = managerList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ManagerReassignEmployeeManager(string applicationUserId, string managerId)
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserRole == "NewUser" || currentUser.UserRole == "Employee" || currentUser.UserRole == "TeamLead")
            {
                return Json(new { success = false, message = "Error During Assignment" });
            }
            var applicationUser = await _context.ApplicationUsers.FindAsync(applicationUserId);
            var managerUser = await _context.ApplicationUsers.FindAsync(managerId);
            if (managerUser.UserRole == "NewUser" || managerUser.UserRole == "Employee" || managerUser.UserRole == "TeamLead")
            {
                return Json(new { success = false, message = "Error During Assignment" });
            }

            if (managerUser.UserActive != true)
            {
                return Json(new { success = false, message = "That manager is not active" });
            }

            if (applicationUser.UserActive != true)
            {
                applicationUser.UserActive = true;
            }
            if (applicationUser.UserRole == "NewUser")
            {
                applicationUser.UserRole = "Employee";
                await _userManager.AddToRoleAsync(applicationUser, "Employee");
            }
            applicationUser.ManagerID = managerUser.Id;
            _context.ApplicationUsers.Update(applicationUser);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Manager Assignment Successful" });
        }




        public IActionResult Tasks()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TaskCreate()
        {
            EmployeeTask = new EmployeeTask();

            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            List<ApplicationUser> applicationUserList = new List<ApplicationUser>();
            applicationUserList = (from product in _context.ApplicationUsers.Where(x => x.CompanyId == currentUser.CompanyId) select product).ToList();
            ViewBag.ListofUsers = applicationUserList;

            return View(EmployeeTask);
        }

        [HttpGet]
        public async Task<IActionResult> TaskEdit(int? id)
        {

            var employeeTask = await _context.EmployeeTask.FirstOrDefaultAsync(y => y.Id == id);
            var currentUser = await GetCurrentUserAsync();

            if (employeeTask.ApplicationUserId == currentUser.Id || employeeTask.ManagerId == currentUser.Id)
            {
                EmployeeTask = new EmployeeTask();
                return View(employeeTask);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> TaskUpsert(EmployeeTask employeeTask)
        {
            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserActive == false)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (employeeTask.Id == 0)
                {
                    var empUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == employeeTask.ApplicationUserId);

                    employeeTask.ManagerFullName = currentUser.FullName;
                    employeeTask.ManagerUserName = currentUser.UserName;
                    employeeTask.ApplicationUserFullName = empUser.FullName;
                    employeeTask.ApplicationUserName = empUser.UserName;
                    employeeTask.Comments = employeeTask.ManagerUserName + "<br />" + DateTime.Now + "<br />" + employeeTask.Comments + "<br />" + "<br />";
                    employeeTask.Status = StatusOfTask.Assigned;
                    employeeTask.CompanyId = currentUser.CompanyId;
                    employeeTask.AssignedDate = DateTime.Now;
                    _context.EmployeeTask.Add(employeeTask);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    var empTask = await _context.EmployeeTask.FirstAsync(x => x.Id == employeeTask.Id);

                    empTask.TaskDescription = employeeTask.TaskDescription;
                    empTask.Severity = employeeTask.Severity;
                    empTask.DueDate = employeeTask.DueDate;
                    _context.EmployeeTask.Update(empTask);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TaskDelete(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);

            if (employeeTask.ManagerId == currentUser.Id)
            {
                if (employeeTask.Status == StatusOfTask.Assigned)
                {
                    _context.EmployeeTask.Remove(employeeTask);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> TaskDetails(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);

            if (employeeTask.ApplicationUserId == currentUser.Id || employeeTask.ManagerId == currentUser.Id)
            {
                employeeTask.Comments = employeeTask.Comments.Replace("<br />", "\r\n");
                return View(employeeTask);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> TaskNewComment(int taskId, string newComment)
        {
            if (taskId == 0 || newComment == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == taskId);

            if (employeeTask.ApplicationUserId == currentUser.Id)
            {
                if (ModelState.IsValid)
                {
                    employeeTask.Comments = employeeTask.Comments + DateTime.Now + "<br />" + employeeTask.ApplicationUserFullName + "<br />" + newComment + "<br />" + "<br />";
                    if (employeeTask.Status == StatusOfTask.Assigned)
                    {
                        employeeTask.Status = StatusOfTask.WorkInProgress;
                    }
                    employeeTask.ManagerReply = true;
                    employeeTask.EmployeeReply = false;
                    _context.EmployeeTask.Update(employeeTask);
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            else if (employeeTask.ManagerId == currentUser.Id)
            {
                if (ModelState.IsValid)
                {
                    employeeTask.Comments = employeeTask.Comments + DateTime.Now + "<br />" + employeeTask.ManagerFullName + "<br />" + newComment + "<br />" + "<br />";
                    employeeTask.ManagerReply = false;
                    employeeTask.EmployeeReply = true;
                    _context.EmployeeTask.Update(employeeTask);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return NotFound();
            }
            return View();
        }

        public IActionResult TaskCalendar()
        {
            return View();
        }



        private bool CorrectAppUser(string userId, int reportId)
        {
            var tempReport = _context.Reports.FirstOrDefault(x => x.Id == reportId);
            if (tempReport.ApplicationUserId != userId)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }

        private bool ManagerExists(string userRole, int companyId)
        {
            return _context.ApplicationUsers.Where(x => x.CompanyId == companyId).Any(e => e.UserRole == userRole);
        }

        private bool CampaignUserExists(string id)
        {
            return _context.CampaignUsers.Any(e => e.Id == id);
        }

    }
}