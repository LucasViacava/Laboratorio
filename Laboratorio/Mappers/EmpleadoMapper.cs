using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class EmpleadoMapper : Profile
    {
        public EmpleadoMapper()
        {
            this.CreateMap<EmpleadoDTO, Empleado>().ReverseMap();
        }
    }
}
