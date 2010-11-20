using System.Runtime.Serialization;
using ConOverConf.Contracts.Data;
using System.Collections.Generic;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    public class SearchGames : Query<IEnumerable<SearchResultDTO>>
    {
        [DataMember]
        public string SearchText { get; set; }
    }
    
}