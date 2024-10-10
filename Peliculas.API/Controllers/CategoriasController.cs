using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peliculas.API.Models.DTOs;
using Peliculas.API.Repository.Interface;

namespace Peliculas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lista = await _repository.GetAll();
            return Ok(lista);
        }

        [HttpGet("id:int",Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _repository.GetById(id);

            if (categoria == null) 
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaCreateDTO dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(dto == null)
                return BadRequest();

            if(await _repository.ExisteByNombre(dto.Nombre))
                return BadRequest();

            var categoria = await _repository.Crear(dto);

            if(categoria == null)
                return BadRequest();

            return CreatedAtRoute("GetById", new { id = categoria.Id }, categoria);
        }
    }
}
