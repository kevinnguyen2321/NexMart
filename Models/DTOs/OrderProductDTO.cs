namespace NexMart.Models.DTOs;

public class OrderProductDTO
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public OrderDTO Order { get; set; }
    public int ProductId { get; set; } 
    public ProductDTO Product { get; set; }
    public int Quantity { get; set; }
    public decimal ProductTotal => Product != null ? Product.Price * Quantity : 0;
}