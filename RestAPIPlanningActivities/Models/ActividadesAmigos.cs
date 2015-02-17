using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace RestAPIPlanningActivities.Models
{
    [Table("actividadesamigos")]
    public class ActividadesAmigos
    {
        [Key]
        [Column(Order=1)]
        public Int64 idactividad { get; set; }
        [Key]
        [Column(Order = 2)]
        public Int64 idamigo { get; set; }

    }
}