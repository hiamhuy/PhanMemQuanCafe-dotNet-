using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    public class hoadonDAO
    {
        private static hoadonDAO temp;

        public static hoadonDAO Temp
        {
            get { if (temp == null) hoadonDAO.temp = new hoadonDAO(); return temp; }
            set { hoadonDAO.temp = value; }
        }
        private hoadonDAO() { }
        public void insertBill(int id)
        {
            DataPro.Dataitem.ExecuteNonQuery("USP_InsertBill @idtable", new object[] { id });
        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE hoadon SET datecheckout = GETDATE(), trangthai = 1, " + "giagia = " + discount + ", totalPrice = " + totalPrice + " WHERE id = " + id;
            DataPro.Dataitem.ExecuteNonQuery(query);
        }
        public int GetUnCheckBillIdByTableId(int id)
        {
            DataTable data = DataPro.Dataitem.ExecuteQuery("select * from hoadon where idtable = " + id + " and trangthai = 0");
            if (data.Rows.Count > 0)
            {
                HoaDon bill = new HoaDon(data.Rows[0]);
                return bill.ID;
            }

            return -1;
        }
        public DataTable getBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataPro.Dataitem.ExecuteQuery("USP_getListBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });

        }
        public DataTable getTotalPrice(DateTime checkIn, DateTime checkOut)
        {
            return DataPro.Dataitem.ExecuteQuery("USP_getTotalPrice @checkIn , @checkOut", new object[] { checkIn, checkOut });

        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataPro.Dataitem.ExecuteScalar("select MAX(id) from hoadon");

            }
            catch
            {
                return 1;
            }
        }
        public int tinhSum()
        {

            try
            {
                return (int)DataPro.Dataitem.ExecuteScalar("select SUM(totalPrice) from hoadon");

            }
            catch
            {
                return 1;
            }
        }
    }
}
