using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.Configurations
{
    public class TotalSearchesConfiguration : IEntityTypeConfiguration<TotalSearches>
    {
        public void Configure(EntityTypeBuilder<TotalSearches> builder)
        {
            builder.HasNoKey();
            
        }

    }
}
