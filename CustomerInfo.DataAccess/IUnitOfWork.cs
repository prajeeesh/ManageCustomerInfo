using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInfo.DataAccess
{
    public interface IUnitOfWork<T>
    {
        T Context { get; }
        void Commit();
        void RollBack();
        bool HasTransaction { get; }
    }
}
