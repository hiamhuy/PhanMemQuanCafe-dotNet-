using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    class NhanvienDAO
    {
        private static NhanvienDAO temp;

        public static NhanvienDAO Temp
        {
            get { if (temp == null) NhanvienDAO.temp = new NhanvienDAO(); return temp; }
            set { NhanvienDAO.temp = value; }
        }
        private NhanvienDAO() { }

        public List<nhanvienDTO> danhSachNhanVien()
        {
            List<nhanvienDTO> list = new List<nhanvienDTO>();
            string query = "select * from nhanvien";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in datatable.Rows)
            {
                nhanvienDTO nv = new nhanvienDTO(item);
                list.Add(nv);
            }
            return list;
        }
        public bool insertNhanVien(string tennv, string gt, string chucvu, DateTime ngayvaolam, string diachi, int sdt)
        {

            string query = string.Format("insert nhanvien (tennv, gt, chucvu, ngayvaolam, diachi, sdt) values (N'{0}',N'{1}',N'{2}','{3}',N'{4}','{5}')", tennv, gt, chucvu, ngayvaolam, diachi, sdt);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateNhanVien(int manv, string tennv, string gt, string chucvu, DateTime ngayvaolam, string diachi, int sdt)
        {

            string query = string.Format("update nhanvien set tennv = N'{0}', gt = N'{1}', chucvu = N'{2}', ngayvaolam = '{3}', diachi = N'{4}', sdt = '{5}' where manv = '{6}'", tennv, gt, chucvu, ngayvaolam, diachi, sdt, manv);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteNhanVien(int manv)
        {

            string query = string.Format("delete nhanvien where manv = {0}", manv);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
