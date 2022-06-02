using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    class KhachhangDAO
    {
        private static KhachhangDAO temp;

        public static KhachhangDAO Temp
        {
            get { if (temp == null) KhachhangDAO.temp = new KhachhangDAO(); return temp; }
            set { KhachhangDAO.temp = value; }
        }
        private KhachhangDAO() { }

        public List<khachhangDTO> danhSachKhachHang()
        {
            List<khachhangDTO> list = new List<khachhangDTO>();
            string query = "select * from khachhang";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach(DataRow item in datatable.Rows)
            {
                khachhangDTO khachhang = new khachhangDTO(item);
                list.Add(khachhang);
            }
            return list;
        }
        public bool insertKhachhang(string tenkh, string diachi, int sdt)
        {

            string query = string.Format("insert khachhang (tenkh, diachi, sdt) values (N'{0}',N'{1}','{2}')", tenkh, diachi, sdt);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateKhachhang(int makh, string tenkh, string diachi, int sdt)
        {

            string query = string.Format("update khachhang set tenkh = N'{0}', diachi = N'{1}', sdt = '{2}' where makh = '{3}'", tenkh, diachi, sdt, makh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteKhachhang(int makh)
        {

            string query = string.Format("delete khachhang where makh = {0}", makh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
