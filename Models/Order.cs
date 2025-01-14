using System.ComponentModel.DataAnnotations;

namespace NexMart.Models;

public class Order
{
    public int Id { get; set; }
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public int UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    [Required]
    public bool isCanceled { get; set; }
    public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    public decimal OrderTotal => OrderProducts?.Sum(op => op.ProductTotal) ?? 0;
}