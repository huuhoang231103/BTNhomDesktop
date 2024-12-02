using QlBangDia.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlBangDia
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            ShowChildForm(new FrmQLBangDia());
        }
        public void ShowChildForm(Form childForm)
        {
            panelMain.Controls.Clear();

            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnScientist_Click(object sender, EventArgs e)
        {
            btnScientist.BackColor = Color.FromArgb(95, 77, 221);

            btnProject.BackColor = Color.FromArgb(31, 30, 68);
            btnDepartments.BackColor = Color.FromArgb(31, 30, 68);
            btnAccount.BackColor = Color.FromArgb(31, 30, 68);
			iconButton1.BackColor = Color.FromArgb(31, 30, 68);
			ShowChildForm(new FrmQLBangDia());
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            btnProject.BackColor = Color.FromArgb(95, 77, 221);

            btnScientist.BackColor = Color.FromArgb(31, 30, 68);
            btnDepartments.BackColor = Color.FromArgb(31, 30, 68);
            btnAccount.BackColor = Color.FromArgb(31, 30, 68);
			iconButton1.BackColor = Color.FromArgb(31, 30, 68);
			ShowChildForm(new FrmPhieuMuon());
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            btnAccount.BackColor = Color.FromArgb(95, 77, 221);

            btnProject.BackColor = Color.FromArgb(31, 30, 68);
            btnScientist.BackColor = Color.FromArgb(31, 30, 68);
            btnDepartments.BackColor = Color.FromArgb(31, 30, 68);
			iconButton1.BackColor = Color.FromArgb(31, 30, 68);
			ShowChildForm(new FrmThongKe());
        }

        private void btnDepartments_Click(object sender, EventArgs e)
        {
            btnDepartments.BackColor = Color.FromArgb(95, 77, 221);

            btnProject.BackColor = Color.FromArgb(31, 30, 68);
            btnScientist.BackColor = Color.FromArgb(31, 30, 68);
            btnAccount.BackColor = Color.FromArgb(31, 30, 68);
			iconButton1.BackColor = Color.FromArgb(31, 30, 68);

            ShowChildForm(new FrmPhieuTra());
        }

		private void iconButton1_Click(object sender, EventArgs e)
		{
			iconButton1.BackColor = Color.FromArgb(95, 77, 221);

			btnProject.BackColor = Color.FromArgb(31, 30, 68);
			btnScientist.BackColor = Color.FromArgb(31, 30, 68);
			btnAccount.BackColor = Color.FromArgb(31, 30, 68);
			btnDepartments.BackColor = Color.FromArgb(31, 30, 68);

			ShowChildForm(new FrmQlNguoiDung());
		}
	}
}
