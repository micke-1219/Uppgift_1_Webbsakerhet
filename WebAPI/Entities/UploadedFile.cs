using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPI.Entities
{
    public partial class UploadedFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UploadDate { get; set; }
        [Required]
        public byte[] Content { get; set; }
    }
}
