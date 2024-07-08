using ECommerceWeb.Dto.Request;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<BrandsController>
        //public async Task<IActionResult> Post(BrandDtoRequest request)
        //{
        //    var category = new Category
        //    {
        //        Name = request.Name,
        //        Description = request.Description
        //    };

        //    var id = await _repository.AddAsync(category);

        //    return CreatedAtAction(nameof(Get), new { id }, category);
        //}

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
