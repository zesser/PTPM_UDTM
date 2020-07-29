using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WedBanHang.Models
{
    public class Muser
    {
        public String MaKH { set; get; }
        public String TenKH { set; get; }
        public String mUsername { set; get; }
        public String mPassword { set; get; }

		public String DiaChi { set; get; }

		public String DienThoai { set; get; }

		public String Email { set; get; }

		public bool CheckDoDaiUserName()
		{
			if (mUsername.Length < 6 || mUsername.Length > 12)
				return false;
			return true;
		}

		public bool CheckDoDaiPassword()
		{
			if (mPassword.Length < 8 || mPassword.Length > 12)
				return false;
			return true;
		}

        public bool checkDoDaiSDT()
        {
            if (DienThoai.Length != 10)
            {
                return false;
            }
            return true;
        }

        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        public bool isEmail()
        {
            Email = Email ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }

    }
}