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
    public partial class Edit_TGX : UserControl
    {
        public Edit_TGX()
        {
            InitializeComponent();
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = true;
            cbTime.Visible = false;
            lbTu.Visible = true;
            lbDen.Visible = true;
            btnLuuTime.Visible = true;
            dtpkTu.Visible = true;
            dtpkDen.Visible = true;
            lbTu.Location = new Point(15, 83);
            lbDen.Location = new Point(15, 137);
            dtpkTu.Location = new Point(73, 72);
            dtpkDen.Location = new Point(73, 125);
            btnLuuTime.Location = new Point(216, 180);
            lbTieuDe.Text = "Thêm Thời Gian Xét";
            dtgvTG.Width = 449;
            
           
            pn_ThemXoaSua.Height = 238;
        }

        private void dtgvTG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvTG.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_ThemXoaSua.Visible = true;
                cbTime.Visible = true;
                cbTime.Location = new Point(6, 56);
                lbTu.Visible = true;
                lbDen.Visible = true;
                btnLuuTime.Visible = true;
                dtpkTu.Visible = true;
                dtpkDen.Visible = true;
                lbTu.Location = new Point(14, 119);
                lbDen.Location = new Point(15, 161);
                dtpkTu.Location = new Point(72, 108);
                dtpkDen.Location = new Point(72, 150);
                btnLuuTime.Location = new Point(212, 198);
                lbTieuDe.Text = "Sửa Thời Gian Xét";
                dtgvTG.Width = 449;
                
                pn_ThemXoaSua.Height = 238;
            }
        }

        private void btnLuuTime_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = false;
            dtgvTG.Width = 746;
        }

        private void btnXTime_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = false;
            dtgvTG.Width = 746;
        }

        private void btnXEdit_TG_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
