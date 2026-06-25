using GymManagementSystem.DAL.Models;
using GymManagment.BBL.Services.Interfaces;
using GymManagment.BBL.ViewModels.MemberviewModels;
using GymManagment.DAL.Models;
using GymManagment.DAL.Repositories.Interfaces;
using GymManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.BBL.Services.Classes
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> memberrepository;

        public MemberService(IGenericRepository<Member> memberrepository)
        {
            this.memberrepository = memberrepository;
        }

        public async Task<bool> CreateMemberAsync(CreateMemberViewModel model, CancellationToken ct = default)
        {
            // Check Email
            var emailExist = await memberrepository.Anyasync(x => x.Email == model.Email, ct);

            // Check Phone
            var phoneExist = await memberrepository.Anyasync(x => x.Phone == model.Phone, ct);

            // Email Or Phone Exist Return False
            if (emailExist || phoneExist)
                return false;

            // Else Return True Add Member
            var member = new Member()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,

                Adress = new Adress()
                {
                    BuildingNumber = model.BuildingNumber,
                    City = model.City,
                    Street = model.Street
                },

                HealthRecord = new HealthRecord()
                {
                    BloodType = model.HealthRecordViewModel.BloodType,
                    Height = model.HealthRecordViewModel.Height,
                    Weight = model.HealthRecordViewModel.Weight,
                   
                }
            };

            var result=await memberrepository.Add(member, ct);
            
            return result>0;
        }

        public async Task<IEnumerable<MemberViewModel>> GetAllMembersAsync(CancellationToken ct)
        {
            var members = await memberrepository.GetAllAsync(false, ct);
            if ( !members.Any()) return [];

            var MemberViewModel= members.Select(m => new MemberViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Photo = m.Photo,
                Gender = m.Gender.ToString()  ,
                Phone = m.Phone
            });
            return MemberViewModel;
        }
    }
}
