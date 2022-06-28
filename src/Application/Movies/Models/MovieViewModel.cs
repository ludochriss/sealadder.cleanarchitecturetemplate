using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Movies.Models
{
    public class MovieViewModel
    {
                public int Id { get; set; }
        public int MovieId { get; set; }
        public int EmotionId { get; set; }
        public int UserId { get; set; }
    }
}