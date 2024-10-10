using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peliculas.API.Data;
using Peliculas.API.Models;
using Peliculas.API.Models.DTOs;
using Peliculas.API.Repository.Interface;

namespace Peliculas.API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategoriaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Actualizar(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _context.Categorias.Attach(categoria);
            _context.Categorias.Entry(categoria).State = EntityState.Modified;
            return await Guardar();
            
        }

        public async Task<bool> Borrar(CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            _context.Categorias.Remove(categoria);
            return await Guardar();
        }

        public async Task<CategoriaDTO?> Crear(CategoriaCreateDTO categoriaCreateDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaCreateDTO);
            categoria.FechaCreacion = DateTime.Now;
            await _context.Categorias.AddAsync(categoria);
            return await Guardar() ? _mapper.Map<CategoriaDTO>(categoria) : null ;
        }

        public async Task<bool> ExisteById(int id)
        {
            return await _context.Categorias.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ExisteByNombre(string nombre)
        {
            return await _context.Categorias.AnyAsync(c => c.Nombre.ToLower() == nombre.ToLower());
        }

        public async Task<ICollection<CategoriaDTO>> GetAll()
        {
            var categorias = await _context.Categorias.OrderBy(c => c.Nombre).ToListAsync();

            return categorias.Select(c => _mapper.Map<CategoriaDTO>(c)).ToList();
        }

        public async Task<CategoriaDTO?> GetById(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<bool> Guardar()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
