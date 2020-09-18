using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DAL_BLL;
using System.Data.SqlClient;

namespace DoAnCNPM
{
    public partial class frmPhieuNhapHang : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhap_BLL pnbll = new PhieuNhap_BLL();
        public NHANVIEN nv;
        int flat = 0;
        public frmPhieuNhapHang()
        {
            InitializeComponent();
            changeDate();
        }

        private void frmPhieuNhapHang_Load(object sender, EventArgs e)
        {
            loadcboNCC(); loadcboSP();  resizeDgv();
            txtNguoiLap.Text = nv.MANV;
            txtTenNguoiLap.Text = nv.TENNV;
        }

        public void resizeDgv()
        {
            dgvChiTietPN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPN.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        public void loadcboNCC()
        {
            cboNCC.DataSource = pnbll.loadNCC();
            cboNCC.DisplayMember = "MANCC";
            cboNCC.ValueMember = "MANCC";
            cboNCC.SelectedIndex = 1; cboNCC.SelectedIndex = 0;
        }

        private void LoadALL()
        {
            dgvPhieuNhap.DataSource = pnbll.loadPhieuNhapALL();
        }
        public void loadcboSP()
        {
            cboSanPham.DataSource = pnbll.loadSanPham();
            cboSanPham.DisplayMember = "MASP";
            cboSanPham.ValueMember = "MASP";
            cboSanPham.SelectedIndex = 1; cboNCC.SelectedIndex = 0;
        }

        public void hideTextbox()
        { 
            
        }

        public void enableTextbox()
        {
            dgvPhieuNhap.ClearSelection();  dgvPhieuNhap.Enabled = false;

            txtNguoiLap.Text = nv.MANV; //Lấy từ nhân viên đang sử dụng 
            txtTenNguoiLap.Text = pnbll.loadTenNV(txtNguoiLap.Text.ToString());

            txtSoPhieu.Text = ""; txtThanhTien.Text = ""; cboNCC.SelectedIndex = 0; dtpNgayNhap.Value = DateTime.Today;

            txtSoPhieu.Enabled = dtpNgayNhap.Enabled = cboNCC.Enabled = txtTenNCC.Enabled = true; //Textbox mã phiếu nên tự tăng

            txtSoPhieu.Focus();
        }

        public void loadPhieuNhap(DateTime ngaybd, DateTime ngaykt)
        {
            dgvPhieuNhap.DataSource = pnbll.loadPhieuNhap(ngaybd, ngaykt);

        }

        public void changeDate()
        {
            DateTime ngaybandau = DateTime.Parse(dtpTuNgay.Value.ToShortDateString());
            DateTime ngayketthuc = DateTime.Parse(dtpDenNgay.Value.ToShortDateString());

            if (DateTime.Compare(ngaybandau, ngayketthuc) == 0 || (DateTime.Compare(ngaybandau, ngayketthuc) == -1))
            {
                loadPhieuNhap(ngaybandau, ngayketthuc);
            }
        }

        private void cboNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            String mancc = cboNCC.SelectedValue.ToString();

            txtTenNCC.Text = pnbll.loadTenNCC(mancc);
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            changeDate();           
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            changeDate();
        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            double thanhtien = 0;
            if (e.RowIndex >= 0)
            {
                txtSoPhieu.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
                txtSoPhieu2.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString().Trim();
                string[] date = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString().Split(' ');
                dtpNgayNhap.Value = DateTime.Parse(date[0]);

                txtNguoiLap.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString().Trim();
                txtTenNguoiLap.Text = pnbll.loadTenNV(txtNguoiLap.Text.ToString().Trim());

                cboNCC.SelectedValue = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();

                String mapn = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString().Trim();
                dgvChiTietPN.DataSource = pnbll.loadChiTietPN(mapn);

                thanhtien += dgvChiTietPN.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDouble(t.Cells[4].Value));
                txtThanhTien.Text = thanhtien.ToString().Trim();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flat = 1;
            SetReadOnly(true);
        }

