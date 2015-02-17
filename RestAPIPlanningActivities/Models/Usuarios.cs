using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RestAPIPlanningActivities.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Int64 id { get; set; }
        [MaxLength(250)]
        public string email { get; set; }
        [MaxLength(250)]
        public string password { get; set; }
        [MaxLength(250)]
        public string nombre { get; set; }
        [MaxLength(250)]
        public string apellidos { get; set; }
        [MaxLength(250)]
        public string numerotelefono1 { get; set; }
        [MaxLength(250)]
        public string numerotelefono2 { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        //define la propidad de navegacion
        public virtual ICollection<Actividades> Actividades { get; set; }
    }
}