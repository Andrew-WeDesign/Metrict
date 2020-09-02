using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Metrict.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Metrict.Models;

namespace Metrict.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public AccountsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            Configuration = configuration;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IConfiguration Configuration { get; }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChangeCompany()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationUser = await _context.ApplicationUsers.FindAsync(currentUser.Id);

            List<Company> companyList = new List<Company>();
            companyList = _context.Company.ToList();
            ViewBag.ListofCompanies = companyList;


            return View(applicationUser);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeCompany(int companyId)
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


        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }

    }
}