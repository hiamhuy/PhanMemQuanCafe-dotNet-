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

namespace phanmemcaphe.Gui
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }


        private void btHUY_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btDN_Click_1(object sender, EventArgs e)
        {
            string tentk = txtTK.Text;
            string matk = txtmk.Text;
            if (login(tentk, matk))
            {
                taikhoanDTO loginAccount = TaikhoanDAO.Temp.GetAccountByUsename(tentk);

                fMain f = new fMain(loginAccount);
                this.Hide();
                f.ShowDialog();
            }
            else
                MessageBox.Show("Sai Tên Tài Khoản Hoặc Mật Khẩu ! ", "Thông Báo");

           
        }
        bool login(string tentk, string matk)
        {
            return TaikhoanDAO.Temp.login(tentk, matk);
        }

        private void ckPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckPass.Checked)
            {
                txtmk.UseSystemPasswordChar = false;
            }
            else
            {
                txtmk.UseSystemPasswordChar = true;
            }
        }

        private void txtTK_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtmk.Focus();
            }    
        }

        private void txtmk_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btDN_Click_1(sender, e);
            }    
        }
    }
}
