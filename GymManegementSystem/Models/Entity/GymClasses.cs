using GymManegementSystem.Models.Entity;
using static Gym_Manegement_API.Helper.Enums.Enums;

namespace Gym_Manegement_API.Models.Entity
{
    public class GymClasses
    {
        public int                   Id           { get; set; }
        public string             ClassName         { get; set; }
        public DateTime              StartTime         { get; set; }
        public DateTime              EndTime           { get; set; }
        public string                Description       { get; set; }
        public bool?                 IsActive          { get; set; }
        public virtual List<Client>  RegisteredClients { get; set; }
        

    }
}
