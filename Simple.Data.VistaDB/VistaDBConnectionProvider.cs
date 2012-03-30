namespace Simple.Data.VistaDB
{
    using System.ComponentModel.Composition;
    using System.Data;
    using global::VistaDB.Provider;
    using System.Linq;
    using Ado;
    using Ado.Schema;

    [Export(typeof(IConnectionProvider))]
    [Export("VistaDB.Provider", typeof(IConnectionProvider))]
    public class VistaDBConnectionProvider : IConnectionProvider
    {
        private string _connectionString;

        public VistaDBConnectionProvider()
        {
            
        }

        public VistaDBConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new VistaDBConnection(_connectionString);
        }

        public ISchemaProvider GetSchemaProvider()
        {
            return new VistaDBSchemaProvider(this);
        }

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public string GetIdentityFunction()
        {
            return "SCOPE_IDENTITY()";
        }

        public bool TryGetNewRowSelect(Table table, ref string insertSql, out string selectSql)
        {
            var identityColumn = table.Columns.FirstOrDefault(col => col.IsIdentity);

            if (identityColumn == null)
            {
                selectSql = null;
                return false;
            }

            selectSql = "select * from " + table.QualifiedName + " where " + identityColumn.QuotedName +
                        " = SCOPE_IDENTITY()";
            return true;
        }

        public bool SupportsCompoundStatements
        {
            get { return true; }
        }

        public bool SupportsStoredProcedures
        {
            get { return true; }
        }

        public IProcedureExecutor GetProcedureExecutor(AdoAdapter adapter, ObjectName procedureName)
        {
            return new ProcedureExecutor(adapter, procedureName);
        }
    }
}
