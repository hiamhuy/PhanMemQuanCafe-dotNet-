using phanmemcaphe.DAO;
using phanmemcaphe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace phanmemcaphe
{
    public partial class fMain : Form
    {
        private taikhoanDTO loginAccount;

        internal taikhoanDTO LoginAccount
        { 
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Kieutk); }
        }

        public fMain(taikhoanDTO taikhoan)
        {
            InitializeComponent();
            this.LoginAccount = taikhoan;
        }
        void ChangeAccount(int kieutk)
        {
            btQLNV.Visible = kieutk == 1;
           
            btHH.Visible = kieutk == 1;
            button1.Visible = kieutk == 1;
            button2.Visible = kieutk == 1;
            button3.Visible = kieutk == 1;
            button4.Visible = kieutk == 1;

            lbht.Text += " : (" + loginAccount.Tenht + ") ";
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void btBH_Click(object sender, EventArgs e)
        {
            string tentk = "huy2";
            string matk = "huy2";
            if (login(tentk, matk))
            {
                taikhoanDTO loginAccount = TaikhoanDAO.Temp.GetAccountByUsename(tentk);

                fBanHang banhang = new fBanHang(loginAccount);
                this.Hide();
                banhang.ShowDialog();
            }
        }
        bool login(string tentk, string matk)
        {
            return TaikhoanDAO.Temp.login(tentk, matk);
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

        private void button1_Click(object sender, EventArgs e)
        {
            fhanghoa hanghoa = new fhanghoa();
            this.Hide();
            hanghoa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLTK tk = new QLTK();
            this.Hide();
            tk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fBan ban = new fBan();
            this.Hide();
            ban.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fThongke tt = new fThongke();
            this.Hide();
            tt.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
