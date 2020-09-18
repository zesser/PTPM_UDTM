using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhieuGiao_BLL
    {
        QLBanDoGoDataContext qlch = new QLBanDoGoDataContext();
        public PhieuGiao_BLL() { }
        public IQueryable<KHACHHANG> LoadMaKH_BLL()
        {
            return qlch.KHACHHANGs.Select(h => h);
        }

        public IQueryable<PHIEUXUAT> LoadMaPX_BLL()
        {
            return qlch.PHIEUXUATs.Select(h => h);
        }
        public string GetTenKH(string makh)
        {
            var h = (from n in qlch.KHACHHANGs where (n.MAKHACHHANG == makh) select n.TENKHACHHANG).FirstOrDefault();
            return h;
        }
        public string GetDiaChiKH(string makh)
        {
            var h = (from n in qlch.KHACHHANGs where (n.MAKHACHHANG == makh) select n.DIACHI).FirstOrDefault();
            return h;
        }

        public IQueryable<PHIEUGIAO> LoadMaPG_BLL()
        {
            return qlch.PHIEUGIAOs.Select(h => h);
        }

        public IQueryable LoadChiTiet_PG_BLL(string mahd)
        {
            var h = (from s in qlch.CHITIETPHIEUGIAOs
                     join l in qlch.KHOHANGs
                     on s.MASP
                     equals l.MASP
                     where s.MACTPHIEUGIAO == mahd
                     select new
                     {
                         s.MACTPHIEUGIAO,
                         s.MASP,
                         l.TENSP,
                         s.DONGIA,
                         s.SOLUONG,
                         s.THANHTIEN,
                         s.CHUTHICH
                     });

            return h;
        }

        public IQueryable<SANPHAM> LoadMaSP_BLL()
        {
            return qlch.SANPHAMs.Select(h => h);
        }
        public Boolean KiemTraTrung_PG(string mapx)
        {
            var pn = qlch.PHIEUGIAOs.Where(d => d.MAPHIEUGIAO == mapx).FirstOrDefault();
            if (pn != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }
        public void ThemPhieuGiao(string mapg, string makh, string mapx, string tenkh,string diachi,string manv, DateTime ngaylap,Decimal tongtien)
        {
            PHIEUGIAO px = new PHIEUGIAO();
            px.MAPHIEUGIAO = makh;
            px.MAKHACHHANG = makh;
            px.MAPHIEUXUAT = mapx;
            px.TENNGUOINHAN = tenkh;
            px.DIACHIGIAOHANG = diachi;
            px.MANV = manv;
            px.NGAYLAPPHIEU = ngaylap;
            px.TONGTHANHTIEN = tongtien;
            qlch.PHIEUGIAOs.InsertOnSubmit(px);
            qlch.SubmitChanges();
        }

        

        public void suaPhieuGiao(string mapg, string makh, string tenkh, string diachi, DateTime ngaylap )
        {
            PHIEUGIAO px = qlch.PHIEUGIAOs.Where(d => d.MAPHIEUGIAO == mapg).FirstOrDefault();
            px.MAKHACHHANG = makh;
            px.TENNGUOINHAN = tenkh;
            px.DIACHIGIAOHANG = diachi;
            px.NGAYLAPPHIEU = ngaylap;
            qlch.SubmitChanges();
        }

        public void suaPhieuGiao_TongTien(string mapg, decimal tongtien)
        {
            PHIEUGIAO px = qlch.PHIEUGIAOs.Where(d => d.MAPHIEUGIAO == mapg).FirstOrDefault();
            px.TONGTHANHTIEN = tongtien;
            qlch.SubmitChanges();
        }
        // xóa nhân viên
        public void xoaPhieuGiao(string mapg)
        {
            PHIEUGIAO px = qlch.PHIEUGIAOs.Where(d => d.MAPHIEUGIAO == mapg).FirstOrDefault();
            qlch.PHIEUGIAOs.DeleteOnSubmit(px);
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

        public Boolean KiemTraTrung_CTPG(string mahd, string masp)
        {
            var cthd = qlch.CHITIETPHIEUGIAOs.Where(n => (n.MACTPHIEUGIAO == mahd && n.MASP == masp)).FirstOrDefault();
            if (cthd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }

        public void ThemChiTiet_PhieuGiao(string mapg, string masp, decimal dongia,
           int soluong, decimal thanhtien, string chuthich)
        {
            CHITIETPHIEUGIAO hd = new CHITIETPHIEUGIAO();
            hd.MACTPHIEUGIAO = mapg;
            hd.MASP = masp;
            hd.DONGIA = dongia;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            hd.CHUTHICH = chuthich;
            qlch.CHITIETPHIEUGIAOs.InsertOnSubmit(hd);
            qlch.SubmitChanges();
        }

        public void suaChiTiet_PhieuGiao(string mahd, string masp, int soluong, decimal thanhtien, string chuthich)
        {
            CHITIETPHIEUGIAO hd = qlch.CHITIETPHIEUGIAOs.Where(d => d.MACTPHIEUGIAO == mahd && d.MASP == masp).FirstOrDefault();
            hd.MACTPHIEUGIAO = mahd;
            hd.MASP = masp;
            hd.SOLUONG = soluong;
            hd.THANHTIEN = thanhtien;
            hd.CHUTHICH = chuthich;
            qlch.SubmitChanges();
        }
        public void xoaChiTiet_PhieuGiao(string mahd, string masp)
        {
            CHITIETPHIEUGIAO hd = qlch.CHITIETPHIEUGIAOs.Where(d => d.MACTPHIEUGIAO == mahd && d.MASP == masp).FirstOrDefault();
            qlch.CHITIETPHIEUGIAOs.DeleteOnSubmit(hd);
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
