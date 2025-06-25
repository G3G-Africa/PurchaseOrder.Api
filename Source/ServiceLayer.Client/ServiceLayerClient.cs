using AutoFixture;
using ServiceLayer.Client.Models;

namespace ServiceLayer.Client
{
    public class ServiceLayerClient : IServiceLayerClient
    {
        public async Task<PurchaseOrder> Post(PurchaseOrder purchaseOrder)
        {
            purchaseOrder.IsValid();

            // Simulate posting to a service layer
            return await Task.FromResult(purchaseOrder);
        }

        public async Task<PurchaseOrder> Get(Guid id)
        {
            return new Fixture().Create<PurchaseOrder>();
        }

        public async Task<List<PurchaseOrder>> Get()
        {
            // Simulate retrieval from service layer
            return new Fixture().Create<List<PurchaseOrder>>();
        }
    }
}
