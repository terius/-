using DAL;
using Helpers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class InputBLL
    {
        private readonly COMMON comm = new COMMON();
        private readonly COMMON2 comm2 = new COMMON2();
        private readonly string v1Head = System.Configuration.ConfigurationManager.AppSettings["HeadTableName"];
        private readonly string DUNHAOTradeCode = System.Configuration.ConfigurationManager.AppSettings["DunHaoTradeCode"];
        private readonly string connstring2 = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString2"].ConnectionString;
        private readonly string DUNHAOconnstring = System.Configuration.ConfigurationManager.ConnectionStrings["DunHaoConnString"].ConnectionString;
        private readonly string defaultConnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public DataTable GetDataByVoyAgeNo(string voyageNo, string tradeId)
        {

            string sql = "select * from InputWork where VoyageNo = @VoyageNo";
            Hashtable ht = new Hashtable();
            if (tradeId != "")
            {
                sql += " and CompanyId= @CompanyId";
                ht["CompanyId"] = tradeId;
            }
            ht["VoyageNo"] = voyageNo;
            DataTable dt = comm.Query(sql, ht);
            return dt;
        }
        public V1Info GetV1Info(string voyageNo, string sType, string tradeCode)
        {
            V1Info info = new V1Info();
            if (sType.Equals("D", StringComparison.CurrentCultureIgnoreCase))
            {
                return info;
            }
            //string sql = "select count(1) from " + v1Head + " where voyage_no=@voyage_no and ENTRY_TYPE=@Trade_Type";
            Hashtable ht = new Hashtable();
            ht["voyage_no"] = voyageNo;
            ht["ENTRY_TYPE"] = sType;
            //int ticket = comm2.GetIntData(sql, ht);
            //info.Ticket = ticket;
            string sql = "select count(1) allcount,  ISNULL(SUM(PACK_NO),0) packno,ISNULL(SUM(GROSS_WT),0) wt from " + v1Head + " where VOYAGE_NO=@voyage_no and ENTRY_TYPE=@ENTRY_TYPE";
            string newConnstr = tradeCode.Equals(DUNHAOTradeCode, StringComparison.CurrentCultureIgnoreCase) ? DUNHAOconnstring : connstring2;
            DbHelperSQL.connectionString = newConnstr;
            DataRow dr = comm.GetOneRow(sql, ht);
            if (dr != null)
            {
                info.PackNo = Convert.ToInt32(dr["packno"]);
                info.Weight = Convert.ToDouble(dr["wt"]);
                info.Ticket = Convert.ToInt32(dr["allcount"]);
            }
            DbHelperSQL.connectionString = defaultConnString;
            return info;
        }

        public int SaveInputData(IList<Hashtable> dataList, ref IList<string> snoList)
        {
            int id = 0;
            int rs = 0;
            foreach (Hashtable ht in dataList)
            {
                id = Convert.ToInt32(ht["id"]);
                if (id > 0)
                {
                    rs += comm.UpdateTable(ht, "InputWork");
                }
                else
                {
                    ht["SNo"] = GetMaxSno(ht["VoyageNo"].ToString(), ht["I_E_FLAG"].ToString(), ht["InputDate"].ToString());
                    rs += comm.InsertTable(ht, "InputWork", "id");
                }
                snoList.Add(ht["TradeType"].ToString() + "_" + ht["SNo"].ToString());
            }
            return rs;
        }

        public int DeleteData(string voyageNo)
        {
            string sql = "delete from InputWork where VoyageNo = @VoyageNo";
            Hashtable ht = new Hashtable();
            ht["VoyageNo"] = voyageNo;
            return comm.UID(sql, ht);

        }

        private string GetMaxSno(string VoyageNo, string ieflag, string inputDate)
        {

            string ie = ieflag == "I" ? "1" : "0";
            string iDate = Convert.ToDateTime(inputDate).ToString("yyyyMMdd").Substring(2);
            DateTime newInputDate = Convert.ToDateTime(inputDate).Date;
            string no = GetNewNo(newInputDate, ieflag);
            string newSno = ie + iDate + no;
            return newSno;
        }

        private string GetNewNo(DateTime newInputDate, string ieflag)
        {
            string sql = "select max(SNo) from InputWork where  InputDate=@InputDate and I_E_FLAG=@I_E_FLAG";
            //   string sql = "select count(1) from InputWork where  InputDate=CONVERT(VARCHAR(10),GETDATE(),120)";
            Hashtable ht = new Hashtable();
            ht["InputDate"] = newInputDate;
            ht["I_E_FLAG"] = ieflag;
            string no = comm.GetStringData(sql, ht);
            if (string.IsNullOrEmpty(no))
            {
                return "001";
            }
            string noPart = no.Substring(no.Length - 3);
            int newNo = Convert.ToInt32(noPart) + 1;
            return newNo.ToString().PadLeft(3, '0');
        }

        public bool CheckDataExists(string voyageNo)
        {
            string sql = "select top 1 id from InputWork where VoyageNo = @VoyageNo";
            Hashtable ht = new Hashtable();
            ht["VoyageNo"] = voyageNo;
            int id = comm.GetIntData(sql, ht);
            return id > 0 ? true : false;
        }

        public string GetTradeCode(string voyageNo)
        {
            string sql = "select top 1 CompanyId from InputWork where VoyageNo = @VoyageNo";
            Hashtable ht = new Hashtable();
            ht["VoyageNo"] = voyageNo;
            return comm.GetStringData(sql, ht);
        }


        public DataTable QueryInputWork(string voyageNo, string companyId, DateTime sDate, DateTime eDate, string i_e_flag, UserInfo userInfo)
        {
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();
            if (!string.IsNullOrEmpty(voyageNo))
            {
                sb.Append(" and VoyageNo like @VoyageNo");
                ht["VoyageNo"] = "%" + voyageNo + "%";
            }
            if (!string.IsNullOrEmpty(companyId))
            {
                sb.Append(" and CompanyId = @CompanyId");
                ht["CompanyId"] = companyId;
            }

            if (sDate != DateTime.MinValue)
            {
                sb.Append(" and InputDate >=  @stime");
                ht["stime"] = sDate;
            }
            if (eDate != DateTime.MinValue)
            {
                sb.Append(" and InputDate <=  @etime");
                ht["etime"] = eDate;
            }
            if (!string.IsNullOrEmpty(i_e_flag))
            {
                sb.Append(" and I_E_FLAG = @I_E_FLAG");
                ht["I_E_FLAG"] = i_e_flag;
            }
            //SUM(Ticket),SUM(Piece),SUM(Weight), SUM(Price)
            string columns = "CompanyName,VoyageNo,TradeType,CONVERT(VARCHAR(10),InputDate,120) InputDate,"
                + "case I_E_FLAG when 'I' then '进口' when 'E' then '出口' else I_E_FLAG end I_E_FLAG,"
                + "case A_L_TYPE when 'A' then '空运' when 'L' then '陆运' else A_L_TYPE end A_L_TYPE,"
                + "SNo,Ticket,Piece,Weight,Price,Remark,VoyageNo VoyageNoHide,CompanyId";
            string columns2 = "'',VoyageNo,'合计','','','','',0,0,0, 0,'','',''";
            if (userInfo.PermissonLevel == "3" || userInfo.PermissonLevel == "4")
            {
                columns += ",Ticket_C,Piece_C,Weight_C,Price_C";
                columns2 += ",0,0,0,0";
            }
            //string extSql = "";
            //if (userInfo.PermissonLevel == "1" || userInfo.PermissonLevel == "2")
            //{
            //    extSql = " and CompanyId = @CompanyId";
            //    ht["CompanyId"] = userInfo.CompanyId;
            //}

            string sql = string.Format("select * from (select {0} from InputWork where 1=1 {1} "
                + " union all select {2} from InputWork where 1=1 {1}  group by  VoyageNo) a ORDER BY a.VoyageNo,a.TradeType",
                columns, sb.ToString(), columns2);

            string newVOY = "";
            string newCOM = "";
            DataTable dt = comm.Query(sql, ht);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] drAll = dt.Select("TradeType='合计'");
                string voyNo = "";
                int allTicket = 0;
                int allPiece = 0;
                double allWeight = 0;
                decimal allPrice = 0;
                bool isAdmin = userInfo.PermissonLevel == "3" || userInfo.PermissonLevel == "4";

                int allTicket_C = 0;
                int allPiece_C = 0;
                double allWeight_C = 0;
                decimal allPrice_C = 0;
                foreach (DataRow dr in drAll)
                {
                    allTicket = allPiece = 0;
                    allWeight = 0;
                    allPrice = 0;
                    voyNo = dr["VoyageNo"].ToString();
                    dr["VoyageNo"] = "";
                    if (isAdmin)
                    {
                        allTicket_C = 0;
                        allPiece_C = 0;
                        allWeight_C = 0;
                        allPrice_C = 0;
                    }
                    foreach (DataRow drData in dt.Rows)
                    {

                        if (drData["VoyageNo"].ToString() == voyNo)
                        {
                            allTicket += StringHelper.SafeGetIntFromObj(drData["Ticket"]);
                            allPiece += StringHelper.SafeGetIntFromObj(drData["Piece"]);
                            allWeight += StringHelper.SafeGetDoubleFromObj(drData["Weight"]);
                            allPrice += StringHelper.SafeGetDecimalFromObj(drData["Price"]);
                            if (isAdmin)
                            {
                                allTicket_C += StringHelper.SafeGetIntFromObj(drData["Ticket_C"]);
                                allPiece_C += StringHelper.SafeGetIntFromObj(drData["Piece_C"]);
                                allWeight_C += StringHelper.SafeGetDoubleFromObj(drData["Weight_C"]);
                                allPrice_C += StringHelper.SafeGetDecimalFromObj(drData["Price_C"]);
                            }
                            //if (newVOY != voyNo)
                            //{
                            //    newVOY = voyNo;
                            //    newCOM = drData["CompanyName"].ToString();
                            //}
                            //else
                            //{
                            //    drData["VoyageNo"] = "";
                            //    drData["CompanyName"] = "";
                            //}
                        }

                    }
                    dr["Ticket"] = allTicket;
                    dr["Piece"] = allPiece;
                    dr["Weight"] = allWeight;
                    dr["Price"] = allPrice;
                    if (isAdmin)
                    {
                        dr["Ticket_C"] = allTicket_C;
                        dr["Piece_C"] = allPiece_C;
                        dr["Weight_C"] = allWeight_C;
                        dr["Price_C"] = allPrice_C;
                    }
                }

            }
            return dt;

        }

        public DataTable QueryInputReport(string companyId, DateTime stime, DateTime etime, string i_e_flag, bool showKLY, bool ShowCKTJ)
        {
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();

            if (!string.IsNullOrEmpty(companyId))
            {
                sb.Append(" and CompanyId = @CompanyId");
                ht["CompanyId"] = companyId;
            }

            if (stime != DateTime.MinValue)
            {
                sb.Append(" and InputDate >=  @stime");
                ht["stime"] = stime;
            }
            if (etime != DateTime.MinValue)
            {
                sb.Append(" and InputDate <=  @etime");
                ht["etime"] = etime;
            }
            if (!string.IsNullOrEmpty(i_e_flag))
            {
                sb.Append(" and I_E_FLAG = @I_E_FLAG");
                ht["I_E_FLAG"] = i_e_flag;
            }
            string A_L_TYPE_sql = showKLY ? "(CASE  A_L_TYPE WHEN 'A' THEN '空运' ELSE '陆运' END) A_L_TYPE" : "'' A_L_TYPE";
            string tj_sql = ShowCKTJ ? "sum(Ticket_C) Ticket,sum(Piece_C) Piece,sum(Weight_C) Weight,sum(Price_C) Price" : "sum(Ticket) Ticket,sum(Piece) Piece,sum(Weight) Weight,sum(Price) Price";

            string columns = string.Format("TradeType,{0} ,{1}", A_L_TYPE_sql, tj_sql);
            string columns2 = "TradeType,'合计',0,0,0, 0";

            string sql = "";
            if (showKLY)
            {
                sql = string.Format("select * from (select {0} from InputWork where 1=1 {1} group by TradeType,A_L_TYPE "
               + " union all select {2} from InputWork where 1=1 {1}  group by  TradeType) a ORDER BY a.TradeType,a.A_L_TYPE desc",
               columns, sb.ToString(), columns2);
            }
            else
            {
                sql = string.Format("select {0} from InputWork where 1=1 {1} group by TradeType",
             columns, sb.ToString());
            }



            DataTable dt = comm.Query(sql, ht);
            if (showKLY)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] drAll = dt.Select("A_L_TYPE='合计'");
                    string stype = "";
                    int allTicket = 0;
                    int allPiece = 0;
                    double allWeight = 0;
                    decimal allPrice = 0;



                    foreach (DataRow dr in drAll)
                    {
                        allTicket = allPiece = 0;
                        allWeight = 0;
                        allPrice = 0;
                        stype = dr["TradeType"].ToString();
                        foreach (DataRow drData in dt.Rows)
                        {
                            if (drData["TradeType"].ToString() == stype)
                            {
                                allTicket += StringHelper.SafeGetIntFromObj(drData["Ticket"]);
                                allPiece += StringHelper.SafeGetIntFromObj(drData["Piece"]);
                                allWeight += StringHelper.SafeGetDoubleFromObj(drData["Weight"]);
                                allPrice += StringHelper.SafeGetDecimalFromObj(drData["Price"]);

                            }
                        }
                        dr["Ticket"] = allTicket;
                        dr["Piece"] = allPiece;
                        dr["Weight"] = allWeight;
                        dr["Price"] = allPrice;
                    }
                }
            }
            return dt;

        }

        public DataTable QueryInputReportNew(string companyId, DateTime stime, DateTime etime,
            string i_e_flag, bool showKLY, bool ShowCKTJ, string i_e_flag_type = "")
        {
            StringBuilder sb = new StringBuilder();
            Hashtable ht = new Hashtable();
            string ieflagSQL = "";
            if (i_e_flag_type == "I")
            {
                ieflagSQL = " and i_e_flag = 'I' ";
            }
            else if (i_e_flag_type == "E")
            {
                ieflagSQL = " and i_e_flag = 'E' ";
            }

            if (!string.IsNullOrEmpty(companyId))
            {
                sb.Append(" and CompanyId = @CompanyId");
                ht["CompanyId"] = companyId;
            }

            if (stime != DateTime.MinValue)
            {
                sb.Append(" and InputDate >=  @stime");
                ht["stime"] = stime;
            }
            if (etime != DateTime.MinValue)
            {
                sb.Append(" and InputDate <=  @etime");
                ht["etime"] = etime;
            }
            if (!string.IsNullOrEmpty(i_e_flag))
            {
                sb.Append(" and I_E_FLAG = @I_E_FLAG");
                ht["I_E_FLAG"] = i_e_flag;
            }
            StringBuilder sbSql = new StringBuilder();
            string columns = ShowCKTJ ? "isnull(SUM(Ticket_C),0) Ticket,isnull(SUM(Piece_C),0) Piece,isnull(SUM(Weight_C),0) Weight,isnull(SUM(Price_C),0) Price" : "isnull(SUM(Ticket),0) Ticket,isnull(SUM(Piece),0) Piece,isnull(SUM(Weight),0) Weight,isnull(SUM(Price),0) Price";
            if (showKLY)//显示空陆运
            {
                sbSql.AppendFormat("select '全部' TradeType ,'合计' A_L_TYPE,{1} from InputWork where 1=1  {0} {2}"
    + " union all"
    + " select '', '空运',{1} from InputWork where A_L_TYPE = 'A' {0} {2}"
    + " union all"
    + " select '', '陆运',{1} from InputWork where A_L_TYPE = 'L' {0} {2}", sb.ToString(), columns, ieflagSQL);
                string tradeTypeText = "";
                string tradeType = "";
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            tradeTypeText = "A类";
                            tradeType = "A";
                            break;
                        case 1:
                            tradeTypeText = "B类";
                            tradeType = "B";
                            break;
                        case 2:
                            tradeTypeText = "C类";
                            tradeType = "C";
                            break;
                        case 3:
                            tradeTypeText = "普货";
                            tradeType = "D";
                            break;
                        default:
                            break;
                    }
                    sbSql.AppendFormat(" union all select '{0}' ,'合计',{3} from InputWork where TradeType='{1}' {2} {4}"
     + " union all"
     + " select '', '空运', {3} from InputWork where A_L_TYPE = 'A' and TradeType = '{1}' {2} {4}"
     + " union all"
     + " select '', '陆运', {3} from InputWork where A_L_TYPE = 'L' and TradeType = '{1}' {2} {4}", tradeTypeText, tradeType,
     sb.ToString(), columns, ieflagSQL);

                }
            }
            else
            {
                sbSql.AppendFormat("select '全部' TradeType ,{1} from InputWork where 1=1 {0} {2}", sb.ToString(), columns, ieflagSQL);
                string tradeTypeText = "";
                string tradeType = "";
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            tradeTypeText = "A类";
                            tradeType = "A";
                            break;
                        case 1:
                            tradeTypeText = "B类";
                            tradeType = "B";
                            break;
                        case 2:
                            tradeTypeText = "C类";
                            tradeType = "C";
                            break;
                        case 3:
                            tradeTypeText = "普货";
                            tradeType = "D";
                            break;
                        default:
                            break;
                    }
                    sbSql.AppendFormat(" union all select '{0}' ,{3} from InputWork where TradeType='{1}' {2} {4}", tradeTypeText,
                        tradeType, sb.ToString(), columns, ieflagSQL);

                }
            }

            DataTable dt = comm.Query(sbSql.ToString(), ht);


            return dt;


        }


        public DataTable GetCompanyList()
        {
            string sql = "select CompanyId,CompanyName from users where PermissonLevel='1' or PermissonLevel='2' order by CompanyName";
            return comm.Query(sql);
        }
    }
}
