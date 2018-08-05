using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using TransferenciasBancarias.Capa_Negocios;


namespace TransferenciasBancarias.Capa_Presentacion
{
    [FormAttribute("TransferenciasBancarias.Capa_Presentacion.ConsultaDoc", "Capa Presentacion/Users Forms/ConsultaDoc.b1f")]
    class ConsultaDoc : UserFormBase
    {
        private static SAPbouiCOM.Form oForm = null;
        private static SAPbouiCOM.UserDataSource oUDS = null;

        
        public ConsultaDoc()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_2").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_3").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_5").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.DT_DOC = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_DOC")));
            this.DT_SQL = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_SQL")));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_8").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new ResizeAfterHandler(this.Form_ResizeAfter);

        }

        private void OnCustomInitialize()
        {
            oForm = Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            Grid0.Item.Enabled = false;
            for (int iCols = 0; iCols <= Grid0.Columns.Count - 1; iCols++)
            {
                Grid0.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
            }
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            oForm.Close();
        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Grid0.Rows.SelectedRows.Add(pVal.Row);
            }
            catch (Exception) { }
        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.DataTable DT_DOC;
        private SAPbouiCOM.DataTable DT_SQL;


        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                SAPbouiCOM.EditTextColumn oEditCol;
                string sDocEntry = oForm.DataSources.UserDataSources.Item("UD_ENTRY").ValueEx ;
                switch (oForm.DataSources.UserDataSources.Item("UD_DOC").ValueEx)
                {
                    case  "FACTUB":
                        DT_DOC = NConsultaDocumentos.ConsultarFacturas(DT_DOC, sDocEntry , "B");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "18";
                        break;
                    case "FACTUD":
                        DT_DOC = NConsultaDocumentos.ConsultarFacturas(DT_DOC, sDocEntry, "D");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "18";
                        break;
                    case "RECEPB":
                        DT_DOC = NConsultaDocumentos.ConsultarRecepciones(DT_DOC, sDocEntry, "B");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "20";
                        break;
                    case "RECEPD":
                        DT_DOC = NConsultaDocumentos.ConsultarRecepciones(DT_DOC, sDocEntry, "D");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "20";
                        break;
                    case "ORDENB":
                        DT_DOC = NConsultaDocumentos.ConsultarOrdenes(DT_DOC, sDocEntry, "B");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "22";
                        break;
                    case "ORDEND":
                        DT_DOC = NConsultaDocumentos.ConsultarOrdenes(DT_DOC, sDocEntry, "D");
                        oEditCol = (SAPbouiCOM.EditTextColumn)Grid0.Columns.Item(0);
                        oEditCol.LinkedObjectType = "22";
                        break;
                }
                
                //Grid0.Columns.Item(2).Width = 200;

                oUDS = oForm.DataSources.UserDataSources.Item("UD_PAG");
                EditText0.Value =  oUDS.ValueEx;
                oUDS = oForm.DataSources.UserDataSources.Item("UD_PRO");
                EditText2.Value =  oUDS.ValueEx;
                oUDS = oForm.DataSources.UserDataSources.Item("UD_FEC");
                EditText1.Value =  oUDS.ValueEx;
                StaticText3.Caption = "Total Documentos : " + Grid0.DataTable.Rows.Count.ToString();

                Grid0.Columns.Item("Fecha Creacion").RightJustified = true;
                Grid0.Columns.Item("Total").RightJustified = true;

                for (int iCols = 0; iCols <= Grid0.Columns.Count - 1; iCols++)
                {
                    Grid0.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                    if (iCols % 2 == 0)
                        Grid0.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                }
            }
            catch (Exception)
            {
            }

        }

        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;

 


    }
}
