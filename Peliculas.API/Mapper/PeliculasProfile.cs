using AutoMapper;
using Peliculas.API.Models;
using Peliculas.API.Models.DTOs;

namespace Peliculas.API.Mapper
{
    public class PeliculasProfile : Profile
    {
        public PeliculasProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaCreateDTO>().ReverseMap();
        }
    }
}
