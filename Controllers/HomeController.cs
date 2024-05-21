using Microsoft.AspNetCore.Mvc;
using Search_In_Moshaf.Models;
using System.Collections.Generic;
using System.Diagnostics;


namespace Search_In_Moshaf.Controllers
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
        public IActionResult Filter(string searchString)
        {
            var alldata = _context.sewar.ToList();
            List<string> result = new List<string>();
            searchString = ' ' + searchString + ' ';

            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var item in alldata)
                {
                    string[] s = item.Content.Split('.');
                    s[0] = ' ' + s[0];
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
                return View("Result", result);
            }
            return View("Index");
        }
    }
}
