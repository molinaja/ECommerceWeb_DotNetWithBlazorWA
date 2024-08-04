using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using ECommerceWeb.Entities;
using ECommerceWeb.Repositories.Interfaces;
using ECommerceWeb.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWeb.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    private readonly IFileUploader _fileUploader;

    public ProductsController(IProductRepository repository, IFileUploader fileUploader)
    {
        _repository = repository;
        _fileUploader = fileUploader;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var collection = await _repository.ListActiveAsync();

        return Ok(collection);
    }

    [HttpGet("filters")]
    public async Task<IActionResult> Get(string? filter)
    {
        var entity = await _repository.ListAsync(filter ?? string.Empty);


        return Ok(entity);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var entity = await _repository.FindByIdAsync(id);

        if (entity is null)
            return NotFound();


        return Ok(
            new ProductDtoResponse { 
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,  
                Category = entity.Category?.Name ?? string.Empty,
                CategoryId = entity.CategoryId,
                Brand = entity.Brand?.Name ?? string.Empty,
                BrandId = entity.BrandId,
                UrlImage = entity.UrlImage,
            }
        );
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductDtoRequest request)
    {
        var entity = new Product  
        {
            Name = request.Name,
            Price = request.Price,
            CategoryId = request.CategoryId,
            BrandId = request.BrandId,
        };

        entity.UrlImage = await _fileUploader.UploadFileAsync(request.Base64Image, request.FileName);
        
        await _repository.AddAsync(entity);
        
        return Created($"api/products/{entity.Id}", entity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, ProductDtoRequest request)
    {
        var entity = await _repository.FindByIdAsync(id);

        if (entity is null)
            return NotFound();

        entity.Name = request.Name;
        entity.Price = request.Price;
        entity.CategoryId = request.CategoryId;
        entity.BrandId = request.BrandId;

        if (!string.IsNullOrEmpty(request.Base64Image) && !string.IsNullOrEmpty(request.FileName)) {

            entity.UrlImage = await _fileUploader.UploadFileAsync(request.Base64Image, request.FileName);
        }

        await _repository.UpdateAsync();

        return Ok();

    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return Ok();

    }
}