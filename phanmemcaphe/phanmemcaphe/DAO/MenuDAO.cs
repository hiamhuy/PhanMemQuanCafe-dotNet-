using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO temp;

        public static MenuDAO Temp
        {
            get { if (temp == null) MenuDAO.temp = new MenuDAO(); return MenuDAO.temp; }
            set { MenuDAO.temp = value; }
        }
        private MenuDAO() { }

        public List<menu> GetListMenuByTable(int id)
        {
            List<menu> lMenu = new List<menu>();

            string query = "select h.tenhang, t.Slg, h.giasp, h.giasp*t.Slg as TotalPrice from tthoadon as t, hoadon as hd, hanghoa as h where t.idBill = hd.id and t.idFood = h.mahh and hd.trangthai = 0 and hd.idtable =  " + id;
            DataTable data = DataPro.Dataitem.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                menu menu = new menu(item);
                lMenu.Add(menu);
            }
            return lMenu;
        }
    }
}
