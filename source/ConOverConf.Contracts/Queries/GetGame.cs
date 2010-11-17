using System.Runtime.Serialization;
using ConOverConf.Contracts.Data;
using System;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    public class GetGame : Query<GameDTO>
    {
        [DataMember]
        public Guid Id { get; set; }
    }
   
   
}