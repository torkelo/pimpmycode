using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Data
{
    [DataContract]
    public class SearchResultDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        
        [DataMember]
        public string Title { get; set; }
    }
}