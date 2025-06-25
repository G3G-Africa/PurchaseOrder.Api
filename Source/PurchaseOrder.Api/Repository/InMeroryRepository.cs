using AutoFixture;
using System.Linq.Expressions;

namespace PurchaseOrder.Api.Repository
{
    public class InMemoryRepository<InputEntity> : IInMemoryRepository<InputEntity>
        where InputEntity : IRepositoryEntity
    {
        private Dictionary<Guid, InputEntity> Database;

        public InMemoryRepository()
        {
            Database = new Dictionary<Guid, InputEntity>();

            var seeds = new Fixture().Create<List<InputEntity>>();

            seeds.ForEach(item =>
            {
                Database.Add(item.Id, item);
            });
        }

        public async Task<InputEntity> FindAsync(Guid entityId)
        {
            if (!Database.ContainsKey(entityId))
            {
                throw new Exception($"Document with id #{entityId} does not exist");
            }

            return Database[entityId];
        }

        public async Task<Guid> SaveAsync(InputEntity entity)
        {
            entity.IsValid();

            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            if (Database.ContainsKey(entity.Id))
            {
                // update
                Database[entity.Id] = entity;
            }
            else
            {
                // Add
                Database.Add(entity.Id, entity);
            }

            return entity.Id;
        }

        public async Task<Guid> RemoveAsync(Guid entityId)
        {
            if (Database.ContainsKey(entityId))
            {
                // update
                Database.Remove(entityId);
            }

            return entityId;
        }

        public async Task<List<InputEntity>> FilterByAsync(Expression<Func<InputEntity, bool>> expression)
        {
            return Database.Values
                .Where(expression.Compile())
                .ToList();
        }

        public List<InputEntity> QueryByAsync(Expression<Func<InputEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
