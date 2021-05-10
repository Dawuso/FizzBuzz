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
    public class DetailsModel : PageModel
    {
        private readonly FizzBuzz.Data.FBcontext _context;

        public DetailsModel(FizzBuzz.Data.FBcontext context)
        {
            _context = context;
        }

        public DoBazy DoBazy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoBazy = await _context.DoBazy.FirstOrDefaultAsync(m => m.Id == id);

            if (DoBazy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
