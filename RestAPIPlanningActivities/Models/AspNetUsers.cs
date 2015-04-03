using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//todas las tablas que necesito para login y registro de usuarios con los tipos de datos soportados ven PostgreSQL 
namespace RestAPIPlanningActivities.Models
{
    [Table("AspNetUsers", Schema = "dbo")]
    public class AspNetUsers
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [MaxLength(128)]
        public string Id { get; set; }
        [MaxLength(256)]
        public string Email { get; set; }
        //este tipo de dato es boolean o bool puede fallar como boolean cuestion de probar
        [DataType("boolean")]
        public bool EmailConfirmed { get; set; }
        [MaxLength(250)]
        public string PasswordHash { get; set; }
        [MaxLength(500)]
        public string PhoneNumber { get; set; }
        [DataType("boolean")]
        public bool PhoneNumberConfirmed { get; set; }
        [DataType("boolean")]
        public bool TwoFactorEnabled { get; set; }
        //lo mismo hay que definir tipo de dato de fecha al usar PostgreSQL
        public DateTime LockoutEndDateUtc { get; set; }
        [DataType("boolean")]
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        [MaxLength(256)]
        public string UserName { get; set; }
        
        [MaxLength(200)]
        public string Nombre { get; set; }
        [MaxLength(200)]
        public string Apellidos { get; set; }
        
        //campo confirmacion de email campo booleano a ver si MySQL lo coge asi y SQL Server
        //[Column("emailConfirmed", TypeName = "tinyint")]
        //en la programacion ya tengo en cuenta que este campo lo quiero para poner 0 en caso de False y 1 en caso de true
   
        //public DateTime created_at { get; set; }
        //public DateTime updated_at { get; set; }
        //define la propidad de navegacion
        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}

