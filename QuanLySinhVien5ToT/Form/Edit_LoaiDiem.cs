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
            txtTenLoai.MaxLength = 30;
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
            designbtn();
        }
        void designbtn()
        {
            txtTenLoai.BorderColor = Color.FromArgb(213, 218, 223);
            txtTenLoai.PlaceholderText = "";
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
                designbtn();
                flagLuu = 1;
            }
        }
        void loadbtnluu()
        {
            pn_themLĐ.Visible = false;
            btnLuuLĐ.Visible = false;
            dtgv_LĐ.Width = 634;
        }
        private void btnLuuLĐ_Click(object sender, EventArgs e)
        {
            if (txtTenLoai.Text == "" )
            {
                txtTenLoai.BorderColor = Color.Red;
                txtTenLoai.PlaceholderText = "bạn chưa nhập mã tiêu chí";
                txtTenLoai.PlaceholderForeColor = Color.Red;
            }
            else
            {
                
                if (flagLuu == 0)
                {

                    LOAI_DIEM ld = editLoaiDiemBLL.Get(x => x.MaLoaiDiem.ToString()==txtMaLoai.Text && x.TenLoaiDiem==txtTenLoai.Text);
                    if (ld == null)
                    {
                        ld = new LOAI_DIEM();
                        ld.TenLoaiDiem = txtTenLoai.Text;
                        btnThemLĐ.Enabled = true;
                        editLoaiDiemBLL.Add(ld);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemLĐ.Enabled = true;
                        btnThemLĐ_Click(sender, e);
                    }                    
                }
                else
                {
                    try
                    {
                        LOAI_DIEM ld = editLoaiDiemBLL.Get(x => x.MaLoaiDiem.ToString() == txtMaLoai.Text);

                        ld.TenLoaiDiem = txtTenLoai.Text;
                        btnThemLĐ.Enabled = true;
                        editLoaiDiemBLL.Edit(ld);
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadloaidiem(editLoaiDiemBLL.dsloaidiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu(); 
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemLĐ.Enabled = true;
                        btnThemLĐ_Click(sender, e);
                    }
                    
                }
            }

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
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
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
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }

        private void txtTenLoai_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoai.Text.Trim()))
                txtTenLoai.BorderColor = Color.Red;
            else
                txtTenLoai.BorderColor = Color.FromArgb(226, 226, 226);
        }
    }
}
