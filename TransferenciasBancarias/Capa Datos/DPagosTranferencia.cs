using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    class DPagosTranferencia
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
        public DPagosTranferencia()
        {
        }

        //Constructor con Paramentros.
        public DPagosTranferencia(DateTime FechaIni, DateTime FechaFin)
        {
            this.FechaIni = FechaIni;
            this.FechaFin = FechaFin;
        }

        public SAPbouiCOM.DataTable Listar(DPagosTranferencia Pagos_Transferencia, SAPbouiCOM.DataTable DT_Resultado)
        {

            try
            {
                string sp = @"Min_Bancos_Consultar_Pagos_Depositos_Para_TXT
                                @FechaDesde = N'" + Pagos_Transferencia.FechaIni.ToString("MM/dd/yyyy") + @"',
		                        @FechaHasta = N'" + Pagos_Transferencia.FechaFin.ToString("MM/dd/yyyy") + "'";
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
