﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAPI.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

    }
}