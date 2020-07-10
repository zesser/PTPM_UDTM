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
        DulieuDataContext dulieu = new DulieuDataContext();
        // GET: Home
        public ActionResult lstSanPham()
        {
            List<tbl_SanPham>lstsanpham = dulieu.tbl_SanPhams.ToList();
            if (lstsanpham == null)
                return Redirect("testloi");
            Session["lsSanPham"] = lstsanpham;
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            List<tbl_SanPham> lstSanPhams = Session["lsSanPham"] as List<tbl_SanPham>;
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
            tbl_SanPham sanPham = dulieu.tbl_SanPhams.FirstOrDefault(sp => sp.MaSanPham == Ma);
            return View(sanPham);
        }      
        //Tìm kiếm
        [HttpPost]
        public ActionResult Search(FormCollection col)
        {
            String keySearch = col["txtseach"];
            List<tbl_SanPham> lst = dulieu.tbl_SanPhams.Take(8).ToList();
            List<tbl_SanPham> sanPhams =lst.Where(sp => sp.MaL.Contains(keySearch)).ToList();
            Session["lsSanPham"] = sanPhams;
            return View(sanPhams);
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
            Session["lsSanPham"] = SanPhams;
            return RedirectToAction("Index");
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
            Session["lsSanPham"] = SanPhams;
            return RedirectToAction("Index",SanPhams);
        }
        public ActionResult test(string ma)
        {
            tbl_SanPham sp = dulieu.tbl_SanPhams.FirstOrDefault(s => s.MaSanPham == ma);
            List<string> lstImage = GetAllImageName();
            return PartialView(lstImage);
        }
        public ActionResult testloi()
        {
            List<string> lstImage = GetAllImageName();
            return View(lstImage);
        }
    }
}