using GymManagment.DAL.Models;
using GymManagment.Models;
using System.Collections.Generic;

namespace GymManagementSystem.DAL.Models
{
    public class Member : GymUser
    {
        public string? Photo { get; set; } 

        #region Relationships

        public HealthRecord HealthRecord { get; set; } = default!;

        public ICollection<MemberShip> MemberShip { get; set; } = new List<MemberShip>();

        #endregion
    }
}


