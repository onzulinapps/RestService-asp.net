using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace RestAPIPlanningActivities.Models
{
    [Table("Amigos", Schema = "dbo")]
    public class Amigos
    {
        //Id primary key de la tabla 
        [Key]
        public Int64 Id { get; set; }
        [MaxLength(128)]
        public string Idusuario { get; set; }

        [MaxLength(128)]
        public string Idamigo { get; set; }
    }
}