using System;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Commands
{
    [DataContract]
    public class AddEmployeeToStoreCommand : Command
    {
        [DataMember]
        public Guid StoreId { get; set; }

        [DataMember]
        public Guid EmployeeId { get; set; }
    }
}