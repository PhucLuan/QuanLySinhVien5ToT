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
    public partial class THAMGIA_CT : UserControl
    {
        public THAMGIA_CT()
        {
            InitializeComponent();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = false;
            pn_ThemTT.Visible = true;
            btnLuuTT.Visible = true;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_TT.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_Sort.Visible = false;
                pn_ThemTT.Visible = true;
                btnLuuTT.Visible = true;
            }
        }

        private void btnXTT_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = true;
            pn_ThemTT.Visible = false;
            btnLuuTT.Visible = false;
        }

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = true;
            pn_ThemTT.Visible = false;
            btnLuuTT.Visible = false;
        }
    }
    
}
