using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Events;
using Newtonsoft.Json;

namespace CleanArchitecture.Domain.Entities
{
    public class Movie : AuditableEntity, IHasDomainEvent
    {       
        public int Id { get; set; }

        public string Url { get; set; }
       public bool Adult { get; set; }
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

        public int MovieSearchCount { get; set; }

        public int RequestTotal { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        
        public List<Emotion> MovieEmotions { get; set; }

        public void TagEmotion(Movie movie, User user)
        {
            var eTE = new EmotionTaggedEvent(movie, user);
            DomainEvents.Add(eTE);
        }
        public void UpdateMovieInfo(MovieSearchedEvent mse,string url)
        {
            DomainEvents.Add(mse);
            RequestTotal ++;
            MovieSearchCount++;
            Url = url;
            LastModified = DateTime.Now;
            //todo add a dictionary and update witht the search event
        }
   

    }
}
