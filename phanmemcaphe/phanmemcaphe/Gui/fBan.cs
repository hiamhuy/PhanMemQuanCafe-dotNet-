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
    public partial class fBan : Form
    {
        public fBan()
        {
            InitializeComponent();
            loadList();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }
        #region effect
        private void btBH_Click(object sender, EventArgs e)
        {
            string tentk = "admin";
            string matk = "admin";
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

        }

        private void btTK_Click(object sender, EventArgs e)
        {
            fThongke tk = new fThongke();
            this.Hide();
            tk.ShowDialog();
        }

        private void btTrangchu_Click(object sender, EventArgs e)
        {
            string tentk = "admin";
            string matk = "admin";
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

        #region show
        public void loadList()
        {
            dtgvDSBan.DataSource = BanDAO.Temp.danhSachBan();
        }

        #endregion

        private void dtgvDSBan_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvDSBan.CurrentCell.RowIndex;
            txtmaban.Text = dtgvDSBan.Rows[i].Cells[0].Value.ToString();
            txttenban.Text = dtgvDSBan.Rows[i].Cells[1].Value.ToString();
            cbtrangthaiban.Text = dtgvDSBan.Rows[i].Cells[2].Value.ToString();
        }

        private void btThemban_Click(object sender, EventArgs e)
        {
            string tenban = txttenban.Text;
            string thuoctinh = cbtrangthaiban.Text;

            if (txttenban.Text != "" && cbtrangthaiban.Text != "")
            {
                if (BanDAO.Temp.insertBan(tenban, thuoctinh))
                {
                    MessageBox.Show("Thêm Bàn Thành Công ! ");
                    loadList();

                }
                else
                {
                    MessageBox.Show("Thêm Bàn Không Thành Công ! ");
                }
            } else
            {
                MessageBox.Show("Mời Bạn Điền Đầy Đủ Thông Tin");
            }    

        }

        private void btSuaBan_Click(object sender, EventArgs e)
        {
            string tenban = txttenban.Text;
            string thuoctinh = cbtrangthaiban.Text;
            try
            {
                int maban = Convert.ToInt32(txtmaban.Text);
           
                if (txttenban.Text != " " && cbtrangthaiban.Text != " " && txtmaban.Text != " ")
                {
                    if (BanDAO.Temp.updateBan(maban, tenban, thuoctinh))
                    {
                        MessageBox.Show("Sửa Bàn Thành Công ! ");
                        loadList();

                    }
                    else
                    {
                        MessageBox.Show("Sửa Bàn Không Thành Công ! ");
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

        private void btXoaBan_Click(object sender, EventArgs e)
        {
            try
            {
                int maban = Convert.ToInt32(txtmaban.Text);
                if (MessageBox.Show("Bạn Thật Sự Muốn Xoá !!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (BanDAO.Temp.deleteBan(maban))
                    {
                        MessageBox.Show("Xoá Bàn Thành Công ! ");
                        loadList();

                    }
                    else
                    {
                        MessageBox.Show("Xoá Bàn Không Thành Công ! ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mời Nhập Mã Bàn Cần Xoá !");
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

