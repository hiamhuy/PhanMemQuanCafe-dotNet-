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
    public partial class gopban : Form
    {
        public gopban()
        {
            InitializeComponent();
            loadcbLHH(cbphai);
            loadcbLHH(cbtrai);
        }
        void loadcbLHH(ComboBox cb)
        {
            cb.DataSource = BanDAO.Temp.danhSachBan();
            cb.DisplayMember = "tenban";
        }
        private void btgop_Click(object sender, EventArgs e)
        {
            int ban1 = (cbtrai.SelectedItem as banDTO).Maban;
            int ban2 = (cbphai.SelectedItem as banDTO).Maban;
            if (MessageBox.Show("Gộp Bàn Thành Công!", "Thông Báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                BanDAO.Temp.gopTable(ban2, ban1);
            }
            this.Hide();
        }
    }
}
