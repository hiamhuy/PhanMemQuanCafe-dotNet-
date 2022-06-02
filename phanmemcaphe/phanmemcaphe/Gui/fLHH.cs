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
    public partial class fLHH : Form
    {
        public fLHH()
        {
            InitializeComponent();
            loadLHH();
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
        public void loadLHH()
        {
            dtgvloaihanghoa.DataSource = LoaihanghoaDAO.Temp.danhsachLHH();
        }

        private void dtgvloaihanghoa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvloaihanghoa.CurrentCell.RowIndex;
            txtmaloaihang.Text = dtgvloaihanghoa.Rows[i].Cells[0].Value.ToString();
            txttenloaihang.Text = dtgvloaihanghoa.Rows[i].Cells[1].Value.ToString();
            txtmota.Text = dtgvloaihanghoa.Rows[i].Cells[2].Value.ToString();
        }

        private void btThemloaihh_Click(object sender, EventArgs e)
        {
            string tenloaihang = txttenloaihang.Text;
            string mota = txtmota.Text;
            

            if (txttenloaihang.Text != "" && txtmota.Text != "")
            {
                if (LoaihanghoaDAO.Temp.insertLoaiHangHoa(tenloaihang, mota))
                {
                    MessageBox.Show("Thêm Loại Hàng Hoá Thành Công ! ");
                    loadLHH();

                }
                else
                {
                    MessageBox.Show("Thêm Loại Hàng Hoá Không Thành Công ! ");
                }
            }
            else
            {
                MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
            }
        }

        private void btSualoaihh_Click(object sender, EventArgs e)
        {
            string tenloaihang = txttenloaihang.Text;
            string mota = txtmota.Text;
            try
            {
                int malhh = Convert.ToInt32(txtmaloaihang.Text);

                if (txttenloaihang.Text != "" && txtmota.Text != "")
                {
                    if (LoaihanghoaDAO.Temp.updateLoaiHangHoa(malhh, tenloaihang, mota))
                    {
                        MessageBox.Show("Sửa Loại Hàng Hoá Thành Công ! ");
                        loadLHH();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Loại Hàng Hoá Không Thành Công ! ");
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

        private void btXoaloaihh_Click(object sender, EventArgs e)
        {
            try
            {
                int malhh = Convert.ToInt32(txtmaloaihang.Text);
                if (MessageBox.Show("Bạn Thật Sự Muốn Xoá !!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (LoaihanghoaDAO.Temp.deleteLoaiHangHoa(malhh))
                    {
                        MessageBox.Show("Xoá Loại Hàng Hoá Thành Công ! ");
                        loadLHH();

                    }
                    else
                    {
                        MessageBox.Show("Xoá Loại Hàng Hoá Không Thành Công ! ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mời Nhập Mã Loại Hàng Hoá Cần Xoá !");
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
