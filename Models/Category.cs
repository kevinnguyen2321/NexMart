using System.ComponentModel.DataAnnotations;

namespace NexMart.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}