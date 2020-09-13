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
            var itemsViewModel = from i in _context.Items
                                 join c in _context.Categories on i.CategoryID equals c.ID
                                 where i.CategoryID == id
                                 orderby i.Title
                                 select new ItemDisplay { item = i, category = c };

            return View(itemsViewModel);
        }
    }
}
