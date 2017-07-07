using DAL;
using Helpers;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class UserBLL
    {
        private readonly COMMON comm = new COMMON();
        public UserInfo GetUserInfoById(int userId)
        {
            Hashtable ht = new Hashtable();
            ht["id"] = userId;
            DataRow dr = comm.GetOneRow("select * from users where id=@id", ht);
            return ConvertDataRowToInfo(dr);
        }

        public UserInfo GetUserInfoByCompanyId(string companyId)
        {
            Hashtable ht = new Hashtable();
            ht["CompanyId"] = companyId;
            DataRow dr = comm.GetOneRow("select top 1 * from users where CompanyId=@CompanyId", ht);
            return ConvertDataRowToInfo(dr);
        }

        public UserInfo GetUserInfoByLoginName(string loginName)
        {
            Hashtable ht = new Hashtable();
            ht["loginname"] = loginName;
            DataRow dr = comm.GetOneRow("select * from users where loginname=@loginname", ht);
            return ConvertDataRowToInfo(dr);
        }

        public string UpdateLoginIp(int userId)
        {
            string newIP = NetHelper.GetLocalIP();
            Hashtable ht = new Hashtable();
            ht["id"] = userId;
            ht["LastLoginIp"] = newIP;
            comm.UID("update users set LastLoginIp = @LastLoginIp where id=@id", ht);
            return newIP;
        }

        private UserInfo ConvertDataRowToInfo(DataRow dr)
        {
            if (dr == null)
            {
                return null;
            }
            UserInfo info = new UserInfo();
            info.id = Convert.ToInt32(dr["id"]);
            info.CompanyId = dr["CompanyId"].ToString();
            info.CompanyName = dr["CompanyName"].ToString();
            info.CompanyShortName = dr["CompanyShortName"].ToString();
            info.LastLoginIp = dr["LastLoginIp"].ToString();
            info.LoginName = dr["LoginName"].ToString();
            info.PermissonLevel = dr["PermissonLevel"].ToString();
            info.IsActive = Convert.ToBoolean(dr["IsActive"]);
            info.UserName = dr["UserName"].ToString();
            info.Password = dr["Password"].ToString();
            info.UserPer = GetUserPer(info.PermissonLevel);
            
            return info;
        }

        private IList<PerType> GetUserPer(string PermissonLevel)
        {
            IList<PerType> per = new List<PerType>();
            switch (PermissonLevel)
            {
                case "1":
                    per.Add(PerType.Add);
                    per.Add(PerType.QueryCompany);
                    break;
                case "2":
                    per.Add(PerType.Add);
                    per.Add(PerType.EditCompany);
                    per.Add(PerType.QueryCompany);
                    break;
                case "3":
                    per.Add(PerType.EditALL);
                    per.Add(PerType.QueryALL);
                    per.Add(PerType.Delete);
                    break;
                case "4":
                    per.Add(PerType.QueryALL);
                    break;
                default:
                    break;
            }
            return per;
        }



        public bool SaveUserInfo(UserInfo info)
        {
            Hashtable ht = new Hashtable();
            if (info.id > 0)
            {
                ht["id"] = info.id;
            }

            if (!string.IsNullOrEmpty(info.Password))
            {
                ht["Password"] = StringHelper.Sha256(info.Password);
            }

            ht["UserName"] = info.UserName;
            ht["CompanyId"] = info.CompanyId;
            ht["CompanyName"] = info.CompanyName;
            ht["CompanyShortName"] = info.CompanyShortName;
            ht["LoginName"] = info.LoginName;
            ht["PermissonLevel"] = info.PermissonLevel;
            //   ht["LastLoginIp"] = info.LastLoginIp;
            ht["IsActive"] = info.IsActive;
            ht["CompanyShortName"] = info.CompanyShortName;
            if (info.id > 0)
            {
                ht["ModifyUserId"] = info.ModifyUserId;
                ht["Modifytime"] = comm.GetDBDate();
                return comm.UpdateTable(ht, "users") > 0 ? true : false;
            }
            else
            {
                ht["AddUserId"] = info.AddUserId;
                return comm.InsertTable(ht, "users") > 0 ? true : false;
            }

        }

        public bool CheckUserNameExist(string newName, int id = 0)
        {
            if (id > 0)
            {
                string sql = "select count(1) from users where loginname = @loginname  and id != @id";
                Hashtable ht = new Hashtable();
                ht["loginname"] = newName;
                ht["id"] = id;
                return comm.Exists(sql, ht);
            }
            else
            {
                string sql = "select count(1) from users where loginname = @loginname";
                Hashtable ht = new Hashtable();
                ht["loginname"] = newName;
                return comm.Exists(sql, ht);
            }

        }

        public bool DeleteUser(int id)
        {
            string sql = "delete from users where id=@id";
            Hashtable ht = new Hashtable();
            ht["id"] = id;
            return comm.UID(sql, ht) > 0 ? true : false;
        }

        public bool CheckUserCodeExist(string newCode, int id = 0)
        {
            if (id > 0)
            {
                string sql = "select count(1) from users where UserName = @UserName  and id != @id";
                Hashtable ht = new Hashtable();
                ht["UserName"] = newCode;
                ht["id"] = id;
                return comm.Exists(sql, ht);
            }
            else
            {
                string sql = "select count(1) from users where UserName = @UserName";
                Hashtable ht = new Hashtable();
                ht["UserName"] = newCode;
                return comm.Exists(sql, ht);
            }

        }

        public bool ChangePassword(int userId, string newPwd)
        {
            string sql = "update users set password = @password where id=@id";
            newPwd = StringHelper.Sha256(newPwd);
            Hashtable ht = new Hashtable();
            ht["password"] = newPwd;
            ht["id"] = userId;
            return comm.UID(sql, ht) > 0;
        }
    }
}
