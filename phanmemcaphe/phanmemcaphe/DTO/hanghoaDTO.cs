using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class hanghoaDTO
    {
        private int mahh;
        private string tenhang;
        private int malh;
        private int solg;
        private float giasp;

        public hanghoaDTO(int ma, string ten,  int slg, float gia, int mal)
        {
            this.Mahh = ma;
            this.Tenhang = ten;
            this.Solg = slg;
            this.Giasp = gia;
            this.Malh = mal;

        }

        public hanghoaDTO(DataRow row)
        {
            this.Mahh = (int)row["mahh"];
            this.Tenhang = row["tenhang"].ToString();     
            this.Solg = (int)row["solg"];
            this.Giasp = (float)Convert.ToDouble(row["giasp"].ToString());
            this.Malh = (int)row["malh"];

        }

        public int Mahh { get => mahh; set => mahh = value; }
        public string Tenhang { get => tenhang; set => tenhang = value; }
        public int Malh { get => malh; set => malh = value; }
        public int Solg { get => solg; set => solg = value; }
        public float Giasp { get => giasp; set => giasp = value; }
    }
}
