using System.Linq.Expressions;
using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{
		Task Add(TEntity entity);

        Task<TEntity> GetByID(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}

