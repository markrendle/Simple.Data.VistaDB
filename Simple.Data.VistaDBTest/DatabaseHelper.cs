﻿namespace Simple.Data.VistaDBTest
{
    using System.Data;
    using global::VistaDB.Provider;

    internal static class DatabaseHelper
    {
        public static readonly string ConnectionString =
#if(MONO)
			"Data Source=10.37.129.4;Initial Catalog=SimpleTest;User ID=SimpleUser;Password=SimplePassword";
#else
            Properties.Settings.Default.ConnectionString;
#endif
		
        public static dynamic Open()
        {
            return Database.Opener.OpenConnection(ConnectionString);
        }

        public static void Reset()
        {
            using (var cn = new VistaDBConnection(ConnectionString))
            {
                cn.Open();
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = "TestReset";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
