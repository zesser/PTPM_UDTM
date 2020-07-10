using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedBanHang.Models;

namespace WedBanHang.Controllers
{
    public class UserActiveController : Controller
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        //Xử lý đăng nhập đúng sai
        [HttpPost]
        public ActionResult XuLyLogin(FormCollection col)
        {
            KHACHHANG tbl_Khach = dulieu.KHACHHANGs.FirstOrDefault(k => k.TENDN == col["txt_DangNhap"] && k.MATKHAU == col["txt_Password"]);
            if (tbl_Khach == null)
            {
                return View("Register");
            }
            else
            {
                Session["UserDN"] = new Muser() { MaKH = tbl_Khach.MAKHACHHANG.ToString(), mUsername = tbl_Khach.TENDN, TenKH = tbl_Khach.TENKHACHHANG };
                return RedirectToAction("lstSanPham", "Home");
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
            KHACHHANG khachhang = new KHACHHANG();
            var tendn = col["txt_regUser"];
            var password1 = col["txt_rePassword"];
            var password2 = col["txt_rePassword2"];
            var tennd = col["txt_Name"];
            var diachind = col["txt_Diachi"];
            var sodienthoaind = col["txt_Dienthoai"];
            var mailnd = col["txt_mail"];
            List<KHACHHANG> lstmakh = dulieu.KHACHHANGs.ToList();
            string makh = lstmakh.LastOrDefault().MAKHACHHANG;
            String[] ma = makh.Split('K', 'H');
            int stt = Int16.Parse(ma[2]) + 1;
            makh = "KH" + stt;
            khachhang.MAKHACHHANG = makh;
            khachhang.TENDN = tendn;
            khachhang.MATKHAU = password1;
            khachhang.TENKHACHHANG = tennd;
            khachhang.DIACHI = diachind;
            khachhang.DIENTHOAI = sodienthoaind;
            khachhang.EMAIL = mailnd;
            dulieu.KHACHHANGs.InsertOnSubmit(khachhang);
            dulieu.SubmitChanges();
            return RedirectToAction("Login");
        }
        //Hiển thị dữ liệu khách hàng
        public ActionResult mUser(String Ma)
        {
            KHACHHANG khach = dulieu.KHACHHANGs.FirstOrDefault(k => k.MAKHACHHANG.ToString() == Ma);
            List<HOADON> lstDataHoaDon = dulieu.HOADONs.Where(m => m.MAHD == Ma).ToList();
            List<HoaDon> lstHoaDon = new List<HoaDon>();
            foreach (var i in lstDataHoaDon)
            {
                HoaDon hdon = new HoaDon(i.MAHD.ToString());
                lstHoaDon.Add(hdon);
            }
            ViewBag.HoaDon = khach.TENKHACHHANG;
            return View(lstHoaDon);
        }
        //Đăng xuất
        public ActionResult mDangxuat()
        {
            Session.Clear();
            return RedirectToAction("lstSanPham","Home");
        }
    }
}