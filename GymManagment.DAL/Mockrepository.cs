using GymManagement.DAL.Repositories.Interfaces;
using GymManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL
{
    public class Mockrepository : IPlanRepository
    {
        public void Add(Plan plan)
        {
            throw new NotImplementedException();
        }

        public void Delete(Plan plan)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default)
        {
            List<Plan> plans = new List<Plan>
            {
                new(){name="test"}
            };
            return plans;
           
        }

        public Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Plan plan)
        {
            throw new NotImplementedException();
        }
    }
}
