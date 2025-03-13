using System;
using AutoMapper;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;

namespace LandasBisnis_BackEnd.Mappings;

public class UserMapping : Profile{
    public UserMapping(){
        CreateMap<User, UserContract>().ForMember(p => p.Role, option => option.MapFrom(source => source.GetType().Name)).ReverseMap();
        CreateMap<CreateUserContract, User>();

        CreateMap<Admin, AdminContract>().ForMember(p => p.Role, option => option.MapFrom(source => source.GetType().Name)).ReverseMap();
        CreateMap<CreateAdminContract, Admin>();

        CreateMap<Sponsor, SponsorContract>().ForMember(p => p.Role, option => option.MapFrom(source => source.GetType().Name)).ReverseMap();
        CreateMap<CreateSponsorContract, Sponsor>();

        CreateMap<Sponsoree, SponsoreeContract>().ForMember(p => p.Role, option => option.MapFrom(source => source.GetType().Name)).ReverseMap();
        CreateMap<CreateSponsoreeContract, Sponsoree>();

        CreateMap<UpdateAdminContract, Admin>();

        CreateMap<UpdateSponsorContract, Sponsor>();

        CreateMap<UpdateSponsoreeContract, Sponsoree>();
    }
}
