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
    public partial class THUCHIENTIEUCHUAN : UserControl
    {
        public THUCHIENTIEUCHUAN()
        {
            InitializeComponent();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = true;
            pn_Sort.Visible = false;
            btnLuuTT.Visible = true;
        }

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = false;
            pn_Sort.Visible = true;
            btnLuuTT.Visible = false;
        }

        private void btnX_TT_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = false;
            pn_Sort.Visible = true;
            btnLuuTT.Visible = false;
        }

        private void dtgv_TT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_TT.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_Sort.Visible = false;
                pn_ThemTT.Visible = true;
                btnLuuTT.Visible = true;
            }
        }
    }
}
