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
    public partial class Edit_Current_QD : UserControl
    {
        public Edit_Current_QD()
        {
            InitializeComponent();
        }

        private void btnThemQuyDinh_Click(object sender, EventArgs e)
        {
            pn_ThemQuyDinh.Visible = true;
            btnLuuQuyDinh.Visible = true;
            pn_Sort.Visible = false;
        }

        private void dtgvQuyDinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvQuyDinh.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {

                pn_ThemQuyDinh.Visible = true;
                btnLuuQuyDinh.Visible = true;
                pn_Sort.Visible = false;

            }
        }

        private void btnLuuQuyDinh_Click(object sender, EventArgs e)
        {
            pn_ThemQuyDinh.Visible = false;
            btnLuuQuyDinh.Visible = false;
            pn_Sort.Visible = true;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            pn_ThemQuyDinh.Visible = false;
            btnLuuQuyDinh.Visible = false;
            pn_Sort.Visible = true;
        }

        private void btnXQD_Click(object sender, EventArgs e)
        {
            this.Dispose();
            QUYDINHDIEM QD = new QUYDINHDIEM();
            QD.Enabled = true;
        }
    }
}
