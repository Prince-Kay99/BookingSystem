using Microsoft.EntityFrameworkCore;
using ThefortprivateGymWebApi.Models;

namespace ThefortprivateGymWebApi.Data
{
    public class TheFortContext : DbContext
    {

        public TheFortContext(DbContextOptions<TheFortContext>options) : base(options)
        {

        }
     
        public TheFortContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<CoachProfile> CoachProfiles { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<ClientCoachPair> ClientCoachPairs { get; set; }
        public DbSet<GymActiveSession> GymActiveSessions { get; set; }
        public DbSet<ExerciseItem> ExerciseItems { get; set; }
        public DbSet<GymSession> GymSessions { get; set; }
        public DbSet<PendingCoach> PendingCoaches { get; set; }
        public DbSet<CoachAvailability> CoachAvailabilitys { get; set; }
        public DbSet<CoachObject> CoachObject { get; set; } 
        public DbSet<CoachesSession> CoachesSessions { get; set; }
        


    }
}
