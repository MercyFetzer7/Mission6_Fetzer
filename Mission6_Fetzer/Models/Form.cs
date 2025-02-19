using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6.Models;

public class Form
{
    [Key]
    public int FormId { get; set; }

    [ForeignKey("CategoryId")] // Create foreign key
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required(ErrorMessage = "Please enter the title of the movie.")]
    public string Title { get; set; }

    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; } = 1889;
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    [Required(ErrorMessage = "Please indicated whether this movie has been edited or not.")]

    public bool? Edited { get; set; }
    
    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "Please indicated whether this movie has been copied to plex or not.")]
    public bool? CopiedToPlex { get; set; }
    
    [MaxLength(25)]
    public string? Notes { get; set; }
}