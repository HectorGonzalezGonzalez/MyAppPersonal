using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppPersonal.Models
{
    public class Ahorro : BaseDTO
    {
        public decimal aportacion_inicial { get; set; }
        public int noDia_aportar { get; set; }
        public DateTime fecha_termina_reto { get; set; }
        public decimal cantidad_Meta { get; set; }
        public decimal cantidad_ahorrado { get; set; }
        public int status { get; set; }
    }
}
