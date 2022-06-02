using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class banDTO
    {
        private int maban;
        private string tenban;
        private string thuoctinh;

        public banDTO(int ma, string ten, string tt)
        {
            this.Maban = ma;
            this.Tenban = ten;
            this.Thuoctinh = tt;
        }
        public banDTO(DataRow row)
        {
            this.Maban = (int)row["maban"];
            this.Tenban = row["tenban"].ToString();
            this.Thuoctinh = row["thuoctinh"].ToString();

        }

        public int Maban { get => maban; set => maban = value; }
        public string Tenban { get => tenban; set => tenban = value; }
        public string Thuoctinh { get => thuoctinh; set => thuoctinh = value; }
    }
}
