using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    class LoaihanghoaDAO
    {
        private static LoaihanghoaDAO temp;

        public static LoaihanghoaDAO Temp
        {
            get { if (temp == null) LoaihanghoaDAO.temp = new LoaihanghoaDAO(); return temp; }
            set { LoaihanghoaDAO.temp = value; }
        }
        private LoaihanghoaDAO() { }

        public List<loaihanghoaDTO> danhsachLHH()
        {
            List<loaihanghoaDTO> list = new List<loaihanghoaDTO>();
            string query = "select * from loaihanghoa";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in datatable.Rows)
            {
                loaihanghoaDTO lhh = new loaihanghoaDTO(item);
                list.Add(lhh);
            }
            return list;
        }
        public bool insertLoaiHangHoa(string tenlh, string mota)
        {

            string query = string.Format("insert loaihanghoa (tenlh, mota) values (N'{0}',N'{1}')", tenlh, mota);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateLoaiHangHoa(int malh, string tenlh, string mota)
        {

            string query = string.Format("update loaihanghoa set tenlh = N'{0}', mota = N'{1}' where malh = '{2}'", tenlh, mota,  malh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteLoaiHangHoa(int malh)
        {

            string query = string.Format("delete loaihanghoa where malh = '{0}'", malh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
