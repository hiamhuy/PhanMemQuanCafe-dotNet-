using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    class khachhangDTO
    {
        private int makh;
        private string tenkh;
        private string diachi;
        private int sdt;

        public khachhangDTO(int ma, string ten, string dc, int sodt)
        {
            this.Makh = ma;
            this.Tenkh = ten;
            this.Diachi = dc;
            this.Sdt = sodt;
        }
        public khachhangDTO(DataRow row)
        {
            this.Makh = (int)row["makh"];
            this.Tenkh = row["tenkh"].ToString();
            this.Diachi = row["diachi"].ToString();
            this.Sdt = (int)row["sdt"];
        }


        public int Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int Sdt { get => sdt; set => sdt = value; }
    }
}
