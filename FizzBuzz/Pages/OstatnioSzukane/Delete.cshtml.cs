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
    public class DeleteModel : PageModel
    {
        private readonly FizzBuzz.Data.FBcontext _context;

        public DeleteModel(FizzBuzz.Data.FBcontext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoBazy = await _context.DoBazy.FindAsync(id);

            if (DoBazy != null)
            {
                _context.DoBazy.Remove(DoBazy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
