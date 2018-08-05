using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SAPbouiCOM.Framework;
using SAPbobsCOM;

namespace TransferenciasBancarias.Capa_Datos
{
    class DParametrosTXT
    {

        private string _U_TipoRegistro;
        private string _U_Multifecha;
        private string _U_Modalidad;
        private string _U_Convenio;
        private string _U_TipoPago;
        private string _U_CodigoPlantilla;
        private string _U_RUTEmpresa;
        private string _U_RUTFilial;
        private string _U_CorreoEmp;
        private string _U_PlantillaRendici;
        private string _U_DirectorioBanco;
        private string _U_DirectorioRespaldo;


        public string U_TipoRegistro
        {
            get { return _U_TipoRegistro; }
            set { _U_TipoRegistro = value; }
        }
        public string U_Multifecha
        {
            get { return _U_Multifecha; }
            set { _U_Multifecha = value; }
        }
        public string U_Modalidad
        {
            get { return _U_Modalidad; }
            set { _U_Modalidad = value; }
        }
        public string U_Convenio
        {
            get { return _U_Convenio; }
            set { _U_Convenio = value; }
        }
        public string U_TipoPago
        {
            get { return _U_TipoPago; }
            set { _U_TipoPago = value; }
        }
        public string U_CodigoPlantilla
        {
            get { return _U_CodigoPlantilla; }
            set { _U_CodigoPlantilla = value; }
        }
        public string U_RUTEmpresa
        {
            get { return _U_RUTEmpresa; }
            set { _U_RUTEmpresa = value; }
        }
        public string U_RUTFilial
        {
            get { return _U_RUTFilial; }
            set { _U_RUTFilial = value; }
        }
        public string U_CorreoEmp
        {
            get { return _U_CorreoEmp; }
            set { _U_CorreoEmp = value; }
        }
        public string U_PlantillaRendici
        {
            get { return _U_PlantillaRendici; }
            set { _U_PlantillaRendici = value; }
        }
        public string U_DirectorioBanco
        {
            get { return _U_DirectorioBanco; }
            set { _U_DirectorioBanco = value; }
        }
        public string U_DirectorioRespaldo
        {
            get { return _U_DirectorioRespaldo; }
            set { _U_DirectorioRespaldo = value; }
        }

        //Constructor Vacio
        public DParametrosTXT()
        {
        }

        public DParametrosTXT(string U_TipoRegistro
                              ,string U_Multifecha
                              ,string U_Modalidad
                              ,string U_Convenio
                              ,string U_TipoPago
                              ,string U_CodigoPlantilla
                              ,string U_RUTEmpresa
                              ,string U_RUTFilial
                              ,string U_CorreoEmp
                              ,string U_PlantillaRendici
                              ,string U_DirectorioBanco
                              ,string U_DirectorioRespaldo)
        {
            this.U_TipoRegistro = U_TipoRegistro;
            this.U_Multifecha= U_Multifecha;
            this.U_Modalidad= U_Modalidad;
            this.U_Convenio= U_Convenio;
            this.U_TipoPago= U_TipoPago;
            this.U_CodigoPlantilla= U_CodigoPlantilla;
            this.U_RUTEmpresa= U_RUTEmpresa;
            this.U_RUTFilial= U_RUTFilial;
            this.U_CorreoEmp= U_CorreoEmp;
            this.U_PlantillaRendici= U_PlantillaRendici;
            this.U_DirectorioBanco = U_DirectorioBanco;
            this.U_DirectorioRespaldo = U_DirectorioRespaldo;
        }   

