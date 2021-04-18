using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.DTO;
using QuanLySinhVien5ToT.BLL;

namespace QuanLySinhVien5ToT
{
    public partial class THUCHIENTIEUCHUAN : UserControl
    {
        public THUCHIENTIEUCHUAN()
        {
            InitializeComponent();
            
        }
        int pagenumber = 1;
        int numberRecord = 8;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        ThucHien_TieuChuanBLL thucHien_TieuChuanBLL = new ThucHien_TieuChuanBLL();
        List<ThongTinPQ_DTO> listPQ_SV = Login.listPQ;
        private void THUCHIENTIEUCHUAN_Load(object sender, EventArgs e)
        {
            loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbFillterTC();
            loadcbTC_TS();
            loadcbFillterTG();
            loadcbThoiGian_TS();
            loadcbThoiGian_Xem();
            loadcbFillterDV();
            SuggestTxtMssv();
            SuggestTxtSearch();
            maxlength();
            loadPQ();
        }
        void loadPQ()
        {
            if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
            {
                CbFillter_DV.Enabled = false;
                dtgv_THTC.ReadOnly = true;
                CbFillter_DV.Text = listPQ_SV.Select(x => x.DonVi).ToArray().First().ToString();

            }
            else
            {
                CbFillter_DV.Enabled = true;
                dtgv_THTC.ReadOnly = true;
            }
        }
        void loadTHTC(List<ThucHien_TieuChuanDTO> listthtc)
        {
            dtgv_THTC.DataSource = listthtc;
            flagDT = 0;
        }
        private void btnThemTT_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = true;
            pn_Sort.Visible = false;
            btnLuuTT.Visible = true;
            pn_Xem.Visible = false;
            txtMssv_TS.Text = "";
        }

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            if (txtMssv_TS.TextLength<=11)
            {
                //txtMssv_TS.BorderColor = Color.Red;
                //txtMssv_TS.PlaceholderText = "bạn chưa nhập Mssv";
                //txtMssv_TS.PlaceholderForeColor = Color.Red;
                thucHien_TieuChuanBLL.check_input_mssv(txtMssv_TS);
            }
            else
            {                
                THUCHIEN_TIEUCHUAN thtc = thucHien_TieuChuanBLL.Get(x => x.Mssv.Trim() == txtMssv_TS.Text.Trim() && x.MaTieuChuan == Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString()) && x.MaThoiGian == Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString()));
                if (thtc == null)
                {
                    thtc = new THUCHIEN_TIEUCHUAN();
                    thtc.Mssv = txtMssv_TS.Text;
                    thtc.MaTieuChuan = Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString());
                    thtc.MaThoiGian = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                    thucHien_TieuChuanBLL.Add(thtc);
                    MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    pn_ThemTT.Visible = false;
                    pn_Sort.Visible = true;
                    btnLuuTT.Visible = false;
                    pn_Xem.Visible = false;
                }
                else
                {
                    MessageBox.Show("dữ liệu đã bị trùng !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnThemTT_Click(sender, e);
                }
            }
            
        }

        private void btnX_TT_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = false;
            pn_Sort.Visible = true;
            btnLuuTT.Visible = false;
            pn_Xem.Visible = false;
            loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        private void dtgv_TT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_THTC.Columns[e.ColumnIndex].Name;
            if (name == "Xem")
            {
                pn_Sort.Visible = false;
                pn_ThemTT.Visible = false;
                btnLuuTT.Visible = false;
                pn_Xem.Visible = true;
                txtTenSinhVien_Xem.Enabled = false;
                txtTenTieuChuan_Xem.Enabled = false;
                txtDonVi_Xem.Enabled = false;
                cbThoiGian_Xem.Enabled = false;
                cbThoiGian_Xem.FillColor = Color.FromArgb(220, 220, 220);
            }
            DataGridViewRow row = this.dtgv_THTC.Rows[e.RowIndex];
            txtTenSinhVien_Xem.Text = row.Cells["TenSinhVien"].Value.ToString();
            txtTenTieuChuan_Xem.Text = row.Cells["TenTieuChuan"].Value.ToString();
            txtDonVi_Xem.Text = row.Cells["DonVi"].Value.ToString();
            cbThoiGian_Xem.SelectedValue = thucHien_TieuChuanBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
        }

        private void btnX_Xem_Click(object sender, EventArgs e)
        {
            pn_ThemTT.Visible = false;
            pn_Sort.Visible = true;
            btnLuuTT.Visible = false;
            pn_Xem.Visible = false;
            loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            txtMssv_TS.BorderColor = Color.FromArgb(213, 218, 223);
            txtMssv_TS.PlaceholderText = "";
            txtMssv_TS.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<ThucHien_TieuChuanDTO>();
                    listfillter = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.DonVi.Contains(CbFillter_DV.Text) && x.TenTieuChuan.Contains(cbFillterTieuChuan.Text) && x.ThoiGian.Contains(cbThoiGian_TS.Text)).ToList();
                    dtgv_THTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listsearch = new List<ThucHien_TieuChuanDTO>();
                    listsearch = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.TenSinhVien.Contains(txtSearch.Text)).ToList();
                    dtgv_THTC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.THUCHIEN_TIEUCHUAN.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.DonVi.Contains(CbFillter_DV.Text) && x.TenTieuChuan.Contains(cbFillterTieuChuan.Text) && x.ThoiGian.Contains(cbThoiGian_TS.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<ThucHien_TieuChuanDTO>();
                    listfillter = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.DonVi.Contains(CbFillter_DV.Text) && x.TenTieuChuan.Contains(cbFillterTieuChuan.Text) && x.ThoiGian.Contains(cbThoiGian_TS.Text)).ToList();
                    dtgv_THTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                int totlalrecord = 0;
                totlalrecord = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.TenSinhVien.Contains(txtSearch.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listsearch = new List<ThucHien_TieuChuanDTO>();
                    listsearch = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.TenSinhVien.Contains(txtSearch.Text)).ToList();
                    dtgv_THTC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }
        void loadcbFillterTC()
        {
            cbFillterTieuChuan.DataSource = thucHien_TieuChuanBLL.dstieuchuan();
            cbFillterTieuChuan.DisplayMember = "TenTieuChuan";
            cbFillterTieuChuan.ValueMember = "MaTieuChuan";
        }
        void loadcbTC_TS()
        {
            cbTieuChuan_TS.DataSource = thucHien_TieuChuanBLL.dstieuchuan();
            cbTieuChuan_TS.DisplayMember = "TenTieuChuan";
            cbTieuChuan_TS.ValueMember = "MaTieuChuan";
        }
        void loadcbFillterTG()
        {
            cbFillter_TG.DataSource = new BindingSource(thucHien_TieuChuanBLL.showTime(), null);
            cbFillter_TG.DisplayMember = "Value";
            cbFillter_TG.ValueMember = "Key";
        }
        void loadcbThoiGian_TS()
        {
            cbThoiGian_TS.DataSource = new BindingSource(thucHien_TieuChuanBLL.showTime(), null);
            cbThoiGian_TS.DisplayMember = "Value";
            cbThoiGian_TS.ValueMember = "Key";
        }
        void loadcbThoiGian_Xem()
        {
            cbThoiGian_Xem.DataSource = new BindingSource(thucHien_TieuChuanBLL.showTime(), null);
            cbThoiGian_Xem.DisplayMember = "Value";
            cbThoiGian_Xem.ValueMember = "Key";
        }
        void loadcbFillterDV()
        {
            CbFillter_DV.DataSource = thucHien_TieuChuanBLL.dsdonvi();
            CbFillter_DV.DisplayMember = "MaDonVi";
            CbFillter_DV.ValueMember = "MaDonVi";
        }
        void SuggestTxtMssv()
        {
            if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
            {
                txtMssv_TS.AutoCompleteCustomSource.AddRange(thucHien_TieuChuanBLL.dssinhvien().Where(x => x.DonVi == listPQ_SV.Select(y => y.DonVi).ToArray().First()).Select(x => x.Mssv).ToArray());
            }
            else
            {
                txtMssv_TS.AutoCompleteCustomSource.AddRange(thucHien_TieuChuanBLL.dssinhvien().Select(x => x.Mssv).ToArray());
            }
        }
        void SuggestTxtSearch()
        {
            if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
            {
                txtSearch.AutoCompleteCustomSource.AddRange(thucHien_TieuChuanBLL.dssinhvien().Where(x => x.DonVi == CbFillter_DV.Text).Select(x => x.HoTen).ToArray());
            }
            else
            {
                txtSearch.AutoCompleteCustomSource.AddRange(thucHien_TieuChuanBLL.dssinhvien().Select(x => x.HoTen).ToArray());
            }          
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            pagenumber = 1;
            var listfillter = new List<ThucHien_TieuChuanDTO>();
            listfillter = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.DonVi.Contains(CbFillter_DV.Text) && x.TenTieuChuan.Contains(cbFillterTieuChuan.Text) && x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
            dtgv_THTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_THTC.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }
                

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                loadTHTC(thucHien_TieuChuanBLL.dsthuchienTC().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listsearch = new List<ThucHien_TieuChuanDTO>();
                listsearch = thucHien_TieuChuanBLL.dsthuchienTC().Where(x => x.TenSinhVien.Contains(txtSearch.Text)).ToList();
                dtgv_THTC.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }
            
        }

        private void txtMssv_TS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMssv_TS.TextLength < 11)
            {
                txtMssv_TS.Text = "";
                txtMssv_TS.BorderColor = Color.Red;
                txtMssv_TS.PlaceholderText = "chưa nhập đủ 11 kí tự";
                txtMssv_TS.PlaceholderForeColor = Color.Red;
            }
            else
            {
                txtMssv_TS.BorderColor = Color.FromArgb(226, 226, 226);
            }
        }

        private void txtMssv_TS_Leave(object sender, EventArgs e)
        {
            thucHien_TieuChuanBLL.check_input_mssv(txtMssv_TS);
        }
        void maxlength()
        {
            txtMssv_TS.MaxLength = 11;
        }
    }
}
