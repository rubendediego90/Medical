using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Persistence.StreamerContext.Configuration
{
    internal class StreamerConfiguration : IEntityTypeConfiguration<Streamer>
    {
        public void Configure(EntityTypeBuilder<Streamer> builder)
        {
           builder
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
