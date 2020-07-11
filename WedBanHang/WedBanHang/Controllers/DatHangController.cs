using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanHang.Models;

namespace WedBanHang.Controllers
{
    public class DatHangController : Controller
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Giỏ hàng
        public ActionResult Giohang()
        {
            List<GioHang> lstGioHang = LayGioHang();
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }
            if (ViewBag.giamgia != null)
                ViewBag.Tongtien = TongTien();
            ViewBag.Tongtien = TongTien();
            return View(lstGioHang);
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(String Ma, int select)
        {
            List<GioHang> lstGioHang = LayGioHang();
            SANPHAM chon = dulieu.SANPHAMs.FirstOrDefault(c => c.MASP == Ma);
            GioHang sp = lstGioHang.Find(n => n.MaSP == Ma);
            if (sp == null)
            {
                sp = new GioHang(Ma);
                lstGioHang.Add(sp);
            }
            else
            {
                if (sp.DonGia == (double)chon.GIA)
                    sp.Soluong++;
                else
                {
                    sp = new GioHang(Ma);
                    lstGioHang.Add(sp);
                }
            }
            if (select == 1)
                return RedirectToAction("Giohang");//mua ngay
            else return RedirectToAction("SanPham","Home", new { Ma = Ma });// them gio hang
        }
        //Delete sp
        public ActionResult DeleteSP(String ma)
        {
            List<GioHang> lstGioHang = LayGioHang();
            lstGioHang.RemoveAll(t => t.MaSP == ma);
            return Redirect("GioHang");
        }
        // cập nhật tổng tiền
        private double TongTien()
        {
            double tongtien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongtien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return tongtien;
        }
        //cập nhật sl sản phẩm
        public ActionResult UpdateSL(String ma, Boolean update)
        {
            GioHang gioGioHang = LayGioHang().FirstOrDefault(f => f.MaSP == ma);
            if (update == true)
                gioGioHang.Soluong++;
            else gioGioHang.Soluong--;
            return RedirectToAction("Giohang");
        }
        // cập nhật hóa đơn
        [HttpPost]
        public ActionResult ThemPhieuMuaHang(FormCollection col)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Dathang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (Session["UserDN"] == null)
                return RedirectToAction("Login","UserActive");
            return View(lstGioHang);
        }
        //Thanh toan
        public ActionResult ThanhToan()
        {
            if (Session["UserDN"] == null)
                return RedirectToAction("Login","UserActive");
            else
            {
                List<GioHang> lstGioHang = LayGioHang();
                HOADON hoadon = new HOADON();
                CHITIETHOADON chitiethoadon = new CHITIETHOADON();
            }
            return View();
        }
        //cặp nhật giảm giá
        [HttpPost]
        public ActionResult XuLyGiamGia(FormCollection col)
        {
            var giam = col["txt_maGiamGia"];
            List<GioHang> lstGiohang = LayGioHang();
            MAGIAMGIA giams = dulieu.MAGIAMGIAs.FirstOrDefault(g => g.MAGIAMGIA1 == giam);
            GioHang hang = lstGiohang.FirstOrDefault(l => l.MaSP == giams.MASP);
            if (Session["Giamgia"] == null)
            {
                if (hang != null)
                {
                    if (hang.Soluong == 1)
                        hang.DonGia = (double)hang.DonGia - hang.DonGia * double.Parse(giams.TILEGIAM);
                    else
                    {
                        hang.Soluong--;
                        GioHang hang2 = new GioHang(hang.MaSP);
                        hang2.DonGia = (double)hang.DonGia - hang.DonGia * double.Parse(giams.TILEGIAM);
                        lstGiohang.Add(hang2);
                    }
                    Session["Giamgia"] = 1;
                }
            }
            return RedirectToAction("HoaDon");
        }
        [HttpPost]
        public ActionResult XuatHoaDon(FormCollection col)
        {
            return View();
        }
    }
}