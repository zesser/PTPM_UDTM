using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class GioHang
    {
        DulieuDataContext dulieu = new DulieuDataContext();
        public String MaSP { set; get; }
        public String Hinh { set; get; }
        public int Soluong { set; get; }

        public Double DonGia { set; get; }
        public Double ThanhTien { 
            get { return Soluong * DonGia; } 
        }

        public GioHang(String masp)
        {
            tbl_SanPham sp = dulieu.tbl_SanPhams.Single(s => s.MaSanPham == masp);
            MaSP = sp.MaSanPham;
            Hinh = sp.Hinh;
            Soluong = 1;
            DonGia = Double.Parse(sp.Gia.ToString());
        }
    }
}