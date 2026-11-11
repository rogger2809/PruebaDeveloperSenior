using InventoryManagement.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Api.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(e => e.CategoryId);
            builder.Property(e => e.CategoryId)
                .HasColumnName("CategoriaId")
                .ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnName("Nombre").HasMaxLength(255);
            builder.Property(e => e.Description).HasColumnName("Descripcion").HasMaxLength(500);
            builder.Property(e => e.Activo);
        }
    }
}
