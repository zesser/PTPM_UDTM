using DAL_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhieuXuat_BLL
    {
        QLBanDoGoDataContext qlch = new QLBanDoGoDataContext();
        public PhieuXuat_BLL()
        {

        }
        public IQueryable<KHACHHANG> LoadMaKH_BLL()
        {
            return qlch.KHACHHANGs.Select(h => h);
        }

        public IQueryable<PHIEUXUAT> LoadMaPX_BLL()
        {
            return qlch.PHIEUXUATs.Select(h => h);
        }

        public IQueryable LoadChiTiet_PX_BLL(string mahd)
        {
            var h = (from s in qlch.CHITIETPHIEUXUATs
                     join l in qlch.KHOHANGs
                     on s.MASP
                     equals l.MASP
                     where s.MACTPHIEUXUAT == mahd
                     select new
                     {
                         s.MACTPHIEUXUAT,
                         s.MASP,
                         l.TENSP,
                         s.DONGIA,
                         s.SOLUONG,
                         s.THANHTIEN,
                         s.CHUTHICH
                     });
            //return qlch.CHITIETHOADONs.Where(h => h.MAHD == mahd).Select(h => h);

            return h;
        }

        public IQueryable<SANPHAM> LoadMaSP_BLL()
        {
            return qlch.SANPHAMs.Select(h => h);
        }
        public Boolean KiemTraTrung_PN(string mapx)
        {
            var pn = qlch.PHIEUXUATs.Where(d => d.MAPHIEUXUAT == mapx).FirstOrDefault();
            if (pn != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemPhieuXuat(string mapx, string makh, string manv, DateTime ngaylap)
        {
            PHIEUXUAT px = new PHIEUXUAT();
            px.MAPHIEUXUAT = mapx;
            px.MAKHACHHANG= makh;
            px.MANV = manv;
            px.NGAYLAPPHIEU = ngaylap;
            qlch.PHIEUXUATs.InsertOnSubmit(px);
            qlch.SubmitChanges();
        }

        public void suaPhieuXuat(string mapx, string makh, DateTime ngaylap)
        {
            PHIEUXUAT px = qlch.PHIEUXUATs.Where(d => d.MAPHIEUXUAT == mapx).FirstOrDefault();
            px.MAPHIEUXUAT = mapx;
            px.MAKHACHHANG = makh;
            px.NGAYLAPPHIEU = ngaylap;
            qlch.SubmitChanges();
        }

        // xóa nhân viên
        public void xoaPhieuNhap(string mapx)
        {
            PHIEUXUAT px = qlch.PHIEUXUATs.Where(d => d.MAPHIEUXUAT == mapx).FirstOrDefault();
            qlch.PHIEUXUATs.DeleteOnSubmit(px);
            qlch.SubmitChanges();
        }

        public decimal GetDonGia(string masp)
        {
            var h = (from n in qlch.SANPHAMs where (n.MASP == masp) select n.GIA).FirstOrDefault();
            // var  h= qlch.SANPHAMs.Where(n => (n.MASP == masp)).Select(n => n.DONGIA).FirstOrDefault();
            decimal a = Convert.ToDecimal(h);
            return a;
        }

        public int GetSoLiuong(string masp)
        {
            var h = (from n in qlch.KHOHANGs where (n.MASP == masp) select n.SOLUONG).FirstOrDefault();
            int a = Convert.ToInt32(h);
            return a;
        }

        public Boolean KiemTraTrung_CTPX(string mahd, string masp)
        {
            var cthd = qlch.CHITIETPHIEUXUATs.Where(n => (n.MACTPHIEUXUAT == mahd && n.MASP == masp)).FirstOrDefault();
            if (cthd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void ThemChiTiet_PhieuXuat(string mapx, string masp, decimal dongia,
           int soluong, decimal thanhtien, string chuthich)
        {
            CHITIETPHIEUXUAT hd = new CHITIETPHIEUXUAT();
            hd.MACTPHIEUXUAT = mapx;
            hd.MASP = masp;
            hd.DONGIA = dongia;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            hd.CHUTHICH = chuthich;
            qlch.CHITIETPHIEUXUATs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaChiTiet_PhieuXuat(string mahd, string masp, int soluong, decimal thanhtien, string chuthich)
        {
            CHITIETPHIEUXUAT hd = qlch.CHITIETPHIEUXUATs.Where(d => d.MACTPHIEUXUAT == mahd && d.MASP == masp).FirstOrDefault();
            hd.MACTPHIEUXUAT = mahd;
            hd.MASP = masp;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            hd.CHUTHICH = chuthich;
            qlch.SubmitChanges();
        }
        public void xoaChiTiet_PhieuXuat(string mahd, string masp)
        {
            CHITIETPHIEUXUAT hd = qlch.CHITIETPHIEUXUATs.Where(d => d.MACTPHIEUXUAT == mahd && d.MASP == masp).FirstOrDefault();
            qlch.CHITIETPHIEUXUATs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void updateSanPham_saukhiThemCTPX(string masp, int soluong)
        {
            KHOHANG sp = qlch.KHOHANGs.Where(d => d.MASP == masp).FirstOrDefault();
            sp.SOLUONG = soluong;
            qlch.SubmitChanges();
        }
        

    }
}
