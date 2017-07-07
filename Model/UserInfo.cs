

using System.Collections.Generic;

namespace Model
{
    public class UserInfo
    {
        public int id { get; set; }

        public string UserName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyShortName { get; set; }
        public string LoginName { get; set; }
       

        public string Password { get; set; }
        public string PermissonLevel { get; set; }
        public string LastLoginIp { get; set; }
        public bool IsActive { get; set; }

        public int AddUserId { get; set; }

        public int ModifyUserId { get; set; }

        public IList<PerType> UserPer { get; set; }

    }

    public enum PerType
    {
        QueryALL,
        QueryCompany,
        Add,
        EditALL,
        EditCompany,
        Delete
    }
}
