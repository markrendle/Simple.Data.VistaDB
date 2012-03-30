namespace Simple.Data.VistaDB
{
    using System;
    using System.Collections.Generic;
    using global::VistaDB;

    static class VistaDBTypeEx
    {
        private static readonly Dictionary<VistaDBType, Type> Map = new Dictionary<VistaDBType, Type>
                                                                      {
                                                                            { VistaDBType.BigInt, typeof(long)},
                                                                            { VistaDBType.Bit, typeof(bool)},
                                                                            { VistaDBType.Char, typeof(string)},
                                                                            { VistaDBType.DateTime, typeof(DateTime)},
                                                                            { VistaDBType.Decimal, typeof(decimal)},
                                                                            { VistaDBType.Float, typeof(double)},
                                                                            { VistaDBType.Image, typeof(byte[])},
                                                                            { VistaDBType.Int, typeof(int)},
                                                                            { VistaDBType.Money, typeof(decimal) },
                                                                            {VistaDBType.NChar, typeof(string)},
                                                                            { VistaDBType.NText, typeof(string)},
                                                                            { VistaDBType.NVarChar, typeof(string)},
                                                                            { VistaDBType.Real, typeof(Single)},
                                                                            { VistaDBType.SmallDateTime, typeof(DateTime)},
                                                                            { VistaDBType.SmallInt, typeof(short)},
                                                                            { VistaDBType.SmallMoney, typeof(decimal)},
                                                                            { VistaDBType.Text, typeof(string)},
                                                                            { VistaDBType.Timestamp, typeof(byte[])},
                                                                            { VistaDBType.TinyInt, typeof(byte)},
                                                                            { VistaDBType.UniqueIdentifier, typeof(Guid)},
                                                                            { VistaDBType.VarBinary, typeof(byte[])},
                                                                            { VistaDBType.VarChar, typeof(string)},
                                                                      };
        public static Type ToClrType(this VistaDBType vistaDBType)
        {
            return Map[vistaDBType];
        }
    }
}
