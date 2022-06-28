using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Movies.Queries.GetMovies
{
    public class MovieVm : IMapFrom<MovieDto>
    {
        public int Id { get; set; }

public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public int budget { get; set; }
        
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
      
        
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string Title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

        public int EmotionCount { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<Movie, MovieVm>();
                
            profile.CreateMap<MovieDto, MovieVm>();


        }

    }
}
