using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace WebApplicationCourse.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        [MaxLength(80)]
       
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        [MaxLength(200)]
        public string Launch { get; set; }

        [Required]
        [StringLength(200)]
        [MaxLength(200)]
        public string Category  { get; set; }

        [Required]
        [Range(1, 180)]
        public string Duration { get; set; }

        public virtual Category type { get; set; }

    }
}