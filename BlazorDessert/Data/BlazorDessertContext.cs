using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorDessert.Data
{
    public class BlazorDessertContext : DbContext
    {
        public BlazorDessertContext (DbContextOptions<BlazorDessertContext> options)
            : base(options)
        {
        }

        public DbSet<BlazorDessert.Data.Dessert> Dessert { get; set; }
    }
}
