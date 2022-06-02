using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanmemcaphe.DTO
{
    public class HoaDon
    {
        public HoaDon(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int tt, int giamgia = 0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Trangthai = tt;
            this.Giagia = giamgia;
        }

        public HoaDon(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.Trangthai = (int)row["trangthai"];

            if (row["giagia"].ToString() != "")
                this.Giagia = (int)row["giagia"];
        }

        private int iD;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int trangthai;

        private int giagia;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }



        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

       
        public int Trangthai { get => trangthai; set => trangthai = value; }
        public int Giagia { get => giagia; set => giagia = value; }
    }
}
