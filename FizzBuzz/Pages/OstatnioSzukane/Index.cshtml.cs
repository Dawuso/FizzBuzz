using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Do_bazy;

namespace FizzBuzz.Pages.OstatnioSzukane
{
    public class IndexModel : PageModel
    {
        private readonly FizzBuzz.Data.FBcontext _context;

        public IndexModel(FizzBuzz.Data.FBcontext context)
        {
            _context = context;
        }

        public IList<DoBazy> DoBazy { get;set; }

        public async Task OnGetAsync()
        {
            DoBazy = await _context.DoBazy.OrderByDescending(f => f.Data).Take(10).ToListAsync();
        }
    }
}
