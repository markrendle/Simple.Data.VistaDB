using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Simple.Data.TestHelper
{
    using Ado;
    using Ado.Schema;

    [TestFixture]
    public abstract class DatabaseSchemaTestsBase
    {
        private DatabaseSchema _schema;

        private DatabaseSchema GetSchema()
        {
            var adapter = GetDatabase().GetAdapter() as AdoAdapter;
            if (adapter == null) Assert.Fail("Expected an ADO-based database adapter.");
            return adapter.GetSchema();
        }

        protected abstract Database GetDatabase();

        protected DatabaseSchema Schema
        {
            get { return (_schema ?? (_schema = GetSchema())); }
        }
    }
}
