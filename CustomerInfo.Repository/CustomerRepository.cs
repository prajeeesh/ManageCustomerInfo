using CostomerInfo.Entities;
using CustomerInfo.Contracts;
using CustomerInfo.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInfo.Repository
{
    public class CustomerRepository: RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
