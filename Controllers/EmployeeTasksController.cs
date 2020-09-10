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
using Newtonsoft.Json;

namespace Metrict.Controllers
{
    public class EmployeeTasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeTasksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public EmployeeTask EmployeeTask { get; set; }

        public class CalEvent
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Location { get; set; }
            public string Url { get; set; }
            public string BackgroundColor { get; set; }
            public string BorderColor { get; set; }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
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
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Upsert(EmployeeTask employeeTask)
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

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
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

        public IActionResult Calendar()
        {
            return View();
        }

        public async Task<IActionResult> GetAllForCalendar()
        {
            var currentUser = await GetCurrentUserAsync();

            var calEvent = await _context.EmployeeTask.Where(x => x.ApplicationUserId == currentUser.Id || x.ManagerId == currentUser.Id).Select(e => new
            {
                id = e.Id,
                title = e.TaskDescription,
                description = e.Comments.Replace("<br />", "\r\n"),
                start = e.DueDate.ToString("MM/dd/yyyy HH:mm"),
                end = e.DueDate.ToString("MM/dd/yyyy HH:mm"),
                url = "https://localhost:44322/EmployeeTasks/Details?id=" + e.Id.ToString(),
                backgroundColor = FullCalBgColor(e.Status),
                borderColor = FullCalBorderColor(e.ManagerId, e.ApplicationUserId, currentUser.Id)
            }).ToListAsync();

            return new JsonResult(calEvent);
        }

        [HttpPost]
        public async Task<IActionResult> NewComment(int taskId, string newComment)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);

            if (employeeTask.ManagerId == currentUser.Id)
            {
                if (employeeTask.Status == StatusOfTask.Assigned)
                {
                    _context.EmployeeTask.Remove(employeeTask);
                    await _context.SaveChangesAsync();
                    return Json(new { success = true, message = "Delete Successful" });
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> TaskStatusToWorkInProgress(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);
            if (currentUser.Id == employeeTask.ApplicationUserId)
            {
                employeeTask.Status = StatusOfTask.WorkInProgress;
                employeeTask.WorkInProgressDate = DateTime.Now;
                _context.Update(employeeTask);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id });

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> TaskStatusToReview(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);
            if (currentUser.Id == employeeTask.ApplicationUserId)
            {
                employeeTask.Status = StatusOfTask.Review;
                employeeTask.ReviewDate = DateTime.Now;
                _context.Update(employeeTask);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> TaskStatusToCompleted(int id)
        {
            var currentUser = await GetCurrentUserAsync();
            var employeeTask = await _context.EmployeeTask.FirstAsync(x => x.Id == id);
            if (currentUser.Id != employeeTask.ManagerId)
            {
                return NotFound();
            }
            employeeTask.Status = StatusOfTask.Completed;
            employeeTask.CompletedDate = DateTime.Now;
            _context.Update(employeeTask);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMyTasks()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.EmployeeTask.Where(x => x.ApplicationUserId == currentUser.Id || x.ManagerId == currentUser.Id).ToListAsync() });

        }
    
        
        public static string FullCalBorderColor(string managerId, string applicationUserId, string currentUserId)
        {
            if (applicationUserId == currentUserId && managerId == currentUserId)
            {
                string color = "#000000";
                return color;
            }
            else if (managerId == currentUserId)
            {
                string color = "#ffffff";
                return color;
            }

            else
            {
                string color = "#000000";
                return color;
            }
        }

        public static string FullCalBgColor(StatusOfTask status)
        {
            if (status == StatusOfTask.Assigned)
            {
                string color = "#1122d6";
                return color;
            }
            else if (status == StatusOfTask.WorkInProgress)
            {
                string color = "#cad415";
                return color;
            }
            else if (status == StatusOfTask.Review)
            {
                string color = "#00ad17";
                return color;
            }
            else //(status == StatusOfTask.Completed)
            {
                string color = "#969696";
                return color;
            }
        }
    }
}