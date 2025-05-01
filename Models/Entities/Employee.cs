using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TedSolutions.Employee.Models.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { set; get; }

        public required string LastName { set; get; }

        public required string FirstName { set; get; }

        public required string Address { set; get; }

        public required string Designation { set; get; }
   
        public required string EmployeeNumber { set; get; }
    }
}
