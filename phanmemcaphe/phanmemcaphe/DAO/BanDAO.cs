using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    class BanDAO
    {
        private static BanDAO temp;
        public static int TableWidth = 100;
        public static int TableHeight = 100;

        public static BanDAO Temp
        {
            get { if (temp == null) BanDAO.temp = new BanDAO(); return temp; }
            set { BanDAO.temp = value; }
        }
        private BanDAO() { }

        public List<banDTO> danhSachBan()
        {
            List<banDTO> list = new List<banDTO>();
            string query = "select * from ban";
            DataTable datatable = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in datatable.Rows)
            {
                banDTO ban = new banDTO(item);
                list.Add(ban);
            }
            return list;
        }

        public List<banDTO> LoadTableList()
        {
            List<banDTO> dsban = new List<banDTO>();

            DataTable data = DataPro.Dataitem.ExecuteQuery("USP_Danhsachban");

            foreach (DataRow item in data.Rows)
            {
                banDTO table = new banDTO(item);
                dsban.Add(table);
            }

            return dsban;
        }

        public bool insertBan(string tenban, string thuoctinh)
        {

            string query = string.Format("insert ban (tenban, thuoctinh) values (N'{0}',N'{1}')", tenban, thuoctinh);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateBan(int maban, string tenban, string thuoctinh)
        {

            string query = string.Format("update ban set tenban = N'{0}', thuoctinh = N'{1}' where maban = {2}", tenban, thuoctinh, maban);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool deleteBan(int maban)
        {

            string query = string.Format("delete ban where maban = {0}",maban);
            int result = DataPro.Dataitem.ExecuteNonQuery(query);

            return result > 0;
        }
        public void SwichTable(int id1, int id2)
        {
            DataPro.Dataitem.ExecuteQuery("USP_SwichTable @idTable1 , @idTable2", new object[] { id1, id2 });
        }
        public void gopTable(int id1, int id2)
        {
            DataPro.Dataitem.ExecuteQuery("USP_GopBan @idTable1 , @idTable2", new object[] { id1, id2 });
        }

    }
}
