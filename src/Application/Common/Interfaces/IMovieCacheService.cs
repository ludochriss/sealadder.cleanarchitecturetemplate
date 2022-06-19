using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IMovieCacheService
    {
        MovieList GetCachedMovies();

        void DeleteCachedMovie(string key);
        
        void SetMoviesToCache(MovieList movies);
        
        //don't like this being here
        Movie DeserializeMovieResponse(HttpResponseMessage response);

    }
}
 