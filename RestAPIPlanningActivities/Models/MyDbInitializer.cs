using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestAPIPlanningActivities.Models
{
    public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>//System.Data.Entity.DropCreateDatabaseIfModelChanges<MyDbContext>
    //System.Data.Entity. DropCreateDatabaseIfModelChanges<MyDbContext>
    // CreateDatabaseIfNotExists<MyDbContext>
    {
        //creo el metodo para llamarlo para crear la base de datos
        /*
        public virtual void InitializeDatabase(MyDbContext context)
        {
            
            context.Database.CreateIfNotExists();
            context.Database.Initialize(true);
            Seed(context);
        }
        */ 
        protected override void Seed(MyDbContext context)
        {
            //aqui crearemos un usuario de prueba para que la gente pueda probar la aplicacion REST tanto en interfaz web como interfaz movil. Windows, iOS, Android.
            //context.AspNetUsers.Add(new AspNetUsers { Email = "example@restapi.com", password = "jlsmjlsm", nombre = "example", created_at = DateTime.Now, updated_at = DateTime.Now, emailConfirmed = "0" });
            //context.Students.Add(new Student { ID = 1, FirstName = "Mark", LastName = "Richards", EnrollmentDate = DateTime.Now });
            
        }
    }
    /*
    //esta clase la usare en el caso de que la base de datos exista
    public class DbInitializer : CreateDatabaseIfNotExists<MyDbContext>//System.Data.Entity.DropCreateDatabaseIfModelChanges<MyDbContext>
    //System.Data.Entity. DropCreateDatabaseIfModelChanges<MyDbContext>
    // CreateDatabaseIfNotExists<MyDbContext>
    {
        //creo el metodo para llamarlo para crear la base de datos
        
        public virtual void InitializeDatabase(MyDbContext context)
        {
            
            //context.Database.CreateIfNotExists();
            //context.Database.Initialize(true);
            Seed(context);
        }
        
        protected override void Seed(MyDbContext context)
        {
            //aqui crearemos un usuario de prueba para que la gente pueda probar la aplicacion REST tanto en interfaz web como interfaz movil. Windows, iOS, Android.
            context.Usuarios.Add(new Usuarios { id = 1, email = "example@restapi.com", password = "jlsmjlsm", nombre = "example", created_at = DateTime.Now, updated_at = DateTime.Now });
            //context.Students.Add(new Student { ID = 1, FirstName = "Mark", LastName = "Richards", EnrollmentDate = DateTime.Now });

        }
    }
     */ 
}