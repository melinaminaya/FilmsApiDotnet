using AutoMapper;
using Azure;
using FilmsApi.Data;
using FilmsApi.DTO;
using FilmsApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmController: ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateFilmDto filmDto)
    {
        Film film = _mapper.Map<Film>(filmDto);
        _context.Films.Add(film);
        Console.WriteLine("Film added:", film.Title);
        return CreatedAtAction(nameof(GetFilmId),new  {id = film.id}, film);
    }

    /// <summary>
    /// Consulta filmes no banco de dados.
    /// </summary>

    [HttpGet]
    public IEnumerable<ReadFilmDto> GetFilms([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take));
        
    }

    [HttpGet("{id}")]
    public IActionResult GetFilmId(int id)
    {
        var filme = _context.Films.FirstOrDefault(f => f.id == id);
        if(filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmDto>(filme);
        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody]
        UpdateFilmDto filmDto
    )
    {
        var film = _context.Films.FirstOrDefault(film => film.id == id);
        if (film == null) return NotFound();
        _mapper.Map(filmDto, film);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpPatch("{id}")]
    //Update parcial
      public IActionResult UpdateFilmPatch(int id,
      JsonPatchDocument<UpdateFilmDto> patchDto
    )
    {
        var film = _context.Films.FirstOrDefault(film => film.id == id);
        if (film == null) return NotFound();
        var filmToUpdate = _mapper.Map<UpdateFilmDto>(film);
        patchDto.ApplyTo(filmToUpdate, ModelState);
        if(!TryValidateModel(filmToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmToUpdate, film);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        var film = _context.Films.FirstOrDefault(
            f => f.id == id
        );
        if(film == null)return NotFound();
        _context.Remove(film);
        _context.SaveChanges();
        return NoContent();
    }
}
