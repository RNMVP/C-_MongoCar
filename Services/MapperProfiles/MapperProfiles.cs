using AutoMapper;
using MongoDBCars.Models.users;
using MongoDBCars.Services.User.DTOs;

namespace MongoDBCars.Services.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() 
        {
            CreateMap<Customer, CustomerOutput>();
        }
    }
}
