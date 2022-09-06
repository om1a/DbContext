using System.ComponentModel.DataAnnotations;

namespace DataBaseTask
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set; }
    }
}
