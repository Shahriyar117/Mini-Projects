using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.Models
{
    public class Department
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
