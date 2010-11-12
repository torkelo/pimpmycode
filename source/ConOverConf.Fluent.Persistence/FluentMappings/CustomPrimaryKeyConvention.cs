using System;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ConOverConf.Fluent.Persistence.FluentMappings
{
    public class CustomPrimaryKeyConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
        }
    }

    public class CustomTableKeyConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            instance.Table("tbl_" + instance.EntityType.Name);
        }
    }
}