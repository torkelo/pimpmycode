using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Commands
{
    [DataContract]
    public class CheckGameIn : Command
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}