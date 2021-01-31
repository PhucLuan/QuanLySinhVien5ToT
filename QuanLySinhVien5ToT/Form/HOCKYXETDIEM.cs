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
    public partial class HOCKYXETDIEM : UserControl
    {
        public HOCKYXETDIEM()
        {
            InitializeComponent();
        }

        private void HOCKY_XETDIEM_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        

        

        

        

        

        private void btnThemHocKy_Click(object sender, EventArgs e)
        {
            dtgvHocKy.Width = 616;
            pn_ThemHocKy.Visible = true;
            btnLuuHocKy.Visible = true;
            lbTieuDe.Text = "Thêm Học Kỳ Xét";
        }

        private void btnXHocKy_Click(object sender, EventArgs e)
        {
            dtgvHocKy.Width = 960;
            pn_ThemHocKy.Visible = false;
            btnLuuHocKy.Visible = false;
        }

        private void btnLuuHocKy_Click(object sender, EventArgs e)
        {
            dtgvHocKy.Width = 960;
            pn_ThemHocKy.Visible = false;
            btnLuuHocKy.Visible = false;
        }

        private void dtgvHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvHocKy.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                dtgvHocKy.Width = 616;
                pn_ThemHocKy.Visible = true;
                btnLuuHocKy.Visible = true;
                lbTieuDe.Text = "Sửa Học Kỳ Xét";
            }
        }
        
    }
}
