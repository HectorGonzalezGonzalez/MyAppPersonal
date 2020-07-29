using Java.Sql;
using MyAppPersonal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppPersonal.METODOS
{
    public class reto_ahorro
    {
        public List<Ahorro_aportaciones_programadas> algoridmo_reto_ahorro(DateTime DateStar,Ahorro ahorro)
        {            
            decimal aportacionPorSemana = 0;
            decimal ahorro_por_fecha = 0;
            List<Ahorro_aportaciones_programadas> Lst = new List<Ahorro_aportaciones_programadas>();
            for (int i = 1; i <= ahorro.noDia_aportar; i++)
            {
                aportacionPorSemana = ahorro.aportacion_inicial * i;
                ahorro_por_fecha = ahorro_por_fecha + aportacionPorSemana;
                Ahorro_aportaciones_programadas a = new Ahorro_aportaciones_programadas();
                a.NoSemanas = i;
                a.aportacion_por_semana = aportacionPorSemana;
                a.ahorro_por_fecha = ahorro_por_fecha;
                a.fecha_programada = DateStar;
                a.UsrCreoId = ahorro.UsrCreoId;
                a.AhorroId = ahorro.Id;
                a.Fecha_creo = DateStar;
                Lst.Add(a);
                //Console.WriteLine($"No. Semana :{i} ,Aportación:{aportacionPorSemana}, Ahorro:{ahorro} Fecha:{DateStar.ToString("yyyy/MMMM/dd")}");
                DateStar = DateStar.AddDays(7);
            }
            
            return Lst;
        }
    }
}
