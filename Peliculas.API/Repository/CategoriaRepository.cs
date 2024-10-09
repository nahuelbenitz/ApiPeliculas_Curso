using Microsoft.EntityFrameworkCore;
using Peliculas.API.Data;
using Peliculas.API.Models;
using Peliculas.API.Repository.Interface;

namespace Peliculas.API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Actualizar(Categoria categoria)
        {
            _context.Categorias.Attach(categoria);
            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            return await Guardar();
            
        }

        public async Task<bool> Borrar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            return await Guardar();
        }

        public async Task<bool> Crear(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
            return await Guardar();
        }

        public async Task<bool> ExisteById(int id)
        {
            return await _context.Categorias.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ExisteByNombre(string nombre)
        {
            return await _context.Categorias.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<ICollection<Categoria>> GetAll()
        {
            return await _context.Categorias.OrderBy(c => c.Nombre).ToListAsync();
        }

        public async Task<Categoria?> GetById(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> Guardar()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
