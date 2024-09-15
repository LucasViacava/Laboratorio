using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class RolMapper : Profile
    {
        public RolMapper()
        {
            this.CreateMap<RolDTO, Rol>().ReverseMap();
        }
    }
}
