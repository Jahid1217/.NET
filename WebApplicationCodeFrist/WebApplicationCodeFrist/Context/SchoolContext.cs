using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace WebApplicationCodeFrist.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDbConnection") { }

        public DbSet<Student> Students { get; set; }
    }
}