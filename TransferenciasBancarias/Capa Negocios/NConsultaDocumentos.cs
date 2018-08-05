using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;

namespace TransferenciasBancarias.Capa_Negocios
{
    class NConsultaDocumentos
    {
        public static SAPbouiCOM.DataTable ConsultarFacturas(SAPbouiCOM.DataTable DT_Resultado, string sPago, string TipoTabla)
        {
            DConsultaDocumentos Obj = new DConsultaDocumentos();
            return Obj.ConsultarFacturas(DT_Resultado, sPago, TipoTabla);
        }

        public static SAPbouiCOM.DataTable ConsultarRecepciones(SAPbouiCOM.DataTable DT_Resultado, string sPago, string TipoTabla)
        {
            DConsultaDocumentos Obj = new DConsultaDocumentos();
            return Obj.ConsultarRecepciones(DT_Resultado, sPago, TipoTabla);
        }

        public static SAPbouiCOM.DataTable ConsultarOrdenes(SAPbouiCOM.DataTable DT_Resultado, string sPago, string TipoTabla)
        {
            DConsultaDocumentos Obj = new DConsultaDocumentos();
            return Obj.ConsultarOrdenes(DT_Resultado, sPago, TipoTabla);
        }

    }
}
