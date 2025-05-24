using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationCodeFirst.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Game Title")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        [MaxLength(100)]
        public string Tital { get; set; }
        public string Price { get; set; }
        public string Quanrity { get; set; }

        public int GameTypeId { get; set; }

        public GameType GameType { get; set; }
    }
}