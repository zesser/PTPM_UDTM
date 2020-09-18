
using DAL_BLL;
using System;
using System.Linq;
using System.Windows.Forms;
namespace DoAnCNPM
{
    public partial class frm_LapPhieuXuatHang : Form
    {
        public NHANVIEN nv;
        PhieuXuat_BLL px_bll = new PhieuXuat_BLL();
        string t = string.Empty;
        int soluongton;
        public frm_LapPhieuXuatHang()
        {
            InitializeComponent();
        }
        public frm_LapPhieuXuatHang(string manv)
        {
            InitializeComponent();
            manv = t;
        }
        private void frm_LapPhieuXuatHang_Load(object sender, EventArgs e)
        {
            loadCBO_KH();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            loadCBO_PX();
            loadCBO_SP();
            loadDataPX();
            txtMaPX.ReadOnly = true;
            txtMaNV.Text = nv.MANV;
            txtMaNV.ReadOnly = true;
        }

        /// <summary>
        /// phiếu xuất
        /// </summary>
        private void loadDataPX()
        {
            gcPhieuXuatHang.DataSource = px_bll.LoadMaPX_BLL();
            //gcHoaDon.Columns["KHACHHANG"].Visible = false;
            // gcHoaDon.Columns["NHANVIEN"].Visible = false;
        }
        void loadCBO_KH()
        {
            cboMaKH.DataSource = px_bll.LoadMaKH_BLL();
            cboMaKH.DisplayMember = "TENKHACHHANG";
            cboMaKH.ValueMember = "MAKHACHHANG";
            cboMaKH.SelectedIndex = -1;
        }

        Boolean BatLoi_NgayLap_PX(DateTime ngay)
        {
            DateTime baygio = DateTime.Now;
            int kq = DateTime.Compare(baygio.Date, ngay.Date);
            if (kq != 0)
            {
                return true;
            }
            return false;

        }
        void clear_PX()
        {
            txtMaPX.Text = string.Empty;
            cboMaKH.DataSource = null;
            txtMaNV.Text = string.Empty;
            loadCBO_KH();
        }




