﻿namespace GymManegementSystem.DTO_s.Admin
{
    public class AdminDTO
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
        public string Phone    { get; set; }
        public int    Age      { get; set; }
        public bool? IsActive { get; set; }
    }
    public class UpdateAdminDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool? IsActive { get; set; }
    }
}
