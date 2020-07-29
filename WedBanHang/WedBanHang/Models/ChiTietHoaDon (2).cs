using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class ChiTietHoaDon
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        public string maHoaDon { get; set; }
        public string maSanPham { get; set; }
        public int SoLuong { get; set; }
        public ChiTietHoaDon() { }
        public ChiTietHoaDon(String maHoaDon,string maSp)
        {
            CHITIETHOADON chitiet = dulieu.CHITIETHOADONs.FirstOrDefault(m => m.MAHD == maHoaDon && m.MASP == maSp);
            maHoaDon =chitiet.MAHD;
            maSanPham = chitiet.MASP;
            SoLuong = (int)chitiet.SOLUONG;
        }
    }
}