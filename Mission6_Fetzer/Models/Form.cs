using System.ComponentModel.DataAnnotations;

namespace Mission6.Models;

public class Form
{
    [Key]
    public int FormId { get; set; }
    
    [Required(ErrorMessage = "Category is required")]
    public required string Category { get; set; }
    
    public required string Title { get; set; }
    
    public required int Year { get; set; }
    
    public required string Director { get; set; }
    
    public required string Rating { get; set; }

    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
}