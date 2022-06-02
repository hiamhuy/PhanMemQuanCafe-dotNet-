using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class thongtinHD
    {
        public thongtinHD(int id, int billid, int foodid, int slg)
        {
            this.ID = id;
            this.BillID = billid;
            this.FoodID = foodid;
            this.Slg = slg;
        }
        public thongtinHD(System.Data.DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.FoodID = (int)row["idfood"];
            this.Slg = (int)row["slg"];
        }
        private int slg;
        private int foodID;
        private int billID;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }

        public int Slg { get => slg; set => slg = value; }
        public int FoodID { get => foodID; set => foodID = value; }
    }
}
