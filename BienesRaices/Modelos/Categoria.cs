﻿using System.ComponentModel.DataAnnotations;

namespace BienesRaices.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NombreCategoria { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaActualizacoin { get; set; }
        public virtual ICollection<Propiedad> Propiedad { get; set; }
    }
}
