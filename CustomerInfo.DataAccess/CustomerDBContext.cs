using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CustomerInfo.DTO.Models;
namespace CustomerInfo.DataAccess
{
    public class CustomerDBContext : DbContext
    {
       public CustomerDBContext(DbContextOptions<CustomerDBContext> options) :base(options)
        {

        }
        public DbSet<Customer> Customers {get;set;}
        
    }
}
