using GymManagment.DAL.Repositories.Interfaces;
using GymManagment.DAL.Models; // Use Plan from DAL.Models to avoid type conflict
using Microsoft.AspNetCore.Mvc;
using GymManagment.Models;

namespace GymManagementSystem.Controllers
{
    public class PlansController : Controller
    {
        private readonly IGenericRepository<Plan> planRepository;

        public PlansController(IGenericRepository<Plan> planRepository)
        {
            this.planRepository = planRepository;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            IEnumerable<Plan> plans = await planRepository.GetAllAsync(false, ct);

            return View(plans);
        }

        public async Task<IActionResult> Details(int id, CancellationToken ct)
        {
            var plan = await planRepository.GetByIdAsync(id, ct);

            if (plan is null)
                return RedirectToAction(nameof(Index));

            return View(plan);
        }
    }
}