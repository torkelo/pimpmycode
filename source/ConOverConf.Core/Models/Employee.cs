using System;

namespace ConOverConf.Core.Models
{
    public class Employee
    {
        public virtual Guid Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Store Store { get; set; }

    }

    #region address

    //public class Address
    //{
    //    public string StreetAddress { get; set; }
    //    public string ZipCode { get; set; }
    //    public string City { get; set; }
    //}

    #endregion
}   