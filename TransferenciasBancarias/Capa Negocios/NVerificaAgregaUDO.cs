using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;

namespace TransferenciasBancarias.Capa_Negocios
{
    public static class NVerificaAgregaUDO
    {
        public static bool VerificarCrearUDO()
        {
            bool bExiste = false;

            try
            {
                if (!FuncionesUDO.CheckUDOExists("Z_MIN_TXTPAGOS"))
                {
                    if (!FuncionesUDT.CheckTableExists("Z_MIN_TXTPAGOS"))
                    {

                        CreaUDT_TXT_BANCO();
                        FuncionesUDO.CreateUDO("Z_MIN_TXTPAGOS", SAPbobsCOM.BoUDOObjType.boud_MasterData);
                    }
                    else
                        FuncionesUDO.CreateUDO("Z_MIN_TXTPAGOS", SAPbobsCOM.BoUDOObjType.boud_MasterData);
                }
                else
                    bExiste = true;
            }
            catch (Exception) { }

            return bExiste;
        }

        public static void CreaUDT_TXT_BANCO()
        {
            try
            {
                FuncionesUDT.CreateUDT("Z_MIN_TXTPAGOS", "Parametros TXT Pagos", SAPbobsCOM.BoUTBTableType.bott_MasterData);

                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_TipoRegistro", "TipoRegistro", SAPbobsCOM.BoFieldTypes.db_Alpha, 2, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_Multifecha", "Multifecha", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_RUTFilial", "RUT Filial", SAPbobsCOM.BoFieldTypes.db_Alpha, 10, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_CorreoEmp", "Correo Notificaciones", SAPbobsCOM.BoFieldTypes.db_Alpha, 50, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_PlantillaRendici", "Codigo Plantilla Rendicion", SAPbobsCOM.BoFieldTypes.db_Alpha, 4, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_DirectorioBanco", "Directorio para Banco", SAPbobsCOM.BoFieldTypes.db_Alpha, 250, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_DirectorioRespaldo", "Directorio de Respaldo", SAPbobsCOM.BoFieldTypes.db_Alpha, 250, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_Modalidad", "Modalidad Ingreso", SAPbobsCOM.BoFieldTypes.db_Alpha, 1, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_Convenio", "Convenio Servibanca", SAPbobsCOM.BoFieldTypes.db_Alpha, 4, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_TipoPago", "Tipo de Pago", SAPbobsCOM.BoFieldTypes.db_Alpha, 2, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_FechaPago", "Fecha de pago", SAPbobsCOM.BoFieldTypes.db_Alpha, 8, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_CantidadPago", "Numeros de Pagos", SAPbobsCOM.BoFieldTypes.db_Alpha, 5, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_MontoTotal", "Monto Total", SAPbobsCOM.BoFieldTypes.db_Alpha, 17, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_CodigoPlantilla", "Codigo Plantilla", SAPbobsCOM.BoFieldTypes.db_Alpha, 4, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_RUTEmpresa", "RUT Empresa", SAPbobsCOM.BoFieldTypes.db_Alpha, 10, "");
                FuncionesUDT.CreateUDF("Z_MIN_TXTPAGOS", "U_FlujoActivo", "Flujo Aprobacion Activo", SAPbobsCOM.BoFieldTypes.db_Alpha, 10, "");
            }
            catch (Exception) { }
        }
    }
}
