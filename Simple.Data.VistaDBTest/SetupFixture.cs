namespace Simple.Data.VistaDBTest
{
    using System;
    using System.Text.RegularExpressions;
    using NUnit.Framework;
    using System.Diagnostics;
    using global::VistaDB.Provider;

    [SetUpFixture]
    public class SetupFixture
    {
        [SetUp]
        public void CreateStoredProcedures()
        {
            try
            {
                using (var cn = new VistaDBConnection(Properties.Settings.Default.ConnectionString))
                {
                    cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        foreach (
                            var sql in
                                Regex.Split(Properties.Resources.DatabaseReset, @"^\s*GO\s*$", RegexOptions.Multiline))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
