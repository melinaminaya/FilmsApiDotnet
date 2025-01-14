using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsApi.DTO;

public class CreateFilmDto
{
      
    [Required(ErrorMessage = "Title is required")]
    public required string Title { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    [StringLength(50, ErrorMessage ="Field cannot exceed 50 characters")]
    public required string Gender { get; set; }
    [Required(ErrorMessage ="Duration is required")]
    [Range(70,600, ErrorMessage ="Duration must be between 70 and 600 minutes")]
    public int Duration { get; set; }
}
