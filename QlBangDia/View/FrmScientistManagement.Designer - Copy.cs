namespace QlBangDia.View
{
    partial class FrmQlNguoiDung
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
			this.dtgvNguoiDung = new System.Windows.Forms.DataGridView();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtTim = new System.Windows.Forms.TextBox();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtHoTen = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtMa = new System.Windows.Forms.TextBox();
			this.cbbVaiTro = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTenDN = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSDT = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dtgvNguoiDung)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtgvNguoiDung
			// 
			this.dtgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtgvNguoiDung.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dtgvNguoiDung.Location = new System.Drawing.Point(0, 264);
			this.dtgvNguoiDung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dtgvNguoiDung.Name = "dtgvNguoiDung";
			this.dtgvNguoiDung.RowHeadersWidth = 51;
			this.dtgvNguoiDung.RowTemplate.Height = 24;
			this.dtgvNguoiDung.Size = new System.Drawing.Size(1149, 383);
			this.dtgvNguoiDung.TabIndex = 1;
			this.dtgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNguoiDung_CellClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtTim);
			this.groupBox3.Controls.Add(this.button5);
			this.groupBox3.Location = new System.Drawing.Point(12, 178);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(912, 80);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tìm kiếm";
			// 
			// txtTim
			// 
			this.txtTim.Location = new System.Drawing.Point(31, 36);
			this.txtTim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTim.Name = "txtTim";
			this.txtTim.Size = new System.Drawing.Size(583, 22);
			this.txtTim.TabIndex = 4;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(716, 32);
			this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(128, 30);
			this.button5.TabIndex = 3;
			this.button5.Text = "Tìm";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtHoTen);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.txtMa);
			this.groupBox1.Controls.Add(this.cbbVaiTro);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtMatKhau);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtTenDN);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtSDT);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(912, 161);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thuộc tính";
			// 
			// txtHoTen
			// 
			this.txtHoTen.Location = new System.Drawing.Point(491, 13);
			this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtHoTen.Name = "txtHoTen";
			this.txtHoTen.Size = new System.Drawing.Size(177, 22);
			this.txtHoTen.TabIndex = 17;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(21, 19);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Mã người dùng";
			// 
			// txtMa
			// 
			this.txtMa.Location = new System.Drawing.Point(140, 15);
			this.txtMa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMa.Name = "txtMa";
			this.txtMa.ReadOnly = true;
			this.txtMa.Size = new System.Drawing.Size(177, 22);
			this.txtMa.TabIndex = 15;
			// 
			// cbbVaiTro
			// 
			this.cbbVaiTro.FormattingEnabled = true;
			this.cbbVaiTro.Items.AddRange(new object[] {
            "Admin",
            "User"});
			this.cbbVaiTro.Location = new System.Drawing.Point(491, 107);
			this.cbbVaiTro.Name = "cbbVaiTro";
			this.cbbVaiTro.Size = new System.Drawing.Size(177, 24);
			this.cbbVaiTro.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(372, 110);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 16);
			this.label5.TabIndex = 12;
			this.label5.Text = "Vai trò";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(372, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Họ tên";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(372, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Mật khẩu";
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Location = new System.Drawing.Point(491, 58);
			this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(177, 22);
			this.txtMatKhau.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Tên đăng nhập";
			// 
			// txtTenDN
			// 
			this.txtTenDN.Location = new System.Drawing.Point(140, 58);
			this.txtTenDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTenDN.Name = "txtTenDN";
			this.txtTenDN.Size = new System.Drawing.Size(177, 22);
			this.txtTenDN.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Số điện thoại";
			// 
			// txtSDT
			// 
			this.txtSDT.Location = new System.Drawing.Point(140, 98);
			this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSDT.Name = "txtSDT";
			this.txtSDT.Size = new System.Drawing.Size(177, 22);
			this.txtSDT.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Controls.Add(this.button4);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Location = new System.Drawing.Point(961, 12);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(177, 247);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Chức năng";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(27, 134);
			this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 37);
			this.button3.TabIndex = 2;
			this.button3.Text = "Xóa";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(27, 196);
			this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(128, 37);
			this.button4.TabIndex = 13;
			this.button4.Text = "Làm mới";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(27, 76);
			this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 37);
			this.button2.TabIndex = 1;
			this.button2.Text = "Sửa";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(27, 22);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 37);
			this.button1.TabIndex = 0;
			this.button1.Text = "Thêm";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmQlNguoiDung
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1149, 647);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dtgvNguoiDung);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmQlNguoiDung";
			this.Text = "FrmScientistManagement";
			this.Load += new System.EventHandler(this.FrmQlNguoiDung_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgvNguoiDung)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvNguoiDung;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbVaiTro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMa;
		private System.Windows.Forms.TextBox txtHoTen;
	}
}