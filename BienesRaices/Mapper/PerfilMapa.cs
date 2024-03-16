using AutoMapper;
using BienesRaices.DTO;
using BienesRaices.Modelos;

namespace BienesRaices.Mapper
{
    public class PerfilMapa : Profile
    {
        public PerfilMapa()
        {
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
