using GymManagment.DAL.Models;
using GymManagment.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.Models
{
    public class GymUser: BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone{ get; set; }

        public DateTime DateOfBirth { get; set; }
         public  Adress Adress { get; set; }
         public Gender Gender { get; set; }

    }

    [Owned]
    public class Adress {
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;


        public int BuildingNumber { get; set; } = default!;

    }

}
