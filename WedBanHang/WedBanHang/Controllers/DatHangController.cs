using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
            List<GioHang> lstGioHang = LayGioHang();
            if (Session["UserDN"] == null)
                return RedirectToAction("Login","UserActive");
            return View(lstGioHang);
        }
        //Thanh toan
        [HttpPost]
        public ActionResult ThanhToan(FormCollection col)
        {
            var name = col["firstname"] +" "+ col["lastname"];
            var ngaynhan = col["day"];
            var diachi = col["address"];
            var dienthoai = col["phone"];
            HOADON hd = new HOADON();
            Muser user = Session["UserDN"] as Muser;
            hd.MAHD = "HD";
            hd.NGAYLAP = DateTime.Today;
            hd.TENKHACHHANG = name;
            hd.DIACHIGIAOHANG = diachi;
            hd.SDTGIAOHANG = dienthoai;
            hd.MAKHACHHANG = user.MaKH;
            var chietkhau = 0.0;
            var msp = "";
            if (Session["Giamgia"] != null)
            {
                chietkhau = double.Parse(dulieu.MAGIAMGIAs.FirstOrDefault(m => m.MAGIAMGIA1 == Session["Giamgia"]).TILEGIAM);
                msp = dulieu.MAGIAMGIAs.FirstOrDefault(m => m.MAGIAMGIA1 == Session["Giamgia"]).MASP;
                hd.CHIETKHAU = chietkhau/10.0 * (double)dulieu.SANPHAMs.FirstOrDefault(s => s.MASP == msp).GIA;
            }
            hd.THANHTIEN = (decimal?)TongTien();
            dulieu.HOADONs.InsertOnSubmit(hd);
            dulieu.SubmitChanges();
            ViewBag.TongTien=TongTien();
            List<HOADON> mahh = dulieu.HOADONs.Where(h => h.MAKHACHHANG == user.MaKH && h.TENKHACHHANG == name && h.NGAYLAP == DateTime.Today).ToList();
            HOADON mah = mahh.Last();
            string mahd = mah.MAHD;
            List<GioHang> lstGioHang = LayGioHang();
            foreach(GioHang i in lstGioHang)
            {
                CHITIETHOADON ct = dulieu.CHITIETHOADONs.FirstOrDefault(c=>c.MAHD==mahd && c.MASP==i.MaSP);
                if (ct == null)
                {
                    ct = new CHITIETHOADON();
                    ct.MAHD = mahd;
                    ct.MASP = i.MaSP;
                    ct.SOLUONG = i.Soluong;
                    ct.DONGIA = (decimal?)i.DonGia;
                    ct.TONGTIEN = (decimal?)i.ThanhTien;
                    dulieu.CHITIETHOADONs.InsertOnSubmit(ct);
                }
                else
                {
                    ct.SOLUONG = i.Soluong+ct.SOLUONG;
                    ct.TONGTIEN = (decimal?)i.ThanhTien+ct.TONGTIEN;
                }
                dulieu.SubmitChanges();
            }
            return View(hd);
        }
        //cặp nhật giảm giá
        [HttpPost]
        public ActionResult XuLyGiamGia(FormCollection col)
        {
            var giam = col["magiamgia"];
            List<GioHang> lstGiohang = LayGioHang();
            MAGIAMGIA giams = dulieu.MAGIAMGIAs.FirstOrDefault(g => g.MAGIAMGIA1 == giam);
            if (giams == null)
            {
                Session["checkloi"] = "mã giảm giá không tồn tại!";
                return RedirectToAction("Dathang");
            }
            GioHang hang = lstGiohang.FirstOrDefault(l => l.MaSP == giams.MASP);
            if (Session["Giamgia"] == null)
            {
                if (hang != null)
                {
                    if (hang.Soluong == 1)
                    {
                        hang.DonGia = (double)hang.DonGia - (hang.DonGia * (double.Parse(giams.TILEGIAM)/10.0));
                        Session["checkloi"] = "";
                    }    
                    else
                    {
                        hang.Soluong--;
                        GioHang hang2 = new GioHang(hang.MaSP);
                        hang2.DonGia = (double)hang.DonGia - hang.DonGia * (double.Parse(giams.TILEGIAM) / 10.0);
                        lstGiohang.Add(hang2);
                        Session["checkloi"] = "";
                    }
                    Session["Giamgia"] = giam;
                }
                else
                {
                    Session["checkloi"] = "mã giảm giá không phù hợp mới sản phẩm bạn mua!";
                    Session["Giamgia"] = "";
                }
            }
            else
            {
                Session["checkloi"] = "Không thể nhập quá 2 mã giảm giá!";
            }
            return RedirectToAction("Dathang");
        }
        public ActionResult XuLyEnd()
        {
            Session["GioHang"] = null;
            Session["Giamgia"] = null;
            Session["checkloi"] = null;
            return RedirectToAction("lstSanPham","Home");
        }
    }
}