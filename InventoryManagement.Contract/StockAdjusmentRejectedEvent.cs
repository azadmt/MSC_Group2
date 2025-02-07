namespace InventoryManagement.Contract
{

    public class StockAdjusmentRejectedEvent
    {
        public Guid OrderId { get; set; }
    }
}