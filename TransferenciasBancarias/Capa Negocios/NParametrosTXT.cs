using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TransferenciasBancarias.Capa_Datos;

namespace TransferenciasBancarias.Capa_Negocios
{
    class NParametrosTXT
    {


        public static SAPbouiCOM.DataTable ObtenerParametrosTXT(SAPbouiCOM.DataTable DT_PARAM)
        {
            DParametrosTXT Obj = new DParametrosTXT();
            return Obj.ObtenerParametrosTXT(DT_PARAM);
        }

        public static string ActualizarParametrosTXT(string U_TipoRegistro, string U_Multifecha, string U_Modalidad, string U_Convenio
                                                    , string U_TipoPago, string U_CodigoPlantilla, string U_RUTEmpresa, string U_RUTFilial
                                                    , string U_CorreoEmp, string U_PlantillaRendici, string U_DirectorioBanco
                                                    , string U_DirectorioRespaldo, string U_FlujoActivo)
        {
            DParametrosTXT Obj = new DParametrosTXT();
            Obj.U_TipoRegistro = U_TipoRegistro;
            Obj.U_Multifecha = U_Multifecha;
            Obj.U_Modalidad = U_Modalidad;
            Obj.U_Convenio = U_Convenio;
            Obj.U_TipoPago = U_TipoPago;
            Obj.U_CodigoPlantilla = U_CodigoPlantilla;
            Obj.U_RUTEmpresa = U_RUTEmpresa;
            Obj.U_RUTFilial = U_RUTFilial;
            Obj.U_CorreoEmp = U_CorreoEmp;
            Obj.U_PlantillaRendici = U_PlantillaRendici;
            Obj.U_DirectorioBanco = U_DirectorioBanco;
            Obj.U_DirectorioRespaldo = U_DirectorioRespaldo; ;
            Obj.U_FlujoActivo = U_FlujoActivo; ;

            return Obj.ActualizarParametrosTXT(Obj);
        }
    }
}
