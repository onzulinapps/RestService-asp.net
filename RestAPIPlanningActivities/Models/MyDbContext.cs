using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Data.Entity.ModelConfiguration.Conventions; 
namespace RestAPIPlanningActivities.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("MyDbContext")
        {
            //inicializar la base de datos 
            //base.Configuration.ProxyCreationEnabled = false;
            //Database.SetInitializer<MyDbContext>(new MyDbInitializer());
            try
            {
                this.Database.Initialize(false);
            }
            catch (Exception ex)
            {
                
            }
            
        }

        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<Actividades> Actividades { get; set; }
        public DbSet<ActividadesAmigos> ActividadesAmigos { get; set; }
        //public DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUsers> AspNetUserRoles { get; set; }
        //public DbSet<AspNetUsers> AspNetUserClaims { get; set; }
        //public System.Data.Entity.DbSet<Npgsql_EF6.Models.ActorViewModels> ActorViewModels { get; set; }
        #region metodos
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<ActividadesAmigos>().HasKey(a => new { a.idactividad, a.idamigo });
            
            modelBuilder.Entity().ToTable("AspNetUsers", "pubic");
            modelBuilder.Entity().ToTable("Album", "public");
            modelBuilder.Entity().ToTable("Cart", "public");
            modelBuilder.Entity().ToTable("Order", "public");
            modelBuilder.Entity().ToTable("OrderDetail", "public");
            modelBuilder.Entity().ToTable("Genre", "public");
            
        }
        */
        #endregion
    }
}