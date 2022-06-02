
namespace phanmemcaphe.Gui
{
    partial class fDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtmk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btHUY = new System.Windows.Forms.Button();
            this.btDN = new System.Windows.Forms.Button();
            this.ckPass = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDangnhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btHUY);
            this.panel1.Controls.Add(this.btDN);
            this.panel1.Controls.Add(this.ckPass);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(636, 400);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Location = new System.Drawing.Point(254, 184);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 111);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtmk);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Location = new System.Drawing.Point(3, 57);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(315, 40);
            this.panel7.TabIndex = 1;
            // 
            // txtmk
            // 
            this.txtmk.Location = new System.Drawing.Point(151, 7);
            this.txtmk.Name = "txtmk";
            this.txtmk.Size = new System.Drawing.Size(154, 22);
            this.txtmk.TabIndex = 3;
            this.txtmk.UseSystemPasswordChar = true;
            this.txtmk.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmk_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật Khẩu :";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtTK);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Location = new System.Drawing.Point(3, 13);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(315, 38);
            this.panel6.TabIndex = 0;
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(151, 11);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(154, 22);
            this.txtTK.TabIndex = 3;
            this.txtTK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTK_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Đăng Nhập :";
            // 
            // btHUY
            // 
            this.btHUY.BackColor = System.Drawing.Color.DeepPink;
            this.btHUY.Location = new System.Drawing.Point(527, 345);
            this.btHUY.Name = "btHUY";
            this.btHUY.Size = new System.Drawing.Size(93, 32);
            this.btHUY.TabIndex = 3;
            this.btHUY.Text = "Huỷ";
            this.btHUY.UseVisualStyleBackColor = false;
            this.btHUY.Click += new System.EventHandler(this.btHUY_Click_1);
            // 
            // btDN
            // 
            this.btDN.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btDN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btDN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDN.Location = new System.Drawing.Point(349, 335);
            this.btDN.Name = "btDN";
            this.btDN.Size = new System.Drawing.Size(116, 42);
            this.btDN.TabIndex = 2;
            this.btDN.Text = "Đăng Nhập";
            this.btDN.UseVisualStyleBackColor = false;
            this.btDN.Click += new System.EventHandler(this.btDN_Click_1);
            // 
            // ckPass
            // 
            this.ckPass.AutoSize = true;
            this.ckPass.Location = new System.Drawing.Point(421, 301);
            this.ckPass.Name = "ckPass";
            this.ckPass.Size = new System.Drawing.Size(151, 21);
            this.ckPass.TabIndex = 1;
            this.ckPass.Text = "Hiển Thị Mật Khẩu ";
            this.ckPass.UseVisualStyleBackColor = true;
            this.ckPass.CheckedChanged += new System.EventHandler(this.ckPass_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 349);
            this.panel4.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(287, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 169);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDangnhap);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(263, 202);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 54);
            this.panel2.TabIndex = 0;
            // 
            // txtDangnhap
            // 
            this.txtDangnhap.Location = new System.Drawing.Point(161, 16);
            this.txtDangnhap.Multiline = true;
            this.txtDangnhap.Name = "txtDangnhap";
            this.txtDangnhap.Size = new System.Drawing.Size(176, 25);
            this.txtDangnhap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(268, 418);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Location = new System.Drawing.Point(-4, -6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(264, 421);
            this.panel5.TabIndex = 1;
            // 
            // fDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(660, 414);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDangNhap";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtDangnhap;
        private System.Windows.Forms.Button btDN;
        private System.Windows.Forms.CheckBox ckPass;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtmk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btHUY;
    }
}