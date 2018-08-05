using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using SAPbouiCOM.Framework;
using System.Data;
using excel = Microsoft.Office.Interop.Excel;
using TransferenciasBancarias.Capa_Datos;
using System.Diagnostics;

namespace TransferenciasBancarias
{
   
    class Funciones
    {
        //public static SAPbouiCOM.Application oApplication;
        public static SAPbobsCOM.Company oCompany = Conexion.oCompany;
        //public static SAPbobsCOM.SBObob oSBObob;
        //public static SAPbobsCOM.Recordset oRsSUers;
        //public static SAPbouiCOM.ProgressBar oProgBar;

        public static string sCodUsuActual =  Conexion.sCodUsuActual ;
        public static string sAliasUsuActual = Conexion.sAliasUsuActual;
        public static string sNomUsuActual = Conexion.sNomUsuActual;
        public static string sCurrentCompanyDB = Conexion.sCurrentCompanyDB;

        public static void Conectar_Aplicacion()
        {
            Capa_Datos.Conexion.Conectar_Aplicacion();
        }

        public static string FormatMoneyToString(double _double, SAPbobsCOM.Company oCompany, SAPbobsCOM.BoMoneyPrecisionTypes _Precision)
        {
            SAPbobsCOM.SBObob businessObject = (SAPbobsCOM.SBObob)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
            SAPbobsCOM.Recordset recordset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            recordset = businessObject.Format_MoneyToString(_double, _Precision);
            return (string)recordset.Fields.Item(0).Value;
        }

        public static SAPbouiCOM.DataTable GetDataTableFromCLF(SAPbouiCOM.ItemEvent oEvent, SAPbouiCOM.Form oForm)
        {
            SAPbouiCOM.ChooseFromListEvent event2 = (SAPbouiCOM.ChooseFromListEvent)oEvent;
            string chooseFromListUID = event2.ChooseFromListUID;
            SAPbouiCOM.ChooseFromList list = oForm.ChooseFromLists.Item(chooseFromListUID);
            return event2.SelectedObjects;
        }

        public static double GetDoubleFromString(string _doublestring)
        {
            _doublestring = _doublestring.Trim().Substring(0, 1) == "." ? "0" + _doublestring : _doublestring;
            if (Program.oNumberFormatInfo.NumberDecimalSeparator == ",")
            {
                return double.Parse(_doublestring, CultureInfo.CurrentCulture);
            }
            return double.Parse(_doublestring, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo);
        }

        public static string GetStringFromDouble(double _double)
        {
            try
            {
                return _double.ToString().Replace(",", ".");
            }
            catch (Exception)
            {
                return "0.00";
            }
        }

        public static string GetStringFromDoubleDecimal(double _double, int _decimal)
        {
            string str3 = "";
            try
            {
                str3 = _double.ToString().Replace(",", ".");
                if (str3.IndexOf(".") == -1)
                {
                    return str3;
                }
                return str3.Substring(0, (str3.IndexOf(".") + _decimal) + 1);
            }
            catch (Exception)
            {
                return "0.00";
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //  DEFINE UN COLOR RGB
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static int Color_RGB_SAP(int R, int G, int B)
        {
            int DecCol = B * 65536 + G * 256 + R;
            return DecCol;
        }

        public static void Color_BackColorRow_Grid(SAPbouiCOM.Grid oGrid, int nRow, int Color)
        {
            oGrid.CommonSetting.SetRowBackColor(nRow, Color);
        }

        public static void Color_FontCell_Grid(SAPbouiCOM.Grid oGrid, int nCol, int nRow, int ColorFont, int ColorBack)
        {
            oGrid.CommonSetting.SetCellBackColor(nRow, nCol, ColorBack);
            oGrid.CommonSetting.SetCellFontColor(nRow, nCol, ColorFont);
        }

        public static bool Create_ProgressBar(ref SAPbouiCOM.ProgressBar oProgBarx, string sMessage, int iValue)
        {
            bool bSucess = false;

            //********************* PROGRESS BAR
            try
            {
                GC.Collect();
                oProgBarx = null;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgBarx);
                oProgBarx = null;
                GC.Collect();
                bSucess = true;
            }
            catch (Exception) { }

            try
            {
                oProgBarx = Application.SBO_Application.StatusBar.CreateProgressBar(sMessage, iValue, true);
                oProgBarx.Value = 0;
                oProgBarx.Value += 1;
                bSucess = true;
            }
            catch (Exception)
            { bSucess = false; }

            return bSucess;
        }

        public static bool ChangeText_ProgressBar(ref SAPbouiCOM.ProgressBar oProgBar, string sMessage)
        {
            bool bSucess = false;

            try
            {
                oProgBar.Text = sMessage;
                bSucess = true;
            }
            catch (Exception)
            { bSucess = false; }

            return bSucess;
        }

        public static bool Increment_ProgressBar(ref SAPbouiCOM.ProgressBar oProgBar, int iIncrement)
        {
            bool bSucess = false;

            try
            {
                oProgBar.Value += iIncrement;
                bSucess = true;
            }
            catch (Exception)
            { bSucess = false; }

            return bSucess;
        }

        public static bool Close_ProgressBar(ref SAPbouiCOM.ProgressBar oProgBar)
        {
            bool bSucess = false;

            try
            {
                oProgBar.Stop();
                bSucess = true;
            }
            catch (Exception)
            {
                try
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgBar);
                    oProgBar = null;
                    GC.Collect();
                    bSucess = true;
                }
                catch (Exception)
                { bSucess = false; }

            }

