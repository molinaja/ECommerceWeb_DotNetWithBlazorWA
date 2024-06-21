
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repository.ListMinimalAsync();

            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var entity = await _repository.FindByIdAsync(id);

            if (entity is null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(CategoriaDtoRequest request)
        //{
        //    var categoria = new Categoria
        //    {
        //        Nombre = request.Nombre,
        //        Descripcion = request.Descripcion
        //    };

        //    var id = await _repository.AddAsync(categoria);

        //    return CreatedAtAction(nameof(Get), new { id }, categoria);
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Put(int id, CategoriaDtoRequest request)
        //{
        //    var entity = await _repository.FindByIdAsync(id);
        //    if (entity is null)
        //    {
        //        return NotFound();
        //    }

        //    entity.Nombre = request.Nombre;
        //    entity.Descripcion = request.Descripcion;

        //    await _repository.UpdateAsync();

        //    return Ok();
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok();
        }
    }
}
