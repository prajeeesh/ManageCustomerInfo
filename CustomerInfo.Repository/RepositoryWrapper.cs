using CostomerInfo.Entities;
using CustomerInfo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInfo.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private ICustomerRepository _customer;
        public ICustomerRepository Customer
        {
            get
            {
                if(_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
