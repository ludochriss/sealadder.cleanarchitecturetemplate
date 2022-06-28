using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class MovieEmotion :AuditableEntity
    {

        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int EmotionId { get; set; }
        public Emotion Emotion { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}