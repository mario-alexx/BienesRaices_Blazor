using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BienesRaices.Modelos.DTO
{
    public class PropiedadDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "El nombre debe tener entre 5 y 30 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "La desccripcion debe tener entre 20 y 300 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Área es obligatoria")]
        [Range(1, 5000, ErrorMessage = "Debe ingresar un número válido")]
        public int Area { get; set; }
        [Required(ErrorMessage = "Las habitaciones son obligatorio")]
        [Range(1, 10, ErrorMessage = "Debe ingresar un número válido")]
        public int Habitaciones { get; set; }
        [Required(ErrorMessage = "Los baños son obligatorio")]
        [Range(1, 5, ErrorMessage = "Debe ingresar un número válido")]
        public int Banios { get; set; }
        [Required(ErrorMessage = "El  parqueadero es obligatorio")]
        [Range(1, 20, ErrorMessage = "Debe ingresar un número válido")]
        public int Parqueadero { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public double Precio { get; set; }
        [Required]
        public bool Activo { get; set; }
        
        public DateTime FechaActualizacion { get; set; }

        public int  CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<ImagenPropiedad> ImagenPropiedad { get; set; }
        public List<string> UrlImagenes { get; set; }
    }
}
