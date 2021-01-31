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
    public partial class QL_DIEM : UserControl
    {
        public QL_DIEM()
        {
            InitializeComponent();
        }

        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            pn_Them_Sua.Visible = true;
            btnLuuDiem.Visible = true;
            pn_ThongTinDiem.Visible = false;
            dtgv_Diem.Width = 730;
            lebal_Them_Sua.Text = "Thêm Thông Tin Điểm";
        }

        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            pn_Them_Sua.Visible = false;
            btnLuuDiem.Visible = false;
            pn_ThongTinDiem.Visible = false;
            dtgv_Diem.Width = 971;
        }

        private void dtgv_Diem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_Diem.Columns[e.ColumnIndex].Name;
            if (name == "XemChiTiet")
            {
                pn_Them_Sua.Visible = false;
                pn_ThongTinDiem.Visible = true;
                btnLuuDiem.Visible = false;
                dtgv_Diem.Width = 730;
            }
            if (name == "Sua")
            {
                pn_Them_Sua.Visible = true;
                pn_ThongTinDiem.Visible = false;
                btnLuuDiem.Visible = true;
                dtgv_Diem.Width = 730;
                lebal_Them_Sua.Text = "Sửa Thông Tin Điểm";
            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            pn_Them_Sua.Visible = false;
            pn_ThongTinDiem.Visible = false;
            btnLuuDiem.Visible = false;
            dtgv_Diem.Width = 971;
        }

        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            pn_Them_Sua.Visible = false;
            pn_ThongTinDiem.Visible = false;
            btnLuuDiem.Visible = false;
            dtgv_Diem.Width = 971;
        }
    }
}
