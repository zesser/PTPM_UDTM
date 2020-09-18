using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDon_BLL
    {
        QLBanDoGoDataContext qlch = new QLBanDoGoDataContext();
        public HoaDon_BLL() { }

        //hóa đơn
        public IQueryable<HOADON> LoadHoaDon_BLL()
        {
            return qlch.HOADONs.Select(h => h);
        }
        public IQueryable<KHACHHANG> loadKhachHang_BLL()
        {
            return qlch.KHACHHANGs.Select(k => k);
        }

        public double LayChietKhau(string magiamgia)
        {
            var hd = (from n in qlch.MAGIAMGIAs where (n.MAGIAMGIA1 == magiamgia) select (n.TILEGIAM)).FirstOrDefault();
            return double.Parse(hd);
        }
        public Boolean KiemTraTrung_HD(string mahd)
        {
            var hd = qlch.HOADONs.Where(n => (n.MAHD == mahd)).FirstOrDefault();
            if (hd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemHoaDon(string mahd, string manv, DateTime ngaylap,double chietkhau, decimal thanhtien, string makhachhang
            ,string tenkh, string diachigiao, string sdt, string trangthai)
        {
            HOADON hd = new HOADON();
            hd.MAHD = mahd;
            hd.MANV = manv;
            hd.NGAYLAP = ngaylap;
            hd.CHIETKHAU = chietkhau;
            hd.THANHTIEN = thanhtien;
            hd.MAKHACHHANG = makhachhang;
            hd.TENKHACHHANG = tenkh;
            hd.DIACHIGIAOHANG = diachigiao;
            hd.SDTGIAOHANG = sdt;
            hd.TRANGTHAI= trangthai;
            qlch.HOADONs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        


        public void suaHoaDon(string mahd, DateTime ngaylap, double chietkhau,  string makhachhang
            , string tenkh, string diachigiao, string sdt, string trangthai)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            hd.MAHD = mahd;
            hd.NGAYLAP = ngaylap;
            hd.CHIETKHAU = chietkhau;
            hd.MAKHACHHANG = makhachhang;
            hd.TENKHACHHANG = tenkh;
            hd.DIACHIGIAOHANG = diachigiao;
            hd.SDTGIAOHANG = sdt;
            hd.TRANGTHAI = trangthai;
            qlch.SubmitChanges();
        }

        // xóa nhân viên
        public void xoaHoaDon(string mahd)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            qlch.HOADONs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }
        public void updateThanhTienHoaDon_saukhiThemCTD(string mahd, decimal tongtien)
        {
            HOADON hd = qlch.HOADONs.Where(d => d.MAHD == mahd).FirstOrDefault();
            hd.MAHD = mahd;
            hd.THANHTIEN = tongtien;
            qlch.SubmitChanges();
        }

        public string getTenKhach(string makh)
        {
            var hd = (from n in qlch.KHACHHANGs where (n.MAKHACHHANG == makh) select n.TENKHACHHANG).FirstOrDefault();
            return hd;
        }
        public string getDiaChi(string makh)
        {
            var hd = (from n in qlch.KHACHHANGs where (n.MAKHACHHANG == makh) select n.DIACHI).FirstOrDefault();
            return hd;
        }
        public string getSoDT(string makh)
        {
            var hd = (from n in qlch.KHACHHANGs where (n.MAKHACHHANG == makh) select n.DIENTHOAI).FirstOrDefault();
            return hd;
        }


        // chi tiết hóa đơn
        public IQueryable LoadChiTiet_HD_BLL(string mahd)
        {
            var h = (from s in qlch.CHITIETHOADONs
                     join l in qlch.KHOHANGs
                     on s.MASP
                     equals l.MASP
                     where s.MAHD == mahd
                     select new
                     {
                         s.MAHD,
                         s.MASP,
                         l.TENSP,
                         s.DONGIA,
                         s.SOLUONG,
                         s.TONGTIEN
                     });
            return h;
        }

        public IQueryable<SANPHAM> LoadSanPham_BLL()
        {
            return qlch.SANPHAMs.Select(h => h);
        }

        public decimal GetDonGia(string masp)
        {
            var h = (from n in qlch.KHOHANGs where (n.MASP == masp) select n.DONGIA).FirstOrDefault();
            // var  h= qlch.SANPHAMs.Where(n => (n.MASP == masp)).Select(n => n.DONGIA).FirstOrDefault();
            decimal a = Convert.ToDecimal(h);
            return a;
        }

        public int GetSoLuong(string masp)
        {
            var h = (from n in qlch.KHOHANGs where (n.MASP == masp) select n.SOLUONG).FirstOrDefault();
            int a = Convert.ToInt32(h);
            return a;
        }
        public void ThemChiTiet_HoaDon(string mahd, string masp,
           int soluong, decimal dongia , decimal tongtien)
        {
            CHITIETHOADON hd = new CHITIETHOADON();
            hd.MAHD = mahd;
            hd.MASP = masp;
            hd.DONGIA = dongia;
            hd.SOLUONG = soluong;
            hd.TONGTIEN = tongtien;
            qlch.CHITIETHOADONs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaChiTiet_HoaDon(string mahd, string masp, int soluong, decimal tongtien)
        {
            CHITIETHOADON hd = qlch.CHITIETHOADONs.Where(d => d.MAHD == mahd && d.MASP == masp).FirstOrDefault();
            hd.MAHD = mahd;
            hd.MASP = masp;
            hd.SOLUONG = soluong;
            hd.TONGTIEN = tongtien;
            qlch.SubmitChanges();
        }
        public void xoaChiTiet_HoaDon(string mahd, string masp)
        {
            CHITIETHOADON hd = qlch.CHITIETHOADONs.Where(d => d.MAHD == mahd && d.MASP == masp).FirstOrDefault();
            qlch.CHITIETHOADONs.DeleteOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public Boolean KiemTraTrung_CTHD(string mahd, string masp)
        {
            var cthd = qlch.CHITIETHOADONs.Where(n => (n.MAHD == mahd && n.MASP == masp)).FirstOrDefault();
            if (cthd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void updateSanPham_saukhiThemCTD(string masp, int soluong)
        {
            KHOHANG sp = qlch.KHOHANGs.Where(d => d.MASP == masp).FirstOrDefault();
            sp.SOLUONG = soluong;
            qlch.SubmitChanges();
        }

        public double getsoChietKhau(string mahd)
        {
            var hd = (from n in qlch.HOADONs where (n.MAHD == mahd) select n.CHIETKHAU).FirstOrDefault();
            return  Convert.ToDouble( hd);
        }
    }
}
