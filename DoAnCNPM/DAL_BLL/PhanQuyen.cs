using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanQuyen
    {
        QLBanDoGoDataContext qldg = new QLBanDoGoDataContext();
        public PhanQuyen() { }

        public PHANQUYEN GetPhanQuyen(string ma) 
        {
            return qldg.PHANQUYENs.Where(t => t.MAPHANQUYEN == ma).FirstOrDefault();
        }
    }
}
