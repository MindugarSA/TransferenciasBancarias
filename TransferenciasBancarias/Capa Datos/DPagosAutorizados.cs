using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    public class DPagosAutorizados
    {

        private DateTime _FechaIni;
        private DateTime _FechaFin;

        public DateTime FechaIni
        {
            get { return _FechaIni; }
            set { _FechaIni = value; }
        }

        public DateTime FechaFin
        {
            get { return _FechaFin; }
            set { _FechaFin = value; }
        }

        //Constructor Vacio
        public DPagosAutorizados()
        {
        }

        //Constructor con Paramentros.
        public DPagosAutorizados(DateTime FechaIni, DateTime FechaFin)
        {
            this.FechaIni = FechaIni;
            this.FechaFin = FechaFin;
        }

        public SAPbouiCOM.DataTable Listar(DPagosAutorizados Pagos_Autorizados, SAPbouiCOM.DataTable DT_Resultado)
        {

            try
            {
                string sp = @"EXEC [dbo].[Min_Bancos_Consultar_Pagos_Depositos_Autorizados] 
                                @FechaDesde = N'" + Pagos_Autorizados.FechaIni.ToString("MM/dd/yyyy") + @"',
		                        @FechaHasta = N'" + Pagos_Autorizados.FechaFin.ToString("MM/dd/yyyy") + "'";
                DT_Resultado.ExecuteQuery(sp);
            }
            catch
            {
                DT_Resultado = null;
            }

            return DT_Resultado;
        }   

    }
}
