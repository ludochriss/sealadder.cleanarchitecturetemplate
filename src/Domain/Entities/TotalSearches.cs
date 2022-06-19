using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Events;

namespace CleanArchitecture.Domain.Entities
{
    public class TotalSearches: AuditableEntity
    {
        public List<MovieSearchedEvent> MovieSearches { get; set; }

       public List<EmotionTaggedEvent> EmotionTags { get; set; }

    }
}
