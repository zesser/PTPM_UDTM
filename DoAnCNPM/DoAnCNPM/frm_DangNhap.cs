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
using System.Data;
using DAL_BLL;

using DevExpress.XtraBars.Alerter;

namespace DoAnCNPM
{
    public partial class frm_DangNhap : Form
    {
        DangNhap dn = new DangNhap();
        NHANVIEN nv = new NHANVIEN(); 
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTenTaiKhoan.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống tài khoản");
                this.txtTenTaiKhoan.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống mật khẩu" );
                this.txtMatKhau.Focus();
                return;
            }

            int kq = QL_NguoiDung.Check_Config();
            if (kq == 0)
            {
                try
                {
                    nv = dn.getNV(txtTenTaiKhoan.Text);
                    if (nv != null)
                    {
                        MessageBox.Show("ĐĂNG NHẬP THÀNH CÔNG");
                        FormMenu from = new FormMenu();
                        from.nv = nv;
                        this.Hide();
                        from.Show();
                    }
                    else
                    {
                        MessageBox.Show("ĐĂNG NHẬP THẤT BẠI");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối");
                }
            }
            else if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");
                frmConfig cn = new frmConfig();
                cn.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");
                frmConfig cn = new frmConfig();
                cn.Show();
                this.Hide();
            }
            
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
