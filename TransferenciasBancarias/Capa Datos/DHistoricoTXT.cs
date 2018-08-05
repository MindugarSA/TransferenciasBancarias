using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    class DHistoricoTXT
    {
 
	    private string _U_Nombre ;
	    private string _U_PathBanco ;
	    private string _U_PathRespaldo ;
	    private string _U_NumPagos ;
	    private double _U_MontoTotal ;
	    private string _U_Usuario ;
	    private DateTime _U_Fecha ;
	    private string _U_Estado ;
	    private string _U_UsuEstado;
	    private DateTime _U_FechaEstado ;


        public String U_Nombre {
        get {
        return _U_Nombre;
        }
        set {
        _U_Nombre = value;
        }
        }

        public String U_PathBanco {
        get {
        return _U_PathBanco;
        }
        set {
        _U_PathBanco = value;
        }
        }

        public String U_PathRespaldo {
        get {
        return _U_PathRespaldo;
        }
        set {
        _U_PathRespaldo = value;
        }
        }

        public String U_NumPagos {
        get {
        return _U_NumPagos;
        }
        set {
        _U_NumPagos = value;
        }
        }

        public Double U_MontoTotal {
        get {
        return _U_MontoTotal;
        }
        set {
        _U_MontoTotal = value;
        }
        }

        public String U_Usuario {
        get {
        return _U_Usuario;
        }
        set {
        _U_Usuario = value;
        }
        }

        public DateTime U_Fecha
        {
        get {
        return _U_Fecha;
        }
        set {
        _U_Fecha = value;
        }
        }

        public String U_Estado {
        get {
        return _U_Estado;
        }
        set {
        _U_Estado = value;
        }
        }

        public String U_UsuEstado {
        get {
        return _U_UsuEstado;
        }
        set {
        _U_UsuEstado = value;
        }
        }

        public DateTime U_FechaEstado {
        get {
        return _U_FechaEstado;
        }
        set {
        _U_FechaEstado = value;
        }
        }

        //Constructor Vacio
        public DHistoricoTXT()
        {
        }

        //Constructor con Paramentros.
        public DHistoricoTXT(string U_Nombre 
                             ,string U_PathBanco 
                             ,string U_PathRespaldo 
                             ,string U_NumPagos 
                             ,double U_MontoTotal 
                             ,string U_Usuario 
                             ,DateTime U_Fecha 
                             ,string U_Estado 
                             ,string U_UsuEstado
                             ,DateTime U_FechaEstado)
        {
            this.U_Nombre       = U_Nombre;
            this.U_PathBanco    = U_PathBanco;
            this.U_PathRespaldo = U_PathRespaldo;
            this.U_NumPagos     = U_NumPagos;
            this.U_MontoTotal   = U_MontoTotal;
            this.U_Usuario      = U_Usuario;
            this.U_Fecha        = U_Fecha;
            this.U_Estado       = U_Estado;
            this.U_UsuEstado    = U_UsuEstado;
            this.U_FechaEstado =  U_FechaEstado;          
        }   
            
        public SAPbouiCOM.DataTable ListarHistoricoTXT(DHistoricoTXT HistoricoTXT, SAPbouiCOM.DataTable DT_Resultado)
        {

            try
            {
                string sp = @"Min_Bancos_Consultar_Historico_ArchivosTXT 
                                @FechaDesde = N'" + HistoricoTXT.U_Fecha.ToString("MM/dd/yyyy") + @"',
		                        @FechaHasta = N'" + HistoricoTXT.U_FechaEstado.ToString("MM/dd/yyyy") + "'";
                DT_Resultado.ExecuteQuery(sp);
            }
            catch
            {
                DT_Resultado = null;
            }

            return DT_Resultado;
        }

        public string InsertarHistoricoTXT(DHistoricoTXT HistoricoTXT, List<Object> DetallesPago)
        {

            string rpta = "N";

            try
            {
                rpta = FuncionesUDO.InsertRecord("Z_MIN_TXTHIST", HistoricoTXT, "Z_MIN_HISTPAG", DetallesPago);
            }
            catch (Exception) { }

            return rpta;
        }

        public string ActualizarHistoricoTXT(DHistoricoTXT HistoricoTXT, string CodigoArchivo)
        {

            string rpta = "N";

            try
            {
                rpta = FuncionesUDO.UpdateRecordHead("Z_MIN_TXTHIST", HistoricoTXT, CodigoArchivo);
            }
            catch (Exception) { }

            return rpta;
        }
    }
}
