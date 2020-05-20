using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("rate")]
    public class Rate
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("mark")]
        public int Mark { get; set; }
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("subject_id")]
        public int SubjectId { get; set; }
        [Required]
        [Column("student_record_book_number")]
        public int StudentRecordBookNumber { get; set; }
        [Required]
        [Column("teacher_passport_number")]
        public string TeacherPassportNumber { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
        [ForeignKey("StudentRecordBookNumber")]
        public Student Student { get; set; }
        [ForeignKey("TeacherPassportNumber")]
        public Teacher Teacher { get; set; }
    }
}
