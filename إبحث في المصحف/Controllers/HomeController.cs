using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using إبحث_في_المصحف.Models;

namespace إبحث_في_المصحف.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _context;
        public HomeController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Result()
        {
            return View();
        }
        public IActionResult Filter(string searchString)
        {
            var alldata = _context.sewar.ToList();
             List<string> result = new List<string>();

            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var item in alldata)
                {
                    string[] s = item.Content.Split('.');
                    var matchingStrings = s.Where(s => s.Contains(searchString)).ToList();
                    if (matchingStrings.Count > 0)
                    {
                        result.Add(item.Name);
                        foreach (var matchingString in matchingStrings)
                        {
                            result.Add(matchingString);
                        }
                    }
                }
                return View("Result",result);
            }
            return View("Index");
        }
    }
}