        public SAPbouiCOM.DataTable ObtenerParametrosTXT(SAPbouiCOM.DataTable DT_PARAM)
        {
            SAPbobsCOM.GeneralService oGeneralService;
            SAPbobsCOM.GeneralData oGeneralData = null;
            SAPbobsCOM.GeneralDataParams oGeneralParams;
            SAPbobsCOM.CompanyService oCmpSrv;
            SAPbobsCOM.Company oCompany = Conexion.oCompany;

            try
            {
                //get company service
                if (!oCompany.Connected)
                    Funciones.Conectar_Aplicacion();

                oCmpSrv = oCompany.GetCompanyService();

                //Get GeneralService - Main UDO - Retrieve the relevant service
                oGeneralService = oCmpSrv.GetGeneralService("Z_MIN_TXTPAGOS");

                //GetByKey
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);

                oGeneralParams.SetProperty("Code", "1");
                oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                DT_PARAM.Clear();
                DT_PARAM.Columns.Add("Info", SAPbouiCOM.BoFieldsType.ft_Text);

                DT_PARAM.Rows.Add(12);
                DT_PARAM.SetValue("Info", 0, oGeneralData.GetProperty("U_TipoRegistro"));
                DT_PARAM.SetValue("Info", 1, oGeneralData.GetProperty("U_Multifecha"));
                DT_PARAM.SetValue("Info", 2, oGeneralData.GetProperty("U_Modalidad"));
                DT_PARAM.SetValue("Info", 3, oGeneralData.GetProperty("U_Convenio"));
                DT_PARAM.SetValue("Info", 4, oGeneralData.GetProperty("U_TipoPago"));
                DT_PARAM.SetValue("Info", 5, oGeneralData.GetProperty("U_CodigoPlantilla"));
                DT_PARAM.SetValue("Info", 6, oGeneralData.GetProperty("U_RUTEmpresa"));
                DT_PARAM.SetValue("Info", 7, oGeneralData.GetProperty("U_RUTFilial"));
                DT_PARAM.SetValue("Info", 8, oGeneralData.GetProperty("U_CorreoEmp"));
                DT_PARAM.SetValue("Info", 9, oGeneralData.GetProperty("U_PlantillaRendici"));
                DT_PARAM.SetValue("Info", 10, oGeneralData.GetProperty("U_DirectorioBanco"));
                DT_PARAM.SetValue("Info", 11, oGeneralData.GetProperty("U_DirectorioRespaldo"));


            }
            catch (Exception){}

            return DT_PARAM;
        }

        public string ActualizarParametrosTXT(DParametrosTXT Parametros)
        {
            SAPbobsCOM.GeneralService oGeneralService;
            SAPbobsCOM.GeneralData oGeneralData;
            SAPbobsCOM.GeneralDataParams oGeneralParams;
            SAPbobsCOM.CompanyService oCmpSrv;
            SAPbobsCOM.Company oCompany = Conexion.oCompany;
            string rpta = "N";

            try
            {
                //get company service
                if (!oCompany.Connected)
                    Funciones.Conectar_Aplicacion();

                oCmpSrv = oCompany.GetCompanyService();

                //Get GeneralService - Main UDO - Retrieve the relevant service
                oGeneralService = oCmpSrv.GetGeneralService("Z_MIN_TXTPAGOS");

                //GetByKey
                oGeneralParams = (SAPbobsCOM.GeneralDataParams)oGeneralService.GetDataInterface(SAPbobsCOM.GeneralServiceDataInterfaces.gsGeneralDataParams);

                oGeneralParams.SetProperty("Code", "1");
                oGeneralData = oGeneralService.GetByParams(oGeneralParams);

                //Header Data
                oGeneralData.SetProperty("U_TipoRegistro",    Parametros.U_TipoRegistro.Trim());
                oGeneralData.SetProperty("U_Multifecha",      Parametros.U_Multifecha.Trim());
                oGeneralData.SetProperty("U_Modalidad",       Parametros.U_Modalidad.Trim());
                oGeneralData.SetProperty("U_Convenio",        Parametros.U_Convenio.Trim());
                oGeneralData.SetProperty("U_TipoPago",        Parametros.U_TipoPago.Trim());
                oGeneralData.SetProperty("U_CodigoPlantilla", Parametros.U_CodigoPlantilla.Trim());
                oGeneralData.SetProperty("U_RUTEmpresa",      Parametros.U_RUTEmpresa.Trim());
                oGeneralData.SetProperty("U_RUTFilial",       Parametros.U_RUTFilial.Trim());
                oGeneralData.SetProperty("U_CorreoEmp",       Parametros.U_CorreoEmp.Trim());
                oGeneralData.SetProperty("U_PlantillaRendici", Parametros.U_PlantillaRendici.Trim());
                oGeneralData.SetProperty("U_DirectorioBanco", Parametros.U_DirectorioBanco.Trim());
                oGeneralData.SetProperty("U_DirectorioRespaldo", Parametros.U_DirectorioRespaldo.Trim());

                oGeneralService.Update(oGeneralData);

                rpta = "S";

            }
            catch (Exception){}
            return rpta;
        }
    }
}
