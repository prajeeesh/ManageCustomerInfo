using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerInfo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CustomerInfo.DTO.Models
{
    public class PopulateData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerDBContext(
               serviceProvider.GetRequiredService<DbContextOptions<CustomerDBContext>>()))
            {
                if(context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Prajeesh",
                        LastName = "KKE"
                    }
                   ) ;
                context.SaveChanges();

            }
        }
    }
}
