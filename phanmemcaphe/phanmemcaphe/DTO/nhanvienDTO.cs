using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    class nhanvienDTO
    {
        private int manv;
        private string tennv;
        private string gt;
        private string chucvu;
        private DateTime ngayvaolam;
        private string diachi;
        private int sdt;

        public nhanvienDTO(int ma, string ten, string gtinh, string cv, DateTime nvl, string dc, int sdth)
        {
            this.Manv = ma;
            this.Tennv = ten;
            this.Gt = gtinh;
            this.Chucvu = cv;
            this.Ngayvaolam = nvl;
            this.Diachi = dc;
            this.Sdt = sdth;
        }

        public nhanvienDTO(DataRow row)
        {
            this.Manv = (int)row["manv"];
            this.Tennv = row["tennv"].ToString();
            this.Gt = row["gt"].ToString();
            this.Chucvu = row["chucvu"].ToString();
            this.Ngayvaolam = (DateTime)row["ngayvaolam"];
            this.Diachi = row["diachi"].ToString();
            this.Sdt = (int)row["sdt"];
        }

        public int Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gt { get => gt; set => gt = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public DateTime Ngayvaolam { get => ngayvaolam; set => ngayvaolam = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int Sdt { get => sdt; set => sdt = value; }
    }
}
