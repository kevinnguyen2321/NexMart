using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NexMart.Models;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
    [Required]
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; } 

}