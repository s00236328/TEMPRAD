using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductModel;

    public class SupplierLab4Part3Context : DbContext
    {
        public SupplierLab4Part3Context (DbContextOptions<SupplierLab4Part3Context> options)
            : base(options)
        {
        }

        public DbSet<ProductModel.MCategory> Category { get; set; } = default!;
    }
