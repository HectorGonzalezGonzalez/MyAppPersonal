using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppPersonal.Models
{
    public class Ahorro_aportaciones_programadas : BaseDTO
    {
        public int AhorroId { get; set; }
        public int NoSemanas { get; set; }
        public decimal aportacion_por_semana { get; set; }
        public DateTime fecha_programada { get; set; }
        public decimal ahorro_por_fecha { get; set; }
        public Boolean status { get; set; }
    }
}
