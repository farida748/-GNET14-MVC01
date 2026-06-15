namespace GymManagment.Models
{
    public class Session
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }

            public int TrainerId { get; set; }
            public Trainer Trainer { get; set; }

            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }

            public int Capacity { get; set; }

            public List<MemberSession> MemberSessions { get; set; } = new();
        }
    }

