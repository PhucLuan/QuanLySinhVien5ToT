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
    public partial class QL_TIEUCHUAN : UserControl
    {
        public QL_TIEUCHUAN()
        {
            InitializeComponent();
        }
        private int flagLuu = 0;
        int pagenumber = 1;
        int numberRecord = 5;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        Tieu_ChuanBLL Tieu_ChuanBLL = new Tieu_ChuanBLL();
        private void QL_TIEUCHUAN_Load(object sender, EventArgs e)
        {
            dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));
            loadcbLoaiTieuChuan();
            loadcbtieuchi();
            loadcbcaptieuchuan();
            loadcbFillterLTC();
            loadcbFillterTC();
            loadcbFillCTC();
        }
        void dsTieuChuan(List<Tieu_ChuanDTO> litstc)
        {
            dtgv_TC.DataSource = litstc;
        }
        private void btnThemTC_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = false;
            pn_ThemTC.Visible = true;
            btnLuuTC.Visible = true;
            flagLuu = 0;

        }

        private void dtgv_TC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_TC.Columns[e.ColumnIndex].Name;
            if (name == "SuaTC")
            {
                pn_Sort.Visible = false;
                pn_ThemTC.Visible = true;
                btnLuuTC.Visible = true;
                flagLuu = 1;
                binding();
                
            }
        }

        private void btnLuuTC_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTieuChuan.Text.Trim()))
            {
                txtTenTieuChuan.BorderColor = Color.Red;
                txtTenTieuChuan.PlaceholderText = "bạn chưa nhập tên tiêu chuẩn";
                txtTenTieuChuan.PlaceholderForeColor = Color.Red;


            }
            else
            {
                pn_Sort.Visible = true;
                pn_ThemTC.Visible = false;
                btnLuuTC.Visible = false;
                if (flagLuu == 0)
                {
                    TIEU_CHUAN tieuchuan = Tieu_ChuanBLL.Get(x => x.MaTieuChuan.ToString() == txtID.Text.Trim());
                    if (tieuchuan == null)
                    {
                        tieuchuan = new TIEU_CHUAN();
                        tieuchuan.TenTieuChuan = txtTenTieuChuan.Text;
                        tieuchuan.Cap = Convert.ToInt32(cbCTC.SelectedValue.ToString());
                        tieuchuan.MaTieuChi = cbTieuChi.SelectedValue.ToString();
                        tieuchuan.MaLoaiTieuChuan = Convert.ToBoolean(cbLTC.SelectedValue.ToString());
                        Tieu_ChuanBLL.Add(tieuchuan);
                        dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));
                        MessageBox.Show("Thêm Thành Công");
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
                        TIEU_CHUAN tc = Tieu_ChuanBLL.Get(x => x.MaTieuChuan.ToString() == txtID.Text.Trim());

                        tc.TenTieuChuan = txtTenTieuChuan.Text;
                        tc.Cap = Convert.ToInt32(cbCTC.SelectedValue.ToString());
                        tc.MaTieuChi = cbTieuChi.SelectedValue.ToString();
                        tc.MaLoaiTieuChuan = Convert.ToBoolean(cbLTC.SelectedValue.ToString());
                        Tieu_ChuanBLL.Edit(tc);
                        dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));
                        MessageBox.Show("Sửa Thành Công");
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            
        }

        private void btnX_DV_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = true;
            pn_ThemTC.Visible = false;
            btnLuuTC.Visible = false;
            dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));

            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.TIEU_CHUAN.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan(pagenumber, numberRecord));
            }
        }
        void loadcbLoaiTieuChuan()
        {
            cbLTC.DataSource = Tieu_ChuanBLL.dsloaitieuchuan();
            cbLTC.DisplayMember = "TenLoaiTieuChuan";
            cbLTC.ValueMember = "MaLoaiTieuChuan";
        }
        void loadcbtieuchi()
        {
            cbTieuChi.DataSource = Tieu_ChuanBLL.dstieuchi();
            cbTieuChi.DisplayMember = "TenTieuChi";
            cbTieuChi.ValueMember = "MaTieuChi";
        }
        void loadcbcaptieuchuan()
        {
            cbCTC.DataSource = Tieu_ChuanBLL.dscaptieuchuan();
            cbCTC.DisplayMember = "TenCapTieuChuan";
            cbCTC.ValueMember = "MaCapTieuChuan";
        }
        void loadcbFillterLTC()
        {
            cbFillterLTC.DataSource = Tieu_ChuanBLL.dsloaitieuchuan();
            cbFillterLTC.DisplayMember = "TenLoaiTieuChuan";
            cbFillterLTC.ValueMember = "MaLoaiTieuChuan";
        }
        void loadcbFillterTC()
        {
            cbFillterTieuChi.DataSource = Tieu_ChuanBLL.dstieuchi();
            cbFillterTieuChi.DisplayMember = "TenTieuChi";
            cbFillterTieuChi.ValueMember = "MaTieuChi";
        }
        void loadcbFillCTC()
        {
            cbFillterCap.DataSource = Tieu_ChuanBLL.dscaptieuchuan();
            cbFillterCap.DisplayMember = "TenCapTieuChuan";
            cbFillterCap.ValueMember = "MaCapTieuChuan";
        }
        void binding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dtgv_TC.DataSource, "MaTieuChuan");
            txtTenTieuChuan.DataBindings.Clear();
            txtTenTieuChuan.DataBindings.Add("Text", dtgv_TC.DataSource, "TenTieuChuan");
            cbCTC.DataBindings.Clear();
            cbCTC.DataBindings.Add("Text", dtgv_TC.DataSource, "TenCapTieuChuan");
            cbTieuChi.DataBindings.Clear();
            cbTieuChi.DataBindings.Add("Text", dtgv_TC.DataSource, "TenTieuChi");
            cbLTC.DataBindings.Clear();
            cbLTC.DataBindings.Add("Text", dtgv_TC.DataSource, "TenLoaiTieuChuan");
        }

        
    }
}
