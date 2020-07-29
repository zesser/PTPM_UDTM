using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class HoaDon
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        public string maHoaDon { get; set; }
        public string maKhachHang { get; set; }
        public string ngayTao { get; set; }
        public List<ChiTietHoaDon> chitiet { get; set; }
        public HoaDon() { }

        public HoaDon(string ma)
        {
            HOADON hoaDon = dulieu.HOADONs.FirstOrDefault(m => m.MAHD == ma);
            maHoaDon = hoaDon.MAHD.ToString();
            maKhachHang = hoaDon.MAKHACHHANG.ToString();
            ngayTao = hoaDon.NGAYLAP.ToString();
            List<CHITIETHOADON> lstchitiet = dulieu.CHITIETHOADONs.Where(c => c.MAHD == maHoaDon).ToList();
            chitiet = new List<ChiTietHoaDon>();
            foreach(var i in lstchitiet)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon(i.MAHD,i.MASP);
                chitiet.Add(ct);
            }
        }
    }
}