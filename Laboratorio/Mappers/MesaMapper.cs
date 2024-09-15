using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class MesaMapper : Profile
    {
        public MesaMapper()
        {
            this.CreateMap<MesaDTO, Mesa>().ReverseMap();
        }
    }
}
