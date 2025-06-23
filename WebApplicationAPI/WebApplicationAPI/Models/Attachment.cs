using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public class Attachment
    {
        [Key]
        [Required]
        public int AttachmentID { get; set; }
        public int MessageID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
    }
}