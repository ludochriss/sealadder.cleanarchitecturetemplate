using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Movies.Queries.GetMovies
{
    public class MovieListDto : IMapFrom<MovieList>
    {
        public MovieListDto()
        {
            Movies = new List<MovieDto>();
        }

        public int Id { get; set; }
        public string ListName { get; set; }
        public IList<MovieDto> Movies { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieList, MovieListDto>()
                .ReverseMap();
        }

    }
   
}
