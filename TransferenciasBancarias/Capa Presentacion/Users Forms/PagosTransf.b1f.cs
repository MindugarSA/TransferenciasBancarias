using System;
using System.Collections.Generic;
using System.Xml;
using SAPbouiCOM.Framework;

using TransferenciasBancarias.Capa_Negocios;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace TransferenciasBancarias.Capa_Presentacion
{
    [FormAttribute("TransferenciasBancarias.Capa_Presentacion.PagosTransf", "Capa Presentacion/Users Forms/PagosTransf.b1f")]
    class PagosTransf : UserFormBase
    {
        private static SAPbobsCOM.Company oCompany = Funciones.oCompany;
        private static SAPbouiCOM.Form oForm = null;
        private static SAPbouiCOM.Grid oGrid = null;
        //private static SAPbouiCOM.DataTable oDTTable = null;
        //private static SAPbouiCOM.UserDataSource oUDS = null;

        private static int rSelecc = 0;
        private static int NumDocsPagos = 0;
        private static decimal TotalSelecc = 0;

        public PagosTransf()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_1").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_2").Specific));
            this.Folder2 = ((SAPbouiCOM.Folder)(this.GetItem("Item_3").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_4").Specific));
            this.Grid0.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid0_ClickAfter);
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.Grid1 = ((SAPbouiCOM.Grid)(this.GetItem("Item_6").Specific));
            this.Grid1.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid1_ClickAfter);
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.Grid2 = ((SAPbouiCOM.Grid)(this.GetItem("Item_8").Specific));
            this.Grid2.DoubleClickBefore += new SAPbouiCOM._IGridEvents_DoubleClickBeforeEventHandler(this.Grid2_DoubleClickBefore);
            this.Grid2.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid2_ClickAfter);
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_10").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_11").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_12").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_13").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.DT_SQL = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_SQL")));
            this.DT_PEND = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_PEND")));
            this.DT_AUTO = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_AUTO")));
            this.DT_TRAN = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TRAN")));
            this.DT_HEAD = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_HEAD")));
            this.DT_ROWS = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_ROWS")));
            this.DT_TXT = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TXT")));
            this.DT_TIP1 = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TIP1")));
            this.DT_TIP2 = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TIP2")));
            this.DT_TIP3 = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TIP3")));
            this.DT_TIP4 = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TIP4")));
            this.DT_TOT = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_TOT")));
            this.DT_PARAM = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_PARAM")));
            this.DT_HIST = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_HIST")));
            this.DT_PAGH = ((SAPbouiCOM.DataTable)(this.UIAPIRawForm.DataSources.DataTables.Item("DT_PAGH")));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_15").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_16").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_17").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_18").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_19").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_20").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_22").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.Button3 = ((SAPbouiCOM.Button)(this.GetItem("Item_25").Specific));
            this.Button3.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button3_ClickAfter);
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.Button4 = ((SAPbouiCOM.Button)(this.GetItem("Item_30").Specific));
            this.Button4.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button4_ClickAfter);
            this.Folder3 = ((SAPbouiCOM.Folder)(this.GetItem("Item_31").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_32").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_33").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_34").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_35").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("Item_36").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_37").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("Item_38").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_39").Specific));
            this.EditText10 = ((SAPbouiCOM.EditText)(this.GetItem("Item_40").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_41").Specific));
            this.EditText11 = ((SAPbouiCOM.EditText)(this.GetItem("Item_42").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_43").Specific));
            this.EditText12 = ((SAPbouiCOM.EditText)(this.GetItem("Item_44").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_45").Specific));
            this.EditText13 = ((SAPbouiCOM.EditText)(this.GetItem("Item_46").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_47").Specific));
            this.EditText14 = ((SAPbouiCOM.EditText)(this.GetItem("Item_48").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_49").Specific));
            this.EditText15 = ((SAPbouiCOM.EditText)(this.GetItem("Item_50").Specific));
            this.StaticText22 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_51").Specific));
            this.Folder4 = ((SAPbouiCOM.Folder)(this.GetItem("Item_53").Specific));
            this.Button5 = ((SAPbouiCOM.Button)(this.GetItem("Item_54").Specific));
            this.Button5.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button5_ClickAfter);
            this.StaticText23 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_55").Specific));
            this.EditText16 = ((SAPbouiCOM.EditText)(this.GetItem("Item_56").Specific));
            this.StaticText24 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_57").Specific));
            this.StaticText25 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_59").Specific));
            this.EditText18 = ((SAPbouiCOM.EditText)(this.GetItem("Item_60").Specific));
            this.StaticText26 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_61").Specific));
            this.Folder5 = ((SAPbouiCOM.Folder)(this.GetItem("Item_62").Specific));
            this.Grid3 = ((SAPbouiCOM.Grid)(this.GetItem("Item_63").Specific));
            this.Grid3.DoubleClickAfter += new SAPbouiCOM._IGridEvents_DoubleClickAfterEventHandler(this.Grid3_DoubleClickAfter);
            this.Grid3.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid3_ClickAfter);
            this.StaticText27 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_64").Specific));
            this.Button7 = ((SAPbouiCOM.Button)(this.GetItem("Item_68").Specific));
            this.Button7.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button7_ClickAfter);
            this.EditText19 = ((SAPbouiCOM.EditText)(this.GetItem("Item_69").Specific));
            this.EditText20 = ((SAPbouiCOM.EditText)(this.GetItem("Item_70").Specific));
            this.Button8 = ((SAPbouiCOM.Button)(this.GetItem("Item_71").Specific));
            this.StaticText29 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_72").Specific));
            this.StaticText30 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_73").Specific));
            this.Grid4 = ((SAPbouiCOM.Grid)(this.GetItem("Item_74").Specific));
            this.Grid4.ClickAfter += new SAPbouiCOM._IGridEvents_ClickAfterEventHandler(this.Grid4_ClickAfter);
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_58").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.ResizeAfter += new SAPbouiCOM.Framework.FormBase.ResizeAfterHandler(this.Form_ResizeAfter);
            this.CloseBefore += new SAPbouiCOM.Framework.FormBase.CloseBeforeHandler(this.Form_CloseBefore);

        }


        private void OnCustomInitialize()
        {
            oForm = Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);

            Cargar_Grids();

            Folder0.Item.Click();
        }

        public static void Transferencia_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (pVal.BeforeAction == true)
            {
                switch (pVal.MenuUID)
                {
                    case "Anular Archivo TXT": // Menu Anular Archivo TXT EN GRID HISTORICO ARCHIVOS
                        try
                        {
                            BubbleEvent = false;
                            if(AnularArchivoTXT() == "S")
                            {
                                ((SAPbouiCOM.Button)oForm.Items.Item("Item_68").Specific).Item.Click();
                                Application.SBO_Application.StatusBar.SetText("Archivo TXT Anulado Exitosamente", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                            }
                            else
                                Application.SBO_Application.StatusBar.SetText("Error al Anular el Archivo TXT", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);

                                                  
                        }
                        catch (Exception) { }
                        break;
                }
            }
        }

        public static void Transferencia_RightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if (eventInfo.ItemUID == "Item_63")
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_63").Specific;
                oGrid.Rows.SelectedRows.Add(eventInfo.Row);
            }

            if (eventInfo.ItemUID == "Item_63") //GRID HISTORICO ARCHIVOS
            {
                try
                {
                    SAPbouiCOM.DataTable DT_HIST = oForm.DataSources.DataTables.Item("DT_HIST");
                    oGrid = (SAPbouiCOM.Grid)oForm.Items.Item(eventInfo.ItemUID).Specific;
                    int nRow = oGrid.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);

                    if (eventInfo.BeforeAction == true && DT_HIST.GetValue("U_Estado", nRow).ToString() == "Activo")
                        Funciones.Create_ContextMenu("Anular Archivo TXT", "Anular Archivo TXT", -1);
                    else
                        Application.SBO_Application.Menus.RemoveEx("Anular Archivo TXT");
                }
                catch (Exception)
                { }

            }
        }

        public static void Transferencias_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool bBubbleEvent)
        {
            bBubbleEvent = true;
            oCompany = Funciones.oCompany;
            try
            {
                switch (pVal.BeforeAction)
                {
                    case true:  //BeforeAction == true
                        if (pVal.ItemUID == "Item_4" || pVal.ItemUID == "Item_6" || pVal.ItemUID == "Item_8")
                        {
                            switch (pVal.EventType)
                            {
                                case SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED:
                                    try
                                    {
                                        oGrid = (SAPbouiCOM.Grid)oForm.Items.Item(pVal.ItemUID).Specific;
                                        //string sCodigo = Convert.ToString(oGrid.DataTable.GetValue(pVal.ColUID, pVal.Row));

                                        switch (pVal.ColUID)
                                        {
                                            case "Facturas":
                                                AbrirConsultaFacturas(oGrid,pVal.Row);
                                                bBubbleEvent = false;
                                                break;
                                            case "Recepciones":
                                                AbrirConsultaRecepciones(oGrid, pVal.Row);
                                                bBubbleEvent = false;
                                                break;
                                            case "Ordenes":
                                                AbrirConsultaOrdenesCompra(oGrid, pVal.Row);
                                                bBubbleEvent = false;
                                                break;
                                        }
                                    }
                                    catch(Exception){ }
                                    break;
                                case SAPbouiCOM.BoEventTypes.et_CLICK:
                                    break;
                                case SAPbouiCOM.BoEventTypes.et_RIGHT_CLICK:
                                    break;
                                case SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST:
                                    break;
                            }
                        }
                        break;

                    case false: //BeforeAction == false
                        break;
                }
            }
            catch (Exception){ }
        }

        private void Form_ResizeAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {

            oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
            SAPbouiCOM.Item oItem = oForm.Items.Item("Item_0");
            oItem.Top = 25;
            oItem.Left = 16;
            oItem.Height = oForm.Height - 95;
            oItem.Width = oForm.Width - 45;

        }

        private void Form_CloseBefore(SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            rSelecc = 0;
            TotalSelecc = 0;
            NumDocsPagos = 0;
        }

        private void Grid0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Grid0.Rows.SelectedRows.Add(pVal.Row);
            }
            catch (Exception) { }
        }

        private void Grid1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Grid1.Rows.SelectedRows.Add(pVal.Row);
            }
            catch (Exception) { }
        }

        private void Grid2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {    
                Grid2.Rows.SelectedRows.Add(pVal.Row);

                if (pVal.ColUID == "Transf.")
                {
                    bool bTieneBanco = Grid2.DataTable.GetValue("Cuenta", pVal.Row).ToString().Trim().Length == 0 ? false : true;
                    decimal iMontoPago = Convert.ToInt32(Convert.ToString(Grid2.DataTable.GetValue("Monto a Transferir", pVal.Row)).Replace(".", ""));
                    int iDocumentosPago = Convert.ToInt32(Grid2.DataTable.GetValue("Num Documentos", pVal.Row));
                    if (!bTieneBanco)
                    {
                        Grid2.DataTable.SetValue("Transf.", pVal.Row, "N");
                        Application.SBO_Application.MessageBox("El Proveedor NO tiene Cuenta Bancaria Asignada");
                    }
                    else
                    {
                        if (((SAPbouiCOM.CheckBoxColumn)Grid2.Columns.Item("Transf.")).IsChecked(pVal.Row))
                        {
                            Grid2.CommonSetting.SetRowBackColor(pVal.Row + 1, Funciones.Color_RGB_SAP(141, 182, 0));
                            rSelecc += 1;
                            TotalSelecc += iMontoPago;
                            NumDocsPagos += iDocumentosPago;
                        }
                        else
                        {
                            Grid2.CommonSetting.SetRowBackColor(pVal.Row + 1, Funciones.Color_RGB_SAP(250, 255, 255));
                            rSelecc -= 1;
                            TotalSelecc -= iMontoPago;
                            NumDocsPagos -= iDocumentosPago;
                        }
                        StaticText12.Caption = "Total Seleccionados : " + rSelecc.ToString();
                        StaticText23.Caption = "Monto a Pagar Seleccionados :  " + string.Format("{0:C0}", TotalSelecc);
                    }
                }
            }
            catch (Exception) { }
        
        }

        private void Grid2_DoubleClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (pVal.ColUID == "Transf.")
                BubbleEvent = false;

        }

        private void Grid3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Grid3.Rows.SelectedRows.Add(pVal.Row);
                Cargar_Grid_Historico_Pagos(Convert.ToInt32(Grid3.DataTable.GetValue("Code", pVal.Row)));
            }
            catch (Exception) { }
        }

        private void Grid3_DoubleClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (pVal.ColUID == "Archivo")
            {
                string sRuta = Grid3.DataTable.GetValue("U_PathRespaldo", pVal.Row).ToString().Trim() + @"\" + Grid3.DataTable.GetValue("Archivo", pVal.Row).ToString().Trim();
                Funciones.Open_File(sRuta);
            }

        }

        private void Grid4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                Grid4.Rows.SelectedRows.Add(pVal.Row);
            }
            catch (Exception) { }
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                oForm.Freeze(true);
                Cargar_Grid_Pendientes();
            }
            catch (Exception) { }
            finally { oForm.Freeze(false); }
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                oForm.Freeze(true);
                Cargar_Grid_Autorizados();
            }
            catch (Exception) { }
            finally { oForm.Freeze(false); }
        }

        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                oForm.Freeze(true);
                Cargar_Grid_Por_Transferir();
            }
            catch (Exception) { }       
            finally { oForm.Freeze(false); }
        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            Abrir_y_seleccionar_Estado_de_Pagos_Pendientes_por_Autorizar();
        }

        private void Button4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                if (rSelecc > 0)
                {
                    DateTime FechaAct = DateTime.Now;
                    string Nombre = NArchivoTransferencia.Nombre();
                    string Ruta = DT_PARAM.GetValue("Info", 10).ToString().Trim();
                    string RutaR = DT_PARAM.GetValue("Info", 11).ToString().Trim();
                    
                    if (!Directory.Exists(Ruta))
                    {
                        Ruta = NArchivoTransferencia.Ruta();
                    }

                    CargarDatosdePagosParaEncabezado(DT_TOT);
                    DT_SQL.CopyFrom(DT_TOT);

                    DT_HEAD = NArchivoTransferencia.GenerarEncabezado(DT_SQL, DT_HEAD);
                    DT_TIP1 = NArchivoTransferencia.GenerarEncabezadoFormato610(DT_SQL, DT_TIP1);
                    Funciones.Unir_DataTables(DT_HEAD, DT_TIP1);
                    DT_ROWS = NArchivoTransferencia.GenerarRegistros(DT_SQL, DT_TRAN, DT_ROWS);
                    DT_TXT = NArchivoTransferencia.GenerarArchivoDT(DT_HEAD, DT_ROWS, DT_TXT);

                    Funciones.Generar_Archivo_TXT(Ruta + Nombre, DT_TXT);
                    Funciones.Copy_File_to_Directoy(Ruta + Nombre, RutaR);
                    NHistoricoTXT.InsertarHistoricoTXT(Nombre, Ruta, RutaR
                                                       , rSelecc.ToString()
                                                       , Convert.ToDouble(TotalSelecc)
                                                       , Funciones.Nombre_Usuario_Actual()
                                                       , FechaAct, "Activo", ""
                                                       , Convert.ToDateTime(null)
                                                       , DT_TRAN);

                    Application.SBO_Application.StatusBar.SetText("Se ha Generado con Exito el Archivo de Transferencia", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);

                    oForm.Freeze(true);
                    rSelecc = 0;
                    NumDocsPagos = 0;
                    TotalSelecc = 0;
                    Cargar_Grids();
                    StaticText12.Caption = "Total Seleccionados : " + rSelecc.ToString();
                    StaticText23.Caption = "Monto a Pagar Seleccionados :  " + string.Format("{0:C0}", TotalSelecc);
                }
                else
                {
                    Application.SBO_Application.StatusBar.SetText("No se ha seleccionado ningun Pago para el Archivo TXT", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                }
            }
            catch (Exception) { }
            finally {oForm.Freeze(false);}
        }

        private void Button5_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            if (Application.SBO_Application.MessageBox("¿Actualizar Datos de Parametrizacion del Archivo TXT de Transferencias?") == 1)
            {
                Actualizar_Datos_ParametrizacionTXT();
            }
        }

        private void Button7_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            try
            {
                oForm.Freeze(true);
                rSelecc = 0;
                NumDocsPagos = 0;
                TotalSelecc = 0;
                Cargar_Grids();
            }
            catch (Exception) { }
            finally { oForm.Freeze(false); }

        }


        //***********************************************************************************************************************************************
        //***************** PROCEDIMIENTOS Y FUNCIONES **************************************************************************************************
        //***********************************************************************************************************************************************
        private void Cargar_Grids()
        {
            Cargar_Grid_Pendientes();
            Cargar_Grid_Autorizados();
            Cargar_Grid_Por_Transferir();
            Cargar_Grid_Historico_Archivos();
            int Code = Grid3.Rows.SelectedRows.Count > 0 ? Convert.ToInt32(Grid3.DataTable.GetValue("Code", Grid3.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder))) : -99;
            Cargar_Grid_Historico_Pagos(Code);
            Cargar_Datos_ParametrizacionTXT();
        }

        private void Cargar_Grid_Pendientes()
        {
            try
            {
                string sIni = oForm.DataSources.UserDataSources.Item("FECINIP").ValueEx;
                string sFin = oForm.DataSources.UserDataSources.Item("FECFINP").ValueEx;

                DateTime FecIni = sIni.Trim() == "" ? new DateTime(1900, 01, 01) : Convert.ToDateTime(sIni);
                DateTime FecFin = sFin.Trim() == "" ? new DateTime(2100, 01, 01) : Convert.ToDateTime(sFin);

                Grid0.DataTable = NPagosPendientes.Listar(FecIni, FecFin, DT_PEND);

                Formatear_Grid_Pendientes();
                StaticText9.Caption = "Total Pagos : " + DT_PEND.Rows.Count.ToString();
            }
            catch (Exception){}
        }

        private static void Formatear_Grid_Pendientes()
        {
            try
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_4").Specific;

                SAPbouiCOM.EditTextColumn oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(0);
                oEditCol.LinkedObjectType = "140";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(3);
                oEditCol.LinkedObjectType = "2";
                oEditCol.Width += 13;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(5);
                oEditCol.LinkedObjectType = "1";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Facturas");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Recepciones");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Ordenes");
                oEditCol.LinkedObjectType = "63";

                List<int> ColumnasJustificadas = new List<int>(new int[] { 2, 5, 7, 8, 10, 15, 16, 17, 18, 19, 20 });
                List<int> ColumnasEnfasis = new List<int>(new int[] { 0, 3, 5, 8, 10, 15, 16, 17, 18, 19, 20 });
                List<int> ColumnasNoVisibles = new List<int>(new int[] { 11, 12, 21, 22, 24 });

                oGrid.Item.Enabled = false;

                for (int iCols = 0; iCols <= oGrid.Columns.Count - 1; iCols++)
                {
                    oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                    if (ColumnasJustificadas.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).RightJustified = true;
                    }
                    if (ColumnasEnfasis.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                    }
                    if (ColumnasNoVisibles.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).Visible = false;
                    }

                    if (iCols > 24)
                        oGrid.Columns.Item(iCols).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                }

                for (int i = 1; i < oGrid.Rows.Count; i++)
                {
                    decimal dFacturado = !string.IsNullOrEmpty(oGrid.DataTable.GetValue("Monto Facturas", i - 1).ToString())
                                         ? decimal.Parse(oGrid.DataTable.GetValue("Monto Facturas", i - 1).ToString()) : 0;
                    decimal dRecepcionado = !string.IsNullOrEmpty(oGrid.DataTable.GetValue("Monto Recepciones", i - 1).ToString())
                                            ? decimal.Parse(oGrid.DataTable.GetValue("Monto Recepciones", i - 1).ToString()) :  0;
                    decimal dOrdenado = !string.IsNullOrEmpty(oGrid.DataTable.GetValue("Monto Facturas", i - 1).ToString())
                                        ? decimal.Parse(oGrid.DataTable.GetValue("Monto Facturas", i - 1).ToString()) : 0;
                    if (dFacturado != dRecepcionado || dFacturado != dOrdenado)
                    {
                        oGrid.CommonSetting.SetCellFontColor(i, 2, Funciones.Color_RGB_SAP(255, 0, 0));
                        oGrid.CommonSetting.SetCellFontColor(i, 11, Funciones.Color_RGB_SAP(255, 0, 0));
                    }
                        //oGrid.CommonSetting.SetRowBackColor(i,Funciones.Color_RGB_SAP(250, 250, 210));
                }
                Funciones.Numero_Fila_Grid(oGrid);
            }
            catch (Exception){}
        }

        private void Cargar_Grid_Autorizados()
        {
            try
            {
                string sIni = oForm.DataSources.UserDataSources.Item("FECINIA").ValueEx;
                string sFin = oForm.DataSources.UserDataSources.Item("FECFINA").ValueEx;

                DateTime FecIni = sIni.Trim() == "" ? new DateTime(1900, 01, 01) : Convert.ToDateTime(sIni);
                DateTime FecFin = sFin.Trim() == "" ? new DateTime(2100, 01, 01) : Convert.ToDateTime(sFin);

                Grid1.DataTable = NPagosAutorizados.Listar(FecIni, FecFin, DT_AUTO);
                Formatear_Grid_Autorizados();
                StaticText10.Caption = "Total Pagos : " + DT_AUTO.Rows.Count.ToString();
            }
            catch (Exception) { }
        }

        private static void Formatear_Grid_Autorizados()
        {
            try
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_6").Specific;

                SAPbouiCOM.EditTextColumn oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(0);
                oEditCol.LinkedObjectType = "140";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(3);
                oEditCol.LinkedObjectType = "2";
                oEditCol.Width += 13;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(5);
                oEditCol.LinkedObjectType = "1";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Facturas");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Recepciones");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Ordenes");
                oEditCol.LinkedObjectType = "63";

                List<int> ColumnasJustificadas = new List<int>(new int[] { 2, 5, 7, 8, 10, 15, 16, 17, 18, 19, 20 });
                List<int> ColumnasEnfasis = new List<int>(new int[] { 0, 3, 5, 8, 10, 15, 16, 17, 18, 19, 20 });
                List<int> ColumnasNoVisibles = new List<int>(new int[] { 11, 12, 21, 22, 24 });

                oGrid.Item.Enabled = false;

                for (int iCols = 0; iCols <= oGrid.Columns.Count - 1; iCols++)
                {
                    oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                    if (ColumnasJustificadas.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).RightJustified = true;
                    }
                    if (ColumnasEnfasis.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                    }
                    if (ColumnasNoVisibles.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).Visible = false;
                    }
                    if (iCols > 24)
                        oGrid.Columns.Item(iCols).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                }
                Funciones.Numero_Fila_Grid(oGrid);
            }
            catch (Exception) { }
        }

        private void Cargar_Grid_Por_Transferir()
        {
            try
            {
                string sIni = oForm.DataSources.UserDataSources.Item("FECINIT").ValueEx;
                string sFin = oForm.DataSources.UserDataSources.Item("FECFINT").ValueEx;

                DateTime FecIni = sIni.Trim() == "" ? new DateTime(1900, 01, 01) : DateTime.ParseExact(sIni, "yyyyddMM", CultureInfo.InvariantCulture); 
                DateTime FecFin = sFin.Trim() == "" ? new DateTime(2100, 01, 01) : DateTime.ParseExact(sFin, "yyyyMMdd", CultureInfo.InvariantCulture);

                Grid2.DataTable = NPagosTranferencia.Listar(FecIni, FecFin, DT_TRAN);
                Formatear_Por_Transferir();
                StaticText11.Caption = "Total Pagos : " + DT_TRAN.Rows.Count.ToString();

            }
            catch (Exception) { }
        }

        private static void Formatear_Por_Transferir()
        {
            try
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_8").Specific;

                oGrid.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;

                SAPbouiCOM.EditTextColumn oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(1);
                oEditCol.LinkedObjectType = "46";
                oEditCol.Width += 20;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(4);
                oEditCol.LinkedObjectType = "2";
                oEditCol.Width += 13;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(6);
                oEditCol.LinkedObjectType = "1";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Facturas");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Recepciones");
                oEditCol.LinkedObjectType = "63";
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item("Ordenes");
                oEditCol.LinkedObjectType = "63";


                List<int> ColumnasJustificadas = new List<int>(new int[] { 3, 6, 8, 9, 11, 16, 17, 18, 19, 20, 21 });
                List<int> ColumnasEnfasis = new List<int>(new int[] { 1, 4, 6, 9, 11, 16, 17, 18, 19, 20, 21 });
                List<int> ColumnasNoVisibles = new List<int>(new int[] { 12, 13, 22, 23, 25, 26 });

                for (int iCols = 0; iCols <= oGrid.Columns.Count - 1; iCols++)
                {
                    oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                    oGrid.Columns.Item(iCols).Editable = iCols > 0 ? false: true;
                    if (ColumnasJustificadas.Contains(iCols))
                        oGrid.Columns.Item(iCols).RightJustified = true;
                    if (ColumnasEnfasis.Contains(iCols))
                        oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                    if (ColumnasNoVisibles.Contains(iCols))
                        oGrid.Columns.Item(iCols).Visible = false;
                    if (iCols > 32)
                        oGrid.Columns.Item(iCols).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
                }
                Funciones.Numero_Fila_Grid(oGrid);

                oGrid.Columns.Item(26).TitleObject.Caption = "Banco";

            }
            catch (Exception) { }
        }

        private void Cargar_Grid_Historico_Archivos()
        {
            try
            {
                string sIni = oForm.DataSources.UserDataSources.Item("FECINIH").ValueEx;
                string sFin = oForm.DataSources.UserDataSources.Item("FECFINH").ValueEx;

                DateTime FecIni = sIni.Trim() == "" ? new DateTime(1900, 01, 01) : DateTime.ParseExact(sIni, "yyyyddMM", CultureInfo.InvariantCulture);
                DateTime FecFin = sFin.Trim() == "" ? new DateTime(2100, 01, 01) : DateTime.ParseExact(sFin, "yyyyMMdd", CultureInfo.InvariantCulture);

                Grid3.DataTable = NHistoricoTXT.ListarHistoricoTXT(FecIni, FecFin, DT_HIST);
                Formatear_Grid_Historico();
                //StaticText11.Caption = "Total Pagos : " + DT_TRAN.Rows.Count.ToString();

            }
            catch (Exception) { }
        }

        private static void Formatear_Grid_Historico()
        {
            try
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_63").Specific;

                List<int> ColumnasJustificadas = new List<int>(new int[] { 1, 2, 3});
                List<int> ColumnasEnfasis = new List<int>(new int[] { 2, 6 });
                List<int> ColumnasNoVisibles = new List<int>(new int[] { 9,10,11,12,13,14,15,16,17,18 });

                oGrid.Item.Enabled = false;

                for (int iCols = 0; iCols <= oGrid.Columns.Count - 1; iCols++)
                {
                    oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                    if (ColumnasJustificadas.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).RightJustified = true;
                    }
                    if (ColumnasEnfasis.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                    }
                    if (ColumnasNoVisibles.Contains(iCols))
                    {
                        oGrid.Columns.Item(iCols).Visible = false;
                    }
                }

                for (int i = 0; i <= oGrid.Rows.Count - 1; i++)
                {
                    if (oGrid.DataTable.GetValue("U_Estado", i).ToString() == "Anulado")
                        oGrid.CommonSetting.SetCellFontColor(i + 1, 7, Funciones.Color_RGB_SAP(255, 0, 0));
                    else
                        oGrid.CommonSetting.SetCellFontColor(i + 1, 7, Funciones.Color_RGB_SAP(0, 100, 0));

                }

                Funciones.Numero_Fila_Grid(oGrid);
            }
            catch (Exception) { }
        }

        private void Cargar_Grid_Historico_Pagos(int CodigoArchivo)
        {
            try
            {
                oForm.Freeze(true);
                Grid4.DataTable = NHistoricoPagos.ListarPagosArchivoTXT(CodigoArchivo, DT_PAGH);

                Formatear_Grid_Historico_Pagos();
            }
            catch (Exception) { }
            finally{oForm.Freeze(false);}
        }

        private static void Formatear_Grid_Historico_Pagos()
        {
            try
            {
                oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_74").Specific;
                oGrid.Item.Visible = false;
                oGrid.Item.Enabled = false;

                SAPbouiCOM.EditTextColumn oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(0);
                oEditCol.LinkedObjectType = "46";
                oEditCol.Width += 20;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(3);
                oEditCol.LinkedObjectType = "2";
                oEditCol.Width += 13;
                oEditCol = (SAPbouiCOM.EditTextColumn)oGrid.Columns.Item(5);
                oEditCol.LinkedObjectType = "1";

                if (!oGrid.DataTable.IsEmpty)
                    oGrid.Item.Visible = true;

                if (oGrid.Item.Visible)
                {
                    List<int> ColumnasJustificadas = new List<int>(new int[] { 2, 5, 7, 8, 9 });
                    List<int> ColumnasEnfasis = new List<int>(new int[] { 0, 3, 5, 8, 9 });
                    List<int> ColumnasNoVisibles = new List<int>(new int[] { 12 });


                    for (int iCols = 0; iCols <= oGrid.Columns.Count - 1; iCols++)
                    {
                        oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 255, 255);
                        if (ColumnasJustificadas.Contains(iCols))
                        {
                            oGrid.Columns.Item(iCols).RightJustified = true;
                        }
                        if (ColumnasEnfasis.Contains(iCols))
                        {
                            oGrid.Columns.Item(iCols).BackColor = Funciones.Color_RGB_SAP(250, 250, 210);
                        }
                        if (ColumnasNoVisibles.Contains(iCols))
                        {
                            oGrid.Columns.Item(iCols).Visible = false;
                        }
                    }
                        Funciones.Numero_Fila_Grid(oGrid);
                }
            }
            catch (Exception) { }
        }

        private void Abrir_y_seleccionar_Estado_de_Pagos_Pendientes_por_Autorizar()
        {
            try
            {
                string sUsuAct = CheckBox0.Checked ? Funciones.sNomUsuActual: "";
                    
                Application.SBO_Application.ActivateMenuItem("14851");

                SAPbouiCOM.Form oFormP = Application.SBO_Application.Forms.ActiveForm;
                //oFormP.Visible = false;
                SAPbouiCOM.Matrix oMatrix = null;
                SAPbouiCOM.CheckBox oChkCol = null;

                SAPbouiCOM.UserDataSource oUDS = oFormP.DataSources.UserDataSources.Item("UD_R");
                oUDS.ValueEx = this.UIAPIRawForm.UniqueID;   //Asignamos el FormUID de Formulario al Valor del  User Data Source
                 

                //oFormP.Select();

                oFormP.Freeze(true);

                List<string> CheckBoxMarcar = new List<string>(new string[] { "32"});

                foreach (string sItem in CheckBoxMarcar)
                {
                    ((SAPbouiCOM.CheckBox)oFormP.Items.Item(sItem).Specific).Checked = true;
                }

                List<string> CheckBoxDesmarcar = new List<string>(new string[] { "33", "34", "35", "37", "38" });

                foreach (string sItem in CheckBoxDesmarcar)
                {
                    ((SAPbouiCOM.CheckBox)oFormP.Items.Item(sItem).Specific).Checked = false;
                }

                List<string> EditTextLimpiar = new List<string>(new string[] { "10", "13", "19", "16", "25", "28", "40", "39", "45", "46", "48", "47" });

                foreach (string sItem in EditTextLimpiar)
                {
                    if((sItem == "16" || sItem =="19") && sUsuAct.Trim().Length > 0)
                        ((SAPbouiCOM.EditText)oFormP.Items.Item(sItem).Specific).Value = sUsuAct;
                    else
                        ((SAPbouiCOM.EditText)oFormP.Items.Item(sItem).Specific).Value = "";
                }

                oMatrix = (SAPbouiCOM.Matrix)oFormP.Items.Item("7").Specific;
                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    oChkCol = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("2").Cells.Item(i).Specific;

                    if (oChkCol.Checked)
                        oChkCol.Checked = false;

                    //oMatrix.GetLineData(i);
                    //oMatrix.Columns.Item("2").Cells.Item(i).Click(SAPbouiCOM.BoCellClickType.ct_Regular);
                }

                oMatrix = (SAPbouiCOM.Matrix)oFormP.Items.Item("8").Specific;
                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    oChkCol = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("2").Cells.Item(i).Specific;

                    if (oChkCol.Checked)
                        oChkCol.Checked = false;
                }

                oMatrix = (SAPbouiCOM.Matrix)oFormP.Items.Item("140000052").Specific;
                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    oChkCol = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("140000003").Cells.Item(i).Specific;

                    if (oChkCol.Checked)
                        oChkCol.Checked = false;
                }

                oMatrix = (SAPbouiCOM.Matrix)oFormP.Items.Item("1470000058").Specific;
                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    oChkCol = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("1470000003").Cells.Item(i).Specific;

                    if (oChkCol.Checked)
                        oChkCol.Checked = false;
                }

                oMatrix = (SAPbouiCOM.Matrix)oFormP.Items.Item("140000055").Specific;
                for (int i = 1; i <= oMatrix.VisualRowCount; i++)
                {
                    oChkCol = (SAPbouiCOM.CheckBox)oMatrix.Columns.Item("140000003").Cells.Item(i).Specific;

                    if (!oChkCol.Checked)
                        oChkCol.Checked = true;
                }

                oFormP.Freeze(false);

                ((SAPbouiCOM.Button)oFormP.Items.Item("1").Specific).Item.Click();

            }
            catch (Exception) { }
            finally
            {
                SAPbouiCOM.Form oFormP = Application.SBO_Application.Forms.ActiveForm;
                oFormP.Freeze(false);
            }
        }

        private void CargarDatosdePagosParaEncabezado(SAPbouiCOM.DataTable DT_TOTA)
        {
            try
            {
                DT_TOTA.Clear();
                DT_TOTA.Columns.Add("Info", SAPbouiCOM.BoFieldsType.ft_AlphaNumeric);

                DT_TOTA.Rows.Add(4);
                DT_TOTA.SetValue("Info", 0, DateTime.Now.ToString("ddMMyyyy"));
                DT_TOTA.SetValue("Info", 1, rSelecc.ToString());
                DT_TOTA.SetValue("Info", 2, string.Format("{0:00}", TotalSelecc));
                DT_TOTA.SetValue("Info", 3, NumDocsPagos.ToString());
                //DT_TOTA.
                //                DT_SQL.SetValue("Info", 2, string.Format("{0:N0}", TotalSelecc)); // String.Format("{0:00}", result)
            }
            catch (Exception) { }
        }

         private void Cargar_Datos_ParametrizacionTXT()
        {
            try
            {


                DT_PARAM = NParametrosTXT.ObtenerParametrosTXT(DT_PARAM);

                EditText6.Value = DT_PARAM.GetValue("Info", 0).ToString();   //oGeneralData.GetProperty("U_TipoRegistro");
                EditText7.Value = DT_PARAM.GetValue("Info", 1).ToString();    //oGeneralData.GetProperty("U_Multifecha");
                EditText8.Value = DT_PARAM.GetValue("Info", 2).ToString();    //oGeneralData.GetProperty("U_Modalidad");
                EditText9.Value = DT_PARAM.GetValue("Info", 3).ToString();    //oGeneralData.GetProperty("U_Convenio");
                EditText10.Value = DT_PARAM.GetValue("Info", 4).ToString();   //oGeneralData.GetProperty("U_TipoPago");
                EditText11.Value = DT_PARAM.GetValue("Info", 5).ToString();   //oGeneralData.GetProperty("U_CodigoPlantilla");
                EditText12.Value = DT_PARAM.GetValue("Info", 6).ToString();   //oGeneralData.GetProperty("U_RUTEmpresa");
                EditText13.Value = DT_PARAM.GetValue("Info", 7).ToString();   //oGeneralData.GetProperty("U_RUTFilial");
                EditText14.Value = DT_PARAM.GetValue("Info", 8).ToString();   //oGeneralData.GetProperty("U_CorreoEmp");
                EditText15.Value = DT_PARAM.GetValue("Info", 9).ToString();   //oGeneralData.GetProperty("U_PlantillaRendici");
                EditText16.Value = DT_PARAM.GetValue("Info", 10).ToString();  //oGeneralData.GetProperty("U_DirectorioBanco");
                EditText18.Value = DT_PARAM.GetValue("Info", 11).ToString();  //oGeneralData.GetProperty("U_DirectorioRespaldo");

            }
            catch (Exception) {
                Application.SBO_Application.StatusBar.SetText("Error en la Carga de los Parametros", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);             
            }
           
        }

         private void Actualizar_Datos_ParametrizacionTXT()
         {
             string sDirBanco = EditText16.Value.Trim();
             string sDirServer = EditText18.Value.Trim();

             if (!Directory.Exists(sDirBanco))
             {
                 Application.SBO_Application.MessageBox("La Ruta para la Generacion del Archivo de Texto No existe, Se guardara en :" + NArchivoTransferencia.Ruta());
                 sDirBanco = NArchivoTransferencia.Ruta();
             }

             string Actulizacion = NParametrosTXT.ActualizarParametrosTXT(EditText6.Value.Trim()      //U_TipoRegistro
                                                                          , EditText7.Value.Trim()    //U_Multifecha
                                                                          , EditText8.Value.Trim()    //U_Modalidad
                                                                          , EditText9.Value.Trim()    //U_Convenio
                                                                          , EditText10.Value.Trim()   //U_TipoPago
                                                                          , EditText11.Value.Trim()   //U_CodigoPlantilla
                                                                          , EditText12.Value.Trim()   //U_RUTEmpresa
                                                                          , EditText13.Value.Trim()   //U_RUTFilial
                                                                          , EditText14.Value.Trim()   //U_CorreoEmp
                                                                          , EditText15.Value.Trim()   //U_PlantillaRendici
                                                                          , sDirBanco.Trim()          //U_DirectorioBanco
                                                                          , sDirServer.Trim());       //U_DirectorioRespaldo

             if (Actulizacion == "S")
             {
                 Application.SBO_Application.StatusBar.SetText("Actualizacion Exitosa de los Parametros", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                 DT_PARAM = NParametrosTXT.ObtenerParametrosTXT(DT_SQL);
             }
             else
                 Application.SBO_Application.StatusBar.SetText("Error en la Actualizacion de los Parametros", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);             
                
         }

         private static string AnularArchivoTXT()
         {
             string resp = "N";
             try
             {
                 SAPbouiCOM.DataTable DT_HIST = oForm.DataSources.DataTables.Item("DT_HIST");
                 oGrid = (SAPbouiCOM.Grid)oForm.Items.Item("Item_63").Specific;
                 int nRow = oGrid.Rows.SelectedRows.Item(0, SAPbouiCOM.BoOrderType.ot_RowOrder);
                 resp = NHistoricoTXT.UpdateHistoricoTXT(DT_HIST.GetValue("U_Nombre", nRow).ToString()
                                                          , DT_HIST.GetValue("U_PathBanco", nRow).ToString()
                                                          , DT_HIST.GetValue("U_PathRespaldo", nRow).ToString()
                                                          , DT_HIST.GetValue("U_NumPagos", nRow).ToString()
                                                          , Convert.ToDouble(DT_HIST.GetValue("U_MontoTotal", nRow).ToString().Replace(".", ""))
                                                          , DT_HIST.GetValue("U_Usuario", nRow).ToString()
                                                          , Convert.ToDateTime(DT_HIST.GetValue("U_Fecha", nRow))
                                                          , "Anulado"
                                                          , Funciones.Nombre_Usuario_Actual()
                                                          , DateTime.Now
                                                          , DT_HIST.GetValue("Code", nRow).ToString());
                 Funciones.Delete_File(DT_HIST.GetValue("U_PathBanco", nRow).ToString() + DT_HIST.GetValue("U_Nombre", nRow).ToString());
             }
             catch (Exception) { }
             return resp;
         }

         private static void AbrirConsultaFacturas(SAPbouiCOM.Grid oGrid, int nRow)
         {
             try
             {
                 string sDocEntry = oGrid.DataTable.GetValue("N° Interno", nRow).ToString();
                 string sPago = oGrid.DataTable.GetValue("N° Pago", nRow).ToString();
                 string sProv = oGrid.DataTable.GetValue("Proveedor", nRow).ToString();
                 string sFecha = Convert.ToDateTime(oGrid.DataTable.GetValue("Fecha Pago", nRow)).ToString("dd/MM/yyyy");

                 AbrirPantallaConsultaDocumentos("Facturas Asociadas al Pago", "FACTU", sPago, sProv, sFecha, sDocEntry);
             }
             catch (Exception) { }
         }

         private static void AbrirConsultaRecepciones(SAPbouiCOM.Grid oGrid, int nRow)
         {
             try
             {
                 string sDocEntry = oGrid.DataTable.GetValue("N° Interno", nRow).ToString();
                 string sPago = oGrid.DataTable.GetValue("N° Pago", nRow).ToString();
                 string sProv = oGrid.DataTable.GetValue("Proveedor", nRow).ToString();
                 string sFecha = Convert.ToDateTime(oGrid.DataTable.GetValue("Fecha Pago", nRow)).ToString("dd/MM/yyyy");

                 AbrirPantallaConsultaDocumentos("Recepciones Asociadas al Pago", "RECEP", sPago, sProv, sFecha, sDocEntry);
             }
             catch (Exception) { }
         }

         private static void AbrirConsultaOrdenesCompra(SAPbouiCOM.Grid oGrid, int nRow)
         {
             try
             {
                 string sDocEntry = oGrid.DataTable.GetValue("N° Interno", nRow).ToString();
                 string sPago = oGrid.DataTable.GetValue("N° Pago", nRow).ToString();
                 string sProv = oGrid.DataTable.GetValue("Proveedor", nRow).ToString();
                 string sFecha = Convert.ToDateTime(oGrid.DataTable.GetValue("Fecha Pago", nRow)).ToString("dd/MM/yyyy");

                 AbrirPantallaConsultaDocumentos("Ordenes de Compra Asociadas al Pago", "ORDEN", sPago, sProv, sFecha, sDocEntry);
             }
             catch (Exception) { }
         }

         private static void AbrirPantallaConsultaDocumentos(string Titulo, string TipoDoc, string sPago, string sProv, string sFecha, string sDocEntry)
         {

             try
             {
                 Capa_Presentacion.ConsultaDoc oConsultaDoc = new Capa_Presentacion.ConsultaDoc();

                 oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_0").ValueEx = oForm.UniqueID;

                 oConsultaDoc.UIAPIRawForm.Title = Titulo;
                 oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_ENTRY").ValueEx = sDocEntry;
                 oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_PAG").ValueEx = sPago;
                 oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_PRO").ValueEx = sProv;
                 oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_FEC").ValueEx = sFecha;
                 switch (oForm.PaneLevel)// Si el panel es 1 o 2 los pagos son tipos borrador.
                 {
                     case 3:
                         oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_DOC").ValueEx = TipoDoc + "D";
                         break;
                     default:
                         oConsultaDoc.UIAPIRawForm.DataSources.UserDataSources.Item("UD_DOC").ValueEx = TipoDoc + "B";
                         break;
                 }

                 oConsultaDoc.Show();
             }
             catch (Exception) { }
         }


        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.Folder Folder2;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.Grid Grid1;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.Grid Grid2;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.DataTable DT_SQL;
        private SAPbouiCOM.DataTable DT_PEND;
        private SAPbouiCOM.DataTable DT_AUTO;
        private SAPbouiCOM.DataTable DT_TRAN;
        private SAPbouiCOM.DataTable DT_HEAD;
        private SAPbouiCOM.DataTable DT_ROWS;
        private SAPbouiCOM.DataTable DT_TXT;
        private SAPbouiCOM.DataTable DT_TIP1;
        private SAPbouiCOM.DataTable DT_TIP2;
        private SAPbouiCOM.DataTable DT_TIP3;
        private SAPbouiCOM.DataTable DT_TIP4;
        private SAPbouiCOM.DataTable DT_TOT;
        private SAPbouiCOM.DataTable DT_HIST;
        private SAPbouiCOM.DataTable DT_PAGH;
        private SAPbouiCOM.DataTable DT_PARAM;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.Button Button3;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.Button Button4;
        private SAPbouiCOM.Folder Folder3;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.EditText EditText9;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.EditText EditText10;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText11;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.EditText EditText12;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.EditText EditText13;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.EditText EditText14;
        private SAPbouiCOM.StaticText StaticText21;
        private SAPbouiCOM.EditText EditText15;
        private SAPbouiCOM.StaticText StaticText22;
        private SAPbouiCOM.Folder Folder4;
        private SAPbouiCOM.Button Button5;
        private SAPbouiCOM.StaticText StaticText23;
        private SAPbouiCOM.EditText EditText16;
        private SAPbouiCOM.StaticText StaticText24;
        private SAPbouiCOM.StaticText StaticText25;
        private SAPbouiCOM.EditText EditText18;
        private SAPbouiCOM.StaticText StaticText26;
        private SAPbouiCOM.Folder Folder5;
        private SAPbouiCOM.Grid Grid3;
        private SAPbouiCOM.StaticText StaticText27;
        private SAPbouiCOM.Button Button7;
        private SAPbouiCOM.EditText EditText19;
        private SAPbouiCOM.EditText EditText20;
        private SAPbouiCOM.Button Button8;
        private SAPbouiCOM.StaticText StaticText29;
        private SAPbouiCOM.StaticText StaticText30;
        private SAPbouiCOM.Grid Grid4;
        private SAPbouiCOM.CheckBox CheckBox0;


    }
}