using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RestAPIPlanningActivities.Models
{
    [Table("actividades")]
    public class Actividades
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        //ntext para SQL Server y text para MySQL
        //[Column("informacion", TypeName = "ntext")]
        [Column("informacion", TypeName = "text")]
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
        public virtual Usuarios Usuario { get; set; }
        
        
        
    }
}