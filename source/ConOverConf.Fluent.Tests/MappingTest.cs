using System;
using ConOverConf.Fluent.Core.Models;
using ConOverConf.Fluent.Persistence.FluentMappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace ConOverConf.Fluent.Tests
{
    [TestFixture]
    public class MappingTest
    {
        [Test]
        public void TestMappings()
        {
            var sesionFactory = CreateSessionFactory();

            using (var session = sesionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var store = new Store();
                    store.Name = "MyStore";
                   
                    //var product = new Product();
                    //product.Name = "UberProduct";
                    //product.Price = 123.0;

                    //store.AddProduct(product);

                    //var employee = new Employee();
                    //employee.FirstName = "Torkel";
                    //employee.LastName = "Ödegaard";
                    //store.AddEmployee(employee);

                    session.Save(store);
                    transaction.Commit();
                }
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Data Source=.\SQLEXPRESS;Initial Catalog=PimpMyCode;Integrated Security=True;Pooling=False"))
                .Mappings(BuildFluentMappingConfig)
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildFluentMappingConfig(MappingConfiguration mappings)
        {
            //mappings.FluentMappings.AddFromAssemblyOf<EmployeeMap>();

            var autoCfg = new FluentAutoMappingConfiguration();
            var autoMappings = AutoMap.AssemblyOf<Employee>(autoCfg)
                .Conventions.AddFromAssemblyOf<CustomPrimaryKeyConvention>();

            mappings.AutoMappings.Add(autoMappings);
        }

        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
