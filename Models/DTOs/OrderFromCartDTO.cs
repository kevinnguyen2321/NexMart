namespace NexMart.Models.DTOs;

public class OrderFromCartDTO
{
    public int UserProfileId {get;set;}
    public List<OrderProductsFromCartDTO> OrderProductsFromCarts {get;set;}

}