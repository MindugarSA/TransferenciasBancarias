using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;

namespace TransferenciasBancarias.Capa_Negocios
{
    class NHistoricoPagos
    {
        public static SAPbouiCOM.DataTable ListarPagosArchivoTXT(int CodigoArchivo, SAPbouiCOM.DataTable DT_Resultado)
        {
            DHistoricoPagos Obj = new DHistoricoPagos();
            return Obj.ListarHistoricoPagosTXT(CodigoArchivo, DT_Resultado);
        }
    }
}
