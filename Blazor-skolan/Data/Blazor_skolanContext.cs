using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blazor_skolan.Models;

namespace Blazor_skolan.Data
{
    public class Blazor_skolanContext : DbContext
    {
        public Blazor_skolanContext (DbContextOptions<Blazor_skolanContext> options)
            : base(options)
        {
        }

        public DbSet<Blazor_skolan.Models.Students> Students { get; set; } = default!;
    }
}
