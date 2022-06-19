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

        public string Title { get; set; }

        public int EmotionCount { get; set; }

        public void Mapping(Profile profile)
        {

            profile.CreateMap<Movie, MovieVm>();
                
            profile.CreateMap<MovieDto, MovieVm>();


        }

    }
}
