using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OutSystems.HubEdition.Extensibility.Data.TransactionService;
using OutSystems.HubEdition.Extensibility.Data;
using Npgsql;
using System.Data;

namespace ardo.DatabaseProvider.PostgreSQL.TransactionService
{
    public class PGTransactionService : BaseTransactionService
    {
        public PGTransactionService(IDatabaseServices services) : base(services) { }

        public override bool NeedsSeparateAdminConnection
        {
            get { return false; }
        }

        protected override IDbConnection GetConnectionFromDriver()
        {
            return new NpgsqlConnection(DatabaseServices.DatabaseConfiguration.ConnectionString);
        }

        protected override void ReleaseAllPooledConnections()
        {
            NpgsqlConnection.ClearAllPools();
        }

        protected override IsolationLevel IsolationLevel
        {
            get { return IsolationLevel.ReadCommitted; }
        }
    }
}
