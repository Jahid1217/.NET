using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; } // "Doctor" or "Patient"

    }
}