            return bSucess;
        }

        public static void LoadComboQuery(string _query, ref SAPbouiCOM.ComboBox oComboBox, string fieldValue, string fieldDesc, SAPbobsCOM.Company oCompany)
        {
            SAPbobsCOM.Recordset businessObject = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            businessObject.DoQuery(_query);
            SAPbouiCOM.ValidValues validValues = oComboBox.ValidValues;
            while (oComboBox.ValidValues.Count > 0)
            {
                oComboBox.ValidValues.Remove(0, SAPbouiCOM.BoSearchKey.psk_Index);
            }
            if (!string.Equals(fieldDesc, string.Empty))
            {
                while (!businessObject.EoF)
                {
                    validValues.Add((dynamic)businessObject.Fields.Item(fieldValue).Value, (dynamic)businessObject.Fields.Item(fieldDesc).Value);
                    businessObject.MoveNext();
                }
            }
            else
            {
                while (!businessObject.EoF)
                {
                    validValues.Add((dynamic)businessObject.Fields.Item(fieldValue).Value, "");
                    businessObject.MoveNext();
                }
            }
        }

        public static void Cargar_ComboBox(SAPbouiCOM.ComboBox oComboBox, SAPbouiCOM.DataTable oDataTable, string Query, int ValorValue, int ValorDescription, bool ValorVacio)
        {
            try
            {
                //oForm =   Application.SBO_Application.Forms.Item(FormId) ;
                //oComboBox = (SAPbouiCOM.ComboBox) oForm.Items.Item(ComboID).Specific;
                //oDTTable = oForm.DataSources.DataTables.Item(DataTableID) ;

                oDataTable.ExecuteQuery(Query);

                if (ValorVacio)  // Agrega primera linea de ComboBox Vacia
                {
                    oComboBox.ValidValues.Add("", "");
                }

                for (int i = 0; i <= oDataTable.Rows.Count - 1; i++)
                {
                    oComboBox.ValidValues.Add(Convert.ToString(oDataTable.GetValue(ValorValue, i)), Convert.ToString(oDataTable.GetValue(ValorDescription, i)));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static void Inicializar_ComboBox(SAPbouiCOM.ComboBox oComboBox)
        {
            int i = 0;

            while (oComboBox.ValidValues.Count > 0)
            {
                try
                {
                    oComboBox.ValidValues.Remove(i, SAPbouiCOM.BoSearchKey.psk_Index);
                }
                catch (Exception)
                {
                }
            }

        }

        public static void Numero_Fila_Grid(SAPbouiCOM.Grid oGrid)
        {
            SAPbouiCOM.RowHeaders oHeader = null;
            oHeader = oGrid.RowHeaders;
            if(!oGrid.DataTable.IsEmpty)
                for (int i = 0; i <= oGrid.Rows.Count - 1; i++)
                {
                    oHeader.SetText(i, Convert.ToString(i + 1));
                }
        }

        public static void Unir_DataTables(SAPbouiCOM.DataTable DT1, SAPbouiCOM.DataTable DT2)
        {
            try
            {
                for (int iRow = 0; iRow <= DT2.Rows.Count - 1; iRow++)
                {
                    DT1.Rows.Add();
                    int nRow = DT1.Rows.Count - 1;

                    for (int iCol = 0; iCol <= DT2.Columns.Count - 1; iCol++)
                    {
                        try
                        {
                            DT1.SetValue(iCol, nRow, DT2.GetValue(iCol, iRow));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static void LinkedObjectForm(string FormUniqueID, string ActivateMenuItem, string FindItemUID, string FindItemUIDValue)
        {

            try
            {
                SAPbouiCOM.Form oForm = null;
                SAPbouiCOM.IEditText oEditText = null;
                bool Bool = false;

                //For frm As Integer = 0 To Application.SBO_Application.Forms.Count - 1
                // Dim sCad As String = Application.SBO_Application.Forms.Item(frm).UniqueID
                // If Application.SBO_Application.Forms.Item(frm). = FormUniqueID Then
                // 'Application.SBO_Application.Forms.Item(pVal.FormUID)
                // oForm = Application.SBO_Application.Forms.Item(FormUniqueID)
                // oForm.Close()

                // Exit For

                // End If

                //Next


                if (Bool == false)
                {
                    Application.SBO_Application.ActivateMenuItem(ActivateMenuItem);

                    Application.SBO_Application.Forms.ActiveForm.Freeze(true);

                    oForm = Application.SBO_Application.Forms.ActiveForm;

                    oForm.Select();

                    oForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;

                    oForm.Items.Item(FindItemUID).Enabled = true;

                    oEditText = (SAPbouiCOM.IEditText)oForm.Items.Item(FindItemUID).Specific;
                    oEditText.Value = FindItemUIDValue.Trim();

                    oForm.Items.Item("1").Click();

                    oForm.Freeze(false);


                }


            }
            catch (Exception)
            {
                Application.SBO_Application.MessageBox(oCompany.GetLastErrorDescription());
            }
            finally
            {
            }

        }

        public static void Create_ContextMenu(String IDMenu, String Descripcion, int Position)
        {
            SAPbouiCOM.MenuItem oMenuItem;
            SAPbouiCOM.Menus oMenus;

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = (SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams));

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
            oCreationPackage.UniqueID = IDMenu;
            oCreationPackage.String = Descripcion;
            oCreationPackage.Enabled = true;
            oCreationPackage.Position = Position;

            oMenuItem = Application.SBO_Application.Menus.Item("1280"); //Data
            oMenus = oMenuItem.SubMenus;
            oMenus.AddEx(oCreationPackage);

        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //  RETORNA EL NOMBRE DEL USUARIO ACTIVO EN LA SESION ACTUAL
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static string Nombre_Usuario_Actual()
        {
            string sNombreUsu = "";
            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.GetForm("169", 0); //Toma la Descripcion del Usuario Actual del Menu Principal
            SAPbouiCOM.StaticText oStatic = (SAPbouiCOM.StaticText)oForm.Items.Item("8").Specific;
            sNombreUsu = oStatic.Caption;
            return (string)sNombreUsu;

        }

        public static long Random()
        {
            long num2 = 1L;
            long num3 = 0x3e8L;
            System.Random random = new System.Random();
            return (((num2 - num3) * random.Next()) + num3);
        }

        public static void DatatableSAP_a_Excel(SAPbouiCOM.DataTable DataTable)
        {
            try
            {
                SAPbouiCOM.ProgressBar oProgBar = null;
                Microsoft.Office.Interop.Excel.Application _excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook wBook;//= default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel._Worksheet wSheet;//= default(Microsoft.Office.Interop.Excel.Worksheet);

                wBook = (excel.Workbook)(_excel.Workbooks.Add(""));
                wSheet = (excel.Worksheet)_excel.ActiveSheet;

                int colIndex = 0;
                int rowIndex = 0;

                // Crea Progress Bar
                try
                {
                    oProgBar = Application.SBO_Application.StatusBar.CreateProgressBar("Generando Columnas Excel", DataTable.Columns.Count, true);
                }
                catch (Exception)
                {
                }

                int ind = 0;

                for (int i = 1; i <= DataTable.Columns.Count; i++)
                {
                    colIndex = colIndex + 1;
                    _excel.Cells[1, colIndex] = DataTable.Columns.Item(i - 1).Name;
                    ind += 1;
                    // Actualiza Progress Bar
                    try
                    {
                        oProgBar.Value += 1;
                    }
                    catch (Exception)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgBar);
                        oProgBar = null;
                        oProgBar = Application.SBO_Application.StatusBar.CreateProgressBar("Generando Columnas Excel", DataTable.Columns.Count, true);
                        oProgBar.Value = colIndex + 1;
                    }
                }

                // Cierra Progress Bar
                try
                {
                    oProgBar.Stop();
                }
                catch (Exception)
                {
                }


                // Crea Progress Bar
                try
                {
                    oProgBar = Application.SBO_Application.StatusBar.CreateProgressBar("Generando Filas Excel", DataTable.Rows.Count, true);
                }
                catch (Exception)
                {
                }


                for (int i = 0; i <= DataTable.Rows.Count - 1; i++)
                {
                    rowIndex = rowIndex + 1;
                    colIndex = 0;

                    for (int c = 1; c <= DataTable.Columns.Count; c++)
                    {
                        colIndex = colIndex + 1;
                        _excel.Cells[rowIndex + 1, colIndex] = DataTable.GetValue(c - 1, i);
                    }

                    // Actualiza Progress Bar
                    try
                    {
                        oProgBar.Value += 1;
                    }
                    catch (Exception)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(oProgBar);
                        oProgBar = null;
                        oProgBar = Application.SBO_Application.StatusBar.CreateProgressBar("Generando Filas Excel", DataTable.Rows.Count, true);
                        oProgBar.Value = rowIndex + 1;
                    }

                }

                // Cierra Progress Bar
                try
                {
                    oProgBar.Stop();
                }
                catch (Exception)
                {
                }

                wSheet.Columns.AutoFit();

                _excel.Visible = true;
                _excel.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;

            }
            catch (Exception)
            {
            }

            //Dim strFileName As String = "C:\datatable.xlsx"
            //If System.IO.File.Exists(strFileName) Then
            // System.IO.File.Delete(strFileName)
            //End If

            //wBook.SaveAs(strFileName)
            //wBook.Close()
            //_excel.Quit()
        }

        public static void Generar_Archivo_TXT(string sRutaArchivo, SAPbouiCOM.DataTable DT_INFO)
        {
            try
            {

                StreamWriter archivo = new StreamWriter(sRutaArchivo);

                for (int i = 0; i <= DT_INFO.Rows.Count - 1; i++)
                {
                    archivo.WriteLine(DT_INFO.GetValue(0,i).ToString().Replace("<*>",""));
                }

                archivo.Close();

            }
            catch (Exception){}
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        //  EJECUTA UN ARCHIVO CONTENIDO EN LA RUTA INGRESADA COMO PARAMETRO
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static void Open_File(String Path)
        {

            ProcessStartInfo psi = new ProcessStartInfo(); 

            psi.UseShellExecute =  true;

            psi.FileName = Path;

            try 
            {	        
                Process.Start(psi);
            }
            catch (Exception)
            {
                Application.SBO_Application.MessageBox("Ruta de archivo Invalida");
            }
        }

        public static void Copy_File_to_Directoy(string FilePath, string DestinyPath)
        {

            try 
	        {	        
		        if (Directory.Exists(System.IO.Path.GetDirectoryName(FilePath)))
                    if (Directory.Exists(System.IO.Path.GetDirectoryName(DestinyPath)))
                    {
                        string FileName = System.IO.Path.GetFileName(FilePath);
                        System.IO.File.Copy(FilePath, DestinyPath +@"\"+ FileName, true);
                    }
                    else
                        Application.SBO_Application.MessageBox("No existe el directorio " + DestinyPath.Trim());
                else
                    Application.SBO_Application.MessageBox("No existe el directorio " + FilePath.Trim());
	        }
	        catch (Exception){
                Application.SBO_Application.MessageBox("Error al Copiar el Anexo a " + DestinyPath.Trim());
            }
            
        }

        public static void Delete_File(string FilePath)
        {
            // Delete a file by using File class static method...
            if(System.IO.File.Exists(FilePath))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(FilePath);
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        public class FormAnterior
        {
            private static string _FormIDAnterior;

            public static string FormIDAnterior
            {
                get { return _FormIDAnterior; }
                set { _FormIDAnterior = value; }
            }
        }

    }
}
