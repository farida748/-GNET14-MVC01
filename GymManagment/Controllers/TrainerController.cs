using GymManagment.DbContexts;
using GymManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Controllers
{
    public class TrainerController : Controller
    {
        private readonly GymDbContext _context;

        public TrainerController(GymDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var trainers = await _context.Trainers.ToListAsync();
            return View(trainers);
        }

        public async Task<IActionResult> TrainerDetails(int id)
        {
            var trainer = await _context.Trainers
                .FirstOrDefaultAsync(t => t.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }


        public async Task<IActionResult> Edit(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }




        public async Task<IActionResult> Delete(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return View(trainer);
        }


        public IActionResult Create()
        {
            return View();
        }



    }

}
