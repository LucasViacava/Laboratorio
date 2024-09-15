using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class PagoMapper : Profile
    {
        public PagoMapper()
        {
            this.CreateMap<PagoDTO, Pago>().ReverseMap();
        }
    }
}
