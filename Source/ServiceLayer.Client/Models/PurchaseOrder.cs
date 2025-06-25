namespace ServiceLayer.Client.Models
{
    public class PurchaseOrder
    {
        public Guid Id { get; set; }
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public DateTime DocDate { get; set; }
        public DateTime DocDueDate { get; set; }

        public IEnumerable<PurchaseOrderLine> DocumentLines { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void IsValid()
        {
            
        }
    }
}
