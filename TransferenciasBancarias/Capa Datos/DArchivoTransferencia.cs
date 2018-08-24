using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Data;
using System.Data.SqlClient;

namespace TransferenciasBancarias.Capa_Datos
{
    class DArchivoTransferencia
    {
        private string _Ruta;
        public static SAPbobsCOM.Company oCompany = Conexion.oCompany;

        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        //Constructor Vacio
        public DArchivoTransferencia()
        {
            string sFecha = DateTime.Now.ToString("ddMMyyyy");
            string sHora = DateTime.Now.ToString("hhmmss");

            string sUbicacion = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //Directory.GetCurrentDirectory();
            string sArchivo = @"\IPPagos" + sFecha + sHora + ".TXT";

            string sRuta = sUbicacion + sArchivo;

            _Ruta = sUbicacion;
            _Nombre = sArchivo;
        }

        //Constructor con Parametros
        public DArchivoTransferencia(string Ruta, string Nombre)
        {
            _Ruta = Ruta;
            _Nombre = Nombre;
        }


        public SAPbouiCOM.DataTable GenerarEncabezado(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_HEAD)
        {
            try
            {
                string FechaPago = DT_SQL.GetValue(0,0).ToString();
                string CantidadPagos = DT_SQL.GetValue(0, 1).ToString();
                string MontoPagos = DT_SQL.GetValue(0, 2).ToString();//.Replace(".","");
                string[] SeparaTotal = MontoPagos.Split('.');
                string MontoEntero = SeparaTotal[0];
                string MontoDecimal = SeparaTotal.Count() == 1 ? "00" : MontoPagos.Split('.')[1] ;
                 
                string sql = @"EXEC	[dbo].[Min_Bancos_Generar_Encabezado_Archivo_PagoTXT]
		                        @U_FechaPago = N'"+ FechaPago +@"',
		                        @U_CantidadPago = N'"+ CantidadPagos +@"',
		                        @U_MontoTotal = N'" + MontoEntero + MontoDecimal + "'";
                DT_HEAD.ExecuteQuery(sql);
                
                //Hay que establecer la columana de tipo TEXT para que puedan agregarse posteriormente los rgistros de detalle
                string RC = DT_HEAD.GetValue(0, 0).ToString().Trim();
                DT_HEAD.Clear();
                DT_HEAD.Columns.Add("Info", SAPbouiCOM.BoFieldsType.ft_Text);

                DT_HEAD.Rows.Add(1);
                DT_HEAD.SetValue("Info", 0, RC);
                //DT_HEAD.SetValue("Info", 0, "RC00354803021120160000100000000016184000578509689910000968991000                     cgonzalez@ditecautomoviles.cl1636");
            }
            catch (Exception){}

            return DT_HEAD;
        }

        public SAPbouiCOM.DataTable GenerarEncabezadoFormato610(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_RESULT)
        {
            try
            {
                string FechaPago = DT_SQL.GetValue(0, 0).ToString();
                string CantidadPagos = DT_SQL.GetValue(0, 1).ToString();
                string CantidadDocu = DT_SQL.GetValue(0, 3).ToString(); ;
                string MontoPagos = DT_SQL.GetValue(0, 2).ToString();//.Replace(".","");
                string[] SeparaTotal = MontoPagos.Split('.');
                string MontoEntero = SeparaTotal[0];
                string MontoDecimal = SeparaTotal.Count() == 1 ? "00" : MontoPagos.Split('.')[1];

                string sql = @"EXEC	[dbo].[Min_Bancos_Generar_Encabezado_Archivo_PagoTXT_Formato610]
		                        @U_CantidadPago = N'" + CantidadPagos + @"',
                                @U_CantidadDocu = N'" + CantidadDocu + @"',
		                        @U_MontoTotal = N'" + MontoEntero + MontoDecimal + "'";
                DT_RESULT.ExecuteQuery(sql);

            }
            catch (Exception) { }

            return DT_RESULT;
        }

