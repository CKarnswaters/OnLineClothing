using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnLineClothing.Data;
using OnLineClothing.ViewModels;

namespace OnLineClothing.Controllers
{
    public class ItemController : Controller
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {

            //Join the items and categories table and place it in the ItemDisplay view model, then store the value in the variable to be passed to the View.
            var itemsViewModel = from i in _context.Items
                                 join c in _context.Categories on i.CategoryID equals c.ID
                                 where i.CategoryID == id
                                 orderby i.Title
                                 select new ItemDisplay { item = i, category = c };

            return View(itemsViewModel);
        }
    }
}
