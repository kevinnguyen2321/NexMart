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
    [Authorize]
    public IActionResult Get ([FromQuery] int? userProfileId)
    {
    
         
         // Base query with Includes
    var baseQuery = _dbContext.Orders
        .Include(o => o.UserProfile)
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product);

    // Apply filter if userProfileId is provided
    IQueryable<Order> ordersQuery = baseQuery;
    if (userProfileId.HasValue)
    {
        ordersQuery = ordersQuery.Where(o => o.UserProfileId == userProfileId.Value);
    }

    if (!userProfileId.HasValue)
    {
        ordersQuery = ordersQuery.Where(o => !o.isCanceled);
        
    }

    // Transform the data into DTOs
    var orders = ordersQuery
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
            isCanceled = o.isCanceled,
            OrderProducts = o.OrderProducts != null ? o.OrderProducts
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
                })
                .ToList() : null
        })
        .ToList();

    return Ok(orders);

  

        

    }

    [HttpGet("{id}")]
    [Authorize]

    public IActionResult GetById(int id)
    {
        Order foundOrder = _dbContext.Orders
        .Include(o => o.UserProfile)
        .Include(o => o.OrderProducts)
        .ThenInclude(op => op.Product)
        .FirstOrDefault(o => o.Id == id);

        if (foundOrder == null)
        {
            return NotFound();
        }

        OrderDTO foundOrderDTO = new OrderDTO
        {
            Id = foundOrder.Id,
            OrderDate = foundOrder.OrderDate,
            UserProfileId = foundOrder.UserProfileId,
            UserProfile = new UserProfileDTO
            {
                Id = foundOrder.UserProfile.Id,
                FirstName = foundOrder.UserProfile.FirstName,
                LastName = foundOrder.UserProfile.LastName,
                Address = foundOrder.UserProfile.Address,
                IdentityUserId = foundOrder.UserProfile.IdentityUserId
            },
            isCanceled = foundOrder.isCanceled,
            OrderProducts = foundOrder.OrderProducts != null ?
            foundOrder.OrderProducts
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
                    CategoryId = op.Product.CategoryId,
                    StockQuantity = op.Product.StockQuantity,
                    ImageUrl = op.Product.ImageUrl != null ?
                    op.Product.ImageUrl : null
                },
                Quantity = op.Quantity

            }
            
             ).ToList(): null
        };


        return Ok(foundOrderDTO);
        
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult CancelOrder(int id)
    {
        Order orderToCancel = _dbContext.Orders
        .FirstOrDefault(o => o.Id == id);

        if (orderToCancel == null)
        {
            return NotFound();
        }

        orderToCancel.isCanceled = true;
        _dbContext.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    [Authorize]
    public IActionResult PlaceOrder(OrderFromCartDTO order)
    {

        if (order.OrderProductsFromCart == null || 
        !order.OrderProductsFromCart.Any())
        {
            return BadRequest("Order must contain at least one product.");
        }

        Order newOrder = new Order
        {
            OrderDate = DateTime.Now,
            UserProfileId = order.UserProfileId,
            isCanceled = false,
            OrderProducts = new List<OrderProduct>()
        };

        _dbContext.Orders.Add(newOrder);
        _dbContext.SaveChanges();

        foreach (OrderProductsFromCartDTO op in order.OrderProductsFromCart)
        {
            OrderProduct orderProduct = new OrderProduct
            {
                OrderId = newOrder.Id,
                ProductId = op.ProductId,
                Quantity = op.Quantity

            };

            newOrder.OrderProducts.Add(orderProduct);
        }

        _dbContext.OrderProducts.AddRange(newOrder.OrderProducts);
        _dbContext.SaveChanges();

        OrderDTO newOrderDTO = new OrderDTO
        {
            Id = newOrder.Id,
            OrderDate = newOrder.OrderDate,
            UserProfileId = newOrder.UserProfileId,
            isCanceled = newOrder.isCanceled,
            OrderProducts = newOrder.OrderProducts
            .Select(op => new OrderProductDTO
            {
                Id = op.Id,
                OrderId = op.OrderId,
                ProductId = op.ProductId,
                Quantity = op.Quantity

            }).ToList()

        };


        return Created($"/api/order/{newOrder.Id}",newOrderDTO);


        
    }

 


    

}
