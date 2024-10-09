using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Peliculas.API.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;
        [Required]
        [DisplayName("Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

    }
}
