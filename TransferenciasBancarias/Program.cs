using System;
using System.Collections.Generic;
using SAPbouiCOM.Framework;
using System.Globalization;

namespace TransferenciasBancarias
{
    class Program
    {
        public static NumberFormatInfo oNumberFormatInfo = new NumberFormatInfo();
        public static SAPbouiCOM.Application SBO_Application = null;
        public static SAPbouiCOM.Form oForm = null;
        public static SAPbobsCOM.Company oCompany = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                Application oApp = null;
                if (args.Length < 1)
                {
                    oApp = new Application();
                }
                else
                {
                    oApp = new Application(args[0]);
                }
                Menu MyMenu = new Menu();
                MyMenu.AddMenuItems();
                oApp.RegisterMenuEventHandler(MyMenu.SBO_Application_MenuEvent);
                Application.SBO_Application.AppEvent += new SAPbouiCOM._IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent);
                Application.SBO_Application.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent);
                Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
                Application.SBO_Application.RightClickEvent += new SAPbouiCOM._IApplicationEvents_RightClickEventEventHandler(SBO_Application_RightClickEvent);

                Capa_Datos.Conexion.Conectar_Aplicacion();
                oCompany = Capa_Datos.Conexion.oCompany;

                Funciones.sCodUsuActual = Capa_Datos.Conexion.sCodUsuActual;
                Funciones.sAliasUsuActual = Capa_Datos.Conexion.sAliasUsuActual;
                Funciones.sNomUsuActual = Capa_Datos.Conexion.sNomUsuActual;
                Funciones.sCurrentCompanyDB = Capa_Datos.Conexion.sCurrentCompanyDB;

                oApp.Run();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        static void SBO_Application_AppEvent(SAPbouiCOM.BoAppEventTypes EventType)
        {
            switch (EventType)
            {
                case SAPbouiCOM.BoAppEventTypes.aet_ShutDown:
                    //Exit Add-On
                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.ExitThread();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_CompanyChanged:
                    System.Windows.Forms.Application.Exit();
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_FontChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_LanguageChanged:
                    break;
                case SAPbouiCOM.BoAppEventTypes.aet_ServerTerminition:
                    System.Windows.Forms.Application.Exit();
                    System.Windows.Forms.Application.ExitThread();
                    break;
                default:
                    break;
            }
        }

        static void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                oForm = Application.SBO_Application.Forms.ActiveForm;
                switch (oForm.TypeEx)
                {
                    case "TransferenciasBancarias.Capa_Presentacion.PagosTransf":
                        TransferenciasBancarias.Capa_Presentacion.PagosTransf.Transferencia_MenuEvent(ref pVal, out BubbleEvent);
                        break;
                    default:
                        Application.SBO_Application.Menus.RemoveEx("Anular Archivo TXT");
                        break;
                }
            }
            catch (Exception){}
        }

        static void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if ((pVal.FormTypeEx != null) 
                    && (pVal.FormTypeEx == "TransferenciasBancarias.Capa_Presentacion.PagosTransf"))
                {
                    TransferenciasBancarias.Capa_Presentacion.PagosTransf.Transferencias_ItemEvent(FormUID, ref pVal, out BubbleEvent);
                }
            }
            catch (Exception){}
        }

        static void SBO_Application_RightClickEvent(ref SAPbouiCOM.ContextMenuInfo eventInfo, out bool BubbleEvent)
        {

            BubbleEvent = true;
            try
            {
                oForm = Application.SBO_Application.Forms.ActiveForm;

                switch (oForm.TypeEx)
                {
                    case "TransferenciasBancarias.Capa_Presentacion.PagosTransf":
                        TransferenciasBancarias.Capa_Presentacion.PagosTransf.Transferencia_RightClickEvent(ref eventInfo, out BubbleEvent);
                        break;
                }
            }
            catch (Exception){}

        }
    }
}
