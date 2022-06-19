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

        public string Title { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }       

        public string Url { get; set; }
   
        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        public int MovieSearchCount { get; set; }

        public int RequestTotal { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        
        public List<Emotion> Emotions { get; set; }

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