        private void btnThemPX_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thêm" +
                    " Phiếu Xuất  ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (cboMaKH.SelectedIndex != -1)
                    {

                            string mapx = "PX";
                            string makh = cboMaKH.SelectedValue.ToString();
                            string manv = nv.MANV;
                            DateTime ngaylap = DateTime.Now;
                            px_bll.ThemPhieuXuat(mapx, makh, nv.MANV, ngaylap);
                            MessageBox.Show("Tạo Thành Công Phiếu Nhập " + mapx + "Thông báo");
                            clear_PX();
                            loadDataPX();
                            loadCBO_PX();

                    }

                }
                else
                {
                    MessageBox.Show("Có Thông Tin Còn Bỏ Trống", "Thông báo");
                }
                loadDataPX();
                loadCBO_PX();
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }


        }

        private void btnXoaPX_Click(object sender, EventArgs e)
        {
            string mapx = string.Empty;
            try
            {
                if (gvphieuXuatHang.RowCount != 0)
                {
                    mapx = gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "MAPHIEUXUAT").ToString();
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Phiếu Xuất ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    px_bll.xoaPhieuNhap(mapx);
                    MessageBox.Show("Xóa Thành Công Phiếu Xuất  " + mapx);
                    clear_PX();
                    loadDataPX();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi" + mapx);
            }
        }

        // có vãn đề
        private void btnSuaPX_Click(object sender, EventArgs e)
        {
            
            int id = gvphieuXuatHang.FocusedRowHandle;
            string ma = "MAPHIEUXUAT";

            try
            {
                string makh;
                DateTime ngaylap = dateTimePicker1.Value;

                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Phiếu Xuất  " + txtMaPX.Text + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {

                        makh = cboMaKH.SelectedValue.ToString();
                        px_bll.suaPhieuXuat(txtMaPX.Text, makh, DateTime.Now);
                        loadDataPX();
                        MessageBox.Show("Sửa Thành Công Phiếu Xuất " + txtMaPX.Text, "Thông Báo");
                        clear_PX();

                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Phiếu Xuất " + txtMaPX.Text, "Thông Báo");
            }
        }

        private void btnLamMoiPX_Click(object sender, EventArgs e)
        {
            clear_PX();
            
        }

        private void gvphieuXuatHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvphieuXuatHang.RowCount != 0)
            {
                txtMaPX.EditValue = gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "MAPHIEUXUAT").ToString();
                cboMaKH.SelectedValue = gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "MAKHACHHANG").ToString();
                txtMaNV.EditValue = gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "MANV").ToString();
                dateTimePicker1.Text = gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "NGAYLAPPHIEU").ToString();
            }
        }
        ////////////////////////////////////////////////////////////
        /// CHI TIẾT PHIẾU XUẤT
        void loadCBO_PX()
        {
            cboMaPX.DataSource = px_bll.LoadMaPX_BLL();
            cboMaPX.DisplayMember = "MAPHIEUXUAT";
            cboMaPX.ValueMember = "MAPHIEUXUAT";
            cboMaPX.SelectedIndex = -1;
        }

        void loadCBO_SP()
        {
            cboMaSP.DataSource = px_bll.LoadMaSP_BLL();
            cboMaSP.DisplayMember = "TENSP";
            cboMaSP.ValueMember = "MASP";
            cboMaSP.SelectedIndex = -1;
        }

        private void cboMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaSP.SelectedIndex != -1)
            {
                txtDonGia.Text = Convert.ToString(px_bll.GetDonGia(cboMaSP.SelectedValue.ToString()));
                soluongton = Convert.ToInt32(px_bll.GetSoLiuong(cboMaSP.SelectedValue.ToString()));
                txtSL.Text = string.Empty;
                txtThanhTien.Text = string.Empty;
            }
        }

        decimal laydata_thanhtien()
        {
            decimal tongthanhtien = 0;
            for (int i = 0; i < gvphieuXuatHang.RowCount; i++)
            {
                if (gvphieuXuatHang.GetRowCellValue(gvphieuXuatHang.FocusedRowHandle, "THANHTIEN").ToString() != string.Empty)
                {
                    tongthanhtien = tongthanhtien + decimal.Parse(gvphieuXuatHang.GetRowCellValue(i, "THANHTIEN").ToString());
                }
            }
            return tongthanhtien;
        }


        private void txtSL_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSL.Text != string.Empty)
            {
                decimal thanhtien = decimal.Parse(txtDonGia.EditValue.ToString()) * int.Parse(txtSL.EditValue.ToString());
                txtThanhTien.Text = Convert.ToString(thanhtien);
            }
        }

        private void gvCTPX_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvCTPX.RowCount != 0)
            {
                cboMaPX.SelectedValue = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MACTPHIEUXUAT").ToString();
                cboMaSP.SelectedValue = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MASP").ToString();
                txtDonGia.Text = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "DONGIA").ToString();
                txtSL.EditValue = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "SOLUONG").ToString();
                txtThanhTien.Text = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "THANHTIEN").ToString();
                if(gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "CHUTHICH") != null)
                {
                    txtChuThich.Text = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "CHUTHICH").ToString();
                }
                else
                {
                    txtChuThich.Text = "";
                }
            }
        }

        private void btnThemCTPX_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thêm Vào Phiếu Xuất ?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                if (cboMaPX.SelectedIndex != -1 && cboMaSP.SelectedIndex != -1 && txtSL.Text != string.Empty && txtThanhTien.Text != string.Empty && txtDonGia.Text != string.Empty)
                {
                    string mapx = cboMaPX.SelectedValue.ToString();
                    string masp = cboMaSP.SelectedValue.ToString();
                    int soluong = Convert.ToInt32(txtSL.Text);
                    decimal dongia = Convert.ToDecimal(txtDonGia.Text);
                    decimal thanhtien = Convert.ToDecimal(txtThanhTien.Text);
                    string chuthich = string.Empty;
                    if (txtChuThich.Text != string.Empty)
                    {
                        chuthich = txtChuThich.Text;
                    }
                    else
                    {
                        chuthich = string.Empty;
                    }
                    if (px_bll.KiemTraTrung_CTPX(mapx, masp) == true)
                    {
                        if (soluong > 0 && soluong <= soluongton)
                        {
                            px_bll.ThemChiTiet_PhieuXuat(mapx, masp, dongia, soluong, thanhtien, chuthich);
                            MessageBox.Show("Thêm Thành Công Vào Phiếu Xuất " + mapx, "Thông báo");
                            Clear_CTPX();
                            loadData_CTPX(mapx);
                            // update số lượng sản phẩm lại nè
                            int soluong_hientai = soluongton - soluong;
                            px_bll.updateSanPham_saukhiThemCTPX(masp, soluong_hientai);
                            // update lại tổng tiền của hóa đơn
                        }
                        else
                        {
                            MessageBox.Show("Sai Sô Lượng ", "Thông báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phiếu Xuát Đã Tồn Tại Sản Phẩm " + masp, "Thông báo");
                    }
                    loadDataPX();
                }
            }
        }

        private void Clear_CTPX()
        {
            cboMaSP.DataSource = null;
            loadCBO_SP();
            txtDonGia.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtThanhTien.Text = string.Empty;
            txtChuThich.Text = string.Empty;
        }

        private void loadData_CTPX(string mahd)
        {
            gcCTPX.DataSource = px_bll.LoadChiTiet_PX_BLL(mahd);
            //dataGVCTHD.Columns["SANPHAM"].Visible = false;
            //dataGVCTHD.Columns["HOADON"].Visible = false;
        }
        private void cboMaPX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPX.SelectedIndex != -1)
            {
                loadData_CTPX(cboMaPX.SelectedValue.ToString());
            }
        }

        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            int id;
            string ma = string.Empty;
            object value = string.Empty;
            string mahd = string.Empty;
            string masp = string.Empty;
            int soluong = 0;
            if (gvCTPX.RowCount != 0)
            {
                id = gvCTPX.FocusedRowHandle;
                ma = "MACTPHIEUXUAT";
                value = gvCTPX.GetRowCellValue(id, ma);

                mahd = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MACTPHIEUXUAT").ToString();
                masp = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MASP").ToString();
                soluong = int.Parse(gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "SOLUONG").ToString());
            }
            int slht = Convert.ToInt32(px_bll.GetSoLiuong(masp));
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Hóa Đơn  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    px_bll.xoaChiTiet_PhieuXuat(value.ToString(), masp);
                    loadData_CTPX(value.ToString());
                    MessageBox.Show("Xóa Thành Công Hóa Đơn  " + value.ToString() + " Có Mã Sản Phẩm " + masp);
                    loadDataPX();
                    int soluong_hientai = slht + soluong;
                    px_bll.updateSanPham_saukhiThemCTPX(masp, soluong_hientai);
                    Clear_CTPX();
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Hóa Đơn  " + mahd);
            }
        }

        private void btnSuaCTPX_Click(object sender, EventArgs e)
        {
            string mapx = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MACTPHIEUXUAT").ToString();
            string masp = gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "MASP").ToString();
            int trucuasanpham = 0;
            int soluong_trongcthd = int.Parse(gvCTPX.GetRowCellValue(gvCTPX.FocusedRowHandle, "SOLUONG").ToString());
            int soluongsanpham = Convert.ToInt32(px_bll.GetSoLiuong(masp));
            string chuthich = string.Empty;
            if (txtChuThich.Text != string.Empty)
            {
                chuthich = txtChuThich.Text;
            }
            else
            {
                chuthich = string.Empty;
            }
            try
            {
                int soluong = int.Parse(txtSL.EditValue.ToString());
                decimal thanhtien = 0;
                if (txtThanhTien.Text != string.Empty)
                {
                    thanhtien = decimal.Parse(txtThanhTien.Text);
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + mapx + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (txtSL.Text != string.Empty)
                    {
                        if (px_bll.KiemTraTrung_CTPX(mapx, masp) == false)
                        {
                            px_bll.suaChiTiet_PhieuXuat(mapx, masp, soluong, thanhtien, chuthich);
                           
                            Clear_CTPX();
                            MessageBox.Show("Sửa Thành Công Hóa Đơn " + mapx + " Có Mã Sản Phẩm " + masp, "Thông Báo");
                           loadData_CTPX(cboMaPX.SelectedValue.ToString());
                            // update lại số lượng sản phẩm sau khi sửa
                            if (soluong != soluong_trongcthd)
                            {
                                if (soluong > soluong_trongcthd)
                                {
                                    trucuasanpham = soluongsanpham - (soluong - soluong_trongcthd);
                                    px_bll.updateSanPham_saukhiThemCTPX(masp, trucuasanpham);
                                }
                                else
                                {
                                    trucuasanpham = soluongsanpham + (soluong_trongcthd - soluong);
                                    px_bll.updateSanPham_saukhiThemCTPX(masp, trucuasanpham);
                                }
                            }
                        }
                        else
                        {
                           
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  ");
            }
        }

        private void btnLamMoiCTPX_Click(object sender, EventArgs e)
        {
            loadCBO_PX();
            Clear_CTPX();
            
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
