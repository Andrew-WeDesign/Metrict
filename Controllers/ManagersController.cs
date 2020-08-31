using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Metrict.Data;
using Metrict.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Metrict.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public ManagersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _context = context;
            _emailSender = emailSender;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeReports()
        {
            var currentUser = await GetCurrentUserAsync();

            return Json(new { data = await _context.Reports.Where(x => x.ManagerId == currentUser.Id).ToListAsync() });
        }

        [HttpGet]
        public IActionResult InviteUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InviteUsers(string email)
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
    }
}