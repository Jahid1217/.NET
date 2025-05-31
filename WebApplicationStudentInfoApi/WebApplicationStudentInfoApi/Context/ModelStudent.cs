using System;
using System.Data.Entity;
using System.Linq;
using WebApplicationStudentInfoApi.Models;

namespace WebApplicationStudentInfoApi.Context
{
    public class ModelStudent : DbContext
    {
        // Your context has been configured to use a 'ModelStudent' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplicationStudentInfoApi.Context.ModelStudent' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelStudent' 
        // connection string in the application configuration file.
        public ModelStudent()
            : base("name=ModelStudent")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<StudentInfo> Students { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}