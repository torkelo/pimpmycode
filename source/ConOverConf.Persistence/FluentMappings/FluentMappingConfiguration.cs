using FluentNHibernate.Automapping;

namespace ConOverConf.Persistence.FluentMappings
{
    public class FluentAutoMappingConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.Namespace == "ConOverConf.Core.Models";
        }

    }
}