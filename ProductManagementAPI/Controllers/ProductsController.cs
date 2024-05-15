using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativApps.Products.Core.Args;
using NativApps.Products.Core.Models;
using NativApps.Products.Core.Services;
using ProductManagementAPI.Common;
using ProductManagementAPI.Dtos;
using System.Net;

namespace ProductManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private IMapper Mapper { get; }

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        Mapper = mapper;
    }

    [HttpPost]
    [Authorize(Roles = "Administrador")]
    public async Task<ActionResult<ProductResponseDto>> CreateProduct(ProductDto productDto)
    {
        try
        {
            var product = Mapper.Map<Product>(productDto);
            await _productService.AddAsync(product);
            var productCreated = await _productService.GetByIdAsync(product.Id);
            return Ok(Mapper.Map<ProductResponseDto>(productCreated));
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateProduct(Guid id, ProductDto productDto)
    {
        try
        {
            if (id == Guid.Empty)
            {
                return BadRequest(Constants.ErrorMessages.UpdateProductError);
            }

            var product = Mapper.Map<Product>(productDto);
            product.Id = id;
            await _productService.UpdateAsync(product);
            var updatedProduct = await _productService.GetByIdAsync(product.Id);
            return Ok(Mapper.Map<ProductResponseDto>(updatedProduct));
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    //[Authorize]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts()
    {
        try
        {
            var products = Mapper.Map<List<ProductResponseDto>>(await _productService.GetAllAsync());
            return Ok(products);
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponseDto>> GetProductById(Guid id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ProductResponseDto>(product));
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
        catch
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, string.Format(Constants.ErrorMessages.GetProductByIdError, id));
        }
    }
    

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice)
    {
        try
        {
            var products = await _productService.SearchAsync(new FilterSearch { Name = name, MinPrice = minPrice, MaxPrice = maxPrice});
            return Ok(Mapper.Map<List<ProductResponseDto>>(products));
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
