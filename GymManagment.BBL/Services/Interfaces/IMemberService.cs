using GymManagment.BBL.ViewModels.MemberviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.BBL.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct =default);
        Task<bool> CreateMemberAsync(CreateMemberViewModel member,CancellationToken ct =default); 
    }
}
