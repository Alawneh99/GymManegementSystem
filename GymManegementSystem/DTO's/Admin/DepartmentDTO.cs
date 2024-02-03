namespace GymManegementSystem.DTO_s.Department
{
    public class DepartmentDTO
    {
        public string ArabicName       { get; set; }
        public string EnglishName    { get; set; }
        public string Description    { get; set; }
        public bool?  IsActive        { get; set; }
    }
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
    }
}
