using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace WebApplicationAPI.Models
{
    public class Conversation
    {
        [Key]
        [Required]
        public int ConversationID { get; set; }
        public int DoctorID { get; set; }
        public int ParentID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastMessageDate { get; set; }
        public bool IsArchived { get; set; }
        public User Doctor { get; set; }
        public User Parent { get; set; }
        public List<Message> Messages { get; set; }
        public int UnreadCount { get; set; }
    }
}