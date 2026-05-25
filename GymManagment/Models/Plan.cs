namespace GymManagment.Models
{
    public class Plan
    {
        public int id { get; set; }
        public String name { get; set; } = default!;

        public String description{ get; set; } = default!;

        public  decimal price{ get; set; }

        public bool isActive { get; set; }

        public int DurationDays { get; set; }

        public DateTime CreatedAt{ get; set; }

        public DateTime ? UpdatedAt { get; set; }

}
}
