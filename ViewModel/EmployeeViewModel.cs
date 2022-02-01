using EmployeeDirectory.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDirectory.ViewModel
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        [ForeignKey("DepartmentID")]
        [Display (Name = "Department Name")]
        public int DepartmentID { get; set; }
    }
}
