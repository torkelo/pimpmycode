using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Data
{
    [DataContract]
    public class StoreDTO
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool IsOpen { get; set; }
    }
}