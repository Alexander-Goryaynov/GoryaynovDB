using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("hours")]
        public int Hours { get; set; }
        public List<Rate> Rates { get; set; }
    }
}
