using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace TransferenciasBancarias
{
    [FormAttribute("50104", "Capa Presentacion/System Form/SystemForm1.b1f")]
    class SystemForm1 : SystemFormBase
    {
        private static SAPbouiCOM.Form oForm = null;

        public SystemForm1()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.CloseAfter += new CloseAfterHandler(this.Form_CloseAfter);
        }

        private void Form_CloseAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.UserDataSource oUDS = oForm.DataSources.UserDataSources.Item("UD_R");
                SAPbouiCOM.UserDataSource oUDSR = oForm.DataSources.UserDataSources.Item("UD_Z");
                if (oUDS.ValueEx.Trim().Length > 0 && oUDSR.ValueEx.Trim() == "Y")
                {

                    SAPbouiCOM.Form oFormP = Application.SBO_Application.Forms.Item(oUDS.ValueEx.Trim());
                    ((SAPbouiCOM.Button)oFormP.Items.Item("Item_68").Specific).Item.Click();
                }
            }
            catch (Exception) { }

        }

        private void OnCustomInitialize()
        {
            try
            {
                oForm = Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
                oForm.DataSources.UserDataSources.Add("UD_R", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 100);
                oForm.DataSources.UserDataSources.Add("UD_Z", SAPbouiCOM.BoDataType.dt_SHORT_TEXT, 10);
                oForm.DataSources.UserDataSources.Item("UD_Z").ValueEx = "N";
            }
            catch (Exception){}
            
        }

        private SAPbouiCOM.Button Button0;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Funciones.FormAnterior.FormIDAnterior = this.UIAPIRawForm.UniqueID;
            }
            catch (Exception) { }
        }

    }
}
