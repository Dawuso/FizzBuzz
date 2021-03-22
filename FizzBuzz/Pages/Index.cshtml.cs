using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzz.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FBwynik FBwynik { get; set; }

        public string Result = "";


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (FBwynik.Number % 3 == 0)
                    Result += "Fizz";
                if (FBwynik.Number % 5 == 0)
                    Result += "Buzz";
                if ((FBwynik.Number % 5 != 0)&&(FBwynik.Number % 3 != 0))
                    Result += "Liczba " + FBwynik.Number + " nie spełnia kryteriów Fizz/Buzz";
                HttpContext.Session.SetString("SesjaWyniki", JsonConvert.SerializeObject(FBwynik));
                HttpContext.Session.SetString("Result", Result);
                return Page();
            }
            return Page();
        }      
    }
}
