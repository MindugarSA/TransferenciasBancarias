using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;


namespace TransferenciasBancarias.Capa_Negocios
{
    class NArchivoTransferencia
    {

        public static string Nombre()
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.Nombre;
        }

        public static string Ruta()
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.Ruta;
        }

        public static SAPbouiCOM.DataTable GenerarEncabezado(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_HEAD)
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.GenerarEncabezado(DT_SQL, DT_HEAD);
        }

        public static SAPbouiCOM.DataTable GenerarEncabezadoFormato610(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_HEAD)
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.GenerarEncabezadoFormato610(DT_SQL, DT_HEAD);
        }
        public static SAPbouiCOM.DataTable GenerarRegistros(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_DATOS, SAPbouiCOM.DataTable DT_ROWS)
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.GenerarRegistros(DT_SQL, DT_DATOS , DT_ROWS);
        }

        public static SAPbouiCOM.DataTable GenerarArchivoDT(SAPbouiCOM.DataTable DT_HEAD, SAPbouiCOM.DataTable DT_ROWS, SAPbouiCOM.DataTable DT_DATOS)
        {
            DArchivoTransferencia Obj = new DArchivoTransferencia();
            return Obj.GenerarArchivoDT(DT_HEAD, DT_ROWS, DT_DATOS);
        }


    }
}
