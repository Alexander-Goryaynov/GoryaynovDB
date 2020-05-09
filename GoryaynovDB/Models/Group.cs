using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("groups")]
    public class Group
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("year")]
        public int Year { get; set; }
        [Required]
        [Column("prefect_last_name")]
        public string PrefectLastName { get; set; }
        public List<Student> Students { get; set; }
    }
}
