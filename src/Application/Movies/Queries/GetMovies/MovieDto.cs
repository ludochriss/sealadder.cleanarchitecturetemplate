using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Movies.Queries.GetMovies
{
    public class MovieDto : IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Adult { get; set; }
       
        public string Url { get; set; }
        

        public string OriginalLanguage { get; set; }
        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
        public string ImdbId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Movie, MovieDto>()
                .ForMember(m=>m.Url,opt=>opt.Ignore())
                .ReverseMap();
        }
      
    }
}
