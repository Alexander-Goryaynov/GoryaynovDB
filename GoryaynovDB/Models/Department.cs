using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GoryaynovDB.Models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("curator_last_name")]
        public string CuratorLastName { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
