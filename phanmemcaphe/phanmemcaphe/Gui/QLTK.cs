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
    public partial class QLTK : Form
    {

        public QLTK()
        {
            InitializeComponent();
            LoadQLTK();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
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

        private void btBan_Click(object sender, EventArgs e)
        {
            fBan ban = new fBan();
            this.Hide();
            ban.ShowDialog();
        }

        private void btTKe_Click(object sender, EventArgs e)
        {
            fThongke tk = new fThongke();
            this.Hide();
            tk.ShowDialog();
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
        public void LoadQLTK()
        {
            dtgvQLTK.DataSource = TaikhoanDAO.Temp.danhSachTK();
        }

        private void dtgvQLTK_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvQLTK.CurrentCell.RowIndex;
            txttendangnhap.Text = dtgvQLTK.Rows[i].Cells[0].Value.ToString();
            txtmatkhau.Text = dtgvQLTK.Rows[i].Cells[1].Value.ToString();
            txttenhienthi.Text = dtgvQLTK.Rows[i].Cells[2].Value.ToString();
            txttheloai.Text = dtgvQLTK.Rows[i].Cells[3].Value.ToString();
        }

        private void btThemtk_Click(object sender, EventArgs e)
        {

            string matkhau = txtmatkhau.Text;
            int loaitk = Convert.ToInt32(txttheloai.Text);
            string tenhienthi = txttenhienthi.Text;
            try
            {
                string tentk = txttendangnhap.Text;
                if (txttendangnhap.Text != "" && txtmatkhau.Text != "" && txttheloai.Text != "" && txttenhienthi.Text != "")
                {
                    if (TaikhoanDAO.Temp.insertTaiKhoan(tentk, matkhau, tenhienthi, loaitk))
                    {
                        MessageBox.Show("Tạo Tài Khoản Thành Công ! ");
                        LoadQLTK();

                    }
                    else
                    {
                        MessageBox.Show("Tạo Tài Khoản Không Thành Công ! ");
                    }
                }
                else
                {
                    MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
                }
            }
            catch
            {
                MessageBox.Show("Tên Đăng Nhập Đã Tồn Tại!");
            }
        }

        private void btSuatk_Click(object sender, EventArgs e)
        {
            try
            {
                string tentk = txttendangnhap.Text;
                string matkhau = txtmatkhau.Text;
                int loaitk = Convert.ToInt32(txttheloai.Text);
                string tenhienthi = txttenhienthi.Text;

                if (txttendangnhap.Text != "" && txtmatkhau.Text != "" && txttheloai.Text != "" && txttenhienthi.Text != "")
                {
                    if (TaikhoanDAO.Temp.updateTaiKhoan(tentk, matkhau, tenhienthi, loaitk))
                    {
                        MessageBox.Show("Sửa Thông Tin Tài Khoản Thành Công ! ");
                        LoadQLTK();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Thông Tin Tài Khoản Không Thành Công ! ");
                    }
                }
                else
                {
                    MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
                }
            }
            catch
            {
                MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
            }
        }

        private void btXoatk_Click(object sender, EventArgs e)
        {
            try
            {
                string tentk = txttendangnhap.Text;
                if (MessageBox.Show("Bạn Thật Sự Muốn Xoá !!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (TaikhoanDAO.Temp.deleteTaiKhoan(tentk))
                    {
                        MessageBox.Show("Xoá Tài Khoản Thành Công ! ");
                        LoadQLTK();

                    }
                    else
                    {
                        MessageBox.Show("Xoá Tài Khoản Không Thành Công ! ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mời Nhập Tên Đăng Nhập Cần Xoá !");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}


