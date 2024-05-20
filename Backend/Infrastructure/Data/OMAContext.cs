using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OMAContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    Id = 1, 
                    FirstName = "John",
                    LastName = "Doe", 
                    ContactNumber = "1234567890",
                    IsDeleted = false,
                    Email = "john@test.com"
                },
                new Customer 
                { 
                    Id = 2, 
                    FirstName = "Tom",
                    LastName = "Jones", 
                    ContactNumber = "7274553833",
                    IsDeleted = false,
                    Email = "tom@test.com"
                                
                      
                });

                modelBuilder.Entity<Address>().HasData(
                new Address 
                { 
                    Id = 1, 
                    CustomerID = 1,
                    AddressLine1 = "1010 Main St.", 
                    AddressLine2 = "Suite 101",
                    City = "Tampa",
                    State = "Florida",
                    Country = "USA"
                },
                new Address 
                { 
                    Id = 2, 
                    CustomerID = 2,
                    AddressLine1 = "2010 Main St.", 
                    AddressLine2 = "Suite 201",
                    City = "Tampa",
                    State = "Florida",
                    Country = "USA"
                                
                      
                });

                 modelBuilder.Entity<Order>().HasData(
                new Order 
                { 
                    Id = 1, 
                    CustomerID = 1,
                    OrderDate = new DateTime(2024,5,20), 
                    Description = "Some good stuff 1",
                    TotalAmount = 5000,
                    DepositAmount = 1000,
                    IsDelivery = false,
                    Status = Status.Pending,
                    OtherNotes = "Notes 1",
                    IsDeleted = false

                },
                 new Order 
                { 
                    Id = 2, 
                    CustomerID = 2,
                    OrderDate = new DateTime(2024,5,21), 
                    Description = "Some good stuff 2",
                    TotalAmount = 4000,
                    DepositAmount = 250,
                    IsDelivery = false,
                    Status = Status.Draft,
                    OtherNotes = "Notes 2",
                    IsDeleted = false

                  });
        }
    }
}
        
