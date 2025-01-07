namespace NexMart.Models;

public class OrderProduct
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int ProductId { get; set; } 
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal ProductTotal => Product != null ? Product.Price * Quantity : 0;
}