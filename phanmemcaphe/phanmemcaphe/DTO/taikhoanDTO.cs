using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class taikhoanDTO
    {
        private string tentk;
        private string matk;
        private string tenht;
        private int kieutk;

        public taikhoanDTO(string ten, string mat, string tenhient, int kieu)
        {
            this.Tentk = ten;
            this.Matk = mat;
            this.Tenht = tenhient;
            this.Kieutk = kieu;
        }

        public taikhoanDTO(DataRow row)
        {
            this.Tentk = row["tentk"].ToString();
            this.Matk = row["matk"].ToString();
            this.Tenht = row["tenht"].ToString();
            this.Kieutk = (int)row["kieutk"];
        }

        public string Tentk { get => tentk; set => tentk = value; }
        public string Matk { get => matk; set => matk = value; }
        public string Tenht { get => tenht; set => tenht = value; }
        public int Kieutk { get => kieutk; set => kieutk = value; }
    }
}
