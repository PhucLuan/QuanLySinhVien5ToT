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
        private int flagDT = 0;
        private int flagluu=0;
        int pagenumber = 1;
        int numberRecord = 3;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QL_Chuong_TrinhBLL QL_Chuong_TrinhBLL = new QL_Chuong_TrinhBLL();
        private void QL_CT_Load(object sender, EventArgs e)
        {
            ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            suggestTxtsearch();
            loadcbDonVi();
            loadcbTieuChuan();
            loadcbFillterDV();
            loadcbFillterTC();
            txtChuongTrinh.MaxLength = 500;
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
            txtID.Enabled = false;
            flagluu = 0;
            txtChuongTrinh.Text = "";
            txtID.Text = "";
            desingbtn();
        }
        void desingbtn()
        {
            txtChuongTrinh.BorderColor = Color.FromArgb(226, 226, 226);
            txtChuongTrinh.PlaceholderText = "";
        }
        void loadbtnluu()
        {
            pn_Sort.Visible = true;
            pn_Them_Sua.Visible = false;
            btnLuu.Visible = false;
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
                        MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();
                        btnThemHD.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();                       
                        btnThemHD.Enabled = true;
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
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
                txtID.Enabled = false;
                binding();
                desingbtn(); ;
                
            }
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<Chuong_TrinhDTO>();
                    listfillter = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenTieuChuan.Contains(cbFillterTC.Text) && x.ThoiGianDienRa.ToString().Contains(dtpkTGDR.Text) && x.DonViToChuc.Contains(cbFillter_DV.Text)).ToList();
                    dtgv_CT.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listsearch = new List<Chuong_TrinhDTO>();
                    listsearch = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenChuongTrinh.Contains(txtSearch.Text)).ToList();
                    dtgv_CT.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                int totlalrecord = 0;
                totlalrecord = db.TIEU_CHUAN.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenTieuChuan.Contains(cbFillterTC.Text) && x.ThoiGianDienRa.ToString().Contains(dtpkTGDR.Text) && x.DonViToChuc.Contains(cbFillter_DV.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<Chuong_TrinhDTO>();
                    listfillter = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenTieuChuan.Contains(cbFillterTC.Text) && x.ThoiGianDienRa.ToString().Contains(dtpkTGDR.Text) && x.DonViToChuc.Contains(cbFillter_DV.Text)).ToList();
                    dtgv_CT.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                int totlalrecord = 0;
                totlalrecord = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenChuongTrinh.Contains(txtSearch.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listsearch = new List<Chuong_TrinhDTO>();
                    listsearch = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenChuongTrinh.Contains(txtSearch.Text)).ToList();
                    dtgv_CT.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
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
        void loadcbFillterDV()
        {
            cbFillter_DV.DataSource = QL_Chuong_TrinhBLL.dsdonvi();
            cbFillter_DV.DisplayMember = "MaDonVi";
            cbFillter_DV.ValueMember = "MaDonVi";
        }
        void loadcbFillterTC()
        {
            cbFillterTC.DataSource = QL_Chuong_TrinhBLL.dstieuchuan();
            cbFillterTC.DisplayMember = "TenTieuChuan";
            cbFillterTC.ValueMember = "MaTieuChuan";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listsearch = new List<Chuong_TrinhDTO>();
                listsearch = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenChuongTrinh.Contains(txtSearch.Text)).ToList();
                dtgv_CT.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listfillter = new List<Chuong_TrinhDTO>();
            listfillter = QL_Chuong_TrinhBLL.dschuongtrinh().Where(x => x.TenTieuChuan.Contains(cbFillterTC.Text) && x.ThoiGianDienRa.ToString().Contains(dtpkTGDR.Text) && x.DonViToChuc.Contains(cbFillter_DV.Text)).ToList();
            dtgv_CT.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_CT.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowChuongTrinh(QL_Chuong_TrinhBLL.dschuongtrinh().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
        }
        void suggestTxtsearch()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(QL_Chuong_TrinhBLL.dschuongtrinh().Select(x => x.TenChuongTrinh).ToArray());
        }
        
    }
}
