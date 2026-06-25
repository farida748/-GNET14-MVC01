using GymManagment.BBL.Services.Interfaces;
using GymManagment.BBL.ViewModels.MemberviewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagment.PL.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var members = await memberService.GetAllMembersAsync(ct);
            return View();
        }

       public IActionResult Create() => View();


        [HttpPost]
          public async Task<IActionResult> Create(CreateMemberViewModel member, CancellationToken ct)
          {
                if (!ModelState.IsValid)
                 return View(member);
    
                var result = await memberService.CreateMemberAsync(member, ct);
    
                if (!result)
                {
                 ModelState.AddModelError(string.Empty, "Email or Phone already exists.");
                 return View(member);
                }
    
                return RedirectToAction(nameof(Index));
        }


    }
}
