using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorDessert.Data;

namespace BlazorDessert.Pages.DessertView
{
    public class EditModel : PageModel
    {
        private readonly BlazorDessert.Data.BlazorDessertContext _context;

        public EditModel(BlazorDessert.Data.BlazorDessertContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dessert Dessert { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dessert = await _context.Dessert.FirstOrDefaultAsync(m => m.DessertID == id);

            if (Dessert == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dessert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DessertExists(Dessert.DessertID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DessertExists(string id)
        {
            return _context.Dessert.Any(e => e.DessertID == id);
        }
    }
}
