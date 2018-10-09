using System;
using System.Data;

namespace Extensao.Infra.Data.Transactions
{
    public interface IUow : IDisposable
    {
        void BeginTransaction();
        bool Commit();
        bool Rollback();

        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
    }
}
