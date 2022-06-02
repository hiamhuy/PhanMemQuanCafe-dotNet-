using phanmemcaphe.DAO;
using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using execl = Microsoft.Office.Interop.Excel;

namespace phanmemcaphe
{
    public partial class fThongke : Form
    {
        
       /* SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2DF8P82\SQLEXPRESS;Initial Catalog=QuanCafe;Integrated Security=True");*/
        public fThongke()
        {
            InitializeComponent();
            loadDateTimePicker();

        }
        #region effect
        private void btBH_Click(object sender, EventArgs e)
        {
            string tentk = " ";
            string matk = " ";
            if (login(tentk, matk))
            {
                taikhoanDTO loginAccount = TaikhoanDAO.Temp.GetAccountByUsename(tentk);

                fBanHang banhang = new fBanHang(loginAccount);
                this.Hide();
                banhang.ShowDialog();
            }
        }

        private void btQLNV_Click(object sender, EventArgs e)
        {
            fQLNV ql = new fQLNV();
            this.Hide();
            ql.ShowDialog();
        }



        private void btHH_Click(object sender, EventArgs e)
        {
            fLHH lhh = new fLHH();
            this.Hide();
            lhh.ShowDialog();
        }

        private void btHanghoa_Click(object sender, EventArgs e)
        {
            fhanghoa hanghoa = new fhanghoa();
            this.Hide();
            hanghoa.ShowDialog();
        }

        private void btQLTK_Click(object sender, EventArgs e)
        {
            QLTK qltk = new QLTK();
            this.Hide();
            qltk.ShowDialog();
        }

        private void btBan_Click(object sender, EventArgs e)
        {
            fBan ban = new fBan();
            this.Hide();
            ban.ShowDialog();
        }

        private void btTK_Click(object sender, EventArgs e)
        {

        }

        private void btTrangchu_Click(object sender, EventArgs e)
        {
            string tentk = " ";
            string matk = " ";
            if (login(tentk, matk))
            {
                taikhoanDTO loginAccount = TaikhoanDAO.Temp.GetAccountByUsename(tentk);

                fMain f = new fMain(loginAccount);
                this.Hide();
                f.ShowDialog();
            }
        }
        bool login(string tentk, string matk)
        {
            return TaikhoanDAO.Temp.login(tentk, matk);
        }
        #endregion
        void loadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
        }
        void showTTHD(DateTime checkIn, DateTime checkOut)
        {
            dtgvThongKe.DataSource = hoadonDAO.Temp.getBillListByDate(checkIn, checkOut);
        }
        void showTotalPrice(DateTime checkIn, DateTime checkOut)
        {

            dtgvThongKe.DataSource = hoadonDAO.Temp.getTotalPrice(checkIn,checkOut);
        }
        void tinhSum()
        {
            /*SqlCommand comm = new SqlCommand("select SUM(totalPrice) from hoadon", conn);
            conn.Open();
            SqlDataReader rd = comm.ExecuteReader();
            float sum = 0;
            if (rd.Read())
            {
                sum = float.Parse(rd[0].ToString());
                conn.Close();
            }
            conn.Close();

            label6.Text += " " + float.Parse(sum.ToString()) + " VNĐ";*/
            
        }
        private void btThongKe_Click(object sender, EventArgs e)
        {
            showTTHD(dateTimePicker1.Value, dateTimePicker2.Value);

          
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showTotalPrice(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            execl.Application app = new execl.Application();
            execl.Workbook work = app.Workbooks.Add();
            execl.Worksheet sheet = null;
            app.Visible = true;
            sheet = work.Sheets["sheet1"];
            sheet = work.ActiveSheet;
            
            for (int i = 0; i < dtgvThongKe.Columns.Count; i++)
            {
                sheet.Cells[1, i+1] = dtgvThongKe.Columns[i].HeaderText.Replace("0:00:00"," ");
            }
            for(int i = 0; i < dtgvThongKe.Rows.Count - 1; i++)
            {
                for(int j = 0; j < dtgvThongKe.Columns.Count; j++)
                {
                    sheet.Cells[i + 2, j + 1] = dtgvThongKe.Rows[i].Cells[j].Value.ToString().Replace("0:00:00"," ");
                }    
            }
            
            sheet.Columns.AutoFit();
        }
    }

}
