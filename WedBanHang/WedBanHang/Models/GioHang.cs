using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class GioHang
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        public String MaSP { set; get; }
        public String TenSP { set; get; }
        public String Hinh { set; get; }
        public int Soluong { set; get; }

        public Double DonGia { set; get; }
        public Double ThanhTien { 
            get { return Soluong * DonGia; } 
        }

        public GioHang(String masp)
        {
            SANPHAM sp = dulieu.SANPHAMs.Single(s => s.MASP == masp);
            TenSP = sp.TENSP;
            MaSP = sp.MASP;
            Hinh = sp.ANHSP;
            Soluong = 1;
            DonGia = Double.Parse(sp.GIA.ToString());
        }
    }
}