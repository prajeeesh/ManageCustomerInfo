using CustomerInfo.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CostomerInfo.Entities
{
    public class PopulateStartupData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RepositoryContext(
               serviceProvider.GetRequiredService<DbContextOptions<RepositoryContext>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = 1,
                        FirstName = "Prajeesh",
                        LastName = "KKE",
                        DateOfBirth = new DateTime(1983,01,31)
                    },
                     new Customer
                     {
                         Id = 2,
                         FirstName = "James",
                         LastName = "Bond",
                         DateOfBirth = new DateTime(1963, 02, 20)
                     },
                      new Customer
                      {
                          Id = 3,
                          FirstName = "Captain",
                          LastName = "America",
                          DateOfBirth = new DateTime(1965, 08, 15)
                      }
                   );
                context.SaveChanges();

            }
        }
    }
}
