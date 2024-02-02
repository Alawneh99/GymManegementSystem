namespace Gym_Manegement_API.Models.Entity
{
    public class Person
    {
        public int                   PersonId              { get; set; }
        public string                FirstName             { get; set; }
        public string                LastName              { get; set; }
        public string                FullName              { get; set; }
        public string                Email                 { get; set; }
        public string                Phone                 { get; set; }
        public string                Password              { get; set; }
        public DateTime              BirthDate             { get; set; }
        public int                   Age                   { get; set; }
        public string                Specialization        { get; set; }
        public string                Gender                { get; set; }
        public string                CoachDescription      { get; set; }
        public bool?                 IsActive              { get; set; }
        public bool?                 IsAvaible             { get; set; }
        public string                EmergencyContactName  { get; set; }
        public string                EmergencyContactPhone { get; set; }
        public virtual PersonType    PersonType            { get; set; }
        public virtual Department    Department            { get; set; }
        public virtual GymClasses    Classes               { get; set; }
        public virtual Subscriptions Subscriptions         { get; set; }
    } 
}
