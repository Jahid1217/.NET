using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationCodeFirst.Models
{
    public class GameType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        //public virtual ICollection<Game> Games { get; set; }
        //public GameType()
        //{
        //    Games = new HashSet<Game>();
        //}
    }
}