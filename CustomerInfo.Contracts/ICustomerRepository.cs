using CustomerInfo.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInfo.Contracts
{
   public interface ICustomerRepository: IRepositoryBase<Customer>
    {
    }
}
