using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Metrict.Models;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Metrict.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Metrict.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _context = context;
            _signInManager = signInManager;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> Login(LoginClass lc)
        //{
        //    //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "andytest.local", "Administrator", "Password123!"))

        //    using (PrincipalContext pc = new PrincipalContext
        //        (ContextType.Domain,
        //        Configuration.GetSection("LDAP")["Domain"],
        //        Configuration.GetSection("LDAP")["UserDomainName"],
        //        Configuration.GetSection("LDAP")["UserDomainPassword"]))
        //    {
        //        //Username and password for authentication.
        //        bool isAuthenticated = pc.ValidateCredentials(lc.UserName, lc.Password);

        //        if (isAuthenticated == true)
        //        {
        //            //credentials are valid
        //            ApplicationUser appUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == lc.UserName);

        //            await _signInManager.SignInAsync(appUser, isPersistent: false);
        //            string status = "success";
        //            return Json(status);
        //        }
        //        else if (isAuthenticated == false)
        //        {
        //            //credentials are not valid
        //            string status = "invalid";
        //            return Json(status);
        //        }
        //        else
        //        {
        //            //something went wrong, credentials were not checked
        //            string status = "something went wrong";
        //            return Json(status);
        //        }
        //    }
        //}
    }
}
