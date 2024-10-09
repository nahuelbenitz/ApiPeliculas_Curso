using Peliculas.API.Models;

namespace Peliculas.API.Repository.Interface
{
    public interface ICategoriaRepository
    {
        Task<ICollection<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task<bool> ExisteById(int id);
        Task<bool> ExisteByNombre(string nombre);
        Task<bool> Crear(Categoria categoria);
        Task<bool> Actualizar(Categoria categoria);
        Task<bool> Borrar(Categoria categoria);
        Task<bool> Guardar();


    }
}
