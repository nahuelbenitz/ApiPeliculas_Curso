

using System.ComponentModel.DataAnnotations;

namespace Peliculas.API.Models.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Nombre { get; set; } = null!;

    }
}
