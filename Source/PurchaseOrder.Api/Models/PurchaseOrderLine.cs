namespace PurchaseOrder.Api.Models
{
    public class PurchaseOrderLine
    {
        public int LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}
