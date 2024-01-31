namespace Gym_Manegement_API.Models.Entity
{
    public class PersonType
    {
        public int                  PersonTypeId { get; set; }
        public string               TypeName     { get; set; }
        public bool?                IsActive     { get; set; }
        public virtual List<Person> People       { get; set; }
    }
}

