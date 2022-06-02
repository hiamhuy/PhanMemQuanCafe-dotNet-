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
    public partial class fhanghoa : Form
    {
        public fhanghoa()
        {
            InitializeComponent();
            LoadHangHoa();
            loadDanhSach(cbloaihh);
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
            fQLNV qlnv = new fQLNV();
            this.Hide();
            qlnv.ShowDialog();
        }

        private void btHH_Click(object sender, EventArgs e)
        {
            fLHH lhh = new fLHH();
            this.Hide();
            lhh.ShowDialog();
        }

        private void btHanghoa_Click(object sender, EventArgs e)
        {
            
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
        private void label2_Click(object sender, EventArgs e)
        {
         
        }
        #endregion

        public void LoadHangHoa()
        {
            dtgvHangHoa.DataSource = HanghoaDAO.Temp.danhSachHangHoa();
        }
        void loadDanhSach(ComboBox cb)
        {
            cb.DataSource = LoaihanghoaDAO.Temp.danhsachLHH();
            cb.DisplayMember = "tenlh";
            cb.ValueMember = "malh";
        }

        private void dtgvHangHoa_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvHangHoa.CurrentCell.RowIndex;
            txtmahh.Text = dtgvHangHoa.Rows[i].Cells[0].Value.ToString();
            txttenhh.Text = dtgvHangHoa.Rows[i].Cells[1].Value.ToString();
            txtSlghh.Text = dtgvHangHoa.Rows[i].Cells[3].Value.ToString();
            cbloaihh.SelectedValue = dtgvHangHoa.Rows[i].Cells[2].Value;
            txtgiahh.Text = dtgvHangHoa.Rows[i].Cells[4].Value.ToString();
        }

        private void btthemhh_Click(object sender, EventArgs e)
        {
            string tenhang = txttenhh.Text;
            int malh = (cbloaihh.SelectedItem as loaihanghoaDTO).Malh;
            int solg = Convert.ToInt32(txtSlghh.Text);
            int giasp = Convert.ToInt32(txtgiahh.Text);

            if (txttenhh.Text != "" && cbloaihh.Text != "" && txtSlghh.Text != "" && txtgiahh.Text != "")
            {
                if (HanghoaDAO.Temp.insertHangHoa(tenhang, solg, giasp, malh))
                {
                    MessageBox.Show("Thêm Hàng Hoá Thành Công ! ");
                    LoadHangHoa();

                }
                else
                {
                    MessageBox.Show("Thêm Hàng Hoá Không Thành Công ! ");
                }
            }
            else
            {
                MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
            }
        }

        private void btsuahh_Click(object sender, EventArgs e)
        {
            string tenhang = txttenhh.Text;
            int malh = (cbloaihh.SelectedItem as loaihanghoaDTO).Malh;
            int solg = Convert.ToInt32(txtSlghh.Text);
            int giasp = Convert.ToInt32(txtgiahh.Text);
            try
            {
                int mahh = Convert.ToInt32(txtmahh.Text);

                if (txttenhh.Text != "" && cbloaihh.Text != "" && txtSlghh.Text != "" && txtgiahh.Text != "")
                {
                    if (HanghoaDAO.Temp.updateHangHoa(mahh, tenhang, solg, giasp, malh))
                    {
                        MessageBox.Show("Sửa Hàng Hoá Thành Công ! ");
                        LoadHangHoa();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Hàng Hoá Không Thành Công ! ");
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

        private void btxoahh_Click(object sender, EventArgs e)
        {
            try
            {
                int mahh = Convert.ToInt32(txtmahh.Text);
                if (MessageBox.Show("Bạn Thật Sự Muốn Xoá !!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (HanghoaDAO.Temp.deleteHangHoa(mahh))
                    {
                        MessageBox.Show("Xoá Hàng Hoá Thành Công ! ");
                        LoadHangHoa();

                    }
                    else
                    {
                        MessageBox.Show("Xoá Hàng Hoá Không Thành Công ! ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mời Nhập Mã Hàng Hoá Cần Xoá !");
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
