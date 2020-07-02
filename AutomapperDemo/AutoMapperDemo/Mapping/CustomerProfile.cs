using AutoMapper;
using AutoMapperDemo.Models;

namespace AutoMapperDemo.Mapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            // Mapping properties from Customer to CustomerModel  
            CreateMap<Customer, CustomerModel>()
                .ForMember(dest =>
                   dest.FullName,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.MiddleName + " " + src.LastName));
        }
    }
}
