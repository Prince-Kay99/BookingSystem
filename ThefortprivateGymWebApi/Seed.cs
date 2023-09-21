using HashPass;
using System;
using ThefortprivateGymWebApi.Data;
using ThefortprivateGymWebApi.Models;

namespace ThefortprivateGymWebApi
{

    /* qick delete on the ssms
         drop table [TheFortPrivateGymDb].[dbo].[Users];
drop table [TheFortPrivateGymDb].[dbo].[ClientCoachPairs]
drop table [TheFortPrivateGymDb].[dbo].[ClientProfiles];
drop table [TheFortPrivateGymDb].[dbo].[CoachAvailabilitys]
drop table [TheFortPrivateGymDb].[dbo].[CoachProfiles]
drop table [TheFortPrivateGymDb].[dbo].[GymActiveSessions];
drop table [TheFortPrivateGymDb].[dbo].[GymSessions];
drop table [TheFortPrivateGymDb].[dbo].[PendingCoaches];
drop table [TheFortPrivateGymDb].[dbo].[ExerciseItems];
drop table [TheFortPrivateGymDb].[dbo].[CoachesSessions];

     */
    public class Seed
    {
        private readonly TheFortContext dataContext;
        public Seed(TheFortContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.ClientProfiles.Any())
            {
                var pro = new List<ClientProfile>()
                {
                    new ClientProfile
                    {
                        AGE=22,
                        COACH_ID=3,
                        selectedSessions=5,
                        ClientId=5
                    }
                };
            }

            if (!dataContext.CoachAvailabilitys.Any())
            {
                var available = new List<CoachAvailability>()
                {
                    new CoachAvailability
                    {
                         Coach_Id = 2,
                        Session_Id = 1
                    },
                    new CoachAvailability
                    {
                         Coach_Id = 3,
                        Session_Id = 1
                    },
                    new CoachAvailability
                    {
                        Coach_Id = 3,
                        Session_Id = 2
                    },
                     new CoachAvailability
                    {
                        Coach_Id = 3,
                        Session_Id = 22
                    }
                    ,
                     new CoachAvailability
                    {
                        Coach_Id = 3,
                        Session_Id = 34
                    }
                };
                dataContext.CoachAvailabilitys.AddRange(available);
                dataContext.SaveChanges();
            }

            if (!dataContext.GymActiveSessions.Any())
            {
                var active = new List<GymActiveSession>()
                {
                    new GymActiveSession()
                    {
                         Coach_Id=3,
                        Client_Id = 5,
                       CoachAvailability_Id=3,
                    },
                    new GymActiveSession()
                    {
                        Coach_Id=3,
                        Client_Id = 5,
                        CoachAvailability_Id=2,
                    }
                };
                dataContext.GymActiveSessions.AddRange(active);
                dataContext.SaveChanges();
            }

           /**if (!dataContext.ClientCoachPairs.Any())
            {
                var pairings = new List<ClientCoachPair>()
                {
                    new ClientCoachPair {
                    CoachId=3,
                    ClientId=5
                    }
                };
                dataContext.ClientCoachPairs.AddRange(pairings);
                dataContext.SaveChanges();
            }**/

           if (!dataContext.ExerciseItems.Any())
            {
                var items = new List<ExerciseItem>()
                {
                    new ExerciseItem()
                    {
                        ExerciseName="Push up",
                        ExerciseDescription="You make sure that youu push up",
                        ExerciseRecomendedSets=5,
                        ExerciseRecomendedReps=5,
                        ExerciseTargetMuscel = "Arms"
                    },
                    new ExerciseItem()
                    {
                        ExerciseName="Pull up",
                        ExerciseDescription="You make sure that you pull up",
                        ExerciseRecomendedSets=5,
                        ExerciseRecomendedReps=5,
                        ExerciseTargetMuscel = "Arms"
                    },
                     new ExerciseItem()
                    {
                        ExerciseName="Jogging ",
                        ExerciseDescription="You make sure that you Jog ",
                        ExerciseRecomendedSets=5,
                        ExerciseRecomendedReps=5,
                        ExerciseTargetMuscel = "Legs"
                    }

                };
                dataContext.ExerciseItems.AddRange(items);
                dataContext.SaveChanges();
            }

