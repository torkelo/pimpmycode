using AutoMapper;
using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Data;
using ConOverConf.Core.Models;

namespace ConOverConf.Handlers
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<Game, SearchResultDTO>();
        }

        public class Customer
        {
            public string Name { get; set; }
            public Address Address { get; set; }
        }

        public class Address
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
        }

        public class CustomerDTO
        {
            public string Name { get; set; }
            
            public string AddressStreet { get; set; }
            public string AddressCity { get; set; }
            public string AddressZipCode { get; set; }
        }
    }
}