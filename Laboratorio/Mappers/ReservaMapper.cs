using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class ReservaMapper : Profile
    {
        public ReservaMapper()
        {
            this.CreateMap<ReservaDTO, Reserva>().ReverseMap();
        }
    }
}
