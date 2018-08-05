using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace TransferenciasBancarias
{
    [FormAttribute("50105", "Capa Presentacion/System Form/SystemForm2.b1f")]
    class SystemForm2 : SystemFormBase
    {

        public SystemForm2()
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
        }

        private SAPbouiCOM.Button Button0;

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (Button0.Caption == "Actualizar")
                {
                    SAPbouiCOM.Form oFormP = Application.SBO_Application.Forms.Item(Funciones.FormAnterior.FormIDAnterior);
                    oFormP.DataSources.UserDataSources.Item("UD_Z").ValueEx = "Y";
                }
            }
            catch (Exception){}
           
        }

        private void OnCustomInitialize()
        {
        }
    }
}
