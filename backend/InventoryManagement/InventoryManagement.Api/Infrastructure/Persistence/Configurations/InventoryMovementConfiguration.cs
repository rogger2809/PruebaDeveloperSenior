using InventoryManagement.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Api.Infrastructure.Persistence.Configurations
{
    public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
    {
        public void Configure(EntityTypeBuilder<InventoryMovement> builder)
        {
            builder.ToTable("MovimientosInventario");
            builder.HasKey(e => e.MovementId);
            builder.Property(e => e.MovementId)
                .HasColumnName("MovimientoId")
                .ValueGeneratedOnAdd();
            builder.Property(e => e.ProductId).HasColumnName("ProductoId");
            builder.Property(e => e.MovementType).HasColumnName("TipoMovimiento").HasMaxLength(1);
            builder.Property(e => e.Quantity).HasColumnName("Cantidad");
            builder.Property(e => e.Observations).HasColumnName("Observaciones").HasMaxLength(500);
        }
    }
}
