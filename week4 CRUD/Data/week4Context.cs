using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using week4.Models;

namespace week4.Data
{
    public class week4Context : DbContext
    {
        public week4Context (DbContextOptions<week4Context> options)
            : base(options)
        {
        }

        public DbSet<week4.Models.Movie> Movie { get; set; } = default!;
    }
}
