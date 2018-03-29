using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _7DayTutorial.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId  { get; set; }
        [Required(ErrorMessage="Enter First Name")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}