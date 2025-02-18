using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Form
{
    [Key]
    public int FormId { get; set; }
    
    [ForeignKey("CategoryId")] // Create foreign key
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public required string Title { get; set; }
    
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public required int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    public required bool Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    public required bool CopiedToPlex { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
}