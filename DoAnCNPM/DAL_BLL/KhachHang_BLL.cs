using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class KhachHang_BLL
    {
        QLBanDoGoDataContext qldg = new QLBanDoGoDataContext();
        public KhachHang_BLL() { }

        public IQueryable LoadKhachHang()
        {
            var phieunhaps = from pn in qldg.KHACHHANGs
                             select new { pn.MAKHACHHANG, pn.TENKHACHHANG, pn.DIACHI, pn.DIENTHOAI,pn.EMAIL };

            return phieunhaps;
        }
        //Chọn Load sản phẩm theo
        public IEnumerable<KHACHHANG> LoadKHTheoTen(string ten)
        {
            String keySearch = ten;
            List<KHACHHANG> lst = qldg.KHACHHANGs.ToList();
            List<KHACHHANG> kh = new List<KHACHHANG>();
            keySearch = LocDau(keySearch);
            keySearch = UpperToLower(keySearch);
            foreach (KHACHHANG s in lst)
            {
                string str1;
                str1 = LocDau(s.TENKHACHHANG);
                str1 = UpperToLower(str1);
                if (str1.Contains(keySearch))
                    kh.Add(s);
            }

            return kh;
        }

       

        public void ThemKH(string MaKH, string TenKH, string DiaChi, string Sdt, string Email)
        {
            KHACHHANG sp = new KHACHHANG();
            sp.MAKHACHHANG = MaKH;
            sp.TENKHACHHANG = TenKH;
            sp.DIACHI = DiaChi;
            sp.DIENTHOAI = Sdt;
            sp.EMAIL = Email;
            qldg.KHACHHANGs.InsertOnSubmit(sp);
            qldg.SubmitChanges();

        }

        public void suaKH(string MaKH, string TenKH, string DiaChi, string Sdt, string Email)
        {
            KHACHHANG sp = qldg.KHACHHANGs.Where(t => t.MAKHACHHANG == MaKH).FirstOrDefault();
            sp.MAKHACHHANG = MaKH;
            sp.TENKHACHHANG = TenKH;
            sp.DIACHI = DiaChi;
            sp.DIENTHOAI = Sdt;
            sp.EMAIL = Email;
            qldg.SubmitChanges();

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

        public static bool CheckEmail(string inputEmail)
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

        public static bool CheckSDT(string SDT)
        {
            if(SDT.Length == 10 && checkChu(SDT))
            {
                return true;
            }
            return false;
        }
        public static bool checkChu(string sdt)
        {
            for(int i = 0; i < sdt.Length; i++)
            {
                if(Char.IsDigit(sdt[i]) || Char.IsControl(sdt[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }



}
