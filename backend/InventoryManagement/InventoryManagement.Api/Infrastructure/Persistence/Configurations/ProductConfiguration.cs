using InventoryManagement.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Api.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductId)
                .HasColumnName("ProductoId")
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnName("Nombre").HasMaxLength(255);
            builder.Property(e => e.Description).HasColumnName("Descripcion").HasMaxLength(500);
            builder.Property(e => e.Price).HasColumnName("Precio").HasPrecision(18,2);
            builder.Property(e => e.StockActual).HasColumnName("StockActual");
            builder.Property(e => e.Activo);
        }
    }
}