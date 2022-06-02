using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class menu
    {
        public menu(string foodname, int slg, float price, float totalprice = 0)
        {
            this.Tenhang = foodname;
            this.Slg = slg;
            this.giasp = price;
            this.TotalPrice = totalprice;
        }

        public menu(DataRow row)
        {
            this.Tenhang = row["tenhang"].ToString();
            this.Slg = (int)row["slg"];
            this.Giasp = (float)Convert.ToDouble(row["giasp"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
        private string tenhang;
        private int slg;
        private float giasp;
        private float totalPrice;

        public string Tenhang { get => tenhang; set => tenhang = value; }
        public int Slg { get => slg; set => slg = value; }
        public float Giasp { get => giasp; set => giasp = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
