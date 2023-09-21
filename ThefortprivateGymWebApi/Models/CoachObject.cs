namespace ThefortprivateGymWebApi.Models
{
    public class CoachObject
    {

        public int Id { get; set; }
        public User userObject  { get; set; }
        public int Age { get; set; }
        public string Branch { get; set; }
        public string Qualification { get; set; }
        public string Personality { get; set; }
        public string Experience { get; set; }
        public string Rating { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }

    }
}
