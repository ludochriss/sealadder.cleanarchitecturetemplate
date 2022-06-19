using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Emotion> Emotions { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
