using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using HotChocolate;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Customers
                .Include(o => o.Orders)
                .Include(a => a.Address);
        }
        
        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Orders
                .Include(c => c.Customer);
        }
    }
}