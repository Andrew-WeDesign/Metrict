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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Metrict.Controllers
{
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Campaign Campaign { get; set; }

        [BindProperty]
        public Report Report { get; set; }

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
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignReportData.Reports.CampaignId);
            if (currentUser.UserActive == true)
            {
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
                        campaignReportData.Reports.Company = currentUser.Company;
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
                            report.Company = currentUser.Company;
                            _context.Reports.Update(report);
                        }
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
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

            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.idOfCampaign = campaign.Id;

            var currentUser = await GetCurrentUserAsync();

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

            if (ModelState.IsValid)
            {
                if (Campaign.Id == 0)
                {
                    Campaign.ManagerId = currentUser.Id;
                    Campaign.StartDate = DateTime.Now;
                    Campaign.CampaignActive = true;
                    Campaign.Company = currentUser.Company;
                    _context.Campaigns.Add(Campaign);
                    //_context.SaveChanges();
                    if (currentUser.UserRole == "NewUser")
                    {
                        var applicationUser = await _context.ApplicationUsers.FindAsync(currentUser.Id);
                        if (!ManagerExists("Manager", currentUser.Company))
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
                        Campaign.StartDate = DateTime.Now;
                        Campaign.CampaignActive = true;
                        Campaign.Company = currentUser.Company;
                        _context.Campaigns.Update(Campaign);
                        //_context.SaveChanges();
                    }
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Campaign);
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

        private bool ManagerExists(string userRole, string company)
        {
            return _context.ApplicationUsers.Where(x => x.Company == company).Any(e => e.UserRole == userRole);
        }

    }
}