using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class SanPham_BLL
    {
        QLBanDoGoDataContext qldg = new QLBanDoGoDataContext();
        public SanPham_BLL() { }
        public IEnumerable<SANPHAM> LoadSanPham()
        {
            return qldg.SANPHAMs;
        }
        //Chọn Load sản phẩm theo
        public IEnumerable<SANPHAM> LoadSanPhamTheoLoai(string MaLoai)
        {
            return qldg.SANPHAMs.Where(t => t.MALOAI == MaLoai);
        }

        public IEnumerable<SANPHAM> LoadSanPhamTheoPhong(string MaPhong)
        {
            return qldg.SANPHAMs.Where(t => t.MAPH == MaPhong);
        }

        public IEnumerable<SANPHAM> LoadSanPhamTheoLoaiVaPhong(string MaPhong, string MaLoai)
        {
            return qldg.SANPHAMs.Where(t => t.MAPH == MaPhong && t.MALOAI == MaLoai);
        }


        public void ThemSanPham(string MaSP, string TenSP, string MaPhong, string MaLoai, string Mota, string BaoHanh, decimal Gia)
        {
            SANPHAM sp = new SANPHAM();
            sp.MASP = MaSP;
            sp.TENSP = TenSP;
            sp.MAPH = MaPhong;
            sp.MALOAI = MaLoai;
            sp.MOTA = Mota;
            sp.BAOHANH = BaoHanh;
            sp.GIA = Gia;
            qldg.SANPHAMs.InsertOnSubmit(sp);
            qldg.SubmitChanges();

        }

        public void XoaSanPham(string MaSP)
        {
            SANPHAM sp = qldg.SANPHAMs.Where(t => t.MASP == MaSP).FirstOrDefault();
            qldg.SANPHAMs.DeleteOnSubmit(sp);
            qldg.SubmitChanges();
        }

        public void SuaSanPham(string MaSP, string TenSP, string MaPhong, string MaLoai, string Mota, string BaoHanh, decimal Gia)
        {
            SANPHAM sp = qldg.SANPHAMs.Where(t => t.MASP == MaSP).FirstOrDefault();
            sp.MASP = MaSP;
            sp.TENSP = TenSP;
            sp.MAPH = MaPhong;
            sp.MALOAI = MaLoai;
            sp.MOTA = Mota;
            sp.BAOHANH = BaoHanh;
            sp.GIA = Gia;
            qldg.SubmitChanges();

        }

        public IEnumerable<SANPHAM> LoadSPTheoTen(string ten)
        {
            String keySearch = ten;
            List<SANPHAM> lst = qldg.SANPHAMs.ToList();
            List<SANPHAM> kh = new List<SANPHAM>();
            keySearch = LocDau(keySearch);
            keySearch = UpperToLower(keySearch);
            foreach (SANPHAM s in lst)
            {
                string str1;
                str1 = LocDau(s.TENSP);
                str1 = UpperToLower(str1);
                if (str1.Contains(keySearch))
                    kh.Add(s);
            }

            return kh;
        }

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



    }
}
