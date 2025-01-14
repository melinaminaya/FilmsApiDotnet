using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsApi.DTO;

public class ReadFilmDto
{
      
    public required string Title { get; set; }
    public required string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime HoraDaConsulta { get; set; }
}
