using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductRepository repository, ILogger<ProductsController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var collection = await _repository.ListAsync();

        var response = collection.Select(p => new ProductDtoResponse
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Category = p.Category?.Name ?? string.Empty
        }).ToList();

        _logger.LogWarning("this is a warning message");

        return Ok(response);
    }

    [HttpGet("filtros")]
    public async Task<IActionResult> Get(string? filtro)
    {
        var collection = await _repository.ListAsync(filtro ?? string.Empty);

        var response = collection.Select(p => new ProductDtoResponse
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            CategoryId = p.CategoryId,
            Category = p.Category
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _repository.FindByIdAsync(id);

        if (entity is null)
            return NotFound();

        return Ok(new ProductDtoResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            CategoryId = entity.CategoryId,
            Category = entity.Category?.Name ?? string.Empty
        });
    }

    [HttpPost]
    public async Task< IActionResult> Post(ProductDtoRequest request)
    {
        var entity = new Product
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(entity);

        return Created($"api/products/{entity.Id}", entity);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, Product request)
    {
        // TODO: Corregir
        await _repository.UpdateAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}