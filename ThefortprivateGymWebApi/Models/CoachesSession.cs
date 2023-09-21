


namespace ThefortprivateGymWebApi.Models
{
    public class CoachesSession
    {
        public int Id { get; set; }
       
        public int coachId { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string day { get; set; }
        public int booked { get; set; }

    }
}
