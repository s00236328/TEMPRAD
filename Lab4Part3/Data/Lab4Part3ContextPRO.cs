using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductModel;

namespace Lab4Part3.Data
{
    public class Lab4Part3ContextPRO : DbContext
    {
        public Lab4Part3ContextPRO (DbContextOptions<Lab4Part3ContextPRO> options)
            : base(options)
        {
        }

        public DbSet<ProductModel.MProduct> MProduct { get; set; } = default!;
    }
}
