using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransferenciasBancarias.Capa_Datos;


namespace TransferenciasBancarias.Capa_Negocios
{
    class NHistoricoTXT
    {
        public static SAPbouiCOM.DataTable ListarHistoricoTXT(DateTime FecIni, DateTime FecFin, SAPbouiCOM.DataTable DT_Resultado)
        {
            DHistoricoTXT Obj = new DHistoricoTXT();
            Obj.U_Fecha = FecIni;
            Obj.U_FechaEstado = FecFin;
            return Obj.ListarHistoricoTXT(Obj, DT_Resultado);
        }
                       
        public static string InsertarHistoricoTXT(string U_Nombre 
                                                 ,string U_PathBanco 
                                                 ,string U_PathRespaldo 
                                                 ,string U_NumPagos 
                                                 ,double U_MontoTotal 
                                                 ,string U_Usuario 
                                                 ,DateTime U_Fecha 
                                                 ,string U_Estado 
                                                 ,string U_UsuEstado
                                                 ,DateTime U_FechaEstado
                                                 ,SAPbouiCOM.DataTable DT_TRAN)
         {
             DHistoricoTXT Obj = new DHistoricoTXT();
             Obj.U_Nombre = U_Nombre;
             Obj.U_PathBanco = U_PathBanco;
             Obj.U_PathRespaldo = U_PathRespaldo;
             Obj.U_NumPagos = U_NumPagos;
             Obj.U_MontoTotal = U_MontoTotal;
             Obj.U_Usuario = U_Usuario;
             Obj.U_Fecha = U_Fecha;
             Obj.U_Estado = U_Estado;
             Obj.U_UsuEstado = U_UsuEstado;
             Obj.U_FechaEstado = U_FechaEstado;

             List<Object> detallesPago = new List<Object>();
             for (int i = 0; i <= DT_TRAN.Rows.Count - 1; i++)
             {
                 string val = DT_TRAN.GetValue(0, i).ToString();
                 if (DT_TRAN.GetValue(0, i).ToString() == "Y") //Registros Seleccionados
                 {
                     DHistoricoPagos dPago = new DHistoricoPagos();
                     dPago.U_PagoEntry = DT_TRAN.GetValue("N° Interno", i).ToString();
                     dPago.U_PagoNum = DT_TRAN.GetValue("N° Pago", i).ToString();
                     dPago.U_TaxDate = Convert.ToDateTime(DT_TRAN.GetValue("Fecha Pago", i));
                     dPago.U_CardCode = DT_TRAN.GetValue("Codigo", i).ToString();
                     dPago.U_CardName = DT_TRAN.GetValue("Proveedor", i).ToString();
                     dPago.U_CtaContable = DT_TRAN.GetValue("Cta Contable", i).ToString();
                     dPago.U_CodBanco = DT_TRAN.GetValue("Banco", i).ToString();
                     dPago.U_DateTransf = Convert.ToDateTime(DT_TRAN.GetValue("Fecha Transf.", i).ToString());
                     dPago.U_MontoTransf = Convert.ToDouble(DT_TRAN.GetValue("Monto a Transferir", i).ToString());
                     dPago.U_MontoPago = Convert.ToDouble(DT_TRAN.GetValue("Total Pago", i).ToString());
                     dPago.U_BancoProv = DT_TRAN.GetValue("Banco", i).ToString();
                     dPago.U_CtaBanProv = DT_TRAN.GetValue("Cuenta", i).ToString();
                     dPago.U_NombreTXT = U_Nombre;

                     detallesPago.Add(dPago);
                 }
             }

             return Obj.InsertarHistoricoTXT(Obj, detallesPago);
         }

        public static string UpdateHistoricoTXT(string U_Nombre
                                                 , string U_PathBanco
                                                 , string U_PathRespaldo
                                                 , string U_NumPagos
                                                 , double U_MontoTotal
                                                 , string U_Usuario
                                                 , DateTime U_Fecha
                                                 , string U_Estado
                                                 , string U_UsuEstado
                                                 , DateTime U_FechaEstado
                                                 , string CodigoArchivo)
        {
            DHistoricoTXT Obj = new DHistoricoTXT();
            Obj.U_Nombre = U_Nombre;
            Obj.U_PathBanco = U_PathBanco;
            Obj.U_PathRespaldo = U_PathRespaldo;
            Obj.U_NumPagos = U_NumPagos;
            Obj.U_MontoTotal = U_MontoTotal;
            Obj.U_Usuario = U_Usuario;
            Obj.U_Fecha = U_Fecha;
            Obj.U_Estado = U_Estado;
            Obj.U_UsuEstado = U_UsuEstado;
            Obj.U_FechaEstado = U_FechaEstado;

            return Obj.ActualizarHistoricoTXT(Obj, CodigoArchivo);

        }

    }
}
