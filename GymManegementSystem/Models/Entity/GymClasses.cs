using static Gym_Manegement_API.Helper.Enums.Enums;

namespace Gym_Manegement_API.Models.Entity
{
    public class GymClasses
    {
        public int                   ClassId           { get; set; }
        public ClassName             ClassName         { get; set; }
        public DateTime              StartTime         { get; set; }
        public DateTime              EndTime           { get; set; }
        public string                Description       { get; set; }
        public bool?                 IsActive          { get; set; }
        public virtual List<Person>  RegisteredClients { get; set; }
        public virtual Subscriptions Subscription      { get; set; }
    }
}
