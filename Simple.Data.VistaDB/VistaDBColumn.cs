namespace Simple.Data.VistaDB
{
    using System.Data;
    using Ado.Schema;
    using global::VistaDB;

    public class VistaDBColumn : Column
    {
        private readonly VistaDBType _vistaDbType;

        public VistaDBColumn(string actualName, Table table) : base(actualName, table)
        {
        }

        public VistaDBColumn(string actualName, Table table, VistaDBType vistaDbType)
            : base(actualName, table)
        {
            _vistaDbType = vistaDbType;
        }

        public VistaDBColumn(string actualName, Table table, bool isIdentity) : base(actualName, table, isIdentity)
        {
        }

        public VistaDBColumn(string actualName, Table table, bool isIdentity, VistaDBType vistaDbType, int maxLength)
            : base(actualName, table, isIdentity, default(DbType), maxLength)
        {
            _vistaDbType = vistaDbType;
        }

        public VistaDBType VistaDbType
        {
            get { return _vistaDbType; }
        }

        public override bool IsBinary
        {
            get
            {
                return VistaDbType == VistaDBType.Image ||
                       VistaDbType == VistaDBType.VarBinary;
            }
        }

        public override bool IsWriteable
        {
            get { return (!IsIdentity) && VistaDbType != VistaDBType.Timestamp; }
        }
    }
}