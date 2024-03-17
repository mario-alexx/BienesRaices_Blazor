using System.ComponentModel.DataAnnotations;

namespace BienesRaices.Modelos.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
    }
}
