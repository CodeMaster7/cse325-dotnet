using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models;

public class MovieGenreViewModel
{
    public List<Movie>? Movies { get; set; }
    public SelectList? Genres { get; set; }

    /// <summary>Years from the DB for the "from year" filter dropdown.</summary>
    public SelectList? ReleaseYears { get; set; }

    public string? MovieGenre { get; set; }
    public string? SearchString { get; set; }

    /// <summary>When set, Index shows movies from this year forward (inclusive).</summary>
    public int? ReleaseYear { get; set; }
}