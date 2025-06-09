using System.Linq.Expressions;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.Business.Interfaces;

public interface IQueryRepository<TEntity> : IDisposable where TEntity : Entity
{
	Task<TEntity?> GetByIdAsync(Guid id);
	Task<IEnumerable<TEntity>> GetAllAsync();
	Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
}
