using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [Key]
        [Required]
        [Column("passport_number")]
        public string PassportNumber { get; set; }
        [Required]
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }
        [Required]
        [Column("middle_name")]
        public string MiddleName { get; set; }
        [Required]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
