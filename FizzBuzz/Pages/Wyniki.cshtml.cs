using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using FizzBuzz.Models;

namespace FizzBuzz.Pages
{
    public class WynikiModel : PageModel
    {
        public FBwynik FBwynik { get; set; }
        public string Wyn { get; set; }
        public void OnGet()
        {
            var SesjaWyniki = HttpContext.Session.GetString("SesjaWyniki");
            string Result = HttpContext.Session.GetString("Result");

            if (SesjaWyniki != null)
                FBwynik = JsonConvert.DeserializeObject<FBwynik>(SesjaWyniki);

            Wyn = Result;

        }
    }
}
