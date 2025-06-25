using Microsoft.AspNetCore.Mvc;
using PurchaseOrder.Api.Repository;
using ServiceLayer.Client;
using SAPPurchaseOrder = PurchaseOrder.Api.Models.PurchaseOrder;

namespace PurchaseOrder.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly IInMemoryRepository<SAPPurchaseOrder> _purchaseOrderRepository;
        private readonly IServiceLayerClient _serviceLayerClient;

        public PurchaseOrderController(
            ILogger<PurchaseOrderController> logger,
            IInMemoryRepository<SAPPurchaseOrder> purchaseOrderRepository,
            IServiceLayerClient serviceLayerClient  
            )
        {
            _logger = logger;
            _purchaseOrderRepository = purchaseOrderRepository;
            _serviceLayerClient = serviceLayerClient;
        }

        [HttpGet]
        public async Task<IEnumerable<SAPPurchaseOrder>> Get()
        {
            _logger.LogInformation("Retrieving all purchase orders");
            return await _purchaseOrderRepository.FilterByAsync(x => true);
        }

        [HttpGet]
        [Route("{purchaseOrderId}")]
        public async Task<SAPPurchaseOrder> GetById(Guid purchaseOrderId)
        {
            _logger.LogInformation($"Retrieving purchase order with ID: {purchaseOrderId}");
            return await _purchaseOrderRepository.FindAsync(purchaseOrderId);
        }

        [HttpPost]
        public async Task<SAPPurchaseOrder> Post([FromBody] SAPPurchaseOrder request)
        {
            _logger.LogInformation("Creating a new purchase order");

            request.IsValid();

            var purchaseOrderId = await _purchaseOrderRepository.SaveAsync(request);

            // ToDo: Use AutoMapper
            var serviceLayerRequest = new ServiceLayer.Client.Models.PurchaseOrder
            {
                Id = purchaseOrderId,
                DocEntry = request.DocEntry,
                DocNum = request.DocNum,
                CardCode = request.CardCode,
                CardName = request.CardName,
                DocumentLines = request.DocumentLines.Select(line => new ServiceLayer.Client.Models.PurchaseOrderLine
                {
                    ItemCode = line.ItemCode,
                    Quantity = line.Quantity,
                    Price = line.Price
                }),
            };

            await _serviceLayerClient.Post(serviceLayerRequest);

            return await _purchaseOrderRepository.FindAsync(purchaseOrderId);
        }

        [HttpDelete]
        [Route("{purchaseOrderId}")]
        public async Task Delete(Guid purchaseOrderId)
        {
            _logger.LogInformation($"Deleting purchase order with ID: {purchaseOrderId}");

            await _purchaseOrderRepository.RemoveAsync(purchaseOrderId);

            await Task.CompletedTask;
        }

        [HttpPatch]
        [Route("{purchaseOrderId}")]
        public async Task Update(Guid purchaseOrderId, [FromBody] SAPPurchaseOrder request)
        {
            _logger.LogInformation($"Updating purchase order with ID: {purchaseOrderId}");

            request.IsValid();

            request.Id = purchaseOrderId;

            await _purchaseOrderRepository.SaveAsync(request);

            await Task.CompletedTask;
        }
    }
}
