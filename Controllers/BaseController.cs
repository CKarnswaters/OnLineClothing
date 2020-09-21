using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnLineClothing.Data;
using OnLineClothing.Models;
using OnLineClothing.ViewModels;

namespace OnLineClothing.Controllers
{
    public class BaseController : Controller
    {
        protected DataContext _context;

        public BaseController(DataContext context)
        {
            _context = context;            
        }

        public BaseViewModel UserData()
        {

            var LoginID = HttpContext.Session.GetString("LoginID");

            if (LoginID != null)
            {
                var currentUser = from l in _context.Login
                                  join u in _context.Users on l.ID equals u.LoginID
                                  join c in _context.Cart on l.ID equals c.LoginID into cl
                                  from c in cl.DefaultIfEmpty()                                  
                                  where l.ID == int.Parse(LoginID)
                                  select new { login = l, user = u, cart = c };
                
                

                return new BaseViewModel { login = currentUser.Select(x => x.login).ToList(), users = currentUser.Select(x => x.user).ToList(), cart = currentUser.Select(x => x.cart).ToList() };
            }

            else
            {
                return new BaseViewModel { login = null, users = null, cart = null };
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            var model = context.ModelState.Keys;

            if(model.Count() == 0)
            {
                var LoginID = HttpContext.Session.GetString("LoginID");

                if (LoginID != null)
                {
                    IEnumerable<BaseViewModel> baseViewModel = new BaseViewModel[] { new BaseViewModel { login = UserData().login, users = UserData().users, cart = UserData().cart } };

                    ViewData.Model = baseViewModel;
                }
            }
        }


    }
}
