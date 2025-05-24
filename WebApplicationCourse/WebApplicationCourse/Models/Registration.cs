using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourse.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [MaxLength(200)]
        public string UserName { get; set; }
        [Required]
        [StringLength(200)]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Type { get; set; }
    }
}