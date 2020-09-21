using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnLineClothing.Data;
using OnLineClothing.Models;
using OnLineClothing.ViewModels;

namespace OnLineClothing.Controllers
{
    public class ItemController : BaseController
    {

        public ItemController(DataContext context) : base(context)
        {
            
        }

        //The default display for any category of items, uses the ItemDisplay view model to combine the two tables
        public IActionResult Index(int id)
        {


            //Join the items and categories table and place it in the ItemDisplay view model, then store the value in the variable to be passed to the View.
            var itemsViewModel = from i in _context.Items
                                 join c in _context.Categories on i.CategoryID equals c.ID
                                 where i.CategoryID == id
                                 orderby i.Title
                                 select new ItemViewModel { item = i, category = c, login = UserData().login, users = UserData().users, cart = UserData().cart };

            return View(itemsViewModel);
        }
    }
}
