namespace PurchaseOrder.Api.Repository
{
    public interface IInMemoryRepository<T> : IRepository<T> where T : IRepositoryEntity
    {
    }
}
