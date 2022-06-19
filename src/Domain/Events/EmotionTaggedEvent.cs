using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events
{
    public class EmotionTaggedEvent : DomainEvent
    {
        public EmotionTaggedEvent()
        {

        }
        public EmotionTaggedEvent(Movie movie, User user)
        {
            DateOccurred=   DateTime.Now;
            Movie = movie;
            User = user;
        }
        public Movie Movie { get; set; }
        public User User { get; set; }

      //todo add properties to track whether the user has already tagged the emotion that is being searched.

    }
}
