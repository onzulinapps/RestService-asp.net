using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RestAPIPlanningActivities.Models
{
    [Table("actividades", Schema = "dbo")]
    public class Actividades
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        //ntext para SQL Server y text para MySQL
        //[Column("informacion", TypeName = "ntext")]
        [Column("Informacion", TypeName = "text")]
        public string Informacion { get; set; }
        [MaxLength(250)]
        public string Direccion { get; set; }
        public DateTime Horarioinicial { get; set; }
        public DateTime Horariofinal { get; set; }
        [MaxLength(250)]
        public string Latitud { get; set; }
        [MaxLength(250)]
        public string Longitud { get; set; }
        [MaxLength(250)]
        public string Altitud { get; set; }
        //precision = accurac
        [MaxLength(250)]
        public string Accuracy { get; set; }
        //[ForeignKey("UsuarioID")]
        public Int64 UsuarioID { get; set; }
        public virtual AspNetUsers Usuario { get; set; }
        
        
        
    }
    /*
    [Table("AspNetRoles", Schema = "public")]
    public class AspNetRoles
    {
        [MaxLength(128)]
        [Key]
        public string Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
    }
    [Table("AspNetUserClaims",Schema = "public")]
    public class AspNetUserClaims
    {
        [Key]
        public int Id { get; set; }
        //FK de la tabla AspNetUsers ver como definirla
        public string UserId { get; set; }
        [MaxLength(400)]
        public string ClaimType { get; set; }
        [MaxLength(400)]
        public string ClaimValue { get; set; }
    }
    [Table("AspNetUserLogins",Schema = "public")]
    public class AspNetUserLogins
    {
        [Key]
        [MaxLength(128)]
        public string LoginProvider { get; set; }
        [MaxLength(128)]
        public string ProviderKey { get; set; }
        [MaxLength(128)]
        public string UserId { get; set; }
        //veremos a ver si esta forma de definir una Foreign Key da problemas 
        [ForeignKey("UserId")]
        public AspNetUsers User { get; set; }
    }
    [Table("AspNetUserRoles", Schema = "public")]
    public class AspNetUserRoles
    {
        [Key]
        [MaxLength(128)]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AspNetUsers User { get; set; }
        [Key]
        [MaxLength(128)]
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public AspNetRoles Role { get; set; }

        
    }
    */ 
}