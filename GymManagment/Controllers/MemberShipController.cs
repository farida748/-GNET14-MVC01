using GymManagment.DbContexts;
using GymManagment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Controllers
{
    public class MemberSessionController : Controller
    {
        private readonly GymDbContext _context;

        public MemberSessionController(GymDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var now = DateTime.Now;

            var sessions = await _context.Sessions
                .Include(s => s.Trainer)
                .Include(s => s.MemberSessions)
                .ToListAsync();

            return View(sessions);
        }

        public async Task<IActionResult> GetMembersForUpcomingSession(int sessionId)
        {
            var session = await _context.Sessions
                .Include(s => s.MemberSessions)
                .ThenInclude(ms => ms.Member)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
                return NotFound();

            return View(session);
        }

        public async Task<IActionResult> GetMembersForOngoingSessions(int sessionId)
        {
            var session = await _context.Sessions
                .Include(s => s.MemberSessions)
                .ThenInclude(ms => ms.Member)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
                return NotFound();

            return View(session);
        }

        public async Task<IActionResult> Create(int sessionId)
        {
            ViewBag.SessionId = sessionId;
            ViewBag.Members = await _context.Members.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int sessionId, int memberId)
        {
            var session = await _context.Sessions
                .Include(s => s.MemberSessions)
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
                return NotFound();

            if (session.MemberSessions.Count >= session.Capacity)
            {
                ModelState.AddModelError("", "Session is full");
                ViewBag.Members = await _context.Members.ToListAsync();
                return View();
            }

            var alreadyBooked = await _context.MemberSessions
                .AnyAsync(ms => ms.SessionId == sessionId && ms.MemberId == memberId);

            if (alreadyBooked)
            {
                ModelState.AddModelError("", "Member already booked this session");
                ViewBag.Members = await _context.Members.ToListAsync();
                return View();
            }

            _context.MemberSessions.Add(new MemberSession
            {
                SessionId = sessionId,
                MemberId = memberId,
                BookingDate = DateTime.Now,
                IsAttended = false
            });

            await _context.SaveChangesAsync();

            return RedirectToAction("GetMembersForUpcomingSession", new { sessionId });
        }

        [HttpPost]
        public async Task<IActionResult> MarkAttendance(int memberSessionId)
        {
            var booking = await _context.MemberSessions.FindAsync(memberSessionId);

            if (booking == null)
                return NotFound();

            booking.IsAttended = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("GetMembersForOngoingSessions", new { sessionId = booking.SessionId });
        }
    }
}

