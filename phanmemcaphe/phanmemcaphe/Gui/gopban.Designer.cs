
namespace phanmemcaphe.Gui
{
    partial class gopban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gopban));
            this.cbphai = new System.Windows.Forms.ComboBox();
            this.cbtrai = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btgop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbphai
            // 
            this.cbphai.FormattingEnabled = true;
            this.cbphai.Location = new System.Drawing.Point(21, 53);
            this.cbphai.Name = "cbphai";
            this.cbphai.Size = new System.Drawing.Size(109, 24);
            this.cbphai.TabIndex = 0;
            // 
            // cbtrai
            // 
            this.cbtrai.FormattingEnabled = true;
            this.cbtrai.Location = new System.Drawing.Point(243, 53);
            this.cbtrai.Name = "cbtrai";
            this.cbtrai.Size = new System.Drawing.Size(121, 24);
            this.cbtrai.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(143, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 47);
            this.panel1.TabIndex = 2;
            // 
            // btgop
            // 
            this.btgop.BackColor = System.Drawing.Color.Teal;
            this.btgop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btgop.BackgroundImage")));
            this.btgop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btgop.Location = new System.Drawing.Point(167, 94);
            this.btgop.Name = "btgop";
            this.btgop.Size = new System.Drawing.Size(52, 41);
            this.btgop.TabIndex = 7;
            this.btgop.UseVisualStyleBackColor = false;
            this.btgop.Click += new System.EventHandler(this.btgop_Click);
            // 
            // gopban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(376, 147);
            this.Controls.Add(this.btgop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbtrai);
            this.Controls.Add(this.cbphai);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(394, 194);
            this.MinimumSize = new System.Drawing.Size(394, 194);
            this.Name = "gopban";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gộp Bàn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbphai;
        private System.Windows.Forms.ComboBox cbtrai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btgop;
    }
}