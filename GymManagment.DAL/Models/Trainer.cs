using GymManagment.DAL.Models.Enums;

namespace GymManagment.Models
{
    public class Trainer :GymUser
    {
        
        public Specialty  Specialty { get; set; }

        public ICollection<Session> Sessions { get; set; } = default!;
    }
}
