namespace GymManagment.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Adress { get; set; }
        public  DateOnly  DateOfBirth { get; set; }
        public List<Session> Sessions { get; set; } = new();
    }
}
