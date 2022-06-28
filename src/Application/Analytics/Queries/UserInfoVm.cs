using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Analytics.Queries
{
    public class UserInfoVm
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie>  MoviesSearched { get; set; }

        public List<Emotion> EmotionsSearched { get; set; }

     
    }
}
