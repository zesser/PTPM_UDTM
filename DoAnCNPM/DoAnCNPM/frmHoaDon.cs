using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_BLL;
using DevExpress.XtraGrid.Views.Card.ViewInfo;
using DevExpress.XtraRichEdit.API.Native;

namespace DoAnCNPM
{
    public partial class frmHoaDon : Form
    {
        HoaDon_BLL hd_bll = new HoaDon_BLL();
        public NHANVIEN nv;
        int flat = 0;
        public frmHoaDon()
        {
            InitializeComponent();
        }
        private void frmHoaDon_Load_1(object sender, EventArgs e)
        {
            loadDataHD();
            loadKhachHang_cbo();
            LoadCbo_TrangTrai();
            dtpNgayLap.Value = DateTime.Now;
            loadCboSP();
            loadCboHD();
            txtMaNV.Text = nv.MANV;
        }
        // hóa đơn
        private void loadDataHD()
        {
            gcHoaDon.DataSource = hd_bll.LoadHoaDon_BLL();
        }
        void loadKhachHang_cbo()
        {
            cboMaKH.DataSource = hd_bll.loadKhachHang_BLL();
            cboMaKH.DisplayMember = "TENKHACHHANG";
            cboMaKH.ValueMember = "MAKHACHHANG";
            cboMaKH.SelectedIndex = -1;
        }
        private void loadCboHD()
        {
            cboHoaDon.DataSource = hd_bll.LoadHoaDon_BLL();
            cboHoaDon.DisplayMember = "MAHD";
            cboHoaDon.ValueMember = "MAHD";
            cboHoaDon.SelectedIndex = -1;
        }
        private void loadCboSP()
        {
            cboMaSP.DataSource = hd_bll.LoadSanPham_BLL();
            cboMaSP.DisplayMember = "TENSP";
            cboMaSP.ValueMember = "MASP";
            cboMaSP.SelectedIndex = -1;
        }
        void LoadCbo_TrangTrai()
        {
            cboTrangThai.Items.Add("Tiếp Nhận");
            cboTrangThai.Items.Add("Đang chờ giao hàng");
            cboTrangThai.Items.Add("Hoàng Thành");
            cboTrangThai.SelectedIndex = -1;
        }
        private void btnLoadMa_Click(object sender, EventArgs e)
        {
            if(txtmagiamgia.Text != string.Empty)
            {
                if(Convert.ToString(hd_bll.LayChietKhau(txtmagiamgia.Text)) != "")
                {
                    txtChietKhau.Text = Convert.ToString(hd_bll.LayChietKhau(txtmagiamgia.Text));
                    txtChietKhau.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Mã Giảm Giá Không Tồn Tại ", "Thông báo");
                    txtChietKhau.Enabled = true;
                }             
            }
        }

        private void txtmagiamgia_TextChanged(object sender, EventArgs e)
        {
            txtChietKhau.Clear();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMaKH.SelectedIndex != -1)
            {
                string t = cboMaKH.SelectedValue.ToString();
                txtTenKH.Text = hd_bll.getTenKhach(t);
                txtSDT.Text = hd_bll.getSoDT(t);
                txtDiaChi.Text = hd_bll.getDiaChi(t);
            }
            else
            {
                txtTenKH.Text = "";
                txtSDT.Text ="";
                txtDiaChi.Text = "";
            }
        }

        Boolean BatLoi_NgayLap_HD(DateTime ngay)
        {
            DateTime baygio = DateTime.Now;
            int kq = DateTime.Compare(baygio.Date, ngay.Date);
            //TimeSpan dayyy = baygio - ngay;
            if (kq == 0)
            {
                return true;
            }
            return false;

        }
        void lammoi_HD()
        {
            cboMaKH.DataSource = null;
            cboTrangThai.Items.Clear();
            txtMaHD.Clear();
            txtMaNV.Clear();
            LoadCbo_TrangTrai();
            loadKhachHang_cbo();
            loadDataHD();
            dtpNgayLap.Value = DateTime.Now;
            txtmagiamgia.Clear();
            txtThanhTien.Clear();
            txtChietKhau.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = nv.MANV;
            txtThanhTien.Text = "";
            txtMaHD.Text = "";
            SetReadOnly(true);
            flat = 1;
        }


        private void SetReadOnly(bool a)
        {
            txtDiaChi.ReadOnly = !a;
            txtSDT.ReadOnly = !a;
            txtTenKH.ReadOnly = !a;
            txtChietKhau.ReadOnly = !a;
            txtmagiamgia.ReadOnly = !a;
            cboMaKH.Enabled = a;
            cboTrangThai.Enabled = a;
            

        }

