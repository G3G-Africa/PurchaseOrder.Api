namespace PurchaseOrder.Api.Repository
{
    public interface IRepositoryEntity
    {
        Guid Id { get; set; }
        DateTime UpdatedAt { get; set; }

        void IsValid();
    }
}
