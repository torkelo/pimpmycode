using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ConOverConf.Contracts.Commands;

namespace ConOverConf.Contracts
{
    [DataContract]
    [KnownType(typeof(AddGameToLibrary))]
    [KnownType(typeof(CheckGameIn))]
    [KnownType(typeof(CheckGameOut))]
    public class Command
    { 
       
    }
}