using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorDessert.Data;

namespace BlazorDessert.Pages.DessertView
{
    public class DeleteModel : PageModel
    {
        private readonly BlazorDessert.Data.BlazorDessertContext _context;

        public DeleteModel(BlazorDessert.Data.BlazorDessertContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dessert = await _context.Dessert.FindAsync(id);

            if (Dessert != null)
            {
                _context.Dessert.Remove(Dessert);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
