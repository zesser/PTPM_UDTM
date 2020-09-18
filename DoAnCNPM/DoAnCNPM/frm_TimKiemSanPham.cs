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
    public partial class frm_TimKiemSanPham : Form
    {
        SanPham sanphams = new SanPham();
        public frm_TimKiemSanPham()
        {
            InitializeComponent();
        }

        private void frm_TimKiemSanPham_Load(object sender, EventArgs e)
        {
            gcTimKiemSP.DataSource = sanphams.getAllSanPham();
        }
    }
}
