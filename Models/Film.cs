using System.ComponentModel.DataAnnotations;

namespace FilmsApi.Models;

public class Film
{
    [Key]
    [Required]
    public int id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(30)]
    public required string Title { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    [MaxLength(50, ErrorMessage ="Field cannot exceed 50 characters")]
    public required string Gender { get; set; }
    [Required(ErrorMessage ="Duration is required")]
    [Range(70,600, ErrorMessage ="Duration must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}