namespace ThefortprivateGymWebApi.Models
{
    public class ExerciseItem
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set;}
        public int ExerciseRecomendedSets { get; set; }
        public int ExerciseRecomendedReps{ get; set; }
        public string ExerciseTargetMuscel { get; set;}

    }
}
