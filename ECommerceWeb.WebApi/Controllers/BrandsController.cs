using ECommerceWeb.Dto.Request;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {

        private readonly IBrandRepository _repository;

        public BrandsController(IBrandRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<BrandsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var collection = await _repository.ListActiveAsync();
            return Ok(collection);
        }

        // GET api/<BrandsController>/5
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

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> Post(BrandDtoRequest request)
        {
            var brand = new Brand
            {
                Name = request.Name,
            };

            var id = await _repository.AddAsync(brand);

            return CreatedAtAction(nameof(Get), new { id }, brand);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, BrandDtoRequest request)
        {
            var entity = await _repository.FindByIdAsync(id);
            if (entity is null)
                return NotFound();

            entity.Name = request.Name;

            await _repository.UpdateAsync();

            return Ok(entity);
        }

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            return Ok();
        }
    }
}
