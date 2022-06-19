using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events
{
    public class MovieSearchedEvent :DomainEvent
    {
        public MovieSearchedEvent(Movie movie, TimeSpan timeTaken, bool cache)
        {
            TimeTaken = timeTaken;
            MovieItem = movie;
            IsFromCache = cache;
            DateOccurred = DateTime.Now;                     
        }
        public Movie MovieItem { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public bool IsFromCache { get; set; }
        public Dictionary<string,int> SearchedMovieEmotions { get; set; }       
    }
}
