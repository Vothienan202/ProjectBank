using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        dbcontrol sql = new dbcontrol();

        bool LoginCheck()
        {
            sql.Param("@TenDangNhap", txt_TenDangNhap.Text);
            sql.Param("@MatKhau", txt_MatKhau.Text);
            sql.query("select count(*) from Table where TenDangNhap = @TenDangNhap and MatKhau = @MatKhau");
            if ((int)sql.dt.Rows[0][0] == 1)
            {
                return true;
            }
            MessageBox.Show("Invalid username or password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            if (LoginCheck() == true)
            {
                TrangChu tc = new TrangChu();
                Hide();
                tc.ShowDialog();
            }
        }

        private void llb_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
        }
    }
}

