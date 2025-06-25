using PurchaseOrder.Api.Repository;

namespace PurchaseOrder.Api.Models
{
    public class PurchaseOrder : IRepositoryEntity
    {
        public Guid Id { get;set; }
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
