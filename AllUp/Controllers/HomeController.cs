using AllUp.ViewModels;
using AllUp.DAL;
using AllUp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AllUp.Models;
using Microsoft.EntityFrameworkCore;

namespace AllUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db=db;    
        }
        public async Task<IActionResult> IndexAsync()
        {

            HomeVM homeVM = new HomeVM
            {
                categories = await _db.Categories.Where(x => x.IsMain).ToListAsync()
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            Category category = await _db.Categories.Include(x => x.Children).Include(x=>x.Parent).FirstOrDefaultAsync(x => x.Id == id);
            return View(category);
        }



    }
}