           if (!dataContext.GymSessions.Any())
           {
                var gymSessions = new List<GymSession>()
                {
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")
                
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Monday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Monday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Monday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Monday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Monday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Monday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    }
                    ,/*Tuesday sessions*/
                     new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Tuesday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Tuesday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    },
                    /*Wednesday*/
                     new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Wednesday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Wednesday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    },
                    /*Thursday */
                     new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Thursday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Thursday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    },
                    /*Friday*/
                     new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Friday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Friday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Friday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Friday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Friday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Friday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    },
                    /*Saturday*/
                     new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Saturday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Saturday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    },
                    /*Sunday*/
                     new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("05:00 AM"),
                        EndTime= Convert.ToDateTime("06:00 AM")

                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("06:00 AM"),
                        EndTime= Convert.ToDateTime("07:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("07:00 AM"),
                        EndTime= Convert.ToDateTime("08:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("08:00 AM"),
                        EndTime= Convert.ToDateTime("09:00 AM")
                    },
                    new GymSession()
                    {
                          SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("09:00 AM"),
                        EndTime= Convert.ToDateTime("10:00 AM")
                    },
                     new GymSession()
                    {
                           SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("10:00 AM"),
                        EndTime= Convert.ToDateTime("11:00 AM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("11:00 AM"),
                        EndTime= Convert.ToDateTime("12:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("12:00 PM"),
                        EndTime= Convert.ToDateTime("01:00 PM")

                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("01:00 PM"),
                        EndTime= Convert.ToDateTime("02:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("02:00 PM"),
                        EndTime= Convert.ToDateTime("03:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("03:00 PM"),
                        EndTime= Convert.ToDateTime("04:00 PM")
                    },
                    new GymSession()
                    {
                          SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("04:00 PM"),
                        EndTime= Convert.ToDateTime("05:00 PM")
                    },
                     new GymSession()
                    {
                           SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("05:00 PM"),
                        EndTime= Convert.ToDateTime("06:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("06:00 PM"),
                        EndTime= Convert.ToDateTime("07:00 PM")
                    },
                      new GymSession()
                    {
                           SessionDay="Sunday",
                          StartTime= Convert.ToDateTime("07:00 PM"),
                        EndTime= Convert.ToDateTime("08:00 PM")
                    },
                    new GymSession()
                    {
                        SessionDay="Sunday",
                        StartTime= Convert.ToDateTime("08:00 PM"),
                        EndTime= Convert.ToDateTime("09:00 PM")
                    }

                };
                dataContext.GymSessions.AddRange(gymSessions);
                dataContext.SaveChanges();
            }

           if (!dataContext.Users.Any())
            {
                var gymUsers = new List<User>()
                {
                    new User()
                    {
                        User_FirstName ="Senzo",
                        User_LastName = "Shongwe",
                        User_Contact = "76313516",
                        User_Email = "manager@fort",
                        User_Password =Secrecy.HashPassword("Manager"),
                        User_Type ="Manager"
                    },
                      new User()
                    {
                         User_FirstName = "Martin",
                         User_LastName = "Banda",
                         User_Contact="082445785",
                         User_Email = "banda@fort",
                         User_Password =Secrecy.HashPassword("banda"),
                         User_Type ="Coach"
                     },
                       new User()
                    {
                         User_FirstName = "Skobho",
                         User_LastName = "Ndzimandze",
                         User_Contact="082168745",
                         User_Email = "skobho@fort",
                         User_Password =Secrecy.HashPassword("skobho"),
                         User_Type ="Coach"
                     },
                     new User()
                    {
                         User_FirstName = "Senkosi",
                         User_LastName = "Mtimandze",
                         User_Contact="0635211147",
                         User_Email = "coach@fort",
                         User_Password =Secrecy.HashPassword("Coach"),
                         User_Type ="Coach"
                     },
                      new User()
                    {
                        User_FirstName = "Phumlani",
                        User_LastName="Gama",
                        User_Contact = "0650541287",
                        User_Email = "gama@fort",
                        User_Password =Secrecy.HashPassword("gama"),
                        User_Type ="Client"
                    },
                    new User()
                    {
                        User_FirstName = "Siphiwo",
                        User_LastName="Bhambolunye",
                        User_Contact = "0792661157",
                        User_Email = "siphiwo@fort",
                        User_Password =Secrecy.HashPassword("siphiwo"),
                        User_Type ="Client"
                    },
                     new User()
                    {
                        User_FirstName = "Sandzile",
                        User_LastName="Mabuza",
                        User_Contact = "0792661157",
                        User_Email = "sandzile@fort",
                        User_Password =Secrecy.HashPassword("sandzile"),
                        User_Type ="Client"
                    }
                };
                dataContext.Users.AddRange(gymUsers);
                dataContext.SaveChanges();
            }          
        }
    }
}
