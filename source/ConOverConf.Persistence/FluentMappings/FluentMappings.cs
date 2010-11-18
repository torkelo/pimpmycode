using ConOverConf.Core.Models;
using FluentNHibernate.Mapping;

namespace ConOverConf.Persistence.FluentMappings
{   
    public class EmployeeMap : ClassMap<Employee>
    {
        public EmployeeMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            References(x => x.Store);
        }
    }

    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.IsOpened);
            HasMany(x => x.Staff)
              .Inverse()
              .Cascade.All();
            HasManyToMany(x => x.Products)
             .Cascade.All()
             .Table("StoreProduct");
        }
    }

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Price);
            HasManyToMany(x => x.StoresStockedIn)
              .Cascade.All()
              .Inverse()
              .Table("StoreProduct");
        }
    }

    public class GameMap : ClassMap<Game>
    {
        public GameMap()
        {
            Id(x => x.Id);
            Map(x => x.Title);
            Map(x => x.Borrower);
            Map(x => x.Notes);
            Map(x => x.AddedOn);
        }
    }
}
