using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Company.DAL.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Employee FirstName is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the FirstName is 30 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Employee LastName is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the LastName is 30 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Employee Age is a required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 50 characters.")]
        public string Position { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
    }
}
