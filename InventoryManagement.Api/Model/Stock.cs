namespace InventoryManagement.Api.Model;

public class Stock
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public uint Quantity { get; set; }
}