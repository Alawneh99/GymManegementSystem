using GymManegementSystem.Models.Entity;
using static Gym_Manegement_API.Helper.Enums.Enums;

namespace Gym_Manegement_API.Models.Entity
{
    public class Department
    {
        public int                   Id { get; set; }
        public string  ArabicName   { get; set; }
        public string EnglishName  { get; set; }
        public string                Description  { get; set; }
        public bool?                 IsActive     { get; set; }
        public virtual List<Coach>  Coaches       { get; set; }
        public virtual List<Employe> Employes     { get; set; }
    }
}
