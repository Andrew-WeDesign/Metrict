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
using Metrict.Models.CampaignViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data;

namespace Metrict.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public Campaign Campaign { get; set; }

        public CampaignsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> Upsert(int? id)
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
        public async Task<IActionResult> Upsert()
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
                    var src = DateTime.Now;
                    var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);

                    Campaign.ManagerId = currentUser.Id;
                    Campaign.StartDate = hm;
                    Campaign.CampaignActive = true;
                    Campaign.CompanyId = currentUser.CompanyId;
                    _context.Campaigns.Add(Campaign);
                    //_context.SaveChanges();
                    if(currentUser.UserRole == "NewUser")
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.Campaigns.Where(a => a.ManagerId == currentUser.Id).Where(x => x.CampaignActive == true).ToListAsync() });
        }

        //[HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var campaignFromDb = await _context.Campaigns.FirstOrDefaultAsync(u => u.Id == id);
            if (campaignFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            var currentUser = await GetCurrentUserAsync();
            if (currentUser.UserActive == false)
            {
                return NotFound();
            }

            if (campaignFromDb.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            campaignFromDb.CampaignActive = false;
            _context.Campaigns.Update(campaignFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });

        }

        public async Task<IActionResult> ManageCampaignUser(int? id)
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

        public async Task<IActionResult> ActivateUser(int campaignId, string applicationUserId)
        {
            var activeCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);
            var activeApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == applicationUserId);
            int tempId = activeCampaign.Id;

            var currentUser = await GetCurrentUserAsync();
            if (activeCampaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            activeApplicationUser.UserActive = true;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeApplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(activeApplicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("ManageCampaignUser", new { id = tempId });
        }

        public async Task<IActionResult> DeactivateUser(int campaignId, string applicationUserId)
        {
            var activeCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);
            var activeApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == applicationUserId);
            int tempId = activeCampaign.Id;

            var currentUser = await GetCurrentUserAsync();
            if (activeCampaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            activeApplicationUser.UserActive = false;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeApplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(activeApplicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("ManageCampaignUser", new { id = tempId });
        }

        public async Task<IActionResult> RemoveUser(int campaignId, string applicationUserId)
        {
            var activeCampaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignId);
            var activeApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.Id == applicationUserId);
            int tempId = activeCampaign.Id;

            var currentUser = await GetCurrentUserAsync();
            if (activeCampaign.ManagerId != currentUser.Id)
            {
                return NotFound();
            }

            string removeId = applicationUserId + campaignId;
            var removeCampaignUser = await _context.CampaignUsers.FirstOrDefaultAsync(x => x.Id == removeId);

            _context.CampaignUsers.Remove(removeCampaignUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("ManageCampaignUser", new { id = tempId });
        }

        public async Task<IActionResult> NewCampaignUser(int? id)
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
        public async Task<IActionResult> NewCampaignUser(int CampaignId, string ApplicationUserId)
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
                if(applicationUser.UserRole == "NewUser")
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

        public async Task<IActionResult> AddUserToCampaign()
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
        public async Task<IActionResult> AddUserToCampaign(int CampaignId, string ApplicationUserId)
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

        public async Task<IActionResult> CampaignUserCountBarGraph(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();

            List<CampaignUser> userCountList = new List<CampaignUser>();
            userCountList = (from x in _context.CampaignUsers
                             .Where(x => x.CampaignId == id)
                             select x)
                             .Where(x => x.Campaign.ManagerId == currentUser.Id)
                             .Where(x => x.ApplicationUser.UserActive == true)
                             .ToList();

            int[] userCount = new int[3];
            userCount[0] = userCountList.Count();
            ViewBag.UserCount = userCount;

            return View();
        }

        public async Task<IActionResult> Dashboard(int? id)
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
                .Where(y => y.IsActive == true)
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

        private bool CampaignExists(int id)
        {
            return _context.Campaigns.Any(e => e.Id == id);
        }

        private bool CampaignUserExists(string id)
        {
            return _context.CampaignUsers.Any(e => e.Id == id);
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }

        private bool ManagerExists(string userRole, int companyId)
        {
            return _context.ApplicationUsers.Where(x => x.CompanyId == companyId).Any(e => e.UserRole == userRole);
        }
    }
}
