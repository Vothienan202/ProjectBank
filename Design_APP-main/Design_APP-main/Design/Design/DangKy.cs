using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Design
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }

        dbcontrol sql = new dbcontrol();

        void register()
        {
            sql.Param("@TenDangNhap", txt_TenDangNhap.Text);
            sql.Param("@MatKhau", txt_MatKhau.Text);
            sql.Param("@SoTaiKhoan", txt_SoTaiKhoan.Text);
            sql.Param("@SoDienThoai", txt_SDT.Text);
            sql.Param("@CCCD", txt_CCCD.Text);
            sql.Param("@GioiTinh", txt_GioiTinh.Text);
            sql.Param("@DiaChi", txt_DiaChi.Text);
            sql.Param("@ChiNhanh", txt_ChiNhanh.Text);
            sql.Param("@HoTen", txt_HoTen.Text);
            sql.query("insert into Table (TenDangNhap,MatKhau,SoTaiKhoan,SoDienThoai,CCCD,GioiTinh,DiaChi,ChiNhanh,HoTen)" +
                "values (@TenDangNhap,@MatKhau,@SoTaiKhoan,@SoDienThoai,@CCCD,@GioiTinh,@DiaChi,@ChiNhanh,@HoTen)");
            if (sql.Check4error(true))
            {
                return;
            }
            MessageBox.Show("Registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            register();
        }
    }
 }

