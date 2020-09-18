using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DangNhap
    {
        QLBanDoGoDataContext QL = new QLBanDoGoDataContext();
        public DangNhap() { }
        
        public List<NHANVIEN> getAllNhanVien()
        {
            List<NHANVIEN> nhanviens = QL.NHANVIENs.ToList();
            return nhanviens;
        }

        public Boolean KTDangNhap(string tenDN, string MK)
        {
            List<NHANVIEN> nhanviens = getAllNhanVien();
            foreach (NHANVIEN i in nhanviens)
            {
                if (i.TENDN.Equals(tenDN) && i.MATKHAU.Equals(MK))
                    return true;
            }
            return false;
        }

        public NHANVIEN getNV(string tenDN)
        {
            return QL.NHANVIENs.Where(t => t.TENDN == tenDN).FirstOrDefault();
        }
    }
}