        private void ThemNH()
        {
            String mapn, manv, mancc;
            DateTime ngaylap;
            if (cboNCC.Text.Trim().Length > 0)
            {
                manv = nv.MANV;
                mancc = cboNCC.SelectedValue.ToString();
                ngaylap = DateTime.Now;
                DialogResult rs = MessageBox.Show("Bạn có muốn thêm phiếu nhập mới?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        pnbll.themPhieuNhap("PN", manv, mancc, ngaylap);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeDate();
                    }
                    catch
                    {
                        MessageBox.Show("Đã tồn tại phiếu nhập này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            String mapn = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa " + mapn, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    pnbll.xoaPhieuNhap(mapn);
                    MessageBox.Show("Xóa thành công phiếu " + mapn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changeDate();
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flat = 2;
            SetReadOnly(false);
        }

        private void dgvChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                cboSanPham.SelectedValue = dgvChiTietPN.CurrentRow.Cells[0].Value.ToString();

                txtTenSP.Text = dgvChiTietPN.CurrentRow.Cells[1].Value.ToString().Trim();

                txtSoLuong.Text = dgvChiTietPN.CurrentRow.Cells[2].Value.ToString().Trim();

                txtDonGia.Text = dgvChiTietPN.CurrentRow.Cells[3].Value.ToString().Trim();

                txtThanhTien2.Text = dgvChiTietPN.CurrentRow.Cells[4].Value.ToString().Trim();
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            String masp = cboSanPham.SelectedValue.ToString();

            txtTenSP.Text = pnbll.loadTenSP(masp);
            txtDonGia.Text = pnbll.loadDonGia(masp);
        }

        private void btnThem2_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thêm Vào Phiếu Nhập ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (cboSanPham.SelectedIndex != -1 && txtSoLuong.Text != string.Empty &&
                        txtThanhTien.Text != string.Empty && txtDonGia.Text != string.Empty)
                    {
                        string mapn = txtSoPhieu2.Text;
                        string masp = cboSanPham.SelectedValue.ToString();
                        int soluong = Convert.ToInt32(txtSoLuong.Text);
                        double dongia = Convert.ToDouble(txtDonGia.Text);
                        double thanhtien = Convert.ToDouble(txtThanhTien.Text);

                        if (pnbll.KiemTraTrung_CTPN(mapn, masp) == true)
                        {
                            pnbll.themChiTietPN(mapn, masp, soluong, dongia, soluong * dongia);
                            MessageBox.Show("Thêm Thành Công Vào Phiếu Nhập " + mapn, "Thông báo");
                            dgvChiTietPN.DataSource = pnbll.loadChiTietPN(mapn);
                            // update số lượng sản phẩm lại nè

                            // update lại tổng tiền của hóa đơn

                        }
                        else
                        {
                            MessageBox.Show("Phiếu Nhập Đã Tồn Tại Sản Phẩm " + masp, "Thông báo");
                        }
                    }
                }
            }
            catch
            {

            }


        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            String masp = cboSanPham.SelectedValue.ToString();
            String mapn = txtSoPhieu2.Text;
            DialogResult rs = MessageBox.Show("Bạn có muốn xóa " + masp + " của " + mapn, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                try
                {
                    pnbll.xoaChiTietPN(mapn, masp);
                    MessageBox.Show("Xóa thành công phiếu " + mapn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvChiTietPN.DataSource = pnbll.loadChiTietPN(mapn);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            String mapn = txtSoPhieu2.Text;
            String masp = dgvChiTietPN.CurrentRow.Cells[0].Value.ToString().Trim();
            int soluong = int.Parse(txtSoLuong.Text);
            if (int.Parse(txtSoLuong.Text) > 0)
            {
                DialogResult rs = MessageBox.Show("Bạn có muốn sửa " + masp + " của " + mapn, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    double dongia = double.Parse(txtDonGia.Text);
                    double thanhtien = soluong * dongia;
                    try
                    {
                        pnbll.suaChiTietPN(mapn, masp, soluong, thanhtien);
                        MessageBox.Show("Sửa thành công phiếu " + masp + " của " + mapn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dgvChiTietPN.DataSource = pnbll.loadChiTietPN(mapn);
                    }
                    catch
                    {
                        MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != string.Empty && txtDonGia.Text != string.Empty)
            {
                txtThanhTien2.Text = int.Parse(txtSoLuong.Text) * double.Parse(txtDonGia.Text) + "";
            }
        }

        private void dgvPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNguoiLap_TextChanged(object sender, EventArgs e)
        {

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (flat == 1)
            {
                ThemNH();
                
            }
            else if (flat == 2)
            {
                SuaNH();

            }
            flat = 0;
            SetReadOnly(false);

        }

        private void SetReadOnly(bool v)
        {
            cboNCC.Enabled = v;

        }

        private void SuaNH()
        {
            String mapn, manv, mancc;
            DateTime ngaylap;
            if (cboNCC.Text.Trim().Length > 0)
            {
                mapn = txtSoPhieu.Text.ToString();
                manv = txtNguoiLap.Text.ToString();
                mancc = cboNCC.SelectedValue.ToString();
                ngaylap = dtpNgayNhap.Value;
                DialogResult rs = MessageBox.Show("Bạn có muốn sửa " + mapn, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    try
                    {
                        pnbll.suaPhieuNhap(mapn, manv, mancc, ngaylap);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        changeDate();
                    }
                    catch
                    {
                        MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}