using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Commands
{
    [DataContract]
    public class AddGameToLibrary : Command
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public double Rating { get; set; }
    }
}