using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Data
{
    public class TestDBcontext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Jab> Jabs { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public TestDBcontext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("app")
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(t => t
            .HasMany(t => t.Pets)
            .WithOne(t => t.Customer)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Jab>(t => t
            .HasOne(t => t.Pet)
            .WithMany(t => t.Jabs)
            .HasForeignKey(t => t.PetId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Pet>(t => t
            .HasOne(t => t.Customer)
            .WithMany(t => t.Pets)
            .HasForeignKey(t => t.CustomerId)
            .OnDelete(DeleteBehavior.Cascade));

            //ez szerintem szar a foreign key nel
            modelBuilder.Entity<Pet>(t => t
            .HasMany(t => t.Jabs)
            .WithOne(t => t.Pet)
            .HasForeignKey(t => t.PetId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer(){ Id=1,FullName="Geza"},
                new Customer(){ Id=2,FullName="Lajos"},
                new Customer(){ Id=3,FullName="Malacka"},
            });
            
            modelBuilder.Entity<Jab>().HasData(new Jab[]
            {
                new Jab(){ Id=1, PetId=1, Type="Fereghajto"},
                new Jab(){ Id=2, PetId=2, Type="C-Vitamin"},
                new Jab(){ Id=3, PetId=1, Type="Sooldat"},
                new Jab(){ Id=4, PetId=1, Type="Tea"},
                new Jab(){ Id=5, PetId=1, Type="Coke"},
            });

            modelBuilder.Entity<Pet>().HasData(new Pet[]
            {
                new Pet(){Id=1, CustomerId=1, Animal="Kutya", Name="Bloki"},
                new Pet(){Id=2, CustomerId=2, Animal="Cica", Name="Macko"},
                new Pet(){Id=3, CustomerId=3, Animal="Nyul", Name="Bimbo"},
                new Pet(){Id=4, CustomerId=3, Animal="Farkas", Name="Bubo"},
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
