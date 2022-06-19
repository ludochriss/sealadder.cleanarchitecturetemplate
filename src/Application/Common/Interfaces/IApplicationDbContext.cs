using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Movie> Movies { get; set; }

         
         DbSet<TotalSearches> TotalSearches { get; set; }
         DbSet<Emotion> Emotions { get; set; }

        DbSet<User> MovieUsers { get; set; } 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
