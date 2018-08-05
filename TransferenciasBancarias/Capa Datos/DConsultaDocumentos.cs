using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferenciasBancarias.Capa_Datos
{
    class DConsultaDocumentos
    {

        public DConsultaDocumentos()
        {
        }

        public SAPbouiCOM.DataTable ConsultarFacturas(SAPbouiCOM.DataTable DT_SQL, string sPago, string TipoTabla)
        {
            try 
	        {
                string sql = "";
                switch (TipoTabla)
                {
                    case "D":
                        sql = @"select 
		                            DocEntry as 'Numero Interno'
		                            ,DocNum as 'Numero Documento'
		                            ,CardName as 'Proveedor'
		                            ,CreateDate as 'Fecha Creacion'
		                            ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(DocTotal AS MONEY),1),2),',','.') as 'Total'
                                from 
		                            OPCH 
                                where 
		                            CANCELED = 'N'
		                            AND DocEntry IN (SELECT 
								                            T1.DocEntry
							                            FROM 
								                            OVPM T0 JOIN VPM2 T1 ON T0.DocEntry = T1.DocNum
							                            WHERE 
								                            T1.InvType = 18 and T1.ObjType = 46 and T0.DocEntry = " + sPago + ")";
                        break;
                    case "B":
                        sql = @"select 
		                            DocEntry as 'Numero Interno'
                                    ,DocNum as 'Numero Documento'
		                            ,CardName as 'Proveedor'
		                            ,CreateDate as 'Fecha Creacion'
		                            ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(DocTotal AS MONEY),1),2),',','.') as 'Total'
                                from 
		                            OPCH 
                                where 
		                            CANCELED = 'N'
		                            AND DocEntry IN (SELECT 
								                            T1.DocEntry
							                            FROM 
								                            OPDF T0 JOIN PDF2 T1 ON T0.DocEntry = T1.DocNum
							                            WHERE 
								                            T0.Canceled = 'N' AND T0.DocType = 'S'
								                            AND T0.TrsfrSum > 0 AND T0.ObjType = 46
								                            AND T1.InvType = 18 AND T1.ObjType = 46 AND T0.DocEntry = " + sPago + ")";
                        break;
                }
                DT_SQL.ExecuteQuery(sql);
	        }
	        catch (Exception){}
            return DT_SQL; 
        }

        public SAPbouiCOM.DataTable ConsultarRecepciones(SAPbouiCOM.DataTable DT_SQL, string sPago, string TipoTabla)
        {
            try
            {
                string sql = "";
                switch (TipoTabla)
                {
                    case "D":
                        sql = @"SELECT
		                            T2.DocEntry as 'Numero Interno' 
		                            ,T2.DocNum as 'Numero Documento'
		                            ,T2.CardName as 'Proveedor'
		                            ,T2.CreateDate as 'Fecha Creacion'
		                            ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(T2.DocTotal AS MONEY),1),2),',','.') as 'Total' 
	                            FROM 
		                            (select distinct docentry as 'Factura', BaseEntry, BaseType from PCH1 where BaseType = 20) T0 
		                            JOIN (select distinct DocNum as 'Pago', DocEntry as 'Factura' from VPM2 where InvType = 18) T1 ON T0.Factura = T1.Factura
		                            JOIN OPDN T2 ON T0.BaseEntry = T2.DocEntry
	                            WHERE 
		                            T0.BaseType = 20 AND T2.CANCELED = 'N'
		                            AND T1.Pago = " + sPago + "";
                        break;
                    case "B":
                        sql = @"SELECT
		                            T2.DocEntry as 'Numero Interno' 
		                            ,T2.DocNum as 'Numero Documento'
		                            ,T2.CardName as 'Proveedor'
		                            ,T2.CreateDate as 'Fecha Creacion'
		                            ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(T2.DocTotal AS MONEY),1),2),',','.') as 'Total' 
	                            FROM 
		                            (select distinct docentry as 'Factura', BaseEntry, BaseType from PCH1 where BaseType = 20) T0 
		                            JOIN (select distinct DocNum as 'Pago', DocEntry as 'Factura' from PDF2 where InvType = 18) T1 ON T0.Factura = T1.Factura
		                            JOIN OPDN T2 ON T0.BaseEntry = T2.DocEntry
	                            WHERE 
		                            T0.BaseType = 20 AND T2.CANCELED = 'N'
		                            AND T1.Pago = " + sPago + "";
                        break;
                }
                DT_SQL.ExecuteQuery(sql);
            }
            catch (Exception) { }
            return DT_SQL;
        }

        public SAPbouiCOM.DataTable ConsultarOrdenes(SAPbouiCOM.DataTable DT_SQL, string sPago, string TipoTabla)
        {
            try
            {
                string sql = "";
                switch (TipoTabla)
                {
                    case "D":
                        sql = @"SELECT DISTINCT
		                            T4.DocEntry as 'Numero Interno' 
		                            ,T4.DocNum as 'Numero Documento'
		                            ,T4.CardName as 'Proveedor'
		                            ,T4.CreateDate as 'Fecha Creacion'
		                            ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(T4.DocTotal AS MONEY),1),2),',','.') as 'Total'   
	                            FROM 
		                            (select distinct docentry as 'Factura', BaseEntry as 'Entrega', BaseType from PCH1 where BaseType = 20) T0 
		                            JOIN (select distinct DocNum as 'Pago', DocEntry as 'Factura' from VPM2 where InvType = 18) T1 ON T0.Factura = T1.Factura
		                            JOIN OPDN T2 ON T0.Entrega = T2.DocEntry
		                            JOIN PDN1 T3 ON T0.Entrega = T3.DocEntry
		                            JOIN OPOR T4 ON T3.BaseEntry = T4.DocEntry
	                            WHERE 
		                            T0.BaseType = 20 AND T2.CANCELED = 'N'
		                            AND T3.BaseType = 22 AND T1.Pago = " + sPago + "";
                        break;
                    case "B":
                        sql = @"	SELECT DISTINCT
		                                T4.DocEntry as 'Numero Interno' 
		                                ,T4.DocNum as 'Numero Documento'
		                                ,T4.CardName as 'Proveedor'
		                                ,T4.CreateDate as 'Fecha Creacion'
		                                ,REPLACE(PARSENAME(CONVERT(VARCHAR,CAST(T4.DocTotal AS MONEY),1),2),',','.') as 'Total'   
	                                FROM 
		                                (select distinct docentry as 'Factura', BaseEntry as 'Entrega', BaseType from PCH1 where BaseType = 20) T0 
		                                JOIN (select distinct DocNum as 'Pago', DocEntry as 'Factura' from PDF2 where InvType = 18) T1 ON T0.Factura = T1.Factura
		                                JOIN OPDN T2 ON T0.Entrega = T2.DocEntry
		                                JOIN PDN1 T3 ON T0.Entrega = T3.DocEntry
		                                JOIN OPOR T4 ON T3.BaseEntry = T4.DocEntry
	                                WHERE 
		                                T0.BaseType = 20 AND T2.CANCELED = 'N'
		                                AND T3.BaseType = 22 AND T1.Pago = " + sPago + "";
                        break;
                }
                DT_SQL.ExecuteQuery(sql);
            }
            catch (Exception) { }
            return DT_SQL;
        }
    }
}
