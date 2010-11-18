using System;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel;
using ConOverConf.Core.Models;
using ConOverConf.Persistence.FluentMappings;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace ConOverConf.Persistence
{
    public static class NHSessionFactory
    {
        private static ISessionFactory _sessionFactory;
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PimpMyCode;Integrated Security=True;Pooling=False";

        // BAD Practice, use WCF OperationContext (just for demo purpose)
        [ThreadStatic]
        private static ISession _session;

        public static ISession GetCurrent()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = BuildSessionFactory(); // normally you would have thread locks around this
            }
            
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
                _session.FlushMode = FlushMode.Commit;
            }

            return _session;
        }

        private static ISessionFactory BuildSessionFactory()
        {
            var config = BuildNHibernateConfiguration();
            
            return config.BuildSessionFactory();
        }

        private static Configuration BuildNHibernateConfiguration()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
                .Mappings(BuildFluentMappingConfig)
                .BuildConfiguration();
        }


        private static void BuildFluentMappingConfig(MappingConfiguration mappings)
        {
            mappings.FluentMappings.AddFromAssemblyOf<EmployeeMap>();
            
        }

        public static void BuildSchema()
        {
            // drop tables
            DropTables();
            DropTables();

            new SchemaExport(BuildNHibernateConfiguration())
              .Create(false, true);
        }

        private static void DropTables()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("dropTables", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();
                }
            }
        }  
        
        #region auto mapping cheat
        //private static void BuildFluentMappingConfig(MappingConfiguration mappings)
        //{
        //    //mappings.FluentMappings.AddFromAssemblyOf<EmployeeMap>();

        //    var autoCfg = new FluentAutoMappingConfiguration();
        //    var autoMappings = AutoMap.AssemblyOf<Employee>(autoCfg)
        //        .Conventions.AddFromAssemblyOf<CustomPrimaryKeyConvention>()
        //        ;

        //    mappings.AutoMappings.Add(autoMappings);
        //}
        #endregion
    }
}