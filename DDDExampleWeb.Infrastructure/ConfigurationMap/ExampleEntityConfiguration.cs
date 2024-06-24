using DDDExampleWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDExampleWeb.Infrastructure.ConfigurationMap
{
    public class ExampleEntityConfiguration : IEntityTypeConfiguration<Example>
    {
        public void Configure(EntityTypeBuilder<Example> builder)
        {
            builder.ToTable(nameof(Example));

            builder.HasKey(x => x.Id);

            builder.Property((x) => x.PropertyName1)
                .HasColumnName("PropertyName1")
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property((x) => x.PropertyName2)
                .HasColumnName("PropertyName2")
                .HasColumnType("number")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property((x) => x.PropertyName3)
                .HasColumnName("PropertyName3")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}
