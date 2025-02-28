using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorBiblioteca.Shared
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreLibro { get; set; }

        [Required]
        public string Autor { get; set; }

        public int NumPaginas { get; set; }

        [Required]
        public DateTime FechaPublicacion { get; set; }
    }
}
