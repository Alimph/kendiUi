using Carwash.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carwash.Mapping
{
    public class CarMapping : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
           builder.ToTable(nameof(Car));    
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(55);
        }
    }
}
