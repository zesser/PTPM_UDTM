using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class HoaDon
    {
        DulieuDataContext dulieu = new DulieuDataContext();
        public string maHoaDon { get; set; }
        public string maKhachHang { get; set; }
        public string ngayTao { get; set; }
        public List<ChiTietHoaDon> chitiet { get; set; }
        public HoaDon() { }

        public HoaDon(string ma)
        {
            tbl_HoaDon hoaDon = dulieu.tbl_HoaDons.FirstOrDefault(m => m.MaHoaDon == Int16.Parse(ma));
            maHoaDon = hoaDon.MaHoaDon.ToString();
            maKhachHang = hoaDon.MaKH.ToString();
            ngayTao = hoaDon.NgayTao.ToString();
            List<tbl_ChiTietHD> lstchitiet = dulieu.tbl_ChiTietHDs.Where(c => c.MAHD == Int16.Parse(maHoaDon)).ToList();
            chitiet = new List<ChiTietHoaDon>();
            foreach(var i in lstchitiet)
            {
                ChiTietHoaDon ct = new ChiTietHoaDon(i.MAHD,i.MASP);
                chitiet.Add(ct);
            }
        }
    }
}