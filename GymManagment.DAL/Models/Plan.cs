using GymManagment.DAL.Models;

namespace GymManagment.Models
{
    public class Plan:BaseEntity
    {
        
        public String Name { get; set; } = default!;

        public String Description { get; set; } = default!;

        public  decimal Price { get; set; }
        public bool IsActive { get; set; }

        public int DurationDays { get; set; }

       

       

    }
}
