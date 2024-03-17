using BienesRaices.Modelos.DTO;

namespace BienesRaices.Repositorio.IRepositorio
{
    public interface IImagenPropiedadRepositorio
    {
        public Task<int> CrearPropiedadImagen(ImagenPropiedadDTO imagenDTO);
        public Task<int> BorrarPropiedadImagenPorIdImagen(int imagenId);
        public Task<int> BorrarPropiedadImagenPorIdPropiedad(int propiedadId);
        public Task<int> BorrarPropiedadImagenPorUrlImagen(string imagenUrl);
        public Task<IEnumerable<ImagenPropiedadDTO>> GetImagenesPropiedad(int propiedadId);

    }
}
