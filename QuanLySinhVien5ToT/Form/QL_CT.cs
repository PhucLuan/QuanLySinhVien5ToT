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
using QuanLySinhVien5ToT;

namespace QuanLySinhVien5ToT
{
    public partial class QL_CT : UserControl
    {
        public QL_CT()
        {
            InitializeComponent();
        }
        private int flagluu=0;
        int pagenumber = 1;
        int numberRecord = 3;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QL_Chuong_TrinhBLL QL_Chuong_TrinhBLL = new QL_Chuong_TrinhBLL();
        private void QL_CT_Load(object sender, EventArgs e)
        {
            ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));
            
            loadcbDonVi();
            loadcbTieuChuan();
        }
        
        void ShowChuongTrinh(List<Chuong_TrinhDTO> listct)
        {
            dtgv_CT.DataSource = listct;
        }
        private void btnThemHD_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = false;
            pn_Them_Sua.Visible = true;
            btnLuu.Visible = true;
            flagluu = 0;
            txtChuongTrinh.Text = "";
            txtID.Text = "";
            txtID.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChuongTrinh.Text.Trim()))
            {
                txtChuongTrinh.BorderColor = Color.Red;
                txtChuongTrinh.PlaceholderText = "bạn chưa nhập tên tiêu chuẩn";
                txtChuongTrinh.PlaceholderForeColor = Color.Red;
            }
            else
            {
                pn_Sort.Visible = true;
                pn_Them_Sua.Visible = false;
                btnLuu.Visible = false;
                if (flagluu == 0)
                {
                    CHUONG_TRINH ct = QL_Chuong_TrinhBLL.Get(x => x.MaChuongTrinh.ToString() == txtID.Text.Trim());
                    if (ct == null)
                    {
                        ct = new CHUONG_TRINH();
                        ct.TenChuongTrinh = txtChuongTrinh.Text;
                        ct.MaTieuChuan = Convert.ToInt32(cbTieuChuan.SelectedValue.ToString());
                        ct.ThoiGianDienRa = dtpkThoiGian.Value;
                        ct.DonViToChuc = cbDonVi.Text;
                        QL_Chuong_TrinhBLL.Add(ct);
                        ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));
                        MessageBox.Show("Thêm Thành Công");
                        btnThemHD.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                else
                {
                    try
                    {
                        CHUONG_TRINH ct = QL_Chuong_TrinhBLL.Get(x => x.MaChuongTrinh.ToString() == txtID.Text.Trim());

                        ct.TenChuongTrinh = txtChuongTrinh.Text;
                        ct.MaTieuChuan = Convert.ToInt32(cbTieuChuan.SelectedValue.ToString());
                        ct.ThoiGianDienRa = dtpkThoiGian.Value;
                        ct.DonViToChuc = cbDonVi.Text;
                        QL_Chuong_TrinhBLL.Edit(ct);
                        ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));
                        MessageBox.Show("Sửa Thành Công");
                        btnThemHD.Enabled = true;
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = true;
            pn_Them_Sua.Visible = false;
            btnLuu.Visible = false;
            btnThemHD.Enabled = true;
            ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_CT.Columns[e.ColumnIndex].Name;
            if (name == "SuaCT")
            {
                pn_Sort.Visible = false;
                pn_Them_Sua.Visible = true;
                btnLuu.Visible = true;
                flagluu = 1;
                btnThemHD.Enabled = false;
                binding();
                txtID.Enabled = false;
            }
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.CHUONG_TRINH.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh(pagenumber, numberRecord));

            }
        }
        void binding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dtgv_CT.DataSource, "MaChuongTrinh");
            txtChuongTrinh.DataBindings.Clear();
            txtChuongTrinh.DataBindings.Add("Text", dtgv_CT.DataSource, "TenChuongTrinh");
            cbTieuChuan.DataBindings.Clear();
            cbTieuChuan.DataBindings.Add("Text", dtgv_CT.DataSource, "TenTieuChuan");
            dtpkThoiGian.DataBindings.Clear();
            dtpkThoiGian.DataBindings.Add("Text", dtgv_CT.DataSource, "ThoiGianDienRa");
            cbDonVi.DataBindings.Clear();
            cbDonVi.DataBindings.Add("Text", dtgv_CT.DataSource, "DonViToChuc");

        }
        void loadcbDonVi()
        {
            cbDonVi.DataSource = QL_Chuong_TrinhBLL.dsdonvi();
            cbDonVi.DisplayMember = "MaDonVi";
            cbDonVi.ValueMember = "MaDonVi";
        }
        void loadcbTieuChuan()
        {
            cbTieuChuan.DataSource = QL_Chuong_TrinhBLL.dstieuchuan();
            cbTieuChuan.DisplayMember = "TenTieuChuan";
            cbTieuChuan.ValueMember = "MaTieuChuan";
        }
    }
}
