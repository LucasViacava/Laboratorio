using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class ComandaMapper : Profile
    {
        public ComandaMapper() 
        {
            this.CreateMap<ComandaDTO, Comanda>().ReverseMap();
        }
    }
}
