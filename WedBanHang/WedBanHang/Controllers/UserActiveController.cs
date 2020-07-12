using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                Session["ERROR_LOGIN"] = "SAI TÊN ĐĂNG NHẬP OR MẬT KHẨU";
                return RedirectToAction("Login");
            }
            else
            {
                if (Session["ERROR_LOGIN"] != null)
                    Session["ERROR_LOGIN"] = null;
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
            /*List<KHACHHANG> lstmakh = dulieu.KHACHHANGs.ToList();
            string makh = lstmakh.LastOrDefault().MAKHACHHANG;
            String[] ma = makh.Split('K', 'H');
            int stt = Int16.Parse(ma[2]) + 1;
            makh = "KH" + stt;*/
            khachhang.MAKHACHHANG = "KH";
            khachhang.TENDN = tendn;
            khachhang.MATKHAU = password1;
            khachhang.TENKHACHHANG = tennd;
            khachhang.DIACHI = diachind;
            khachhang.DIENTHOAI = sodienthoaind;
            khachhang.EMAIL = mailnd;
            if (checkRegister(khachhang) != true)
                return RedirectToAction("Register");
            dulieu.KHACHHANGs.InsertOnSubmit(khachhang);
            dulieu.SubmitChanges();
            return RedirectToAction("Login");
        }
        public Boolean checkRegister(KHACHHANG kh)
        {
            KHACHHANG moi = dulieu.KHACHHANGs.FirstOrDefault(k => k.TENDN == kh.TENDN);
            Session["checkloi"] = "";
            if ( moi!= null)
            {
                Session["checkloi"] = "Tên Đăng Nhập Đã Tồn Tại";
                return false;
            }
            if (!isEmail(kh.EMAIL))
            {
                Session["checkloi"] = "email Không Hợp Lệ";
                return false;
            }
            Session["checkloi"] = "";
            return true;
        }
        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        //Hiển thị dữ liệu khách hàng
        public ActionResult mUser(String Ma)
        {
            KHACHHANG khach = dulieu.KHACHHANGs.FirstOrDefault(k => k.MAKHACHHANG.ToString() == Ma);
            List<HOADON> lstDataHoaDon = dulieu.HOADONs.Where(m => m.MAKHACHHANG == Ma).ToList();
            List<HoaDon> lstHoaDon = new List<HoaDon>();
            foreach (var i in lstDataHoaDon)
            {
                HoaDon hdon = new HoaDon(i.MAHD);
                lstHoaDon.Add(hdon);
            }
            ViewBag.HoaDon = khach.TENKHACHHANG;
            return View(lstHoaDon);
        }
        //Thông tin khách hàng
        [HttpGet]
        public ActionResult TTCT()
        {
            Muser user = Session["UserDN"] as Muser;
            KHACHHANG kh = dulieu.KHACHHANGs.FirstOrDefault(m => m.MAKHACHHANG == user.MaKH);
            return View(kh);
        }
        //update thong tin khách hàng
        [HttpPost]
        public ActionResult UpdateKH(FormCollection col)
        {
            var Ten = col["txt_Name"];
            var DiaChi = col["txt_Diachi"];
            var DienThoai = col["txt_Dienthoai"];
            var Email = col["txt_mail"];
            Muser user = Session["UserDN"] as Muser;
            KHACHHANG kh = dulieu.KHACHHANGs.FirstOrDefault(k => k.MAKHACHHANG == user.MaKH);
            kh.TENKHACHHANG = Ten;
            kh.DIACHI = DiaChi;
            kh.DIENTHOAI = DienThoai;
            kh.EMAIL = Email;
            if (!isEmail(Email))
            {
                Session["checkloi"] = "email Không Hợp Lệ";
                return RedirectToAction("TTCT");
            }
                
            dulieu.SubmitChanges();
            kh = dulieu.KHACHHANGs.FirstOrDefault(k => k.MAKHACHHANG == user.MaKH);
            Session["checkloi"] = "";
            return RedirectToAction("TTCT");
        }
        //Đăng xuất
        public ActionResult mDangxuat()
        {
            Session.Clear();
            return RedirectToAction("lstSanPham","Home");
        }
    }
}