using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}