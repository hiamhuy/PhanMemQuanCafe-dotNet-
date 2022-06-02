using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    public class HanghoaDAO
    {
        private static HanghoaDAO temp;

        public static HanghoaDAO Temp
        {
            get { if (temp == null) HanghoaDAO.temp = new HanghoaDAO(); return temp; }
            set { HanghoaDAO.temp = value; }
        }
        private HanghoaDAO() { }

        public List<hanghoaDTO> hangHoaCB(int id)
        {
            List<hanghoaDTO> listhh = new List<hanghoaDTO>();

            string query = string.Format("select * from hanghoa where malh = {0} ", id);
            DataTable data = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                hanghoaDTO hh = new hanghoaDTO(item);
                listhh.Add(hh);
            }

            return listhh;
        }
        public List<hanghoaDTO> danhSachHangHoa()
        {
            List<hanghoaDTO> list = new List<hanghoaDTO>();
            string query = "select * from hanghoa";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in datatable.Rows)
            {
                hanghoaDTO hh = new hanghoaDTO(item);
                list.Add(hh);
            }
            return list;
        }
        
        public bool insertHangHoa(string tenhang, int solg, float giasp, int malh)
        {

            string query = string.Format("insert hanghoa (tenhang, solg, giasp, malh) values (N'{0}','{1}','{2}','{3}')", tenhang, solg, giasp, malh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateHangHoa(int mahh, string tenhang, int solg, float giasp, int malh)
        {

            string query = string.Format("update hanghoa set tenhang = N'{0}', solg = '{1}', giasp = '{2}', malh = '{3}' where mahh = {4}", tenhang, solg, giasp, malh, mahh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteHangHoa(int mahh)
        {

            string query = string.Format("delete hanghoa where mahh = {0}", mahh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
