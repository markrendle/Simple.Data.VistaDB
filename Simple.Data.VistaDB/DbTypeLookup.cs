namespace Simple.Data.VistaDB
{
    using System.Collections.Generic;
    using System.Data;
    using global::VistaDB;

    internal static class DbTypeLookup
    {
        private static readonly Dictionary<string, VistaDBType> VistaDBTypeLookup = new Dictionary<string, VistaDBType>
                                                                                    {
                                                                                        {"text", VistaDBType.Text},
                                                                                        {"uniqueidentifier", VistaDBType.UniqueIdentifier},
                                                                                        {"tinyint", VistaDBType.TinyInt},
                                                                                        {"smallint", VistaDBType.SmallInt},
                                                                                        {"int", VistaDBType.Int},
                                                                                        {"smalldatetime", VistaDBType.SmallDateTime},
                                                                                        {"real", VistaDBType.Real},
                                                                                        {"money", VistaDBType.Money},
                                                                                        {"datetime", VistaDBType.DateTime},
                                                                                        {"float", VistaDBType.Float},
                                                                                        {"ntext", VistaDBType.NText},
                                                                                        {"bit", VistaDBType.Bit},
                                                                                        {"decimal", VistaDBType.Decimal},
                                                                                        {"numeric", VistaDBType.Decimal},
                                                                                        {"smallmoney", VistaDBType.SmallMoney},
                                                                                        {"bigint", VistaDBType.BigInt},
                                                                                        {"varbinary", VistaDBType.VarBinary},
                                                                                        {"varchar", VistaDBType.VarChar},
                                                                                        {"char", VistaDBType.Char},
                                                                                        {"timestamp", VistaDBType.Timestamp},
                                                                                        {"nvarchar", VistaDBType.NVarChar},
                                                                                        {"nchar", VistaDBType.NChar},
                                                                                        {"image", VistaDBType.Image},
                                                                                    };

        public static VistaDBType GetVistaDBType(string typeName)
        {
            return VistaDBTypeLookup[typeName];
        }
    }
}