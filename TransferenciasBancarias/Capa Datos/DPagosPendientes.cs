using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    public class DPagosPendientes
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
        public DPagosPendientes()
        {
        }

        //Constructor con Paramentros.
        public DPagosPendientes(DateTime FechaIni, DateTime FechaFin)
        {
            this.FechaIni = FechaIni;
            this.FechaFin = FechaFin;
        }

        public SAPbouiCOM.DataTable Listar(DPagosPendientes Pagos_Pendientes, SAPbouiCOM.DataTable DT_Resultado)
        {
            //SAPbouiCOM.DataTable DT_Resultado = new SAPbouiCOM.DataTable();

            try
            {
                string sp = @"Min_Bancos_Consultar_Pagos_Depositos_Por_Autorizar
                                @FechaDesde = N'" + Pagos_Pendientes.FechaIni.ToString("MM/dd/yyyy") + @"',
		                        @FechaHasta = N'" + Pagos_Pendientes.FechaFin.ToString("MM/dd/yyyy") + "'";
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