        private void ThemHD()
        {
            try
            {
                string mahd = "HD";
                string makh;
                txtMaNV.Text = nv.MANV;
                DateTime ngaylap = dtpNgayLap.Value;
                double chietkhau = 0;
                if (txtChietKhau.Text != string.Empty)
                {
                    chietkhau = double.Parse(txtChietKhau.Text);
                }
                else
                {
                    chietkhau = 0;
                }
                string tenkh = txtTenKH.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                string trangthai = "";

                // kt xem textbox có bị bỏ trống không
                if (txtTenKH.Text != string.Empty && txtDiaChi.Text != string.Empty && txtSDT.Text != string.Empty
                    && cboTrangThai.SelectedIndex != -1)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Tạo Hóa Đơn " + mahd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        if (BatLoi_NgayLap_HD(ngaylap) == true)
                        {
                            // thêm nhân viên
                            if (hd_bll.KiemTraTrung_HD(txtMaHD.Text) == true)
                            {
                                trangthai = cboTrangThai.Text;
                                makh = cboMaKH.SelectedValue.ToString();
                                hd_bll.ThemHoaDon(mahd, nv.MANV, ngaylap, chietkhau, 0, makh, tenkh, diachi, sdt, trangthai);
                                MessageBox.Show("Tạo Thành Công Hóa Dơn " + mahd, "Thông báo");
                                loadDataHD();
                                lammoi_HD();
                                loadCboHD();
                            }
                            else
                            {
                                MessageBox.Show("Hóa Đơn Đã Tồn Tại", "Thông báo");
                            }
                        }
                        else
                        {
                            dtpNgayLap.ResetText();
                            dtpNgayLap.Focus();
                            MessageBox.Show("Ngày Tạo Hóa Đơn Khác Với Ngày Hệ Thống", "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Có Thông Tin Chưa Được Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
            catch
            {
                MessageBox.Show("Có Lỗi", "Thông báo");
            }
}



        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = gvHoaDon.FocusedRowHandle;
            string ma = "MAHD";
            object value = gvHoaDon.GetRowCellValue(id, ma);
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //ThucThiXoa_CTHD();
                    hd_bll.xoaHoaDon(value.ToString());
                    loadDataHD();
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + value.ToString());
                    lammoi_HD();
                }
            }
            catch
            {
                MessageBox.Show("Bạn Cần Phải Xóa Sản Phẩm Trong Hóa Đơn " + value.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetReadOnly(true);
            flat = 2;
        }

        private void SuaHD()
        {
            int id = gvHoaDon.FocusedRowHandle;
            string ma = "MAHD";
            object value = gvHoaDon.GetRowCellValue(id, ma);
            try
            {
                string makh;
                string manv = txtMaNV.Text;
                DateTime ngaylap = dtpNgayLap.Value;
                double chietkhau = 0;
                if (txtChietKhau.Text != string.Empty)
                {
                    chietkhau = double.Parse(txtChietKhau.Text);
                }
                else
                {
                    chietkhau = 0;
                }
                string tenkh = txtTenKH.Text;
                string diachi = txtDiaChi.Text;
                string sdt = txtSDT.Text;
                string trangthai = "";

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    trangthai = cboTrangThai.SelectedValue.ToString();
                    makh = cboMaKH.SelectedValue.ToString();
                    hd_bll.suaHoaDon(value.ToString(), ngaylap, chietkhau, makh, tenkh, diachi, sdt, trangthai);
                    loadDataHD();
                    MessageBox.Show("Sửa Thành Công Hóa Đơn " + value.ToString(), "Thông Báo");
                    lammoi_HD();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Hóa Đơn " + value.ToString(), "Thông Báo");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvHoaDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvHoaDon.RowCount != 0)
            {
                //txtMaHD.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHD").ToString();
                cboMaKH.SelectedValue = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAKHACHHANG").ToString();
                txtMaNV.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MANV").ToString();
                dtpNgayLap.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "NGAYLAP").ToString();
                if (gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "THANHTIEN") == null)
                    txtThanhTien.Text = "";
                else
                    txtThanhTien.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "THANHTIEN").ToString();
                txtChietKhau.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "CHIETKHAU").ToString();
                txtTenKH.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TENKHACHHANG").ToString();
                txtDiaChi.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "DIACHIGIAOHANG").ToString();
                txtSDT.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "SDTGIAOHANG").ToString();
                cboTrangThai.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TRANGTHAI").ToString();
            }
        }


        //chi tiết
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                Control ctr = (Control)sender;
                if (txtSLHientai.Text != string.Empty)
                {
                    if (int.Parse(ctr.Text) <= 0 || int.Parse(ctr.Text) > int.Parse(txtSLHientai.Text))
                    {
                        errorProvider1.SetError(ctr, "Nhập số lượng sai!");
                    }
                    else
                    {
                        errorProvider1.Clear();
                    }
                }
            }
            catch
            {

            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control ctr = (Control)sender;
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(ctr, "Chỉ có số không kí tự");
            }
            else
                errorProvider1.Clear();
        }

        private void loadData_CTHD(string mahd)
        {
            try
            {
                gcChiTietHD.DataSource = hd_bll.LoadChiTiet_HD_BLL(mahd);
            }
            catch(Exception e)
            { }
        }

        decimal laydata_thanhtien()
        {
            decimal tongthanhtien = 0;
            if (gvCTHD.RowCount > 0)
            {
                for (int i = 0; i < gvCTHD.RowCount; i++)
                {
                    if (gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "TONGTIEN").ToString() != string.Empty)
                    {
                        tongthanhtien = tongthanhtien + decimal.Parse(gvCTHD.GetRowCellValue(i, "TONGTIEN").ToString());
                    }
                }
            }
            return tongthanhtien;
        }
        private void cboHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHoaDon.SelectedIndex != -1)
            {
                loadData_CTHD(cboHoaDon.SelectedValue.ToString());
            }
            txtTienCanThanhToan.Text = Convert.ToString(laydata_thanhtien());
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != string.Empty)
            {
                if (int.Parse(txtSoLuong.Text) > 0 && int.Parse(txtSoLuong.Text) < hd_bll.GetSoLuong(cboMaSP.SelectedValue.ToString()) )
                {
                    decimal thanhtien = decimal.Parse(txtDonGia.Text.ToString()) * int.Parse(txtSoLuong.Text);
                    txtTongTien.Text = Convert.ToString(thanhtien);
                }
                else
                {
                    txtTongTien.Text = "0";
                }

            }
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex != -1)
            {
                txtDonGia.Text = Convert.ToString(hd_bll.GetDonGia(cboMaSP.SelectedValue.ToString()));
                txtSLHientai.Text = Convert.ToString(hd_bll.GetSoLuong(cboMaSP.SelectedValue.ToString()));
                txtSoLuong.Clear() ;
                txtTongTien.Clear();
            }
        }

        private void gvCTHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvCTHD.RowCount != 0)
                {
                    cboHoaDon.SelectedValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "MAHD").ToString();
                    cboMaSP.SelectedValue = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "MASP").ToString();
                    txtDonGia.Text = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "DONGIA").ToString();
                    txtSoLuong.Text = gvCTHD.GetRowCellValue(gvCTHD.FocusedRowHandle, "SOLUONG").ToString();
                    if (gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TONGTIEN") == null)
                        txtThanhTien.Text = "";
                    else
                        txtThanhTien.Text = gvHoaDon.GetRowCellValue(gvHoaDon.FocusedRowHandle, "TONGTIEN").ToString();
                    txtTienCanThanhToan.Text = Convert.ToString(laydata_thanhtien());
                    // txtSLHientai.EditValue = Convert.ToString(sp_bll.GetSoLiuong(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString()));
                }
            }
            catch { 
            }
           
        }
        void Clear_CTHD()
        {
            //cboMaSP.DataSource = null;
            txtDonGia.Text = "";
            txtSLHientai.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
            loadCboSP();
        }
        private void btnThem2_Click(object sender, EventArgs e)
        {
            
            try
            {
                string mahd = "";
                if (cboHoaDon.SelectedIndex != -1)
                {
                    mahd = cboHoaDon.SelectedValue.ToString();
                }
                string masp = "";
                if (cboMaSP.SelectedIndex != -1)
                {
                    masp = cboMaSP.SelectedValue.ToString();
                }
                decimal dongia = 0;
                if (txtDonGia.Text != string.Empty)
                {
                    dongia = Convert.ToDecimal(txtDonGia.Text);
                }
                int soluong = int.Parse(txtSoLuong.Text.ToString());

                decimal tongtien = 0;
                if (txtTongTien.Text != string.Empty)
                {
                    tongtien = decimal.Parse(txtTongTien.Text);
                }
                int soluong_tonkho = 0;
                if (txtSLHientai.Text != string.Empty)
                {
                    soluong_tonkho = int.Parse(txtSLHientai.Text);
                }
                // kt xem có bị bỏ trống không
                if (mahd != string.Empty && cboHoaDon.SelectedIndex != -1 && masp != string.Empty &&
                    cboMaSP.SelectedIndex != -1)
                {
                    DialogResult result;
                    result = MessageBox.Show("Bạn Có Muốn Thêm Vào Hóa Đơn " + mahd + "?",
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        // thêm chi tiết hóa đơn
                        if (hd_bll.KiemTraTrung_CTHD(mahd, masp) == true)
                        {
                            if (soluong > 0 && soluong <= soluong_tonkho)
                            {
                                hd_bll.ThemChiTiet_HoaDon(mahd, masp, soluong, dongia, tongtien);
                                MessageBox.Show("Thêm Thành Công Vào Hóa Dơn " + mahd, "Thông báo");
                                Clear_CTHD();
                                loadData_CTHD(mahd);
                                // update số lượng sản phẩm lại nè
                                int soluong_hientai = soluong_tonkho - soluong;
                                hd_bll.updateSanPham_saukhiThemCTD(masp, soluong_hientai);
                                // update lại tổng tiền của hóa đơn
                                txtTienCanThanhToan.Text = Convert.ToString(laydata_thanhtien());
                                Clear_CTHD();
                            }
                            else
                            {
                                MessageBox.Show("Sai Sô Lượng ", "Thông báo");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hóa Đơn Đã Tồn Tại Sản Phẩm " + masp, "Thông báo");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Có Thông Tin Chưa Được Nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Thêm Vào Hóa Đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnXoa2_Click(object sender, EventArgs e)
        {
            int id;
            string ma = "";
            object value = "";
            string mahd = "";
            string masp = "";
            object value2 = "";
            int soluong = 0;
            if (gvCTHD.RowCount != 0)
            {
                id = gvCTHD.FocusedRowHandle;
                ma = "MAHD";
                value = gvCTHD.GetRowCellValue(id, ma);

                masp= "MASP";
                value2 = gvCTHD.GetRowCellValue(id, masp);
                soluong = int.Parse(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "SOLUONG").ToString());
            }
            int slht = Convert.ToInt32(hd_bll.GetSoLuong(masp));
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    hd_bll.xoaChiTiet_HoaDon(value.ToString(), value2.ToString());
                    loadDataHD();
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + value.ToString() + " Có Mã Sản Phẩm " + value2.ToString());
                    loadData_CTHD(value.ToString());
                    int soluong_hientai = slht + soluong;
                    hd_bll.updateSanPham_saukhiThemCTD(value2.ToString(), soluong_hientai);
                    Clear_CTHD();
                    txtTienCanThanhToan.Text = Convert.ToString(laydata_thanhtien());
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Hóa Đơn  " + mahd);
            }
        }

        private void btnSua2_Click(object sender, EventArgs e)
        {
            string mahd = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MAHD").ToString();
            string masp = gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "MASP").ToString();
            int trucuasanpham = 0;
            int soluong_trongcthd = int.Parse(gvCTHD.GetRowCellValue(gvHoaDon.FocusedRowHandle, "SOLUONG").ToString());
            int soluongsanpham = Convert.ToInt32(hd_bll.GetSoLuong(masp)); ;
            int soluong_tonkho = 0;
            if (txtSLHientai.Text != string.Empty)
            {
                soluong_tonkho = int.Parse(txtSLHientai.Text);
            }
            try
            {
                int soluong = int.Parse(txtSoLuong.Text);
                decimal tongtien = 0;
                if (txtTongTien.Text != string.Empty)
                {
                    tongtien = decimal.Parse(txtTongTien.Text);
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + mahd + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (soluong > 0 && soluong <= soluong_tonkho)
                    {
                        hd_bll.suaChiTiet_HoaDon(mahd, masp, soluong, tongtien);
                        loadData_CTHD(mahd);
                        Clear_CTHD();
                        MessageBox.Show("Sửa Thành Công Hóa Đơn " + mahd + " Có Mã Sản Phẩm " + masp, "Thông Báo");

                        // update lại số lượng sản phẩm sau khi sửa
                        if (soluong != soluong_trongcthd)
                        {
                            if (soluong > soluong_trongcthd)
                            {
                                trucuasanpham = soluongsanpham - (soluong - soluong_trongcthd);
                                hd_bll.updateSanPham_saukhiThemCTD(masp, trucuasanpham);
                            }
                            else
                            {
                                trucuasanpham = soluongsanpham + (soluong_trongcthd - soluong);
                                hd_bll.updateSanPham_saukhiThemCTD(masp, trucuasanpham);
                            }
                        }
                        txtTienCanThanhToan.Text = Convert.ToString(laydata_thanhtien());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  ");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                int id = gvCTHD.FocusedRowHandle;
                string ma = "MAHD";
                object value = gvCTHD.GetRowCellValue(id, ma);
                double chietkhau = hd_bll.getsoChietKhau(value.ToString());
                decimal tiengiamgia = Convert.ToDecimal(laydata_thanhtien() * Convert.ToDecimal( chietkhau));
                decimal thanhtien = laydata_thanhtien() - tiengiamgia;
                hd_bll.updateThanhTienHoaDon_saukhiThemCTD(value.ToString(), thanhtien);
                loadDataHD();
                MessageBox.Show("Đã Thanh Toán Thành Công " + value.ToString(), "Thông Báo");
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề", "Thông Báo");
            }
        }

        private void gcHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flat == 1)
            {
                ThemHD();
            }
            else if(flat == 2)
            {
                SuaHD();
            }
            SetReadOnly(false);
        }
    }
}
