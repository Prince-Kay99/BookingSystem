namespace ThefortprivateGymWebApi.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public User clientObject {get; set;}
        public CoachObject trainerObject {get; set;}
        public int date { get; set; }
        public int  Time { get; set; }
   

    }
}
