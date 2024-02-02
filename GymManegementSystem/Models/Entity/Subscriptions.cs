using static Gym_Manegement_API.Helper.Enums.Enums;
using static Gym_Manegement_API.Models.Entity.GymClasses;

namespace Gym_Manegement_API.Models.Entity
{
    public class Subscriptions
    {
      public int                      SubscriptionId        { get; set; }
      public string                   Name                  { get; set; }
      public string                   Description           { get; set; }
      public float                    Price                 { get; set; }
      public int                      DurationInDays        { get; set; }
      public int                      TrainingHoursPerDay   { get; set; }
      public bool?                    IsActive              { get; set; }
      public bool?                    IsAvaible             { get; set; }
      public MembershipPlan           MembershipPlan        { get; set; } 
      public ClassSubscriptionPlan    ClassSubscriptionPlan { get; set; }
      public SubscriptionDuration     Duration              { get; set; }
      public virtual List<GymClasses> Classes               { get; set; }
      public virtual List<Person>     SubscribedClients     { get; set; }
    }
}

