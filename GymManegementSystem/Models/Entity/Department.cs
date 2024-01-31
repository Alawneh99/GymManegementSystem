using static Gym_Manegement_API.Helper.Enums.Enums;

namespace Gym_Manegement_API.Models.Entity
{
    public class Department
    {
        public int                   DepartmentId { get; set; }
        public DepartmentArabicName  ArabicName   { get; set; }
        public DepartmentEnglishName EnglishName  { get; set; }
        public string                Description  { get; set; }
        public bool?                 IsActive     { get; set; }
        public virtual List<Person>  People       { get; set; }
    }
}
