using System.Runtime.Serialization;
using ConOverConf.Contracts.Data;
using System.Collections.Generic;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    public class SearchGames : Query<SearchGamesResult>
    {
        [DataMember]
        public string SearchText { get; set; }
    }

    [DataContract]
    public class SearchGamesResult : QueryResult
    {
        [DataMember]
        public IEnumerable<SearchResultDTO> Hits { get; set; }
    }
    
}