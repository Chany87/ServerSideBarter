using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class AutoMapperProfile: AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<User, UserDTO>().ForMember(x => x.CityName, y => y.MapFrom(a => a.City.CityName));
            CreateMap<UserDTO, User>();
            CreateMap<Message, MessageDTO>();
            CreateMap<MessageDTO, Message>();
            CreateMap<OpinionDTO, Opinion>();
            CreateMap<Opinion, OpinionDTO>();
            CreateMap<Star, StarDTO>();
            CreateMap<StarDTO, Star>();
            CreateMap<PublicationDTO, Publication>();
            CreateMap<Publication, PublicationDTO>();
            CreateMap<CustomerInquiryDTO, CustomerInquiry>();
            CreateMap<CustomerInquiry, CustomerInquiryDTO>();
            CreateMap<CityDTO, City>();
            CreateMap<City, CityDTO>();
            CreateMap<UserCreateRequest, User>();
            CreateMap<CategoryUserDTO, CategoryUser>();
            CreateMap<CategoryUser, CategoryUserDTO>();

            CreateMap<User, UserCreateRequest>();
        
        }
    }
}
