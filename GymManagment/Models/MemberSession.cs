namespace GymManagment.Models
{
    public class MemberSession
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }

        public bool IsAttended { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
