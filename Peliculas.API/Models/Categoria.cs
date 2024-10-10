using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Peliculas.API.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = null!;
        [Required]
        public DateTime FechaCreacion { get; set; }

    }
}
