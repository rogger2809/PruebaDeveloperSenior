namespace InventoryManagement.Api.Domain.Entities;

public class InventoryMovement
{
    public int MovementId { get; set; }
    public int ProductId { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string Observations { get; set; } = string.Empty;
}
