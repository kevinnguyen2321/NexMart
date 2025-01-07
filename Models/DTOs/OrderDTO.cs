namespace NexMart.Models.DTOs;


public class OrderDTO
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserProfileId { get; set; }
    public UserProfileDTO UserProfile { get; set; }
    public List<OrderProductDTO> OrderProducts { get; set; } = new List<OrderProductDTO>();
    public decimal OrderTotal => OrderProducts?.Sum(op => op.ProductTotal) ?? 0;
}