using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyAppPersonal.Models
{
    public class Usuario: BaseDTO//, INotifyPropertyChanged
    {
        public string Nombre { get; set; }        
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Password { get; set; }        
        public Boolean Estatus { get; set; }

       
    }
}
