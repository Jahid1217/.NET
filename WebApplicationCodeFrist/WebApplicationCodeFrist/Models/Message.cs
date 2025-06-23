using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; // Ensure you have this using directive for [key] attribute

namespace WebApplicationCodeFrist.Models
{
    public class Message
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
    }
}