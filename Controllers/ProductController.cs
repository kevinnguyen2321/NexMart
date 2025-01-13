using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexMart.Data;
using Microsoft.EntityFrameworkCore;
using NexMart.Models;
using NexMart.Models.DTOs;

namespace NexMart.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private NexMartDbContext _dbContext;

    public ProductController(NexMartDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] int? categoryId)
    {
        List<Product> products = _dbContext.Products
        .Where(p => !categoryId.HasValue || p.CategoryId == categoryId)
        .ToList();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Product foundProduct = _dbContext.Products
         .Include(p => p.Category)
         .FirstOrDefault(p => p.Id == id);

         if (foundProduct == null)
         {
            return NotFound();
         }

         ProductDTO foundProductDTO = new ProductDTO
         {
            Id = foundProduct.Id,
            Name = foundProduct.Name,
            Price = foundProduct.Price,
            CategoryId = foundProduct.CategoryId,
            Category = new CategoryDTO
            {
                Id = foundProduct.Category.Id,
                Name = foundProduct.Category.Name
            },
            Description = foundProduct.Description,
            StockQuantity = foundProduct.StockQuantity,
            ImageUrl = foundProduct.ImageUrl != null ? 
            foundProduct.ImageUrl : null
        };

        return Ok(foundProductDTO);
    }

    [HttpPost]
    [Authorize(Roles ="Admin")]
    public IActionResult AddNewProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        ProductDTO newProduct = new ProductDTO
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            Description = product.Description,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl != null ? product.ImageUrl : null

        };

        return Created($"/api/product/{product.Id}", newProduct);
    }

    [HttpPut("{id}")]
    [Authorize(Roles ="Admin")]
    public IActionResult EditProduct(int id, Product product)
    {
        Product productToUpdate = _dbContext.Products
        .FirstOrDefault(p => p.Id == id);

        if (productToUpdate == null)
        {
            return NotFound();
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Price = product.Price;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.Description = product.Description;
        productToUpdate.StockQuantity = product.StockQuantity;

        if (!string.IsNullOrWhiteSpace(product.ImageUrl))
        {
            productToUpdate.ImageUrl = product.ImageUrl;
        }

        _dbContext.SaveChanges();
        return NoContent();


    }

    




    
}