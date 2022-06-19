using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class MovieList: AuditableEntity
    {
        public MovieList(string listName)
        {
            ListName = listName;
        }
        public int Id { get; set; }

        public string ListName { get; set; }

        public IList<Movie> Movies { get; private set; } =new List<Movie>();
        public List<DomainEvent> DomainEvents { get; set ; } = new List<DomainEvent>();
    }
}
