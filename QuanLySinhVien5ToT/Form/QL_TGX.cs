using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.BLL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT
{
    public partial class QL_TGX : UserControl
    {
        public QL_TGX()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 2;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        ThoiDiemSV_ThamGiaBLL thoiDiemSV_ThamGiaBLL = new ThoiDiemSV_ThamGiaBLL();
        private void QL_TGX_Load(object sender, EventArgs e)
        {
            //loadlistsv(thoiDiemSV_ThamGiaBLL.dssinhvienTG().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        void loadlistsv (List<ThoiDiemSV_ThamGiaDTO> listtt)
        {
            dtgv_ThongTin.DataSource = listtt;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_ThongTin.Columns[e.ColumnIndex].Name;
            if (name == "XemChiTiet")
            {
                pn_Them_TT.Visible = false;
                btnLuuTT.Visible = false;
                pn_XemChiTiet.Visible = true;
                dtgv_ThongTin.Width = 726;
            }
        }
        private void guna2ImageButton5_Click(object sender, EventArgs e)
        {
            dtgv_ThongTin.Width = 1008;
            pn_Them_TT.Visible = false;
            btnLuuTT.Visible = false;
            pn_XemChiTiet.Visible = false;
        }
        private void btnThemKQ_Click(object sender, EventArgs e)
        {
            Edit_TGX UC = new Edit_TGX();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(123, 48);
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            dtgv_ThongTin.Width = 726;
            pn_Them_TT.Visible = true;
            btnLuuTT.Visible = true;
            pn_XemChiTiet.Visible = false;
        }

        private void btnXThem_TT_Click(object sender, EventArgs e)
        {
            dtgv_ThongTin.Width = 1008;
            pn_Them_TT.Visible = false;
            btnLuuTT.Visible = false;
            pn_XemChiTiet.Visible = false;
        }
        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            dtgv_ThongTin.Width = 1008;
            pn_Them_TT.Visible = false;
            btnLuuTT.Visible = false;
            pn_XemChiTiet.Visible = false;
        }

       
    }
}
