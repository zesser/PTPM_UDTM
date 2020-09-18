using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    
    public static class QL_NguoiDung
    {
        
        public static int Check_Config()
        {
            if(Properties.Settings.Default.LTWNCCon == string.Empty)
                return 1;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.LTWNCCon);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        

        public static DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public static DataTable GetDataBaseName(string sv, string user, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select name from sys.Databases",
                "Data Source=" + sv + ";Initial Catalog=master;User ID=" + user + "; Password = " + pass + "");
            sda.Fill(dt);
            return dt;
            //
        }

        public static void SaveConfig(string sv, string user, string pass, string dbname)
        {
            DAL_BLL.Properties.Settings.Default.LTWNCCon =
                "Data Source =" + sv + ";Initial Catalog=" + dbname + ";User ID=" + user + ";Password = " + pass + "";
            DAL_BLL.Properties.Settings.Default.Save();
            //
        }

        public static string Encrypt(string value, string publickey)
        {
            if(String.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            byte[] bytesIn = Encoding.UTF8.GetBytes(value);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] bytesKey = Encoding.UTF8.GetBytes(publickey);
            Array.Resize(ref bytesKey, des.Key.Length);
            Array.Resize(ref bytesKey, des.IV.Length);

            des.Key = bytesKey;
            des.IV = bytesKey;

            MemoryStream mscout = new MemoryStream();
            ICryptoTransform ict = des.CreateDecryptor();
            CryptoStream crypt = new CryptoStream(mscout, ict, CryptoStreamMode.Write);

            crypt.Write(bytesIn, 0, bytesIn.Length);
            crypt.FlushFinalBlock();
            byte[] byteOut = mscout.ToArray();
            crypt.Close();
            mscout.Close();

            return Convert.ToBase64String(byteOut);
        }

    }
}
