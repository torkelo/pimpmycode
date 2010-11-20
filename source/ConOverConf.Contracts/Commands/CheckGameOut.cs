using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Commands
{
    [DataContract]
    public class CheckGameOut : Command
    {
        public Guid Id { get; set; }
        public string Borrower { get; set; }
    }
}