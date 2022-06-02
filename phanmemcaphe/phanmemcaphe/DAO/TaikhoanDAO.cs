using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    class TaikhoanDAO
    {
        private static TaikhoanDAO temp;

        public static TaikhoanDAO Temp
        {
            get { if (temp == null) TaikhoanDAO.temp = new TaikhoanDAO(); return temp; }
            set { TaikhoanDAO.temp = value; }
        }
        private TaikhoanDAO() { }

        public bool login(string tentk, string matk)
        {
            string query = "USP_login @tentk , @matk ";
            DataTable result = DataPro.Dataitem.ExecuteQuery(query, new object[] { tentk, matk });
            return result.Rows.Count > 0;
        }
        public taikhoanDTO GetAccountByUsename(string tentk)
        {
            DataTable data = DataPro.Dataitem.ExecuteQuery("select * from taikhoan where tentk = '" + tentk + " '");

            foreach (DataRow item in data.Rows)
            {
                return new taikhoanDTO(item);
            }
            return null;
        }
        public List<taikhoanDTO> danhSachTK()
        {
            List<taikhoanDTO> list = new List<taikhoanDTO>();
            string query = "select * from taikhoan";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in datatable.Rows)
            {
                taikhoanDTO tk = new taikhoanDTO(item);
                list.Add(tk);
            }
            return list;
        }
        public bool insertTaiKhoan(string tentk, string matk, string tenht, int kieutk)
        {

            string query = string.Format("insert taikhoan (tentk, matk, tenht, kieutk) values (N'{0}',N'{1}',N'{2}','{3}')", tentk, matk, tenht, kieutk);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateTaiKhoan(string tentk, string matk, string tenht, int kieutk)
        {

            string query = string.Format("update taikhoan set matk = N'{0}', tenht = N'{1}', kieutk = N'{2}' where tentk = N'{3}'", matk, tenht, kieutk, tentk);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteTaiKhoan(string tentk)
        {

            string query = string.Format("delete taikhoan where tentk = N'{0}'", tentk);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
