using AutoMapper;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Models.Dtos;
using DataAccessLayer.Entities;

namespace FinalProject.Mapper
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMap<Room, RoomAddDTO>().ReverseMap();

            CreateMap<Advertisement, BuisnessLogicLayer.AddAdvertismentDTO>().ReverseMap();

            CreateMap<Advertisement, UpdateAdvertismentDTO>().ReverseMap();

            CreateMap<Room, RoomUpdateDTO>().ReverseMap();

            CreateMap<Reservation, ReservationDTO>().ReverseMap();

            CreateMap<Branch, BranchDTO>().ReverseMap();

            CreateMap<Branch,UpdateBranchDTO>().ReverseMap();

            CreateMap<Customer, AddCustomerDTO>().ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.UserId))
       .ReverseMap();

            CreateMap<Customer, UpdateCustomerDTO>().ForMember(dest => dest.UpdatedById, opt => opt.MapFrom(src => src.UserId))
       .ReverseMap();

            CreateMap<Reservation, ReservationDTO>().ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.UserId))
   .ReverseMap();

            CreateMap<Reservation, ReservationUpdateDTO>().ForMember(dest => dest.LastUpdatedById, opt => opt.MapFrom(src => src.UserId))
.ReverseMap();


            CreateMap<User, AddUserDTO>().ReverseMap();

            CreateMap<User, UpdateUserDTO>().ReverseMap();




        }
    }
}
