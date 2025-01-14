using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmsApi.Models;
using Microsoft.EntityFrameworkCore;


namespace FilmsApi.Data;

public class FilmContext: DbContext
{
    public FilmContext(DbContextOptions<FilmContext> opts): base(opts)
    {

    }
    public DbSet<Film> Films { get;  set; }
}