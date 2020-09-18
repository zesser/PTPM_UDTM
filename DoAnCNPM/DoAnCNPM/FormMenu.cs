using DAL_BLL;
using DoAnCNPM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnCNPM
{
    public partial class FormMenu : Form
    {
        PhanQuyen pq = new PhanQuyen();
        frm_KhachHang kh = new frm_KhachHang();
        frm_SanPham sp = new frm_SanPham();
        frm_LapPhieuXuatHang xh = new frm_LapPhieuXuatHang();
        frmPhieuGiaoHang gh = new frmPhieuGiaoHang();
        frmPhieuNhapHang nh = new frmPhieuNhapHang();
        frmGioiThieu gt = new frmGioiThieu();
        frmHoaDon hd = new frmHoaDon();
        public NHANVIEN nv;
        public FormMenu()
        {
            InitializeComponent();
            
            
        }
        private Form activeForm = null;
        private void FormMenu_Load(object sender, EventArgs e)
        {
            labelMaNV.Text = nv.MANV;
            labelTenNV.Text = nv.TENNV;
            lbChucVu.Text = pq.GetPhanQuyen(nv.MAPHANQUYEN).TENPHANQUYEN;
            PhanQuyen();
        }
        private void openChildForm(Form childForm)
        {
            panelChildForm.Controls.Clear();
            if (activeForm != null) 
                activeForm.Hide();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm.Name;
            childForm.Show();
            
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            hd.nv = nv;
            openChildForm(hd);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            openChildForm(kh);
        }

        private void btnXuatHang_Click(object sender, EventArgs e)
        {
            xh.nv = nv;
            openChildForm(xh);
        }

        private void btnGiaoHang_Click(object sender, EventArgs e)
        {
            gh.nv = nv;
            openChildForm(gh);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            sp.nv = nv;
            openChildForm(sp);
        }

        private void btnGioiThieu_Click(object sender, EventArgs e)
        {
            openChildForm(gt);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            
            nh.nv = nv;
            openChildForm(nh);
        }

        private void PhanQuyen()
        {
            if (nv.MAPHANQUYEN.Trim().Contains("PQ0001"))
            {
                btnBanHang.Visible = true;
                btnGiaoHang.Visible = true;
                btnGioiThieu.Visible = true;
                btnNhapHang.Visible = true;
                btnSanPham.Visible = true;
                btnSearch.Visible = true;
                btnXuatHang.Visible = true;

            }
            else if(nv.MAPHANQUYEN.Trim().Contains("PQ0002"))
            {
                btnBanHang.Visible = true;
                btnGiaoHang.Visible = false;
                btnGioiThieu.Visible = true;
                btnNhapHang.Visible = false;
                btnSanPham.Visible = true;
                btnSearch.Visible = true;
                btnXuatHang.Visible = false;
            }
            else if (nv.MAPHANQUYEN.Trim().Contains("PQ0003"))
            {
                btnBanHang.Visible = true;
                btnGiaoHang.Visible = false;
                btnGioiThieu.Visible = true;
                btnNhapHang.Visible = false;
                btnSanPham.Visible = true;
                btnSearch.Visible = true;
                btnXuatHang.Visible = true;
            }
            else if (nv.MAPHANQUYEN.Trim().Contains("PQ0004"))
            {
                btnBanHang.Visible = false;
                btnGiaoHang.Visible = false;
                btnGioiThieu.Visible = true;
                btnNhapHang.Visible = true;
                btnSanPham.Visible = true;
                btnSearch.Visible = true;
                btnXuatHang.Visible = true;
            }
            else if (nv.MAPHANQUYEN.Trim().Contains("PQ0005"))
            {
                btnBanHang.Visible = false;
                btnGiaoHang.Visible = true;
                btnGioiThieu.Visible = true;
                btnNhapHang.Visible = false;
                btnSanPham.Visible = true;
                btnSearch.Visible = true;
                btnXuatHang.Visible = false;
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            nh.nv = nv;
            openChildForm(nh);
        }
    }
}
