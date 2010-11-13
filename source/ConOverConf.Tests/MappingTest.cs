
using ConOverConf.Core.Models;
using ConOverConf.Persistence;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ConOverConf.Tests
{
    [TestFixture]
    public class MappingTest
    {
        [Test]
        public void TestMappings()
        {
            using (var session = NHSessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var store = new Store();
                    store.Name = "MyStore";

                    var product = new Product();
                    product.Name = "UberProduct";
                    product.Price = 123.0;

                    store.AddProduct(product);

                    var employee = new Employee();
                    employee.FirstName = "Torkel";
                    employee.LastName = "Ödegaard";
                    store.AddEmployee(employee);

                    session.Save(store);
                    transaction.Commit();
                }
            }
        }

        [Test]
        public static void BuildSchema()
        {
           NHSessionFactory.BuildSchema();
        }
    }
}
