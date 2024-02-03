using Gym_Manegement_API.Models.Entity;

namespace GymManegementSystem.Models.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        
        public virtual GymClasses GymClasses { get; set; }
        public virtual Subscriptions Subscriptions { get; set; }
        public bool? IsActive { get; set; }

    }
}
