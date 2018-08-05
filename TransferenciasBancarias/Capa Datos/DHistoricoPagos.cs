using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    class DHistoricoPagos
    {

        private String _U_PagoEntry;
        private String _U_PagoNum;
	    private DateTime _U_TaxDate ;
        private String _U_CardCode;
        private String _U_CardName;
        private String _U_CtaContable;
        private String _U_CodBanco;
	    private DateTime _U_DateTransf ;
	    private Double _U_MontoTransf ;
        private Double _U_MontoPago;
        private String _U_BancoProv;
        private String _U_CtaBanProv;
        private String _U_NombreTXT;

        public String U_PagoEntry {
        get {
        return _U_PagoEntry;
        }
        set {
        _U_PagoEntry = value;
        }
        }

        public String U_PagoNum {
        get {
        return _U_PagoNum;
        }
        set {
        _U_PagoNum = value;
        }
        }

        public DateTime U_TaxDate {
        get {
        return _U_TaxDate;
        }
        set {
        _U_TaxDate = value;
        }
        }

        public String U_CardCode {
        get {
        return _U_CardCode;
        }
        set {
        _U_CardCode = value;
        }
        }

        public String U_CardName {
        get {
        return _U_CardName;
        }
        set {
        _U_CardName = value;
        }
        }

        public String U_CtaContable {
        get {
        return _U_CtaContable;
        }
        set {
        _U_CtaContable = value;
        }
        }

        public String U_CodBanco {
        get {
        return _U_CodBanco;
        }
        set {
        _U_CodBanco = value;
        }
        }

        public DateTime U_DateTransf {
        get {
        return _U_DateTransf;
        }
        set {
        _U_DateTransf = value;
        }
        }

        public Double U_MontoTransf {
        get {
        return _U_MontoTransf;
        }
        set {
        _U_MontoTransf = value;
        }
        }

        public Double U_MontoPago {
        get {
        return _U_MontoPago;
        }
        set {
        _U_MontoPago = value;
        }
        }

        public String U_BancoProv {
        get {
        return _U_BancoProv;
        }
        set {
        _U_BancoProv = value;
        }
        }

        public String U_CtaBanProv {
        get {
        return _U_CtaBanProv;
        }
        set {
        _U_CtaBanProv = value;
        }
        }

        public String U_NombreTXT {
        get {
        return _U_NombreTXT;
        }
        set {
        _U_NombreTXT = value;
        }
        }

        //Constructores
        public DHistoricoPagos()
        {
        }

        public DHistoricoPagos(string U_PagoEntry, string U_PagoNum, DateTime U_TaxDate, string U_CardCode, string U_CardName, string U_CtaContable, string U_CodBanco, DateTime U_DateTransf, double U_MontoTransf, double U_MontoPago, string U_BancoProv, string U_CtaBanProv, string U_NombreTXT)
        {
            this.U_PagoEntry = U_PagoEntry;
            this.U_PagoNum = U_PagoNum;
            this.U_TaxDate = U_TaxDate;
            this.U_CardCode = U_CardCode;
            this.U_CardName = U_CardName;
            this.U_CtaContable = U_CtaContable;
            this.U_CodBanco = U_CodBanco;
            this.U_DateTransf = U_DateTransf;
            this.U_MontoTransf = U_MontoTransf;
            this.U_MontoPago = U_MontoPago;
            this.U_BancoProv = U_BancoProv;
            this.U_CtaBanProv = U_CtaBanProv;
            this.U_NombreTXT = U_NombreTXT;
        }

        public SAPbouiCOM.DataTable ListarHistoricoPagosTXT(int CodigoHistorico, SAPbouiCOM.DataTable DT_Resultado)
        {

            try
            {
                string sp = @"[Min_Bancos_Consultar_Historico_PagosTXT] 
                                @Codigo = " + CodigoHistorico.ToString() + "";
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
