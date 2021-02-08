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
    public partial class Edit_LoaiDiem : UserControl
    {
        public Edit_LoaiDiem()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 5;
        private int flagLuu = 0;       
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        EditLoaiDiemBLL editLoaiDiemBLL = new EditLoaiDiemBLL();
        private void Edit_LoaiDiem_Load(object sender, EventArgs e)
        {
            loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void loadloaidiem(List<LoaiDiemDTO> listLD)
        {
            dtgv_LĐ.DataSource = listLD;
        }
        private void btnThemLĐ_Click(object sender, EventArgs e)
        {
            
            pn_themLĐ.Visible = true;
            btnLuuLĐ.Visible = true;
            dtgv_LĐ.Width = 323;
            lbTieuDe.Text = "Thêm Loại Điểm";
            txtTenLoai.Text = "";
            txtMaLoai.Text = "";
            txtMaLoai.Enabled = false;
            flagLuu = 0;
            txtTenLoai.BorderColor = Color.FromArgb(213, 218, 223);
            txtTenLoai.PlaceholderText = "";
            txtTenLoai.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
        }

        private void dtgv_LĐ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_LĐ.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_themLĐ.Visible = true;
                btnLuuLĐ.Visible = true;
                dtgv_LĐ.Width = 323;
                lbTieuDe.Text = "Sửa Loại Điểm";
                txtMaLoai.Enabled = false;
                btnThemLĐ.Enabled = false;
                binding();
                flagLuu = 1;
                txtTenLoai.BorderColor = Color.FromArgb(213, 218, 223);
                txtTenLoai.PlaceholderText = "";
                txtTenLoai.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
            }
        }

        private void btnLuuLĐ_Click(object sender, EventArgs e)
        {
            
            
        }

        

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
            QUYDINHDIEM QD = new QUYDINHDIEM();
            
        }

        private void btnXLD_TS_Click(object sender, EventArgs e)
        {
            pn_themLĐ.Visible = false;
            btnLuuLĐ.Visible = false;
            btnThemLĐ.Enabled = true; 
            dtgv_LĐ.Width = 634;
            loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void binding()
        {
            txtMaLoai.DataBindings.Clear();
            txtMaLoai.DataBindings.Add("Text", dtgv_LĐ.DataSource, "MaLoaiDiem");
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", dtgv_LĐ.DataSource, "TenLoaiDiem");
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.LOAI_DIEM.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }
    }
}
