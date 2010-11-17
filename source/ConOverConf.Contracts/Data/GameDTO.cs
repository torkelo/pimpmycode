using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Data
{
    [DataContract]
    public class GameDTO : QueryResult
    {
        [DataMember]
        public Guid Id { get; set; }
        
        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public double Rating { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public string Borrower { get; set; }

        [DataMember]
        public DateTime AddedOn { get; set; }
    }
}