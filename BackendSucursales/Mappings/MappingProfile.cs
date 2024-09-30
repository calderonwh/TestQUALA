using AutoMapper;
using BackendSucursales.DTOs;
using BackendSucursales.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackendSucursales.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sucursale, SucursalDto>().ReverseMap();
        }
    }

}
