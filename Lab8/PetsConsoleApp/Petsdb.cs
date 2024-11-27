using Microsoft.EntityFrameworkCore;
using ModelsClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsConsoleApp
{
    public class Petsdb : DbContext
    {
        public Petsdb(DbContextOptions<Petsdb> options) : base(options) { }

        // DbSet for each entity
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Toy> Toys { get; set; }
        public DbSet<PetToy> PetToys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=D:\\repo\\TEMPRAD\\Lab8\\Pets.db");
        }
        // Fluent API for relationships can be defined here if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Many-to-Many relationship between Pet and Toy
            modelBuilder.Entity<PetToy>()
                .HasKey(pt => new { pt.PetId, pt.ToyId }); // Composite primary key

            modelBuilder.Entity<PetToy>()
                .HasOne(pt => pt.Pet)
                .WithMany(p => p.PetToys)
                .HasForeignKey(pt => pt.PetId);

            modelBuilder.Entity<PetToy>()
                .HasOne(pt => pt.Toy)
                .WithMany(t => t.PetToys)
                .HasForeignKey(pt => pt.ToyId);
        }
    }
}
