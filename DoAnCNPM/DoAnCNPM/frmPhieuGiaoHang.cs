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
namespace DoAnCNPM
{
    public partial class frmPhieuGiaoHang : Form
    {
        public NHANVIEN nv;
        PhieuGiao_BLL px_bll = new PhieuGiao_BLL();
        string t = string.Empty;
        int soluongton;
        public frmPhieuGiaoHang()
        {
            InitializeComponent();
        }

        public frmPhieuGiaoHang(string manv)
        {
            InitializeComponent();
            manv = t;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }

        private void gvPhieuGiaoHang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvPhieuGiaoHang.RowCount != 0)
            {
                txtMaPG.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "MAPHIEUGIAO").ToString();
                cboMaKH.SelectedValue = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "MAKHACHHANG").ToString();
                cboMaPX.SelectedValue = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "MAPHIEUXUAT").ToString();
                txtTenKH_PG.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "TENNGUOINHAN").ToString();
                txtDiaChi_PG.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "DIACHIGIAOHANG").ToString();
                txtMaNV_PG.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "MANV").ToString();
                dateTimePicker1.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "NGAYLAPPHIEU").ToString();
                txtTongTien_PG.Text = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "TONGTHANHTIEN").ToString();
            }
        }
        //chitietphieugiao


        private void frmPhieuGiaoHang_Load(object sender, EventArgs e)
        {
            loadCBO_KH();
            dateTimePicker1.Value = DateTime.Now;
            loadCBO_PX();
            loadCBO_SP();
            loadDataPG();
            loadCBO_PG();
            txtMaNV_PG.Text = nv.MANV;
        }

        private void loadCBO_PX()
        {
            cboMaPX.DataSource = px_bll.LoadMaPX_BLL();
            cboMaPX.DisplayMember = "MAPHIEUXUAT";
            cboMaPX.ValueMember = "MAPHIEUXUAT";
            cboMaPX.SelectedIndex = -1;
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
        private void loadDataPG()
        {
            gcPhieuGiaoHang.DataSource = px_bll.LoadMaPG_BLL();
        }
        void clear_PX()
        {
            txtMaPG.Text = string.Empty;
            cboMaKH.DataSource = null;
            cboMaPX.DataSource = null;
            txtTenKH_PG.Text = string.Empty;
            txtDiaChi_PG.Text = string.Empty;
            txtMaNV_PG.Text = string.Empty;
            txtTongTien_PG.Text = string.Empty;
            loadCBO_KH();
            loadCBO_PX();
        }


        /// <summary>
        ///  phiếu giao
        /// </summary>

        private void btnThemPG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thêm Phiếu Giao  ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (cboMaPX.SelectedIndex != -1
                        && txtTenKH_PG.Text != string.Empty && txtDiaChi_PG.Text != string.Empty)
                    {
                            string mapg = txtMaPG.Text;
                                string mapx = cboMaPX.SelectedValue.ToString();
                                string makh = cboMaKH.SelectedValue.ToString();
                                string manv = nv.MANV;
                                string tenkh = txtTenKH_PG.Text;
                                string diachi = txtDiaChi_PG.Text;
                                DateTime ngaylap = DateTime.Now;
                                px_bll.ThemPhieuGiao(mapg, makh, mapx, tenkh,diachi, nv.MANV,ngaylap,0);
                                MessageBox.Show("Tạo Thành Công Phiếu Giao " + mapg + "Thông báo");
                                clear_PX();
                                loadDataPG();
                                loadCBO_PG();
                            
                    }
                    else
                    {
                        MessageBox.Show("Có Thông Tin Còn Bỏ Trống", "Thông báo");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi", "Thông báo");
            }
        }

        private void btnXoaPG_Click(object sender, EventArgs e)
        {
            string mapg= string.Empty;
            try
            {
                if (gvPhieuGiaoHang.RowCount != 0)
                {
                    mapg = gvPhieuGiaoHang.GetRowCellValue(gvPhieuGiaoHang.FocusedRowHandle, "MAPHIEUGIAO").ToString();
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Phiếu Giao ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    px_bll.xoaPhieuGiao(mapg);
                    MessageBox.Show("Xóa Thành Công Phiếu Giao  " + mapg);
                    clear_PX();
                    loadDataPG();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi" + mapg);
            }
        }

        private void btnSuaPG_Click(object sender, EventArgs e)
        {
            int id = gvPhieuGiaoHang.FocusedRowHandle;
            string ma = "MAPHIEUGIAO";
            object value = gvPhieuGiaoHang.GetRowCellValue(id, ma);
            try
            {
                string makh;
                DateTime ngaylap = DateTime.Now;
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Phiếu Giao  " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (BatLoi_NgayLap_PX(ngaylap))
                    {

                        makh = cboMaKH.SelectedValue.ToString();
                        string tenkh = txtTenKH_PG.Text;
                        string diachi = txtDiaChi_PG.Text;
                        px_bll.suaPhieuGiao(value.ToString(), makh,tenkh,diachi, ngaylap);
                        loadDataPG();
                        MessageBox.Show("Sửa Thành Công Phiếu Giao " + value.ToString(), "Thông Báo");
                        clear_PX();
                    }
                    else
                    {
                        MessageBox.Show("Ngày Xuất Sai", "Thông báo");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Sửa Phiếu Giao " + value.ToString(), "Thông Báo");
            }
        }

        private void btnLamMoiPG_Click(object sender, EventArgs e)
        {
            clear_PX();
        }

        private void cboMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMaKH.SelectedIndex != -1)
            {
                txtTenKH_PG.Text = px_bll.GetTenKH(cboMaKH.SelectedValue.ToString());
                txtDiaChi_PG.Text = px_bll.GetDiaChiKH(cboMaKH.SelectedValue.ToString());
            }
        }

        /// <summary>
        ///  chi tiét phiếu giao
        /// </summary>

        void loadCBO_PG()
        {
            cboMaPG.DataSource = px_bll.LoadMaPG_BLL();
            cboMaPG.DisplayMember = "MAPHIEUGIAO";
            cboMaPG.ValueMember = "MAPHIEUGIAO";
            cboMaPG.SelectedIndex = -1;
        }

        private void gvCTPG_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //try
            //{
            if (gvCTPG.RowCount != 0)
            {
                cboMaPG.SelectedValue = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MACTPHIEUGIAO").ToString();
                cboMaSP.SelectedValue = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MASP").ToString();
                txtDonGiaCTPG.Text = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "DONGIA").ToString();
                txtSL_CTPG.Text = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "SOLUONG").ToString();
                txtThanhTien_CTPG.Text = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "THANHTIEN").ToString();
                txtChuThich_CTPG.Text = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "CHUTHICH").ToString();
                if (gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "CHUTHICH").ToString() != string.Empty)
                {
                    txtChuThich_CTPG.Text = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "CHUTHICH").ToString();
                }
                else
                {
                    txtChuThich_CTPG.Text = "";
                }
            }
            //}
            //catch
            //{

            //}

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
                txtDonGiaCTPG.Text = Convert.ToString(px_bll.GetDonGia(cboMaSP.SelectedValue.ToString()));
                soluongton = Convert.ToInt32(px_bll.GetSoLiuong(cboMaSP.SelectedValue.ToString()));
                txtSL_CTPG.Text = string.Empty;
                txtThanhTien_CTPG.Text = string.Empty;
            }
        }
        decimal laydata_thanhtien()
        {
            decimal tongthanhtien = 0;
            for (int i = 0; i < gvCTPG.RowCount; i++)
            {
                if (gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "THANHTIEN").ToString() != string.Empty)
                {
                    tongthanhtien = tongthanhtien + decimal.Parse(gvCTPG.GetRowCellValue(i, "THANHTIEN").ToString());
                }
            }
            return tongthanhtien;
        }

        private void txtSL_CTPG_EditValueChanged(object sender, EventArgs e)
        {

            if (txtSL_CTPG.Text != string.Empty)
            {
                decimal thanhtien = decimal.Parse(txtDonGiaCTPG.EditValue.ToString()) * int.Parse(txtSL_CTPG.EditValue.ToString());
                txtThanhTien_CTPG.Text = Convert.ToString(thanhtien);
            }
        }

        private void Clear_CTPG()
        {
            cboMaSP.DataSource = null;
            cboMaPG.DataSource = null;
            loadCBO_SP();
            txtDonGiaCTPG.Text = string.Empty;
            txtSL_CTPG.Text = string.Empty;
            txtThanhTien_CTPG.Text = string.Empty;
            loadCBO_PG();
            txtChuThich_CTPG.Text = string.Empty;
        }

        private void btnThemCTPG_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Thêm Vào Phiếu Xuất ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (cboMaPG.SelectedIndex != -1 && cboMaSP.SelectedIndex != -1 && txtSL_CTPG.Text != string.Empty &&
                        txtThanhTien_CTPG.Text != string.Empty && txtDonGiaCTPG.Text != string.Empty)
                    {
                        string mapg = cboMaPG.SelectedValue.ToString();
                        string masp = cboMaSP.SelectedValue.ToString();
                        int soluong = Convert.ToInt32(txtSL_CTPG.Text);
                        decimal dongia = Convert.ToDecimal(txtDonGiaCTPG.Text);
                        decimal thanhtien = Convert.ToDecimal(txtThanhTien_CTPG.Text);
                        string chuthich = string.Empty;
                        if (txtChuThich_CTPG.Text != string.Empty)
                        {
                            chuthich = txtChuThich_CTPG.Text;
                        }
                        else
                        {
                            chuthich = string.Empty;
                        }
                        if (px_bll.KiemTraTrung_CTPG(mapg, masp) == true)
                        {
                            if (soluong > 0 && soluong <= soluongton)
                            {
                                px_bll.ThemChiTiet_PhieuGiao(mapg, masp, dongia, soluong, thanhtien, chuthich);
                                MessageBox.Show("Thêm Thành Công Vào Phiếu Xuất " + mapg, "Thông báo");
                                Clear_CTPG();
                                loadData_CTPG(mapg);
                                // update số lượng sản phẩm lại nè
                                int soluong_hientai = soluongton - soluong;
                                px_bll.updateSanPham_saukhiThemCTPX(masp, soluong_hientai);
                                // update lại tổng tiền của hóa đơn
                                px_bll.suaPhieuGiao_TongTien(mapg, laydata_thanhtien());
                                loadData_CTPG(mapg);
                                loadDataPG();
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
                    }
                }
            }
            catch
            {

            }
        }
        private void loadData_CTPG(string mahd)
        {
            gcCTPG.DataSource = px_bll.LoadChiTiet_PG_BLL(mahd);
            //dataGVCTHD.Columns["SANPHAM"].Visible = false;
            //dataGVCTHD.Columns["HOADON"].Visible = false;
        }

        private void cboMaPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaPG.SelectedIndex != -1)
            {
                loadData_CTPG(cboMaPG.SelectedValue.ToString());
            }
        }

        private void btnXoaCTPG_Click(object sender, EventArgs e)
        {
            int id;
            string ma = string.Empty;
            object value = string.Empty;
            string mahd = string.Empty;
            string masp = string.Empty;
            int soluong = 0;
            if (gvCTPG.RowCount != 0)
            {
                id = gvCTPG.FocusedRowHandle;
                ma = "MACTPHIEUGIAO";
                value = gvCTPG.GetRowCellValue(id, ma);

                mahd = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MACTPHIEUGIAO").ToString();
                masp = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MASP").ToString();
                soluong = int.Parse(gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "SOLUONG").ToString());
            }
            int slht = Convert.ToInt32(px_bll.GetSoLiuong(masp));
            try
            {
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Xóa Phiếu Giao " + value.ToString() + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    px_bll.xoaChiTiet_PhieuGiao(value.ToString(), masp);
                    loadData_CTPG(value.ToString());
                    MessageBox.Show("Xóa Thành Công Phiếu Giao  " + value.ToString() + " Có Mã Sản Phẩm " + masp);
                    loadDataPG();
                    int soluong_hientai = slht + soluong;
                    px_bll.updateSanPham_saukhiThemCTPX(masp, soluong_hientai);
                    Clear_CTPG();
                    px_bll.suaPhieuGiao_TongTien(value.ToString(), laydata_thanhtien());
                    loadDataPG();
                    loadData_CTPG(value.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Có Vấn Đề Trong Việc Xóa Hóa Đơn  " + mahd);
            }
        }

        private void btnSuaCTPG_Click(object sender, EventArgs e)
        {
            string mapg = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MACTPHIEUGIAO").ToString();
            string masp = gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "MASP").ToString();
            int trucuasanpham = 0;
            int soluong_trongcthd = int.Parse(gvCTPG.GetRowCellValue(gvCTPG.FocusedRowHandle, "SOLUONG").ToString());
            int soluongsanpham = Convert.ToInt32(px_bll.GetSoLiuong(masp));
            string chuthich = string.Empty;
            if (txtChuThich_CTPG.Text != string.Empty)
            {
                chuthich = txtChuThich_CTPG.Text;
            }
            else
            {
                chuthich = string.Empty;
            }
            try
            {
                int soluong = int.Parse(txtSL_CTPG.EditValue.ToString());
                decimal thanhtien = 0;
                if (txtThanhTien_CTPG.Text != string.Empty)
                {
                    thanhtien = decimal.Parse(txtThanhTien_CTPG.Text);
                }
                DialogResult result;
                result = MessageBox.Show("Bạn Có Muốn Sửa Hóa Đơn  " + mapg + " ?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (txtSL_CTPG.Text != string.Empty)
                    {
                        if (px_bll.KiemTraTrung_CTPG(mapg, masp) == false)
                        {
                            px_bll.suaChiTiet_PhieuGiao(mapg, masp, soluong, thanhtien, chuthich);
                            
                            Clear_CTPG();
                            MessageBox.Show("Sửa Thành Công Hóa Đơn " + mapg + " Có Mã Sản Phẩm " + masp, "Thông Báo");
                            loadData_CTPG(cboMaPX.SelectedValue.ToString());
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
                            px_bll.suaPhieuGiao_TongTien(mapg, laydata_thanhtien());
                            loadDataPG();
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

        private void btnLamMoiCTPG_Click(object sender, EventArgs e)
        {
            Clear_CTPG();
        }

        private void txtSL_CTPG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGiaCTPG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenKH_PG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
