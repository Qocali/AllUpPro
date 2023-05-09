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
using Google.Cloud.Translation.V2;
using Newtonsoft.Json;

namespace AllUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db=db;    
        }
        public async Task<IActionResult> Index() {
           
             var serializedData = TempData["Translations"] as string;
            if (serializedData != null)
            {
                HomeVM homeVM = new HomeVM
                {
                    categories = await _db.Categories.Where(x => x.IsMain).ToListAsync(),

                    Translates = JsonConvert.DeserializeObject<Translate>(serializedData)
                };
                return View(homeVM);
            }
            else
            {
                HomeVM homeVM = new HomeVM
                {
                    categories = await _db.Categories.Where(x => x.IsMain).ToListAsync(),
                    Translates = await _db.Translate.FirstOrDefaultAsync()
                };
                return View(homeVM);
            }
        }
        public async Task<IActionResult> Details(int? id)
        {
            Category category = await _db.Categories.Include(x => x.Children).Include(x=>x.Parent).FirstOrDefaultAsync(x => x.Id == id);
            return View(category);
        }
        public  async Task<IActionResult> Translate(string key, string language)
        {
            // Replace with your own API key
            var apiKey = "AIzaSyBvO0IKVZiBwVfJhog78Qo98nXC7Yp9P7g";

            // Retrieve data from the database
            var data =await _db.Translate.FirstOrDefaultAsync();

            var translationClient = TranslationClient.CreateFromApiKey(apiKey);

            // Translate each item in the data list
           
                var response = translationClient.TranslateText(data.language, "ru");
            var response1 = translationClient.TranslateText(data.HeaderTitle, "ru");
            var response2 = translationClient.TranslateText(data.HeaderSubtitle, "ru");
            var response3 = translationClient.TranslateText(data.CardTitle, "ru");
            var response4 = translationClient.TranslateText(data.CategoryName, "ru");
            data.language = response.TranslatedText;
            data.HeaderTitle = response1.TranslatedText;
            data.HeaderSubtitle = response2.TranslatedText;
            data.CardTitle = response3.TranslatedText;
            data.CategoryName = response4.TranslatedText;
            var serializedData = JsonConvert.SerializeObject(data);

            TempData["Translations"] = serializedData;
            return RedirectToAction("Index");
        }


    }
}
