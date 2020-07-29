using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppPersonal.Models
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime Fecha_creo { get; set; }
        public int UsrCreoId { get; set; }
    }
}
