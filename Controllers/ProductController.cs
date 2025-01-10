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




    
}