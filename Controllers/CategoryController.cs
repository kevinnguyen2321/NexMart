using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexMart.Data;
using Microsoft.EntityFrameworkCore;
using NexMart.Models;
using NexMart.Models.DTOs;

namespace NexMart.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private NexMartDbContext _dbContext;

    public CategoryController(NexMartDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        List<Category> categories = _dbContext.Categories
        .ToList();

    return Ok(categories);
    }

    [HttpPost]
    [Authorize(Roles ="Admin")]
    public IActionResult AddNewCategory(Category category)
    {
        _dbContext.Categories.Add(category);
        _dbContext.SaveChanges();

        CategoryDTO newCategory = new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name

        };

        return Created($"/api/category/{category.Id}",newCategory);


    }




    
}