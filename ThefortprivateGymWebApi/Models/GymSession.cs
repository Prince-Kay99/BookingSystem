namespace ThefortprivateGymWebApi.Models
{
    public class GymSession
    { 
        public int Id { get; set; }
        public string SessionDay { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
