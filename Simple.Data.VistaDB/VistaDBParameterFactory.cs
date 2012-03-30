namespace Simple.Data.VistaDB
﻿{
﻿    using System.ComponentModel.Composition;
﻿    using System.Data;
﻿    using Ado;
﻿    using Ado.Schema;
     using global::VistaDB;
    using global::VistaDB.Provider;

﻿    [Export(typeof (IDbParameterFactory))]
﻿    public class VistaDBParameterFactory : IDbParameterFactory
﻿    {
﻿        public IDbDataParameter CreateParameter(string name)
﻿        {
﻿            return new VistaDBParameter
﻿                       {
﻿                           ParameterName = name
﻿                       };
﻿        }

﻿        public IDbDataParameter CreateParameter(string name, Column column)
﻿        {
﻿            var vistaDBColumn = (VistaDBColumn) column;
﻿            return new VistaDBParameter(name, vistaDBColumn.VistaDbType, vistaDBColumn.VistaDbType == VistaDBType.Char || vistaDBColumn.VistaDbType == VistaDBType.NChar ? 0 : column.MaxLength, column.ActualName);
﻿        }

﻿        public IDbDataParameter CreateParameter(string name, DbType dbType, int maxLength)
﻿        {
﻿            IDbDataParameter parameter = new VistaDBParameter
﻿                                             {
﻿                                                 ParameterName = name,
﻿                                                 Size = maxLength
﻿                                             };
﻿            parameter.DbType = dbType;
﻿            return parameter;
﻿        }
﻿    }
﻿}