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
        public Int64 id { get; set; }
        [MaxLength(100)] 
        public string nombre { get; set; }
        [Column("informacion", TypeName="ntext")]  
        public string informacion { get; set; }
        [MaxLength(250)] 
        public string direccion { get; set; }
        public DateTime horarioinicial { get; set; }
        public DateTime horariofinal { get; set; }
        [MaxLength(250)] 
        public string latitud { get; set; }
        [MaxLength(250)]
        public string longitud { get; set; }
        [MaxLength(250)]
        public string altitud { get; set; }
        //precision = accuracy
        [MaxLength(250)]
        public string accuracy { get; set; }

        public Int64 idusuario { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        
        
        
    }
}