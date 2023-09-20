using System.ComponentModel.DataAnnotations;
namespace ThefortprivateGymWebApi.Models
{
    public class ClientCoachPair
    {
        [Key]
        public int Id { get; set; }
        public int CoachId { get; set; }
        public int ClientId { get; set;}
    }
}
