using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FizzBuzz.Data;
using FizzBuzz.Do_bazy;

namespace FizzBuzz.Pages.OstatnioSzukane
{
    public class CreateModel : PageModel
    {
        private readonly FizzBuzz.Data.FBcontext _context;

        public CreateModel(FizzBuzz.Data.FBcontext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DoBazy DoBazy { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DoBazy.Add(DoBazy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
