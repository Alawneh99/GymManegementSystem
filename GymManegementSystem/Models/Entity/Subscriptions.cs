using GymManegementSystem.Models.Entity;
using static Gym_Manegement_API.Helper.Enums.Enums;
using static Gym_Manegement_API.Models.Entity.GymClasses;

namespace Gym_Manegement_API.Models.Entity
{
    public class Subscriptions
    {
      public int                      Id                    { get; set; }
      public string                   Name                  { get; set; }
      public string                   Description           { get; set; }
      public float                    Price                 { get; set; }
      public int                      DurationInDays        { get; set; }
      public int                      TrainingHoursPerDay   { get; set; }
      public bool?                    IsActive              { get; set; }
      public bool?                    IsAvaible             { get; set; }
      public string                   MembershipPlan        { get; set; } 
      public string                   ClassSubscriptionPlan { get; set; }
      public SubscriptionDuration     Duration              { get; set; }
      public virtual List<Client>     SubscribedClients     { get; set; }
    }
}

