using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhieuNhap_BLL
    {

        QLBanDoGoDataContext qlch = new QLBanDoGoDataContext();

        public PhieuNhap_BLL()
        { 
        }

        public IQueryable loadNCC()
        {
            var nccs = from ncc in qlch.NHACUNGCAPs select ncc;

            return nccs;
        }

        public String loadTenNCC(String mancc)
        {
            var tenncc = qlch.NHACUNGCAPs.FirstOrDefault(t => t.MANCC == mancc);

            if (tenncc != null)
                return tenncc.TENNCC;
            else
                return "";
        }

        public String loadTenNV(String manv)
        {
            var tennv = qlch.NHANVIENs.FirstOrDefault(t => t.MANV == manv);

            if (tennv != null)
                return tennv.TENNV;
            else
                return "";
        }

        public String loadTenSP(String masp)
        {
            var tensp = qlch.SANPHAMs.FirstOrDefault(t => t.MASP == masp);

            if (tensp != null)
                return tensp.TENSP;
            else
                return "";
        }

        public String loadDonGia(String masp)
        {
            var tensp = qlch.SANPHAMs.FirstOrDefault(t => t.MASP == masp);

            if (tensp != null)
                return Convert.ToString(tensp.GIA);
            else
                return "";
        }

        public IQueryable loadSanPham()
        {
            var sps = from sp in qlch.SANPHAMs select sp;

            return sps;
        }

        public IEnumerable<PHIEUNHAP> loadPhieuNhapALL()
        {
            return qlch.PHIEUNHAPs;
        }


            public IQueryable loadPhieuNhap(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            var phieunhaps = from pn in qlch.PHIEUNHAPs.Where(t => t.NGAYLAP >= ngaybatdau && t.NGAYLAP <= ngayketthuc) 
                             select new {pn.MAPN, pn.MANV, pn.MANCC, pn.NGAYLAP };

            return phieunhaps;
        }

        public IQueryable loadChiTietPN(String mapn)
        {
            var chitietpns = from ctpn in qlch.CHITIETPHIEUNHAPs.Where(t => t.MACTPN== mapn) 
                             join sp in qlch.SANPHAMs on ctpn.MASP equals sp.MASP 
                             select new {ctpn.MASP, sp.TENSP, ctpn.SOLUONG, ctpn.DONGIA, ctpn.THANHTIEN };

            return chitietpns;
        }

        public void themPhieuNhap(String mapn, String manv, String mancc, DateTime ngaylap)
        {
            PHIEUNHAP pn = new PHIEUNHAP();
            pn.MAPN = mapn;
            pn.MANV = manv;
            pn.MANCC = mancc;
            pn.NGAYLAP = ngaylap;

            qlch.PHIEUNHAPs.InsertOnSubmit(pn);
            qlch.SubmitChanges();
        }

        public void xoaPhieuNhap(String mapn)
        {
            PHIEUNHAP pn = qlch.PHIEUNHAPs.Where(t => t.MAPN == mapn).FirstOrDefault();

            qlch.PHIEUNHAPs.DeleteOnSubmit(pn);
            qlch.SubmitChanges();
        }

        public void suaPhieuNhap(String mapn, String manv, String mancc, DateTime ngaylap)
        {
            PHIEUNHAP pn = qlch.PHIEUNHAPs.Where(t => t.MAPN == mapn).FirstOrDefault();
            pn.MANV = manv;
            pn.MANCC = mancc;
            pn.NGAYLAP = ngaylap;

            qlch.SubmitChanges();
        }

        public Boolean KiemTraTrung_CTPN(string mahd, string masp)
        {
            var cthd = qlch.CHITIETPHIEUNHAPs.Where(n => (n.MACTPN == mahd && n.MASP == masp)).FirstOrDefault();
            if (cthd != null)
            {
                return false; // đã tồn tại
            }
            return true; // chưa tồn tại
        }


        public void themChiTietPN( String mapn, String masp, int soluong, double dongia, double thanhtien)
        {
            String dg = Convert.ToString(dongia);
            String tt = Convert.ToString(thanhtien);
            CHITIETPHIEUNHAP ctpn = new CHITIETPHIEUNHAP();
            ctpn.MACTPN = mapn;
            ctpn.MASP = masp;
            ctpn.SOLUONG = soluong;
            ctpn.DONGIA = decimal.Parse(dg);
            ctpn.THANHTIEN = decimal.Parse(tt);

            qlch.CHITIETPHIEUNHAPs.InsertOnSubmit(ctpn);
            qlch.SubmitChanges();
        }

        public void xoaChiTietPN(String mapn, String masp)
        { 
            CHITIETPHIEUNHAP ctpn = qlch.CHITIETPHIEUNHAPs.Where(t => t.MACTPN == mapn && t.MASP == masp).FirstOrDefault();

            qlch.CHITIETPHIEUNHAPs.DeleteOnSubmit(ctpn);
            qlch.SubmitChanges();
        }

        public void suaChiTietPN(String mapn, String masp, int soluong, double thanhtien)
        {
            String tt = Convert.ToString(thanhtien);

            CHITIETPHIEUNHAP ctpn = qlch.CHITIETPHIEUNHAPs.Where(t => t.MACTPN == mapn && t.MASP == masp).FirstOrDefault();

            ctpn.SOLUONG = soluong;
            ctpn.THANHTIEN = decimal.Parse(tt);

            qlch.SubmitChanges();
        }
    }
}
