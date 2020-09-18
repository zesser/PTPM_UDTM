using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DevExpress.XtraExport;

namespace DoAnCNPM
{
    public partial class frm_SanPham : Form
    {
        SanPham_BLL sanphams = new SanPham_BLL();
        public NHANVIEN nv;
        int flat = 0;
        public frm_SanPham()
        {
            InitializeComponent();
        }

        private void frm_TimKiemSanPham_Load(object sender, EventArgs e)
        {
            gcTimKiemSP.DataSource = sanphams.LoadSanPham();
        }

        private void LoadBang()
        {
            gcTimKiemSP.DataSource = sanphams.LoadSanPham();
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            gcTimKiemSP.DataSource = sanphams.LoadSPTheoTen(searchControl1.Text);
        }

        private void btnLuuSP_Click(object sender, EventArgs e)
        {
            if (flat == 1)
            {
                ThemSP();
            }
            else if (flat == 2)
            {
                SuaSP();
            }
            SetReadOnly(false);
            flat = 0;
        }

        private void SuaSP()
        {
            int id = gvTimKiemSP.FocusedRowHandle;
            try
            {

                string tensp = txtTenSP.Text;
                decimal dongia = decimal.Parse(txtDonGia.Text);
                string maph = txtPhong.Text;
                string maloai = txtLoai.Text;
                string baohanh = txtBaoHanh.Text;
                string mota = txtMoTa.Text;
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Thông tin khách hàng ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                    sanphams.SuaSanPham(txtMaSP.Text, tensp, maph, maloai, mota, baohanh, dongia);
                    LoadBang();
                    MessageBox.Show("SửaThành Công ", "Thông Báo");

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Sản phẩm");
            }
        }

        private void ThemSP()
        {
            int id = gvTimKiemSP.FocusedRowHandle;
            try
            {

                string tensp = txtTenSP.Text;
                decimal dongia = decimal.Parse(txtDonGia.Text);
                string maph = txtPhong.Text;
                string maloai = txtLoai.Text;
                string baohanh = txtBaoHanh.Text;
                string mota = txtMoTa.Text;
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thêm Thông tin khách hàng ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                    sanphams.ThemSanPham("SP", tensp, maph, maloai, mota, baohanh, dongia);
                    LoadBang();
                    MessageBox.Show("Thêm Thành Công ", "Thông Báo");

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Sản phẩm");
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            SetReadOnly(true);
            flat = 1;
        }

        private void gcTimKiemSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            

        }
        private void SetReadOnly(bool t)
        {
            txtMaSP.ReadOnly = !t;
            txtDonGia.ReadOnly = !t;
            txtTenSP.ReadOnly = !t;
            txtBaoHanh.ReadOnly = !t;
            txtMoTa.ReadOnly = !t;
            
        }

        private void gcTimKiemSP_Click(object sender, EventArgs e)
        {

        }

        private void gvTimKiemSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvTimKiemSP.RowCount != 0)
                {
                    txtMaSP.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "MASP").ToString();
                    txtTenSP.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "TENSP").ToString();
                    txtPhong.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "MAPH").ToString();
                    txtLoai.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "MALOAI").ToString();
                    txtMoTa.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "MOTA").ToString();
                    txtBaoHanh.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "BAOHANH").ToString();
                    txtDonGia.Text = gvTimKiemSP.GetRowCellValue(gvTimKiemSP.FocusedRowHandle, "GIA").ToString();
                    // txtSLHientai.EditValue = Convert.ToString(sp_bll.GetSoLiuong(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString()));
                }
            }
            catch
            {
            }
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void txtTenSP_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            SetReadOnly(false);
            flat = 2;
        }
    }
}
