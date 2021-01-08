using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlazorDessert.Data;

namespace BlazorDessert.Pages.DessertView
{
    public class CreateModel : PageModel
    {
        private readonly BlazorDessert.Data.BlazorDessertContext _context;

        public CreateModel(BlazorDessert.Data.BlazorDessertContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Dessert Dessert { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dessert.Add(Dessert);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
