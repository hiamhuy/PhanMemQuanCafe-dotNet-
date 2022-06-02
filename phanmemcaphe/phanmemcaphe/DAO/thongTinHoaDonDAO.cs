using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DAO
{
    public class thongTinHoaDonDAO
    {
        private static thongTinHoaDonDAO temp;

        public static thongTinHoaDonDAO Temp
        {
            get { if (temp == null) thongTinHoaDonDAO.temp = new thongTinHoaDonDAO(); return temp; }
            set { thongTinHoaDonDAO.temp = value; }
        }
        private thongTinHoaDonDAO() { }

        public void insertBillInfo(int idBill, int idFood, int Slg)
        {
            DataPro.Dataitem.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @Slg", new object[] { idBill, idFood, Slg });
        }
        public void DeleteBillInfo(int idBill, int idFood, int Slg)
        {
            DataPro.Dataitem.ExecuteNonQuery("USP_DeleteBillInfo @idBill , @idFood , @Slg", new object[] { idBill, idFood, Slg });
        }
        public void ClearBillInfo(int idBill, int idFood, int Slg)
        {
            DataPro.Dataitem.ExecuteNonQuery("USP_ClearBillInfo @idBill , @idFood , @Slg", new object[] { idBill, idFood, Slg });
        }
        public void DeleteBillInfoByFoodID(int id)
        {

            DataPro.Dataitem.ExecuteNonQuery("delete tthoadon where idFood = " + id);

        }
        public List<thongtinHD> GetListBillInfo(int id)
        {
            List<thongtinHD> ListBillInfo = new List<thongtinHD>();

            DataTable data = DataPro.Dataitem.ExecuteQuery("select * from tthoadon where idBill = " + id);

            foreach (DataRow item in data.Rows)
            {
                thongtinHD info = new thongtinHD(item);
                ListBillInfo.Add(info);

            }
            return ListBillInfo;
        }
    }
}
