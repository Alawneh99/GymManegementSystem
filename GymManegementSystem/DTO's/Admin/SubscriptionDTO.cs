﻿using static Gym_Manegement_API.Helper.Enums.Enums;

namespace GymManegementSystem.DTO_s.Subscription
{
    public class SubscriptionDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public int TrainingHoursPerDay { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAvaible { get; set; }
        public string MembershipPlan { get; set; }
        public string ClassSubscriptionPlan { get; set; }
        public SubscriptionDuration Duration { get; set; }
    }
    public class UpdateSubscriptionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int DurationInDays { get; set; }
        public int TrainingHoursPerDay { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsAvaible { get; set; }
        public string MembershipPlan { get; set; }
        public string ClassSubscriptionPlan { get; set; }
        public SubscriptionDuration Duration { get; set; }
    }
}
