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
    public partial class QUYDINHDIEM : UserControl
    {
        public QUYDINHDIEM()
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

        private void btnXHocKy_Click(object sender, EventArgs e)
        {
           
            pn_ThemQuyDinh.Visible = false;
            btnLuuQuyDinh.Visible = false;
            pn_Sort.Visible = true;
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

        private void btnSuaTC_Click(object sender, EventArgs e)
        {
            Edit_LoaiDiem UC = new Edit_LoaiDiem();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(170, 48);
            this.dtgvQuyDinh.Enabled = false;
            this.btnSuaLD.Enabled = false;
            this.btnCurrentQD.Enabled = false;
            this.btnThemQuyDinh.Enabled = false;
            UC.Enabled = true;
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Edit_Current_QD UC = new Edit_Current_QD();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(170, 48);
            this.dtgvQuyDinh.Enabled = false;
            this.btnSuaLD.Enabled = false;
            this.btnCurrentQD.Enabled = false;
            this.btnThemQuyDinh.Enabled = false;
            UC.Enabled = true;

        }
    }
}
