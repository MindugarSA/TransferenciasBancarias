using System;
using System.Collections.Generic;
using System.Text;
using SAPbouiCOM.Framework;

namespace TransferenciasBancarias
{
    class Menu
    {
        private static SAPbouiCOM.Application SBO_Application;

        public void AddMenuItems()
        {
            SAPbouiCOM.Menus oMenus = null;
            SAPbouiCOM.MenuItem oMenuItem = null;

            oMenus = Application.SBO_Application.Menus;
            SBO_Application = Application.SBO_Application;

            SAPbouiCOM.MenuCreationParams oCreationPackage = null;
            oCreationPackage = ((SAPbouiCOM.MenuCreationParams)(Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams)));
            oMenuItem = Application.SBO_Application.Menus.Item("43520"); // moudles'

            oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_POPUP;
            oCreationPackage.UniqueID = "TransferenciasBancarias";
            oCreationPackage.String = "Transferencias Bancarias";
            oCreationPackage.Image = @"\\fssapbo\SAPB1\Anexos\images\coins_add.png";
            oCreationPackage.Enabled = true;
            oCreationPackage.Position = -1;

            oMenus = oMenuItem.SubMenus;

            if (SBO_Application.Menus.Exists("TransferenciasBancarias") == true)
            {
                SBO_Application.Menus.RemoveEx("TransferenciasBancarias");
            }

            try
            {
                //  If the manu already exists this code will fail
                oMenus.AddEx(oCreationPackage);
            }
            catch //(Exception e)
            {

            }

            try
            {
                // Get the menu collection of the newly added pop-up item
                oMenuItem = Application.SBO_Application.Menus.Item("TransferenciasBancarias");
                oMenus = oMenuItem.SubMenus;

                // Create s sub menu
                oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
                oCreationPackage.UniqueID = "TransferenciasBancarias.Capa_Presentacion.PagosTransf";
                oCreationPackage.String = "Pagos para Transferencia";
                oMenus.AddEx(oCreationPackage);
            }
            catch //(Exception er)
            { //  Menu already exists
                Application.SBO_Application.SetStatusBarMessage("Menu Already Exists", SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }

        public void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction && pVal.MenuUID == "TransferenciasBancarias.Capa_Presentacion.PagosTransf")
                {
                    Capa_Presentacion.PagosTransf activeForm = new Capa_Presentacion.PagosTransf();
                    activeForm.Show();
                }
            }
            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }

    }
}
