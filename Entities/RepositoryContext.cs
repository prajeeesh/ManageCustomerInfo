using CustomerInfo.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CostomerInfo.Entities
{
   public class RepositoryContext :DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
