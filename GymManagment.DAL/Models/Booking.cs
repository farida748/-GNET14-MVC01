using GymManagementSystem.DAL.Models;
using GymManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagment.DAL.Models
{
    public class Booking : BaseEntity
    {
        public Member member { get; set; } = default!;
        public int MemberId { get; set; }   
        public Session Session { get; set; } = default!;

        public int SessionId { get; set; }

        public bool IsAttended { get; set; }

    }
}
