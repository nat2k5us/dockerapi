using App.DAL.DbLayers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.DAL.Entities
{
    internal class ProductEntityTypeConfiguration
        : IEntityTypeConfiguration<ProductEntity>
    {
        private readonly AppOptions appOptions;

        public ProductEntityTypeConfiguration(AppOptions appOptions)
        {
            this.appOptions = appOptions;
        }

        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable(appOptions.Products);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}