using FluentNHibernate.Automapping;

namespace ConOverConf.Fluent.Persistence.FluentMappings
{
    public class FluentAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.Namespace == "ConOverConf.Fluent.Core.Models";
        }

    }
}