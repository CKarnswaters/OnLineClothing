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
using Microsoft.AspNetCore.Identity;

namespace OnLineClothing.Controllers
{
    public class UserController : BaseController
    {
        public UserController(DataContext context) : base(context)
        {

        }


        //The default login page.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel userLogin)
        {
            ViewBag.LoginFailed = "";

            var user = from u in _context.Login
                       where u.UserName == userLogin.Username
                       select u;

            

            if (user.Count() > 0)
            {
                if (user.First().PasswordHash == Utilities.Hash(userLogin.Password + user.First().PasswordSalt))
                {
                    HttpContext.Session.SetString("LoginID", user.First().ID.ToString());
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
        public IActionResult Signup([Bind()] LoginViewModel user)
        {
            ViewBag.DuplicateUsername = "";
            ViewBag.ComplexPassword = "";

            if (Utilities.PasswordCheck(user.login[0].PasswordHash))
            {
                if (!Utilities.DuplicateUsername(user.login[0].UserName, _context))
                {


                    user.login[0].PasswordSalt = Utilities.GenerateSalt();
                    user.login[0].PasswordHash = Utilities.Hash(user.login[0].PasswordHash + user.login[0].PasswordSalt);
                    user.login[0].Rights = "normal";


                    _context.Login.Add(user.login[0]);
                    _context.SaveChanges();

                    var LoginID = from u in _context.Login
                                  where u.PasswordHash.Equals(user.login[0].PasswordHash) && u.UserName.Equals(user.login[0].UserName)
                                  select u.ID;

                    user.users[0].LoginID = LoginID.First();
                    _context.Users.Add(user.users[0]);
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
