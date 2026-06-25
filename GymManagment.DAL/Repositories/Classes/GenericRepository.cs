using GymManagment.DAL.Models;
using GymManagment.DAL.Repositories.Interfaces;
using GymManagment.DbContexts;
using GymManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Repositories.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly GymDbContext _db;
        private readonly DbSet<TEntity> _set;
        public GenericRepository(GymDbContext db)
        {
            _db = db;
            _set = _db.Set<TEntity>();
        }
        public async Task<int> Add(TEntity entity, CancellationToken ct = default)
        {
            _db.Set<TEntity>().Add(entity);
            return await _db.SaveChangesAsync(ct);
        }

        

        public Task<bool> Anyasync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct)
        {
            return _set.AsNoTracking().AnyAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool Tracking = false, CancellationToken ct = default)
        {
            IQueryable<TEntity> query= Tracking?_set:_set.AsNoTracking();
            return  await query.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _set.FindAsync(id, ct);
        }

        public async Task<int> Remove(TEntity entity, CancellationToken ct = default)
        {
            _set.Remove(entity);
            return await _db.SaveChangesAsync();
            
        }

        public async Task<int> Update(TEntity entity, CancellationToken ct = default)
        {
            _set.Update(entity);
            return await _db.SaveChangesAsync();
        }

       
    }
}
