using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FifthExample_RepoPattern.Models
{
    [Table("Record")]
    public partial class Record
    {
        [Key]
        public int RecordId { get; set; }
        [Required]
        [StringLength(100)]
        public string RecordDesc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatingDate { get; set; }
    }
}
