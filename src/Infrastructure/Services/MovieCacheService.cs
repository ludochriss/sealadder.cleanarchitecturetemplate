using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace CleanArchitecture.Infrastructure.Services
{
    public class MovieCacheService :   IMovieCacheService
    {
        private readonly IMemoryCache _cache;
        public MovieCacheService(IMemoryCache  cache)
        {
            _cache = cache;
        }

        public void DeleteCachedMovie(string key)
        {
            _cache.Remove(key);
        }

        public   Movie DeserializeMovieResponse(HttpResponseMessage response)
        {
            //read json response as a string
            var data = response.Content.ReadAsStringAsync();
            //deserialise response
            var m =  JsonConvert.DeserializeObject<Movie>(data.Result);
            //m.Url = request.Path;
            return m;
           
        }
       

        //return the dto for processing
        public MovieList GetCachedMovies()
        {
            //gets lsit of moviedto's or generates an empty list
            try
            {
                bool cacheContainsList = _cache.TryGetValue("movies", out MovieList movies);

                if (movies == null || !cacheContainsList)
                {
                    movies = new MovieList("Cached Movies");
                    movies.ListName = "Cached Movies";
                    movies.Created = DateTime.Now;                    
                }

                return movies;

            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);            }            
        }   
     
        public void SetMoviesToCache(MovieList movies)
        {
            movies.LastModified = DateTime.Now;            
            _cache.Set("movies", movies);
           
        }
    }
}
