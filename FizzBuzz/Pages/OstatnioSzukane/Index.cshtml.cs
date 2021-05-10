using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FizzBuzz.Data;
using FizzBuzz.Do_bazy;
using Microsoft.AspNetCore.Authorization;

namespace FizzBuzz.Pages.OstatnioSzukane
{
    [Authorize]
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
            DoBazy = await _context.DoBazy.OrderByDescending(f => f.Data).Take(20).ToListAsync();
        }
    }
}
