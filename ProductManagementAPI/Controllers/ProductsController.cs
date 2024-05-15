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

    /// <summary>
    /// Crea un nuevo producto.
    /// </summary>
    /// <param name="productDto">Los datos del nuevo producto.</param>
    /// <returns>El producto creado.</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
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

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    /// <param name="id">El ID del producto que se va a actualizar.</param>
    /// <param name="productDto">Los datos actualizados del producto.</param>
    /// <returns>El producto actualizado.</returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
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

    /// <summary>
    /// Elimina un producto existente.
    /// </summary>
    /// <param name="id">El ID del producto que se va a eliminar.</param>
    /// <returns>Respuesta sin contenido.</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
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

    /// <summary>
    /// Obtiene una lista de todos los productos.
    /// </summary>
    /// <returns>Una lista de productos.</returns>
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

    /// <summary>
    /// Obtiene un producto por su ID.
    /// </summary>
    /// <param name="id">El ID del producto.</param>
    /// <returns>El producto encontrado o NotFound si no se encuentra.</returns>
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

    /// <summary>
    /// Busca productos según el nombre, precio mínimo y precio máximo.
    /// </summary>
    /// <param name="name">El nombre del producto a buscar.</param>
    /// <param name="minPrice">El precio mínimo del producto a buscar.</param>
    /// <param name="maxPrice">El precio máximo del producto a buscar.</param>
    /// <returns>Una lista de productos que coinciden con los criterios de búsqueda.</returns>
    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice)
    {
        try
        {
            var products = await _productService.SearchAsync(new FilterSearch { Name = name, MinPrice = minPrice, MaxPrice = maxPrice });
            return Ok(Mapper.Map<List<ProductResponseDto>>(products));
        }
        catch (ApplicationException ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
