using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIPlanningActivities.Models
{
    public class UsuariosDTO
    {
        public Int64 id { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        
    }
}