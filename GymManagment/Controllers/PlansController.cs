using GymManagment.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Controllers
{
    public class PlansController : Controller
    {
        private readonly GymDbContext dbContext;
            public PlansController()
            {
               dbContext=new GymDbContext();
        }
        public async Task<IActionResult> index()
        {var plans=await dbContext.Plans.ToListAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id)
            {
            var plan= await dbContext.Plans.FindAsync(id);
            if(plan==null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return View(plan);
        }
    }
}
