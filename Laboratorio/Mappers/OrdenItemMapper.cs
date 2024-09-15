using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class OrdenItemMapper : Profile
    {
        public OrdenItemMapper()
        {
            this.CreateMap<OrdenItemDTO, OrdenItem>().ReverseMap();
        }
    }
}
