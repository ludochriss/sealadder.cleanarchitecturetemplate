using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        //TODO configure the movie entity for validation
        public void Configure(EntityTypeBuilder<Movie> b)
        {

            b.Ignore(e => e.DomainEvents);
            b.Property(m => m.Id)
                 .ValueGeneratedNever();
                b.Ignore(m=>m.Adult);
        }
    }
}
