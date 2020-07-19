using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WedBanHang.Models;

namespace WedBanHang.Controllers
{
    public class HomeController : Controller
    {
        QLBanDoGoDataContext dulieu = new QLBanDoGoDataContext();
        // GET: Home
        public ActionResult lstSanPham()
        {
            List<SANPHAM>lstsanpham = dulieu.SANPHAMs.ToList();
            Session["lsSanPham"] = lstsanpham;
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<SANPHAM> lstSanPhams = Session["lsSanPham"] as List<SANPHAM>;
            List<sanpham> lstHienThi = new List<sanpham>();
            foreach(SANPHAM i in lstSanPhams)
            {
                sanpham sp = new sanpham(i.MASP);
                lstHienThi.Add(sp);
            }
            return View(lstHienThi);
        }
        //Get all image in folder

        public static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
        //change direction to name
        public static String imageFiles(string name)
        {
            string fileName = name;
            FileInfo fi = new FileInfo(fileName);
            string justFileName = fi.Name;
            return justFileName;
        }
        //get direction image
        public static List<string> GetAllImageName(String nameFolder)
        {
            List<string> lst = new List<string>();
            String searchFolder = @"C:\Users\phand\Downloads\PTPM_UDTM-master\PTPM_UDTM-master\WedBanHang\WedBanHang\Models\anhsp\anhdoanweb\"+nameFolder;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = GetFilesFrom(searchFolder, filters, false);
            foreach (string i in files)
            {
                string imageName = imageFiles(i);
                lst.Add(imageName);
            }
            return lst;
        }
        //GET: 1 San Pham
        public ActionResult SanPham(String Ma)
        {
            SANPHAM sanPham = dulieu.SANPHAMs.FirstOrDefault(sp => sp.MASP == Ma);
            ViewBag.slSP = dulieu.KHOHANGs.FirstOrDefault(k => k.MASP == Ma).SOLUONG;
            return View(sanPham);
        }      
        //Chuyển đổi chữ hoa thành chữ thường
        public static string UpperToLower(string str)
        {
            string chuoi = "";
            foreach (char i in str)
            {
                if (char.IsUpper(i))
                    chuoi += char.ToLower(i) + "";
                else
                {
                    chuoi += i + "";
                }
            }
            return chuoi;
        }
        //chuyển ký tự đặt biệt sang ký tự thường
        private static readonly string[] VietNamChar = new string[]
        {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
        };
        public static string LocDau(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return str;
        }
        //Tìm kiếm
        [HttpPost]
        public ActionResult Search(FormCollection col)
        {
            String keySearch = col["txtseach"];
            List<SANPHAM> lst = dulieu.SANPHAMs.ToList();
            List<SANPHAM> sanPhams = new List<SANPHAM>();
            keySearch = LocDau(keySearch);
            keySearch = UpperToLower(keySearch);
            foreach(SANPHAM s in lst)
            {
                string str1;
                str1 = LocDau(s.TENSP);
                str1 = UpperToLower(str1);
                if (str1.Contains(keySearch))
                    sanPhams.Add(s);
            }
            if (sanPhams.Count == 0)
                return View();
            Session["lsSanPham"] = sanPhams;
            if (sanPhams.Count == 1)
            {
                return RedirectToAction("testloi", "Home");
            }
            return RedirectToAction("Index","Home");
        }
        //Loại sản phẩm
        public PartialViewResult lstLoaiSP()
        {
            List<LOAIHANG> loais = dulieu.LOAIHANGs.ToList();
            return PartialView(loais);
        }
        //Load ds theo Loai
        public ActionResult pageLoais(String mLoai)
        {
            List<SANPHAM> SanPhams = dulieu.SANPHAMs.Where(sp => sp.MALOAI == mLoai).ToList();
            Session["lsSanPham"] = SanPhams;
            return RedirectToAction("Index");
        }
        //Nhóm sản phẩm
        public PartialViewResult lstPHONG()
        {
            List<PHONG> lstNhom = dulieu.PHONGs.ToList();
            return PartialView(lstNhom);
        }
        //load ds theo Nhom
        public ActionResult pagePHONG(String mPhong)
        {
            List<SANPHAM> SanPhams = dulieu.SANPHAMs.Where(sp => sp.MAPH == mPhong).ToList();
            Session["lsSanPham"] = SanPhams as List<SANPHAM>;
            return RedirectToAction("Index");
        }
        public ActionResult slideimage(string ma)
        {
            SANPHAM sp = dulieu.SANPHAMs.FirstOrDefault(s => s.MASP == ma);
            List<string> lstImage = GetAllImageName(sp.ANHSP);
            ViewBag.tenFolder = sp.ANHSP;
            return PartialView(lstImage);
        }
        public ActionResult testloi()
        {
            List<SANPHAM> lstsp = Session["lsSanPham"] as List<SANPHAM>;
            List<sanpham> lstHienThi = new List<sanpham>();
            foreach (SANPHAM i in lstsp)
            {
                sanpham sp = new sanpham(i.MASP);
                lstHienThi.Add(sp);
            }
            return View(lstHienThi);
        }
        public ActionResult ImageSP(String masp)
        {
            List<string> lstImage = GetAllImageName(masp);
            String nameImage = lstImage[1];
            ViewBag.tenFolder = (masp);
            return PartialView(nameImage);
        }
    }
}