using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = "El título es requerido")]
        [Display(Name = "Título del Libro")]
        public string? Title { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "El autor es requerido")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha de Publicación")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Disponible")]
        public bool Available { get; set; } = true;

        [Display(Name = "Imagen Miniatura")]
        public string? Thumbnail { get; set; }
    }
}
