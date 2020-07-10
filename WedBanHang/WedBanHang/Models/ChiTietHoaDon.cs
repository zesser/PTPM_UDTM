using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class ChiTietHoaDon
    {
        DulieuDataContext dulieu = new DulieuDataContext();
        public int maHoaDon { get; set; }
        public string maSanPham { get; set; }
        public int SoLuong { get; set; }
        public ChiTietHoaDon() { }
        public ChiTietHoaDon(int maHoaDon,string maSp)
        {
            tbl_ChiTietHD chitiet = dulieu.tbl_ChiTietHDs.FirstOrDefault(m => m.MAHD == (int)maHoaDon && m.MASP == maSp);
            maHoaDon =chitiet.MAHD;
            maSanPham = chitiet.MASP;
            SoLuong = (int)chitiet.SOLUONG;
        }
        
    }
}