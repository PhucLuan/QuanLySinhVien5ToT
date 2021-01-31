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
    public partial class QL_NHAN_VIEN : UserControl
    {
        public QL_NHAN_VIEN()
        {
            InitializeComponent();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = true;
            btnLuuNV.Visible = true;
            dtgv_NV.Width = 651;
            lbTD.Text = "Thêm Nhân Viên";
        }

        private void dtgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_NV.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_Them_NV.Visible = true;
                btnLuuNV.Visible = true;
                dtgv_NV.Width = 651;
                lbTD.Text = "Sửa Nhân Viên";
            }
        }

        private void btnXThemNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            dtgv_NV.Width = 996;
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            dtgv_NV.Width = 996;
        }
    }
}
