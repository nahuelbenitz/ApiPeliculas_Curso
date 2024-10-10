using Peliculas.API.Models;
using Peliculas.API.Models.DTOs;

namespace Peliculas.API.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<ICollection<CategoriaDTO>> GetAll();
        Task<CategoriaDTO?> GetById(int id);
        Task<bool> ExisteById(int id);
        Task<bool> ExisteByNombre(string nombre);
        Task<CategoriaDTO?> Crear(CategoriaCreateDTO categoria);
        Task<bool> Actualizar(CategoriaDTO categoria);
        Task<bool> Borrar(CategoriaDTO categoria);
        Task<bool> Guardar();


    }
}
