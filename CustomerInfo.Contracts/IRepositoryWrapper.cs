using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInfo.Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        void Save();
    } 
}
