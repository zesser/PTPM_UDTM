using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
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
            if (lstsanpham == null)
                return Redirect("testloi");
            Session["lsSanPham"] = lstsanpham;
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<SANPHAM> lstSanPhams = Session["lsSanPham"] as List<SANPHAM>;
            return View(lstSanPhams);
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
        public static List<string> GetAllImageName()
        {
            List<string> lst = new List<string>();
            String searchFolder = @"C:\Users\phand\Downloads\PTPM_UDTM-master\PTPM_UDTM-master\WedBanHang\WedBanHang\Models\Anh\girl";
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
            return View(sanPham);
        }      
        //Tìm kiếm
        [HttpPost]
        public ActionResult Search(FormCollection col)
        {
            String keySearch = col["txtseach"];
            List<SANPHAM> lst = dulieu.SANPHAMs.Take(8).ToList();
            List<SANPHAM> sanPhams =lst.Where(sp => sp.TENSP.Contains(keySearch)).ToList();
            if (sanPhams.Count == 0)
                return View();
            Session["lsSanPham"] = sanPhams;
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
        public ActionResult test(string ma)
        {
            SANPHAM sp = dulieu.SANPHAMs.FirstOrDefault(s => s.MASP == ma);
            List<string> lstImage = GetAllImageName();
            return PartialView(lstImage);
        }
        public ActionResult testloi()
        {
            return View();
        }
    }
}