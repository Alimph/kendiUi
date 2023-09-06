using Carwash.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carwash.Mapping
{
    public class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable(nameof(Service));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NumberPhone)
                .HasMaxLength(11);
            
            builder.Property(x => x.CustomerName)
                .HasMaxLength(55);

            builder.HasOne(x => x.Car)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.CarId);
        }
    }
}
