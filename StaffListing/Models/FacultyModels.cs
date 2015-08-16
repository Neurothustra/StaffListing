using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Web.Peirce.FacultySearch.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }

    public class Faculty
    {
        public int FacultyId { get; set; }

        public string Prefix { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Suffix { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Telephone { get; set; }

        public Department Department { get; set; }

        public int DepartmentId { get; set; }
    }

    public class FacultyContext : DbContext
    {
        public FacultyContext()
            : base("FacultyContext")
        { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> FacultyMembers { get; set; }
    }

}