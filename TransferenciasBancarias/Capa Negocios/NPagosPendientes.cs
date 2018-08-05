using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;

namespace TransferenciasBancarias.Capa_Negocios
{
    public class NPagosPendientes
    {
        public static SAPbouiCOM.DataTable Listar(DateTime FecIni, DateTime FecFin, SAPbouiCOM.DataTable DT_Resultado)
        {
            DPagosPendientes Obj = new DPagosPendientes();
            Obj.FechaIni = FecIni;
            Obj.FechaFin = FecFin;
            return Obj.Listar(Obj, DT_Resultado);
        }

    }

}
