namespace QlBangDia
{
    partial class FrmMain
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
			this.panelMenu = new System.Windows.Forms.Panel();
			this.btnAccount = new FontAwesome.Sharp.IconButton();
			this.btnDepartments = new FontAwesome.Sharp.IconButton();
			this.btnProject = new FontAwesome.Sharp.IconButton();
			this.btnScientist = new FontAwesome.Sharp.IconButton();
			this.panelLogo = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.labelHomeTitle = new System.Windows.Forms.Label();
			this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.iconButton1 = new FontAwesome.Sharp.IconButton();
			this.panelMenu.SuspendLayout();
			this.panelLogo.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panelMenu
			// 
			this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
			this.panelMenu.Controls.Add(this.iconButton1);
			this.panelMenu.Controls.Add(this.btnAccount);
			this.panelMenu.Controls.Add(this.btnDepartments);
			this.panelMenu.Controls.Add(this.btnProject);
			this.panelMenu.Controls.Add(this.btnScientist);
			this.panelMenu.Controls.Add(this.panelLogo);
			this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelMenu.Location = new System.Drawing.Point(0, 0);
			this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
			this.panelMenu.Name = "panelMenu";
			this.panelMenu.Size = new System.Drawing.Size(211, 700);
			this.panelMenu.TabIndex = 0;
			// 
			// btnAccount
			// 
			this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAccount.FlatAppearance.BorderSize = 0;
			this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAccount.ForeColor = System.Drawing.Color.Gainsboro;
			this.btnAccount.IconChar = FontAwesome.Sharp.IconChar.GrinBeamSweat;
			this.btnAccount.IconColor = System.Drawing.Color.Gainsboro;
			this.btnAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAccount.IconSize = 34;
			this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAccount.Location = new System.Drawing.Point(0, 215);
			this.btnAccount.Margin = new System.Windows.Forms.Padding(4);
			this.btnAccount.Name = "btnAccount";
			this.btnAccount.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnAccount.Size = new System.Drawing.Size(211, 49);
			this.btnAccount.TabIndex = 5;
			this.btnAccount.Text = "Thống kê doanh thu";
			this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAccount.UseVisualStyleBackColor = true;
			this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
			// 
			// btnDepartments
			// 
			this.btnDepartments.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnDepartments.FlatAppearance.BorderSize = 0;
			this.btnDepartments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDepartments.ForeColor = System.Drawing.Color.Gainsboro;
			this.btnDepartments.IconChar = FontAwesome.Sharp.IconChar.GrinBeamSweat;
			this.btnDepartments.IconColor = System.Drawing.Color.Gainsboro;
			this.btnDepartments.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnDepartments.IconSize = 34;
			this.btnDepartments.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDepartments.Location = new System.Drawing.Point(0, 166);
			this.btnDepartments.Margin = new System.Windows.Forms.Padding(4);
			this.btnDepartments.Name = "btnDepartments";
			this.btnDepartments.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnDepartments.Size = new System.Drawing.Size(211, 49);
			this.btnDepartments.TabIndex = 4;
			this.btnDepartments.Text = "Quản lý phiếu trả";
			this.btnDepartments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDepartments.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDepartments.UseVisualStyleBackColor = true;
			this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click);
			// 
			// btnProject
			// 
			this.btnProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnProject.FlatAppearance.BorderSize = 0;
			this.btnProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnProject.ForeColor = System.Drawing.Color.Gainsboro;
			this.btnProject.IconChar = FontAwesome.Sharp.IconChar.Squarespace;
			this.btnProject.IconColor = System.Drawing.Color.Gainsboro;
			this.btnProject.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnProject.IconSize = 34;
			this.btnProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProject.Location = new System.Drawing.Point(0, 117);
			this.btnProject.Margin = new System.Windows.Forms.Padding(4);
			this.btnProject.Name = "btnProject";
			this.btnProject.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnProject.Size = new System.Drawing.Size(211, 49);
			this.btnProject.TabIndex = 3;
			this.btnProject.Text = "Quản lý phiếu mượn";
			this.btnProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnProject.UseVisualStyleBackColor = true;
			this.btnProject.Click += new System.EventHandler(this.btnProject_Click);
			// 
			// btnScientist
			// 
			this.btnScientist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(77)))), ((int)(((byte)(221)))));
			this.btnScientist.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnScientist.FlatAppearance.BorderSize = 0;
			this.btnScientist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScientist.ForeColor = System.Drawing.Color.Gainsboro;
			this.btnScientist.IconChar = FontAwesome.Sharp.IconChar.ListSquares;
			this.btnScientist.IconColor = System.Drawing.Color.Gainsboro;
			this.btnScientist.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnScientist.IconSize = 34;
			this.btnScientist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnScientist.Location = new System.Drawing.Point(0, 68);
			this.btnScientist.Margin = new System.Windows.Forms.Padding(4);
			this.btnScientist.Name = "btnScientist";
			this.btnScientist.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.btnScientist.Size = new System.Drawing.Size(211, 49);
			this.btnScientist.TabIndex = 2;
			this.btnScientist.Text = "Quản lý băng đĩa";
			this.btnScientist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnScientist.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnScientist.UseVisualStyleBackColor = false;
			this.btnScientist.Click += new System.EventHandler(this.btnScientist_Click);
			// 
			// panelLogo
			// 
			this.panelLogo.Controls.Add(this.label1);
			this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLogo.Location = new System.Drawing.Point(0, 0);
			this.panelLogo.Margin = new System.Windows.Forms.Padding(4);
			this.panelLogo.Name = "panelLogo";
			this.panelLogo.Size = new System.Drawing.Size(211, 68);
			this.panelLogo.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(28, 22);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(146, 29);
			this.label1.TabIndex = 1;
			this.label1.Text = "QL Băng đĩa";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
			this.panel1.Controls.Add(this.labelHomeTitle);
			this.panel1.Controls.Add(this.iconPictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(211, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1150, 52);
			this.panel1.TabIndex = 1;
			// 
			// labelHomeTitle
			// 
			this.labelHomeTitle.AutoSize = true;
			this.labelHomeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHomeTitle.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.labelHomeTitle.Location = new System.Drawing.Point(72, 11);
			this.labelHomeTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelHomeTitle.Name = "labelHomeTitle";
			this.labelHomeTitle.Size = new System.Drawing.Size(78, 29);
			this.labelHomeTitle.TabIndex = 1;
			this.labelHomeTitle.Text = "Home";
			// 
			// iconPictureBox1
			// 
			this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
			this.iconPictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.iconPictureBox1.ForeColor = System.Drawing.Color.Salmon;
			this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Home;
			this.iconPictureBox1.IconColor = System.Drawing.Color.Salmon;
			this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconPictureBox1.IconSize = 39;
			this.iconPictureBox1.Location = new System.Drawing.Point(25, 6);
			this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(4);
			this.iconPictureBox1.Name = "iconPictureBox1";
			this.iconPictureBox1.Size = new System.Drawing.Size(43, 39);
			this.iconPictureBox1.TabIndex = 0;
			this.iconPictureBox1.TabStop = false;
			// 
			// panelMain
			// 
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelMain.Location = new System.Drawing.Point(211, 52);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1150, 648);
			this.panelMain.TabIndex = 2;
			// 
			// iconButton1
			// 
			this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton1.FlatAppearance.BorderSize = 0;
			this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton1.ForeColor = System.Drawing.Color.Gainsboro;
			this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.GrinBeamSweat;
			this.iconButton1.IconColor = System.Drawing.Color.Gainsboro;
			this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.iconButton1.IconSize = 34;
			this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton1.Location = new System.Drawing.Point(0, 264);
			this.iconButton1.Margin = new System.Windows.Forms.Padding(4);
			this.iconButton1.Name = "iconButton1";
			this.iconButton1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.iconButton1.Size = new System.Drawing.Size(211, 49);
			this.iconButton1.TabIndex = 6;
			this.iconButton1.Text = "Quản lý người dùng";
			this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton1.UseVisualStyleBackColor = true;
			this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1361, 700);
			this.Controls.Add(this.panelMain);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panelMenu);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmMain";
			this.Text = "Form1";
			this.panelMenu.ResumeLayout(false);
			this.panelLogo.ResumeLayout(false);
			this.panelLogo.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnDepartments;
        private FontAwesome.Sharp.IconButton btnProject;
        private FontAwesome.Sharp.IconButton btnScientist;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label labelHomeTitle;
        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconButton btnAccount;
		private FontAwesome.Sharp.IconButton iconButton1;
	}
}

