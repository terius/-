using System.Data;

namespace Model
{
    public class ReportData
    {
        public string CreateDate { get; set; }
        public string DateSelect { get; set; }
        public string Company { get; set; }

        public DataTable I_Data { get; set; }

     

        public DataTable E_Data { get; set; }
    }
}
