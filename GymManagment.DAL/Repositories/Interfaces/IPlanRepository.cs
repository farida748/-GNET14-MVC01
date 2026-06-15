
using GymManagment.Models;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken ct = default);
        Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default);

        void Add(Plan plan);
        void Update(Plan plan);
        void Delete(Plan plan);
        int SaveChanges();
    }
}