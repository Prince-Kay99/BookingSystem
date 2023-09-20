namespace ThefortprivateGymWebApi.Models
{
    public class GymActiveSession
    {
        public int Id { get; set; }
        public int Coach_Id { get; set; }
        public int Client_Id{ get; set; }
        public int CoachAvailability_Id { get; set; }
        public int? Session_Attendance { get; set; }
        
    }
}
