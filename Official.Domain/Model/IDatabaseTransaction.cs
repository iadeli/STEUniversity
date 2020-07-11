using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model
{
    public interface IDatabaseTransaction
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
