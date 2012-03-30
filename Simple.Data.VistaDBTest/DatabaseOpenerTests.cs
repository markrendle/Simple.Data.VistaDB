namespace Simple.Data.VistaDBTest
{
    using NUnit.Framework;
    using Simple.Data.Ado;
    using Simple.Data.VistaDB;

    [TestFixture]
    public class DatabaseOpenerTests
    {
        [Test]
        public void OpenNamedConnectionTest()
        {
            var db = Database.OpenNamedConnection("Test");
            Assert.IsNotNull(db);
            var user = db.Users.FindById(1);
            Assert.AreEqual(1, user.Id);
        }

        [Test]
        public void TestProviderIsSqlProvider()
        {
            var provider = new ProviderHelper().GetProviderByConnectionString(Properties.Settings.Default.ConnectionString);
            Assert.IsInstanceOf(typeof(VistaDBConnectionProvider), provider);
        }

        [Test]
        public void TestProviderIsSqlProviderFromOpen()
        {
            Database db = DatabaseHelper.Open();
            Assert.IsInstanceOf(typeof(AdoAdapter), db.GetAdapter());
            Assert.IsInstanceOf(typeof(VistaDBConnectionProvider), ((AdoAdapter)db.GetAdapter()).ConnectionProvider);
        }

        [Test]
        public void TestProviderIsSqlProviderFromOpenConnection()
        {
            Database db = Database.OpenConnection(Properties.Settings.Default.ConnectionString);
            Assert.IsInstanceOf(typeof(AdoAdapter), db.GetAdapter());
            Assert.IsInstanceOf(typeof(VistaDBConnectionProvider), ((AdoAdapter)db.GetAdapter()).ConnectionProvider);
        }
    }
}
