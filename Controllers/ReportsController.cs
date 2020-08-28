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
    public class ReportsController : Controller
    {
        // GET: /<controller>/
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public Report Report { get; set; }
        public DeletedReport DeletedReport { get; set; }

        public ReportsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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

        public async Task<IActionResult> Reports()
        {
            var currentUser = await GetCurrentUserAsync();
            ViewBag.UserId = currentUser.Id;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.Reports.Where(x => x.ApplicationUserId == currentUser.Id).ToListAsync() });
        }

        public IActionResult StartReport()
        {
            return View();
        }

        public async Task<IActionResult> GetCampaignsForReports()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.CampaignUsers.Where(x => x.ApplicationUserId == currentUser.Id).ToListAsync() });
        }

        public async Task<IActionResult> Create(int id)
        {
            Report = new Report();

            CampaignReportData vm = new CampaignReportData()
            {
                Campaigns = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id)
            };

            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
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

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            Report = new Report();

            var currentUser = await GetCurrentUserAsync();

            List<CampaignUser> myCampaigns = new List<CampaignUser>();
            myCampaigns = (from x in _context.CampaignUsers
                           .Where(a => a.ApplicationUserId == currentUser.Id)
                           select x)
                           .ToList();
            ViewBag.UserReportsList = myCampaigns;

            if (id == null)
            {
                //create
                return View(Report);
            }

            //update
            Report = _context.Reports.FirstOrDefault(u => u.Id == id);
            if (Report == null)
            {
                return NotFound();
            }
            else if (Report.ApplicationUserId != currentUser.Id)
            {
                return NotFound();
            }

            return View(Report);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(CampaignReportData campaignReportData)
        {
            var currentUser = await GetCurrentUserAsync();
            var campaign = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == campaignReportData.Reports.CampaignId);
            if(currentUser.UserActive == true)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            var reportFromDb = await _context.Reports.FirstOrDefaultAsync(u => u.Id == id);

            if (reportFromDb.ApplicationUserId != currentUser.Id)
            {
                return NotFound();
            }

            if (reportFromDb == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }

            DeletedReport = new DeletedReport();
            // add to its own method at a later date
            DeletedReport.Id = reportFromDb.Id;
            DeletedReport.ApplicationUserId = reportFromDb.ApplicationUserId;
            DeletedReport.ApplicationUserName = reportFromDb.ApplicationUserName;
            DeletedReport.CampaignId = reportFromDb.CampaignId;
            DeletedReport.CampaignName = reportFromDb.CampaignName;
            DeletedReport.ManagerId = reportFromDb.ManagerId;
            DeletedReport.SubmissionDate = reportFromDb.SubmissionDate;
            DeletedReport.LastEditDate = reportFromDb.LastEditDate;
            DeletedReport.DataColumnNumber1 = reportFromDb.DataColumnNumber1;
            DeletedReport.DataColumnNumber2 = reportFromDb.DataColumnNumber2;
            DeletedReport.DataColumnNumber3 = reportFromDb.DataColumnNumber3;
            DeletedReport.DataColumnNumber4 = reportFromDb.DataColumnNumber4;
            DeletedReport.DataColumnNumber5 = reportFromDb.DataColumnNumber5;
            DeletedReport.DataColumnNumber6 = reportFromDb.DataColumnNumber6;
            DeletedReport.DataColumnNumber7 = reportFromDb.DataColumnNumber7;
            DeletedReport.DataColumnNumber8 = reportFromDb.DataColumnNumber8;
            DeletedReport.DataColumnNumber9 = reportFromDb.DataColumnNumber9;
            DeletedReport.DataColumnNumber10 = reportFromDb.DataColumnNumber10;
            DeletedReport.DataColumnTextA = reportFromDb.DataColumnTextA;
            DeletedReport.DataColumnTextB = reportFromDb.DataColumnTextB;
            DeletedReport.DataColumnTextC = reportFromDb.DataColumnTextC;
            DeletedReport.DataColumnTextD = reportFromDb.DataColumnTextD;
            DeletedReport.DataColumnTextE = reportFromDb.DataColumnTextE;
            DeletedReport.DataColumnTextF = reportFromDb.DataColumnTextF;
            DeletedReport.DataColumnTextG = reportFromDb.DataColumnTextG;
            DeletedReport.DataColumnTextH = reportFromDb.DataColumnTextH;
            DeletedReport.DataColumnTextI = reportFromDb.DataColumnTextI;
            DeletedReport.DataColumnTextJ = reportFromDb.DataColumnTextJ;
            // add to its own method at a later date
            _context.DeletedReports.Add(DeletedReport);
            await _context.SaveChangesAsync();

            _context.Reports.Remove(reportFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });

        }

        public async Task<IActionResult> Details(int? id)
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

        private bool CorrectAppUser(string userId, int reportId)
        {
            var tempReport = _context.Reports.FirstOrDefault(x => x.Id == reportId);
            if(tempReport.ApplicationUserId != userId)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
