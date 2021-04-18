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
        private int flagDT = 0;
        private int flagLuu = 0;
        int pagenumber = 1;
        int numberRecord = 5;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        Tieu_ChuanBLL Tieu_ChuanBLL = new Tieu_ChuanBLL();
        private void QL_TIEUCHUAN_Load(object sender, EventArgs e)
        {
            dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbLoaiTieuChuan();
            loadcbtieuchi();
            loadcbcaptieuchuan();
            loadcbFillterLTC();
            loadcbFillterTC();
            loadcbFillCTC();
            suggestTxtsearch();
            loadcbQDGiai();
            txtTenTieuChuan.MaxLength = 500;
        }
        void dsTieuChuan(List<Tieu_ChuanDTO> litstc)
        {
            dtgv_TC.DataSource = litstc;
            flagDT = 0;
        }
        private void btnThemTC_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = false;
            pn_ThemTC.Visible = true;
            btnLuuTC.Visible = true;
            flagLuu = 0;
            flagDT = 0;
            txtTenTieuChuan.Text = "";
            txtID.Text = "";
            txtID.Enabled = false;
            txtID.Enabled = false;
            desingbtn(); 
        }

        private void dtgv_TC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_TC.Columns[e.ColumnIndex].Name;
            if (name == "SuaTC")
            {
                pn_Sort.Visible = false;
                pn_ThemTC.Visible = true;
                btnLuuTC.Visible = true;
                txtID.Enabled = false;
                btnThemTC.Enabled = false;
                flagLuu = 1;
                binding();
                desingbtn();
                
            }
        }
        void desingbtn()
        {
            txtTenTieuChuan.BorderColor = Color.FromArgb(226, 226, 226);
            txtTenTieuChuan.PlaceholderText = "";
        }
        void loadbtnluu()
        {
            pn_Sort.Visible = true;
            pn_ThemTC.Visible = false;
            btnLuuTC.Visible = false;
            btnThemTC.Enabled = true;
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
                        tieuchuan.QuyDinhGiai = Convert.ToBoolean(cbQDGiai.Text);
                        Tieu_ChuanBLL.Add(tieuchuan);                        
                        MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();
                    }
                    else
                    {
                        MessageBox.Show("dữ liệu đã bị trùng !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemTC_Click(sender, e);
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
                        tc.QuyDinhGiai = Convert.ToBoolean(cbQDGiai.Text);
                        Tieu_ChuanBLL.Edit(tc);
                        MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());                 
                        loadbtnluu();
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemTC_Click(sender, e);
                    }
                }
            }
            
        }

        private void btnX_DV_Click(object sender, EventArgs e)
        {
            pn_Sort.Visible = true;
            pn_ThemTC.Visible = false;
            btnLuuTC.Visible = false;
            btnThemTC.Enabled = true;
            dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<Tieu_ChuanDTO>();
                    listfillter = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChi.Contains(cbFillterTieuChi.Text) && x.TenLoaiTieuChuan.Contains(cbFillterLTC.Text) && x.TenCapTieuChuan.Contains(cbFillterCap.Text)).ToList();
                    dtgv_TC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listsearch = new List<Tieu_ChuanDTO>();
                    listsearch = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChuan.Contains(txtseach.Text)).ToList();
                    dtgv_TC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                    dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChi.Contains(cbFillterTieuChi.Text) && x.TenLoaiTieuChuan.Contains(cbFillterLTC.Text) && x.TenCapTieuChuan.Contains(cbFillterCap.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<Tieu_ChuanDTO>();
                    listfillter = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChi.Contains(cbFillterTieuChi.Text) && x.TenLoaiTieuChuan.Contains(cbFillterLTC.Text) && x.TenCapTieuChuan.Contains(cbFillterCap.Text)).ToList();
                    dtgv_TC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                int totlalrecord = 0;
                totlalrecord = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChuan.Contains(txtseach.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listsearch = new List<Tieu_ChuanDTO>();
                    listsearch = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChuan.Contains(txtseach.Text)).ToList();
                    dtgv_TC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
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
        void loadcbQDGiai()
        {
            cbQDGiai.Items.Clear();
            cbQDGiai.Items.Add("True");
            cbQDGiai.Items.Add("False");
            cbQDGiai.Text = "True";
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
            cbQDGiai.DataBindings.Clear();
            cbQDGiai.DataBindings.Add("Text", dtgv_TC.DataSource, "QuyDinhGiai");
        }

        private void txtseach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtseach.Text.Trim()))
            {
                dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listsearch = new List<Tieu_ChuanDTO>();
                listsearch = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChuan.Contains(txtseach.Text)).ToList();
                dtgv_TC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listfillter = new List<Tieu_ChuanDTO>();
            listfillter = Tieu_ChuanBLL.dsTieuChuan().Where(x => x.TenTieuChi.Contains(cbFillterTieuChi.Text) && x.TenLoaiTieuChuan.Contains(cbFillterLTC.Text) && x.TenCapTieuChuan.Contains(cbFillterCap.Text)).ToList();
            dtgv_TC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_TC.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dsTieuChuan(Tieu_ChuanBLL.dsTieuChuan().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
        }
        void suggestTxtsearch()
        {
            txtseach.AutoCompleteCustomSource.AddRange(Tieu_ChuanBLL.dsTieuChuan().Select(x => x.TenTieuChuan).ToArray());
        }

        private void txtTenTieuChuan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTieuChuan.Text.Trim()))
                txtTenTieuChuan.BorderColor = Color.Red;
            else
                txtTenTieuChuan.BorderColor = Color.FromArgb(226, 226, 226);
        }
    }
}
