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
    public class DetailsModel : PageModel
    {
        private readonly BlazorDessert.Data.BlazorDessertContext _context;

        public DetailsModel(BlazorDessert.Data.BlazorDessertContext context)
        {
            _context = context;
        }

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
    }
}
