using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using OnLineClothing.Data;
using OnLineClothing.ViewModels;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;

namespace OnLineClothing.Controllers
{
    public class UserController : Controller
    {

        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }


        //The default login page.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {
            ViewBag.LoginFailed = "";

            var user = from u in _context.Login
                       where u.UserName == login.Username
                       select u;



            if (user.Count() > 0)
            {
                if (user.First().PasswordHash == Utilities.Hash(login.Password + user.First().PasswordSalt))
                {
                    HttpContext.Session.SetString("LoginID", user.First().ID.ToString());
                    ViewData["LoginID"] = HttpContext.Session.Get("LoginID");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.LoginFailed = "The username or password was incorrect... Please try again.";
                    return View();
                }
            }

            else
            {
                ViewBag.LoginFailed = "The username or password was incorrect... Please try again.";
                return View();
            }
        }

        //The signup form
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        //Sign up validation and logic for storing in database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup([Bind()] UserDisplay user)
        {
            ViewBag.DuplicateUsername = "";
            ViewBag.ComplexPassword = "";

            if (Utilities.PasswordCheck(user.login.PasswordHash))
            {
                if (!Utilities.DuplicateUsername(user.login.UserName, _context))
                {


                    user.login.PasswordSalt = Utilities.GenerateSalt();
                    user.login.PasswordHash = Utilities.Hash(user.login.PasswordHash + user.login.PasswordSalt);
                    user.login.Rights = "normal";


                    _context.Login.Add(user.login);
                    _context.SaveChanges();

                    var LoginID = from u in _context.Login
                                  where u.PasswordHash.Equals(user.login.PasswordHash) && u.UserName.Equals(user.login.UserName)
                                  select u.ID;

                    user.users.LoginID = LoginID.First();
                    _context.Users.Add(user.users);
                    _context.SaveChanges();


                    return RedirectToAction("Index");

                }

                else
                {
                    ViewBag.DuplicateUsername = "That username already exists, please choose a different one.";
                    return View();
                }
            }

            else
            {
                ViewBag.ComplexPassword = "Password requires 8 characters, a capital and lowercase letter, a number and a special character";
                return View();
            }
        }
    
        

        
        
    }
}
