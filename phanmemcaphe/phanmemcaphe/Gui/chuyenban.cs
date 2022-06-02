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
    public partial class chuyenban : Form
    {
        public chuyenban()
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
        private void btchuyen_Click(object sender, EventArgs e)
        {
            int ban1 = (cbtrai.SelectedItem as banDTO).Maban;
            int ban2 = (cbphai.SelectedItem as banDTO).Maban;
            if (MessageBox.Show("Chuyển Bàn Thành Công!", "Thông Báo", MessageBoxButtons.OK) == System.Windows.Forms.DialogResult.OK)
            {
                BanDAO.Temp.SwichTable(ban1, ban2);
            }
            this.Hide();
        }
    }
}
