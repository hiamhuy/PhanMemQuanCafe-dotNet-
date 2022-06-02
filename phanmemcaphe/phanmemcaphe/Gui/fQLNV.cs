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
    public partial class fQLNV : Form
    {
        public fQLNV()
        {
            InitializeComponent();
            LoadQLNV();
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



        private void btHH_Click(object sender, EventArgs e)
        {
            fLHH hh = new fLHH();
            this.Hide();
            hh.ShowDialog();
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
        public void LoadQLNV()
        {
            dtgvqlnhanvien.DataSource = NhanvienDAO.Temp.danhSachNhanVien();
        }

        private void dtgvqlnhanvien_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvqlnhanvien.CurrentCell.RowIndex;
            txtmanhanvien.Text = dtgvqlnhanvien.Rows[i].Cells[0].Value.ToString();
            txttennhanvien.Text = dtgvqlnhanvien.Rows[i].Cells[1].Value.ToString();
            txtgioitinh.Text = dtgvqlnhanvien.Rows[i].Cells[2].Value.ToString();
            dtpkngayvaolam.Text = dtgvqlnhanvien.Rows[i].Cells[4].Value.ToString().Replace(" 12:00:00 AM", "");
            txtChucvu.Text = dtgvqlnhanvien.Rows[i].Cells[3].Value.ToString();
            txtdiachi.Text = dtgvqlnhanvien.Rows[i].Cells[5].Value.ToString();
            txtsdtnv.Text = dtgvqlnhanvien.Rows[i].Cells[6].Value.ToString();
        }

        private void btThemnhanvien_Click(object sender, EventArgs e)
        {
            string tennv = txttennhanvien.Text;
            int sdt = Convert.ToInt32(txtsdtnv.Text);
            string chucvu = txtChucvu.Text;
            string diachi = txtdiachi.Text;
            DateTime nvl = Convert.ToDateTime(dtpkngayvaolam.Text);
            string gioitinh = txtgioitinh.Text;


            if (txttennhanvien.Text != "" && txtsdtnv.Text != "" && txtChucvu.Text != ""&& txtdiachi.Text!="" && dtpkngayvaolam.Text !=""&& txtgioitinh.Text!="")
            {
                if (NhanvienDAO.Temp.insertNhanVien(tennv, gioitinh, chucvu, nvl, diachi, sdt))
                {
                    MessageBox.Show("Thêm Nhân Viên Thành Công ! ");
                    LoadQLNV();

                }
                else
                {
                    MessageBox.Show("Thêm Nhân Viên Không Thành Công ! ");
                }
            }
            else
            {
                MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
            }
        }

        private void btSuanhanvien_Click(object sender, EventArgs e)
        {
            string tennv = txttennhanvien.Text;
            string chucvu = txtChucvu.Text;
            string diachi = txtdiachi.Text;
            DateTime nvl = Convert.ToDateTime(dtpkngayvaolam.Text);
            string gioitinh = txtgioitinh.Text;
            try
            {
                int manv = Convert.ToInt32(txtmanhanvien.Text);
                int sdt = Convert.ToInt32(txtsdtnv.Text);
                if (txttennhanvien.Text != "" && txtsdtnv.Text != "" && txtChucvu.Text != "" && txtdiachi.Text != "" && dtpkngayvaolam.Text != "" && txtgioitinh.Text != "")
                {
                    if (NhanvienDAO.Temp.updateNhanVien(manv, tennv, gioitinh, chucvu, nvl, diachi, sdt))
                    {
                        MessageBox.Show("Sửa Thông Tin Nhân Viên Thành Công ! ");
                        LoadQLNV();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Thông Tin Nhân Viên Không Thành Công ! ");
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

        private void btXoanv_Click(object sender, EventArgs e)
        {
            try
            {
                int manv = Convert.ToInt32(txtmanhanvien.Text);
                if (MessageBox.Show("Bạn Thật Sự Muốn Xoá !!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (NhanvienDAO.Temp.deleteNhanVien(manv))
                    {
                        MessageBox.Show("Xoá Thông Tin Nhân Viên Thành Công ! ");
                        LoadQLNV();

                    }
                    else
                    {
                        MessageBox.Show("Xoá Thông Tin Nhân Viên Không Thành Công ! ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mời Nhập Mã Nhân Viên Cần Xoá !");
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
