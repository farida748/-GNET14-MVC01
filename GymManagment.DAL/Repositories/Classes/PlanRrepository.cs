using GymManagement.DAL.Repositories.Interfaces;

using GymManagment.DbContexts;
using GymManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Repositories.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _db;

        public PlanRepository (GymDbContext _db)
        {
           this._db =_db;    //   still smells — Section 3 fixes this
        }

        public IEnumerable<Plan> GetAll()
            => _db.Plans.Where(p => p.isActive).ToList();

        public Plan? GetById(int id)
            => _db.Plans.Find(id);

        public void Add(Plan plan) => _db.Plans.Add(plan);
        public void Update(Plan plan) => _db.Plans.Update(plan);
        public void Delete(Plan plan) => _db.Plans.Remove(plan);

        public int SaveChanges() => _db.SaveChanges();

        public Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
