using ServiceLayer.Client.Models;

namespace ServiceLayer.Client
{
    public interface IServiceLayerClient
    {
        Task<List<PurchaseOrder>> Get();
        Task<PurchaseOrder> Get(Guid id);
        Task<PurchaseOrder> Post(PurchaseOrder purchaseOrder);
    }
}