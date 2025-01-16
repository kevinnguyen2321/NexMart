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

    [HttpGet("{id}")]
    [Authorize(Roles ="Admin")]
    public IActionResult GetById(int id)
    {
        Category foundCategory = _dbContext.Categories
        .FirstOrDefault(c => c.Id == id );

        if (foundCategory == null)
        {
            return NotFound();
        }

        return Ok( new CategoryDTO
        {
            Id = foundCategory.Id,
            Name = foundCategory.Name
        });
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

    [HttpPut("{id}")]
    [Authorize(Roles ="Admin")]
    public IActionResult EditCategory(int id, Category category)
    {
        Category categoryToUpdate = _dbContext.Categories
        .FirstOrDefault(c => c.Id == id);

        if (categoryToUpdate == null)
        {
            return NotFound();
        }

        categoryToUpdate.Name = category.Name;
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles ="Admin")]
    public IActionResult DeleteCategory(int id)
    {
        Category categoryToDelete = _dbContext.Categories
        .FirstOrDefault(c => c.Id == id);

        if (categoryToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Categories.Remove(categoryToDelete);
        _dbContext.SaveChanges();

        return NoContent();
    }




    
}