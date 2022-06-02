using phanmemcaphe.DAO;
using phanmemcaphe.DTO;
using phanmemcaphe.Gui;
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
    public partial class fBanHang : Form
    {
        private taikhoanDTO loginAccount;
        public taikhoanDTO LoginAccount 
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Kieutk); }
        }
        DataTable table = new DataTable();
        private List<menu> dsHH = new List<menu>();
        private int numberOfItemPage = 0;
        private int numberOfPrint = 0;
        public fBanHang(taikhoanDTO taikhoan)
        {
            InitializeComponent();
            this.LoginAccount = taikhoan;

            
            LoadTable();
            loadcbLHH(cbTheloai);
            loadDateTime();




        }
        void ChangeAccount(int kieutk)
        {
            btTrangchu.Visible = kieutk == 1;
            btQLNV.Visible = kieutk == 1;
           
            btHH.Visible = kieutk == 1;
            btQLTK.Visible = kieutk == 1;
            btBan.Visible = kieutk == 1;
            btTK.Visible = kieutk == 1;
            btHanghoa.Visible = kieutk == 1;

            lbnhanvien.Text += " " + loginAccount.Tenht + " ";
        }

        void loadDateTime()
        {
            ngayhoadon.Text += " " + DateTime.Now.ToShortDateString() + " ";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        #region effect
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
            fhanghoa hh = new fhanghoa();
            this.Hide();
            hh.ShowDialog();
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

        private void btBH_Click(object sender, EventArgs e)
        {

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

        void loadcbLHH(ComboBox cb)
        {
            cb.DataSource = LoaihanghoaDAO.Temp.danhsachLHH();
            cb.DisplayMember = "tenlh";
            cb.ValueMember = "malh";
        }
        private void LoadTable()
        {
            fplBan.Controls.Clear();
            List<banDTO> tableList = BanDAO.Temp.LoadTableList();

            foreach (banDTO item in tableList)
            {

                Button btn = new Button() { Width = BanDAO.TableWidth, Height = BanDAO.TableHeight };
                btn.Text = item.Tenban;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.BackColor = Color.Teal;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.Thuoctinh)
                {
                    case "Trống":
                        btn.BackgroundImage = Image.FromFile(@"D:\ttcs\thuctap\thuctap\anh\ban01.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.ForeColor = Color.White;
                        break;
                    default:
                        btn.BackgroundImage = Image.FromFile(@"D:\ttcs\thuctap\thuctap\anh\ban03.png");
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        break;

                }

                fplBan.Controls.Add(btn);
            }

        }
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as banDTO).Maban;
            lvOder.Tag = (sender as Button).Tag;
            showHoaDon(tableID);

        }
        void showHoaDon(int id)
        {
            lvOder.Items.Clear();
            dsHH.Clear();
            float totalPrice = 0;
            List<menu> listBillInfo = MenuDAO.Temp.GetListMenuByTable(id);

            foreach (menu item in listBillInfo)
            {
                ListViewItem lvItem = new ListViewItem(item.Tenhang.ToString());
                lvItem.SubItems.Add(item.Slg.ToString());

                lvItem.SubItems.Add(item.TotalPrice.ToString());
                dsHH.Add(item);

                totalPrice += item.TotalPrice;

                lvOder.Items.Add(lvItem);

            }
            txtTongTien.Text = totalPrice.ToString();

            int a = (int)(nDUPDOWN.Value);

            float SellPrice = ((float)(totalPrice - ((totalPrice / 100) * a)));

            txtPhaitra.Text = SellPrice.ToString();

            if (txtKhachdua.Text != "")
            {
                float KhachDuaPrice = float.Parse(txtKhachdua.Text);

                float RePrice = (float)(KhachDuaPrice - SellPrice);

                txtTralai.Text = RePrice.ToString();
            }
        }

        void showFood()
        {
            /* menuGV.DataSource = MenuDAO.Temp.danhSach();*/
            lvMenu.Items.Clear();

            List<hanghoaDTO> foodslist = HanghoaDAO.Temp.danhSachHangHoa();

            
/*            lvMenu.View = View.Details;
            lvMenu.GridLines = true;
            lvMenu.FullRowSelect = true;
            lvMenu.Columns.Add("Tên Món", 150);
            lvMenu.Columns.Add("Giá", 70);*/

            foreach (hanghoaDTO item in foodslist)
            {
                ListViewItem lvitem = new ListViewItem(item.Tenhang.ToString());
                lvitem.SubItems.Add(item.Giasp.ToString());
                lvMenu.Items.Add(lvitem);
            }
        }
        void hienThiTheoDS(int malh)
        {

            lvMenu.Items.Clear();
            List<hanghoaDTO> listfOOD = HanghoaDAO.Temp.hangHoaCB(malh);
            foreach (hanghoaDTO item in listfOOD)
            {
                ListViewItem itemlv = new ListViewItem(item.Tenhang.ToString());

                itemlv.SubItems.Add(item.Giasp.ToString());
                lvMenu.Items.Add(itemlv);
            }
            cbhh.DataSource = listfOOD;
            cbhh.DisplayMember = "tenhang";

        }

        private void cbTheloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cbo = sender as ComboBox;
            if (cbo.SelectedItem == null)
                return;
            loaihanghoaDTO seleted = cbo.SelectedItem as loaihanghoaDTO;
            id = seleted.Malh;
            hienThiTheoDS(id);
        }
 


        private void fBanHang_Load(object sender, EventArgs e)
        {
            showFood();
        }
        #region c
        private void cbTheloai_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int malh = 0;
            hienThiTheoDS(malh);
        }

        private void btGopban_Click(object sender, EventArgs e)
        {
            gopban gb = new gopban();
            gb.ShowDialog();
            LoadTable();
        }

        private void btChuyenBan_Click(object sender, EventArgs e)
        {
            chuyenban cb = new chuyenban();
            cb.ShowDialog();
            LoadTable();
        }

        private void btThemmon_Click(object sender, EventArgs e)
        {
            try
            {
                banDTO table = lvOder.Tag as banDTO;

                int idhoadon = hoadonDAO.Temp.GetUnCheckBillIdByTableId(table.Maban);
                int idhanghoa = (cbhh.SelectedItem as hanghoaDTO).Mahh;
                int themgiam = (int)nbThemgiam.Value;


                if (idhoadon == -1)
                {
                    hoadonDAO.Temp.insertBill(table.Maban);
                    thongTinHoaDonDAO.Temp.insertBillInfo(hoadonDAO.Temp.GetMaxIDBill(), idhanghoa, themgiam);
                }
                else
                {
                    thongTinHoaDonDAO.Temp.insertBillInfo(idhoadon, idhanghoa, themgiam);

                }
                showHoaDon(table.Maban);
                LoadTable();
            }
            catch
            {
                MessageBox.Show("Vui Lòng Chọn Bàn !");
            }

        }
    
        private void btGiammon_Click(object sender, EventArgs e)
        {
            banDTO table = lvOder.Tag as banDTO;

            try
            {
                int idBill = hoadonDAO.Temp.GetUnCheckBillIdByTableId(table.Maban);
                int idname = (cbhh.SelectedItem as hanghoaDTO).Mahh;
                int count = (int)nbThemgiam.Value;

                if (idBill == -1)
                {
                    MessageBox.Show("Món Chưa Được Gọi ! Vui Lòng Gọi Món ");

                }
                else
                {
                    thongTinHoaDonDAO.Temp.DeleteBillInfo(idBill, idname, count);
                }
                showHoaDon(table.Maban);
            }
            catch
            {
                MessageBox.Show("Vui Lòng Chọn Bàn !");
            }
        }

        private void btThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                banDTO table = lvOder.Tag as banDTO;
                int idBill = hoadonDAO.Temp.GetUnCheckBillIdByTableId(table.Maban);

                int discount = (int)nDUPDOWN.Value;

                double totalPrice = Convert.ToDouble(txtTongTien.Text);

                double finalTotalPrice = (totalPrice - ((totalPrice / 100) * discount));
                if (idBill != -1)
                {

                    if (MessageBox.Show("Bạn Có Chắc Thanh Toán Hoá Đơn Cho " + table.Tenban + "!", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        printDocument1.Print();
                        hoadonDAO.Temp.CheckOut(idBill, discount, (float)finalTotalPrice);
                        showHoaDon(table.Maban);
                        LoadTable();
                    }

                }
            }catch
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán !");
            }

        }
        #endregion

        private void lvMenu_Click(object sender, EventArgs e)
        {
            cbhh.Text = lvMenu.SelectedItems[0].SubItems[0].Text;
            
        }
        #region setbutton
        private void nDUPDOWN_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                float totalPrice = float.Parse(txtTongTien.Text);

                int a = (int)(nDUPDOWN.Value);

                if (a != 0)
                {
                    float SellPrice = ((float)(totalPrice - ((totalPrice / 100) * a)));

                    txtPhaitra.Text = SellPrice.ToString();
                }
            }
            catch
            {
                nDUPDOWN.Value = 0;
                MessageBox.Show("Vui lòng nhập đúng định dạng!");
            }
        }

        private void txtPhaitra_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float totalPrice = float.Parse(txtTongTien.Text);

                int a = (int)(nDUPDOWN.Value);

                if (a != 0)
                {
                    float SellPrice = ((float)(totalPrice - ((totalPrice / 100) * a)));

                    txtPhaitra.Text = SellPrice.ToString();
                }
            }
            catch
            {
                nDUPDOWN.Value = 0;
                MessageBox.Show("Vui lòng nhập đúng định dạng!");
            }
        }

        private void txtKhachdua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                float SellPrice = float.Parse(txtPhaitra.Text);
                if (txtKhachdua.Text != "")
                {
                    float KhachDuaPrice = float.Parse(txtKhachdua.Text);

                    float RePrice = (float)(KhachDuaPrice - SellPrice);

                    txtTralai.Text = RePrice.ToString();
                }
            }
            catch
            {
                txtKhachdua.Text = "";
                MessageBox.Show("Vui lòng nhập đúng định dạng!");
            }
        }
        #endregion
        #region design
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Image.FromFile(@"D:\ttcs\thuctap\thuctap\anh\logo22cfe.png");
            e.Graphics.DrawImage(image, 250, 0, image.Width, image.Height);

            e.Graphics.DrawString("Ngày Tạo : " + DateTime.Now, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 350));

            e.Graphics.DrawString("Người Tạo : " + loginAccount.Tenht, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 375));
            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 390));

            e.Graphics.DrawString("Tên Món", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 415));

            e.Graphics.DrawString("Số Lượng", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(312, 415));

            e.Graphics.DrawString("Giá Tiền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, 415));

            e.Graphics.DrawString("Thành Tiền", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(720, 415));

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, 435));

            int yPos = 470;
            for (int i = numberOfPrint; i < dsHH.Count; i++)
            {
                numberOfItemPage++;

                if (numberOfItemPage <= 20)
                {
                    numberOfPrint++;

                    if (numberOfPrint <= dsHH.Count)
                    {
                        e.Graphics.DrawString(dsHH[i].Tenhang, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, yPos));

                        e.Graphics.DrawString(dsHH[i].Slg.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(312, yPos));

                        e.Graphics.DrawString(dsHH[i].Giasp.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos));

                        e.Graphics.DrawString(dsHH[i].TotalPrice.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(720, yPos));
                        yPos += 30;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                else
                {
                    numberOfItemPage = 0;
                    e.HasMorePages = true;
                    return;
                }
            }

            e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------------------------------------- ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(25, yPos));

            e.Graphics.DrawString("Tổng Tiền : " + txtTongTien.Text + " VND ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos + 30));

            e.Graphics.DrawString("Chiết Khấu : " + nDUPDOWN.Value + " % ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos + 60));

            e.Graphics.DrawString("Tiền Phải Trả : " + txtPhaitra.Text + " VND ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos + 90));

            e.Graphics.DrawString("Tiền Khách Đưa : " + txtKhachdua.Text + " VND ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos + 120));

            e.Graphics.DrawString("Tiền Phải Trả : " + txtTralai.Text + " VND ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(540, yPos + 150));

            e.Graphics.DrawString("~~~~~ CÁM ƠN VÀ HẸN GẶP LẠI ! ~~~~~", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Point(270, yPos + 230));

            numberOfItemPage = 0;
            numberOfPrint = 0;

        }

        private void btIN_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát khỏi chương trình", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
