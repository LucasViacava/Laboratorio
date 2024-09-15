using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class OrdenMapper : Profile
    {
        public OrdenMapper()
        {
            this.CreateMap<OrdenDTO, Orden>().ReverseMap(); 
        }
    }
}
