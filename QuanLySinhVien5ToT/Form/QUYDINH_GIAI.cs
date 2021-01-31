using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien5ToT
{
    public partial class QUYDINH_GIAI : UserControl
    {
        public QUYDINH_GIAI()
        {
            InitializeComponent();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            txtTimKiem.Visible = false;
            pn_ThemTC.Visible = true;
            btnLuuTC.Visible = true;
            txtTC.Visible = false;
            cbTC.Visible = true;
        }

        private void dtgv_QD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string name = dtgv_QD.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                txtTimKiem.Visible = false;
                pn_ThemTC.Visible = true;
                btnLuuTC.Visible = true;
                txtTC.Visible = true;
                cbTC.Visible = false;
                
            }
        }

        private void btnLuuTC_Click(object sender, EventArgs e)
        {
            txtTimKiem.Visible = true;
            pn_ThemTC.Visible = false;
            btnLuuTC.Visible = false;
        }

        private void btnX_TC_Click(object sender, EventArgs e)
        {
            txtTimKiem.Visible = true;
            pn_ThemTC.Visible = false;
            btnLuuTC.Visible = false;
        }
        private void Showicondata()
        {
            
           
        }
    }
}
