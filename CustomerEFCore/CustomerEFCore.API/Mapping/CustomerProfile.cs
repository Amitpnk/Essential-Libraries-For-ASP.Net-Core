using AutoMapper;
using CustomerEFCore.API.Model;
using CustomerEFCore.Domain;

namespace CustomerEFCore.API.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();
        }
    }
}
