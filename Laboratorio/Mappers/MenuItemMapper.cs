using AutoMapper;
using Laboratorio.DTOs;
using Laboratorio.Entities;

namespace Laboratorio.Mappers
{
    public class MenuItemMapper : Profile
    {
        public MenuItemMapper() 
        { 
            this.CreateMap<MenuItemDTO, MenuItem>().ReverseMap();
        }
    }
}
