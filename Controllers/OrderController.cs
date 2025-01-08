using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexMart.Data;
using Microsoft.EntityFrameworkCore;
using NexMart.Models;
using NexMart.Models.DTOs;

namespace NexMart.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private NexMartDbContext _dbContext;

    public OrderController(NexMartDbContext context)
    {
        _dbContext = context;
    }

    
    [HttpGet]
    // [Authorize(Roles = "Admin")]
    public IActionResult Get ()
    {
        return Ok(_dbContext.Orders
        .Include(o => o.UserProfile)
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .Select(o => new OrderDTO
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            UserProfileId = o.UserProfileId,
            UserProfile = new UserProfileDTO
            {
                Id = o.UserProfile.Id,
                FirstName = o.UserProfile.FirstName,
                LastName = o.UserProfile.LastName,
                Address = o.UserProfile.Address,
                
            },
            OrderProducts = o.OrderProducts !=  null ? o.OrderProducts
            .Select(op => new OrderProductDTO
            {
                Id = op.Id,
                OrderId = op.OrderId,
                ProductId = op.ProductId,
                Product = new ProductDTO
                {
                    Id = op.Product.Id,
                    Name = op.Product.Name,
                    Price = op.Product.Price,
                    StockQuantity = op.Product.StockQuantity
                },
                Quantity = op.Quantity


            }
            
            ).ToList(): null

        }).ToList()
        
        
        );

    }

 


    

}
