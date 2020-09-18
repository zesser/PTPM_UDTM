using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DAL_BLL;
namespace DoAnCNPM
{
    public partial class frmConfig : Form
    {
        public frm_DangNhap dn;
        

        public frmConfig()
        {
            InitializeComponent();
            LoadCB();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            QL_NguoiDung.SaveConfig(cbbServerName.Text, txtUser.Text, txtPassword.Text, cbbDataBase.Text);
            frm_DangNhap dn = new frm_DangNhap();
            dn.Show();
            this.Close();

        }

        private void LoadCB()
        {
            cbbServerName.DataSource = QL_NguoiDung.GetServerName();
            cbbServerName.DisplayMember = "ServerName";

            
        }
        private void cbbServerName_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cbbDataBase_DropDown(object sender, EventArgs e)
        {
            cbbDataBase.DataSource = QL_NguoiDung.GetDataBaseName(cbbServerName.Text, txtUser.Text, txtPassword.Text);
            cbbDataBase.DisplayMember = "name";
        }
            
        



    }
}
