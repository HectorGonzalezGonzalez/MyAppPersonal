using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppPersonal.Models
{
    public class Memorizar : BaseDTO
    {
        public string Palabra { get; set; }
        public string Definicion { get; set; }
        public string Ejemplo { get; set; }
        public int Estatus { get; set; }

    }
}
