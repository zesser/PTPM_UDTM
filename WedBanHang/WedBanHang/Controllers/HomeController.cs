using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanHang.Models;

namespace WedBanHang.Controllers
{
    public class HomeController : Controller
    {
        DulieuDataContext dulieu = new DulieuDataContext();
        // GET: Home
        public ActionResult Index()
        {
            List<tbl_SanPham> lstSanPham = dulieu.tbl_SanPhams.ToList();
            return View(lstSanPham);
        }
        //GET: 1 San Pham
        public ActionResult SanPham(String Ma)
        {
            tbl_SanPham sanPham = dulieu.tbl_SanPhams.FirstOrDefault(sp => sp.MaSanPham == Ma);
            return View(sanPham);
        }
        //page Đăng nhập
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Xử lý đăng nhập đúng sai
        [HttpPost]
        public ActionResult XuLyLogin(FormCollection col)
        {
            tbl_KhachHang tbl_Khach = dulieu.tbl_KhachHangs.FirstOrDefault(k => k.SoDienThoai == col["txt_DangNhap"] && k.MatKhau == col["txt_Password"]);
            if (tbl_Khach == null)
            {
                return View("Register");
            }
            else
            {
                Session["UserDN"] = new Muser() { Login = tbl_Khach.MaKhachHang.ToString(), mPassword = tbl_Khach.MatKhau, mUserName = tbl_Khach.TenKhachHang } ;
                return View("Index");
            }
        }
        //Trang đăng ký
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //Xử Lý đăng ký đúng sai cập nhật cơ sỡ dữ liệu
        [HttpPost]
        public ActionResult InsertUserToDatabase(FormCollection col)
        {
            var a = col["txt_regUser"];
            var b = col["txt_rePassword"];
            var c = col["txt_rePassword2"];
            var d = col["txt_Name"];
            var e = col["txt_Diachi"];
            var f = col["txt_Dienthoai"];
            var g = col["txt_mail"];
            var h = col["txt_ngaythang"];
            return RedirectToAction("Login");
        }
        //Tạo giỏ hàng
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
                return RedirectToAction("Index");
            }
            ViewBag.Tongtien = TongTien();
            return View(lstGioHang);
        }
        //Thêm giỏ hàng
        public ActionResult ThemGioHang(String Ma,int select)
        {
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.Find(n => n.MaSP == Ma);
            if (sp == null)
            {
                sp = new GioHang(Ma);
                lstGioHang.Add(sp);
            }
            else
            {
                sp.Soluong++;
            }
            if (select == 1)
                return RedirectToAction("Giohang");//mua ngay
            else return RedirectToAction("SanPham",new {Ma=Ma});//them gio hang
        }
        // cập nhật tổng tiền
        private double TongTien()
        {
            double tongtien=0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                tongtien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return tongtien;
        }
        // cập nhật hóa đơn
        [HttpPost]
        public ActionResult ThemPhieuMuaHang(FormCollection col)
        {
            return View();
        }
        //Hiển thij dữ liệu khách hàng
        public ActionResult mUser(String Ma)
        {
            tbl_KhachHang khach = dulieu.tbl_KhachHangs.FirstOrDefault(k => k.MaKhachHang.ToString() == Ma);
            return View(khach);
        }
        //Tìm kiếm
        [HttpPost]
        public ActionResult Search(FormCollection col)
        {
            String keySearch = col["txtseach"];
            List<tbl_SanPham> lst = dulieu.tbl_SanPhams.Take(8).ToList();
            List<tbl_SanPham> sanPhams =lst.Where(sp => sp.MaL.Contains(keySearch)).ToList();
            return View(sanPhams);
        }
        //Đăng xuất
        public ActionResult mDangxuat()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        //Loại sản phẩm
        public PartialViewResult lstLoaiSP()
        {
            List<tbl_Loai> loais = dulieu.tbl_Loais.ToList();
            return PartialView(loais);
        }
        //Load ds theo Loai
        public ActionResult pageLoais(String mLoai)
        {
            List<tbl_SanPham> SanPhams = dulieu.tbl_SanPhams.Where(sp => sp.MaL == mLoai).ToList();
            return View(SanPhams);
        }
        //Nhóm sản phẩm
        public PartialViewResult lstNhom()
        {
            List<tbl_Nhom> lstNhom = dulieu.tbl_Nhoms.ToList();
            return PartialView(lstNhom);
        }
        //load ds theo Nhom
        public ActionResult pageNhoms(String mNhom)
        {
            List<tbl_Loai> lstloais = dulieu.tbl_Loais.Where(sp => sp.Nhom == mNhom).ToList();
            List<tbl_SanPham> SanPhams = new List<tbl_SanPham>();
            foreach (var i in lstloais)
            {
                List<tbl_SanPham> sanpham = dulieu.tbl_SanPhams.Where(sp => sp.MaL == i.MaLoai).ToList();
                SanPhams.AddRange(sanpham);
            }
            return View(SanPhams);
        }

        //Thanh toan
        public ActionResult ThanhToan()
        {
            if (Session["UserDN"] == null)
                return Redirect("Login");
            else
            {
                List<GioHang> lstGioHang = LayGioHang();
                tbl_HoaDon hoadon = new tbl_HoaDon();
                tbl_ChiTietHD chitiethoadon = new tbl_ChiTietHD();
            }
            return View();
        }
    }
}