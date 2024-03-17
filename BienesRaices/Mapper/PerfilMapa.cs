using AutoMapper;
using BienesRaices.Modelos;
using BienesRaices.Modelos.DTO;

namespace BienesRaices.Mapper
{
    public class PerfilMapa : Profile
    {
        public PerfilMapa()
        {
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaDTO>();

            CreateMap<Propiedad, PropiedadDTO>().ReverseMap();
            CreateMap<Categoria, DropDownCategoriaDTO>().ReverseMap();
        }
    }
}
