using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductModel;

namespace Lab4Part3.Data
{
    public class Lab4Part3ContextSUP : DbContext
    {
        public Lab4Part3ContextSUP (DbContextOptions<Lab4Part3ContextSUP> options)
            : base(options)
        {
        }

        public DbSet<ProductModel.MSupplier> MSupplier { get; set; } = default!;
    }
}