        public SAPbouiCOM.DataTable GenerarRegistros(SAPbouiCOM.DataTable DT_SQL, SAPbouiCOM.DataTable DT_DATOS, SAPbouiCOM.DataTable DT_ROWS)
        {
            try
            {
                oCompany = Program.oCompany;
                SAPbobsCOM.Recordset recordset = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string sql = "";
                string sNumPago = "";
                int iNumAviso = 0;
                DT_SQL.Clear();
                DT_ROWS.Clear();
                DT_ROWS.Columns.Add("Info", SAPbouiCOM.BoFieldsType.ft_Text);

                for (int i = 0; i <= DT_DATOS.Rows.Count - 1; i++)
                {
                    string val = DT_DATOS.GetValue(0, i).ToString();
                    if (DT_DATOS.GetValue(0, i).ToString() == "Y") //Registros Seleccionados
                    {
                        iNumAviso += 1;
                        sNumPago = DT_DATOS.GetValue(2, i).ToString();
                        //sql = @"EXEC [dbo].[Min_Bancos_Generar_Detalle_Pagos_Archivo_PagoTXT_Formato610]
                        // @NumPago = N'" + sNumPago + @"'
                        //      ,@NumeroAviso = '" + iNumAviso.ToString() + "'";

                        //DT_SQL.ExecuteQuery(sql);
                        //recordset.DoQuery(sql);
                        //recordset.MoveFirst();

                        //if (!DT_SQL.IsEmpty)
                        //{
                        //    for (int j = 0; j <= DT_SQL.Rows.Count - 1; j++)
                        //    {
                        //        var Linea = DT_SQL.GetValue(0, j);
                        //        var Linea2 = recordset.Fields.Item(0).Value;
                        //        recordset.MoveNext();
                        //        DT_ROWS.Rows.Add();
                        //        DT_ROWS.SetValue(0, DT_ROWS.Rows.Count - 1, DT_SQL.GetValue(0, j).ToString());
                        //        //Linea = Convert.ToString(DT_ROWS.GetValue(0, DT_ROWS.Rows.Count - 1));
                        //    }
                        //}

                        // SE DEBIO USAR System.Dat.DataTable porque el DT de SAP truncaba los resultado del SP
                        DataTable DtResultado = new DataTable();
                        SqlConnection SlqCon = new SqlConnection();

                        try
                        {
                            string sp = @"EXEC ["+oCompany.CompanyDB+ @"].[dbo].[Min_Bancos_Generar_Detalle_Pagos_Archivo_PagoTXT_Formato610]
                                         @NumPago = N'" + sNumPago + @"'
                                        ,@NumeroAviso = '" + iNumAviso.ToString() + "'";

                            SlqCon.ConnectionString = Conexion.CnSQL;
                            SqlCommand SqlCmd = new SqlCommand(sp, SlqCon);

                            SlqCon.Open();
                            //SqlCmd.CommandType = CommandType.Text;
                            //SqlCmd.Parameters.AddWithValue("@NumPago", sNumPago);
                            //SqlCmd.Parameters.AddWithValue("@NumeroAviso", iNumAviso.ToString());

                            SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                            SqlDat.Fill(DtResultado);

                        }
                        catch
                        {
                            DtResultado = null;
                        }
                        finally
                        {
                            if (SlqCon.State == ConnectionState.Open) SlqCon.Close();
                        }


                        if (DtResultado.Rows.Count > 0)
                        {
                            for (int j = 0; j <= DtResultado.Rows.Count - 1; j++)
                            {
                                var Linea = DtResultado.Rows[j][0];
                                DT_ROWS.Rows.Add();
                                DT_ROWS.SetValue(0, DT_ROWS.Rows.Count - 1, Linea);
                                //Linea = Convert.ToString(DT_ROWS.GetValue(0, DT_ROWS.Rows.Count - 1));
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
           
            return DT_ROWS;
        }

        public SAPbouiCOM.DataTable GenerarArchivoDT(SAPbouiCOM.DataTable DT_HEAD, SAPbouiCOM.DataTable DT_ROWS, SAPbouiCOM.DataTable DT_TXT)
        {
            try
            {
                for (int j = 0; j <= DT_ROWS.Rows.Count - 1; j++)
                {
                    string Linea = Convert.ToString(DT_ROWS.GetValue(0, j)); 
                    DT_HEAD.Rows.Add();
                    DT_HEAD.SetValue(0, DT_HEAD.Rows.Count - 1, DT_ROWS.GetValue(0, j).ToString());
                    //Linea = Convert.ToString(DT_HEAD.GetValue(0, DT_HEAD.Rows.Count - 1));
                }
                DT_TXT.CopyFrom(DT_HEAD);
            }
            catch (Exception) { }
           
            return DT_TXT;
        }




    }
}
