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
    public class IndexModel : PageModel
    {
        private readonly BlazorDessert.Data.BlazorDessertContext _context;

        public IndexModel(BlazorDessert.Data.BlazorDessertContext context)
        {
            _context = context;
        }

        public IList<Dessert> Dessert { get;set; }

        public async Task OnGetAsync()
        {
            Dessert = await _context.Dessert.ToListAsync();
        }
    }
}
