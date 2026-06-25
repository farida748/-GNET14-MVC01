using GymManagment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool Tracking = false, CancellationToken ct = default);
        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<int> Add(TEntity entity, CancellationToken ct = default);
        Task<int> Update(TEntity entity, CancellationToken ct = default);
        Task<int> Remove(TEntity entity, CancellationToken ct = default);

        Task<bool> Anyasync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct);
    }
}
