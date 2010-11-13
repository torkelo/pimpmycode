using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace ConOverConf.Persistence.FluentMappings
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

    public class asd : IHasManyToManyConvention
    {
        public void Apply(IManyToManyCollectionInstance instance)
        {   
            instance.Table("tbl_" + instance.TableName);
        }
    }


    public class DefaultStringLengthConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(200);
        }
    }

    //public class StoreOverrideMapping : IAutoMappingOverride<Store>
    //{
    //    public void Override(AutoMapping<Store> mapping)
    //    {
    //        mapping.HasManyToMany(x => x.Products).Cascade.All();
    //        mapping.HasMany(x => x.Staff).Cascade.All();
    //    }
    //}
}