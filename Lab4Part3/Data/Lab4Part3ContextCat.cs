using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductModel;

namespace Lab4Part3.Data
{
    public class Lab4Part3ContextCat : DbContext
    {
        public Lab4Part3ContextCat (DbContextOptions<Lab4Part3ContextCat> options)
            : base(options)
        {
        }

        public DbSet<ProductModel.MCategory> MCategory { get; set; } = default!;
    }
}
