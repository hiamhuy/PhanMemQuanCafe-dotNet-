using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class loaihanghoaDTO
    {
        private int malh;
        private string tenlh;
        private string mota;

        public loaihanghoaDTO(int ma, string ten, string mt)
        {
            this.Malh = ma;
            this.Tenlh = ten;
            this.Mota = mt;
        }
        public loaihanghoaDTO(DataRow row)
        {
            this.Malh = (int)row["malh"];
            this.Tenlh = row["tenlh"].ToString();
            this.Mota = row["mota"].ToString();
        }
        public int Malh { get => malh; set => malh = value; }
        public string Tenlh { get => tenlh; set => tenlh = value; }
        public string Mota { get => mota; set => mota = value; }
    }
}
