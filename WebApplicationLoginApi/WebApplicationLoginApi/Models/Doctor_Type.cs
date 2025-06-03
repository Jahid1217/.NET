using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationLoginApi.Models
{
    public class Doctor_Type
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string doctorType { get; set; }
    }
}