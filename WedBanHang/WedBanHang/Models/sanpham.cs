using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WedBanHang.Models
{
    public class sanpham
    {
        QLBanDoGoDataContext qlbg = new QLBanDoGoDataContext();
        public String masp { get; set; }
        public String tensp { get; set; }
        public String giasp { get; set; }
        public String hinhsp { get; set; }
        public sanpham() { }
        public sanpham(string ma)
        {
            SANPHAM sp = qlbg.SANPHAMs.FirstOrDefault(s => s.MASP == ma);
            masp = sp.MASP;
            tensp = sp.TENSP;
            giasp = sp.GIA.ToString();
            List<string>lstHinh = GetAllImageName(sp.ANHSP);
            hinhsp =sp.ANHSP+'/'+lstHinh[0];
        }

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
            String searchFolder = @"C:\Users\phand\Downloads\PTPM_UDTM-master\PTPM_UDTM-master\WedBanHang\WedBanHang\Models\anhsp\anhdoanweb\" + nameFolder;
            var filters = new String[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp", "svg" };
            var files = GetFilesFrom(searchFolder, filters, false);
            foreach (string i in files)
            {
                string imageName = imageFiles(i);
                lst.Add(imageName);
            }
            return lst;
        }
    }
}