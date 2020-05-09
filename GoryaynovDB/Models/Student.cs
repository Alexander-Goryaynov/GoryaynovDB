using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("student")]
    public class Student
    {
        [Key]
        [Required]
        [Column("record_book_number")]
        public int RecordBookNumber { get; set; }
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
        [Column("gender")]
        public string Gender { get; set; }
        [Required]
        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Column("group_id")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public Group Group { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
