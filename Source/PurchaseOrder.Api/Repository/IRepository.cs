using System.Linq.Expressions;

namespace PurchaseOrder.Api.Repository
{
    public interface IRepository<IEntity> where IEntity : IRepositoryEntity
    {
        Task<Guid> SaveAsync(IEntity entity);
        Task<IEntity> FindAsync(Guid entityId);
        Task<List<IEntity>> FilterByAsync(Expression<Func<IEntity, bool>> expression);
        List<IEntity> QueryByAsync(Expression<Func<IEntity, bool>> expression);
        Task<Guid> RemoveAsync(Guid entityId);
    }
}
