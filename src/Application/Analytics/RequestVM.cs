using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Application.Analytics
{
    public class RequestVM
    {
        public List<MovieSearchedEvent> MovieSearches { get; set; }

        public List<EmotionTaggedEvent> EmotionTags { get; set; }
    }
}
