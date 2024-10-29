using examen_backend_alexis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen_backend_alexis.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Edad)
                .IsRequired();
        }
    }
}
