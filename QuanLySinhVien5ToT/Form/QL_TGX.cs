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
        int numberRecord = 5;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        ThoiDiemSV_ThamGiaBLL thoiDiemSV_ThamGiaBLL = new ThoiDiemSV_ThamGiaBLL();
        private void QL_TGX_Load(object sender, EventArgs e)
        {
            loadlistsv(thoiDiemSV_ThamGiaBLL.dssinhvienTG().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbFillterTG();
            loadcbThoiGian_TS();
            loadcbThoiGian_Xem();
            loadcbFillter_DV();
            TXTSEARCH();
            SuggestTxtMssv();
        }

        void loadlistsv (List<ThoiDiemSV_ThamGiaDTO> listtt)
        {
            dtgv_ThongTin.DataSource = listtt;
            flagDT = 0;
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
                txtMssv_Xem.Enabled = false;
                txtHoTen_Xem.Enabled = false;
                txtDonVi_Xem.Enabled = false;
                txtLop_Xem.Enabled = false;
                cbThoiGian_Xem.Enabled = false;
            }

            DataGridViewRow row = this.dtgv_ThongTin.Rows[e.RowIndex];
            txtMssv_Xem.Text = row.Cells["Mssv"].Value.ToString();
            txtHoTen_Xem.Text= row.Cells["HoTen"].Value.ToString();
            txtDonVi_Xem.Text= row.Cells["DonVi"].Value.ToString();
            txtLop_Xem.Text = row.Cells["Lop"].Value.ToString();
            cbThoiGian_Xem.SelectedValue = thoiDiemSV_ThamGiaBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
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
            txtMssv_TS.Text = "";

            txtMssv_TS.BorderColor = Color.FromArgb(213, 218, 223); 
            txtMssv_TS.PlaceholderText = "";
            txtMssv_TS.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
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
            if (txtMssv_TS.Text == "")
            {
                txtMssv_TS.BorderColor = Color.Red;
                txtMssv_TS.PlaceholderText = "bạn chưa nhập Mssv";
                txtMssv_TS.PlaceholderForeColor = Color.Red;
            }
            else
            {
                dtgv_ThongTin.Width = 1008;
                pn_Them_TT.Visible = false;
                btnLuuTT.Visible = false;
                pn_XemChiTiet.Visible = false;
                THOIDIEM_SV_THAMGIA tdtt = thoiDiemSV_ThamGiaBLL.Get(x => x.Mssv.Trim() == txtMssv_TS.Text.Trim() && x.MaThoiGian == Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString()));
                if (tdtt == null)
                {
                    tdtt = new THOIDIEM_SV_THAMGIA();
                    tdtt.Mssv = txtMssv_TS.Text;
                    tdtt.MaThoiGian = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                    thoiDiemSV_ThamGiaBLL.Add(tdtt);
                    MessageBox.Show("Lưu Thành Công");
                }
                else
                {
                    MessageBox.Show("dữ liệu đã bị trùng");
                }
            }            
        }
        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                if (flagDT == 0)
                {
                    loadlistsv(thoiDiemSV_ThamGiaBLL.dssinhvienTG().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
                else if (flagDT == 1)
                {
                    var listfillter = new List<ThoiDiemSV_ThamGiaDTO>();
                    listfillter = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.Lop.Contains(txtFillter_Lop.Text) && x.ThoiGian.Contains(CbFillter_TG.Text)).ToList();
                    dtgv_ThongTin.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();

                }
                else if (flagDT == 2)
                {
                    var listsearch = new List<ThoiDiemSV_ThamGiaDTO>();
                    listsearch = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.TenSinhVien.Contains(txtSearch.Text.Trim())).ToList();
                    dtgv_ThongTin.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                }

            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.THOIDIEM_SV_THAMGIA.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                if (flagDT == 0)
                {
                    loadlistsv(thoiDiemSV_ThamGiaBLL.dssinhvienTG().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
                else if (flagDT == 1)
                {
                    var listfillter = new List<ThoiDiemSV_ThamGiaDTO>();
                    listfillter = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.Lop.Contains(txtFillter_Lop.Text) && x.ThoiGian.Contains(CbFillter_TG.Text)).ToList();
                    dtgv_ThongTin.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    
                }
                else if (flagDT == 2)
                {
                    var listsearch = new List<ThoiDiemSV_ThamGiaDTO>();
                    listsearch = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.TenSinhVien.Contains(txtSearch.Text.Trim())).ToList();
                    dtgv_ThongTin.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                }

            }
        }
        void loadcbFillterTG()
        {
            CbFillter_TG.DataSource = new BindingSource(thoiDiemSV_ThamGiaBLL.showTime(), null);
            CbFillter_TG.DisplayMember = "Value";
            CbFillter_TG.ValueMember = "Key";
        }
        void loadcbThoiGian_TS()
        {
            cbThoiGian_TS.DataSource = new BindingSource(thoiDiemSV_ThamGiaBLL.showTime(), null);
            cbThoiGian_TS.DisplayMember = "Value";
            cbThoiGian_TS.ValueMember = "Key";
        }
        void loadcbThoiGian_Xem()
        {
            cbThoiGian_Xem.DataSource = new BindingSource(thoiDiemSV_ThamGiaBLL.showTime(), null);
            cbThoiGian_Xem.DisplayMember = "Value";
            cbThoiGian_Xem.ValueMember = "Key";
        }
        void loadcbFillter_DV()
        {
            cbFillter_DV.DataSource = thoiDiemSV_ThamGiaBLL.dsdonvi();
            cbFillter_DV.DisplayMember = "MaDonVi";
            cbFillter_DV.ValueMember = "MaDonVi";
        }

        private void txtMssv_TS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var listfillter = new List<ThoiDiemSV_ThamGiaDTO>();
            listfillter = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.Lop.Contains(txtFillter_Lop.Text) && x.ThoiGian.Contains(CbFillter_TG.Text)).ToList();
            dtgv_ThongTin.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                loadlistsv(thoiDiemSV_ThamGiaBLL.dssinhvienTG().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listsearch = new List<ThoiDiemSV_ThamGiaDTO>();
                listsearch = thoiDiemSV_ThamGiaBLL.dssinhvienTG().Where(x => x.TenSinhVien.Contains(txtSearch.Text.Trim())).ToList();
                dtgv_ThongTin.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
            }
        }
        void TXTSEARCH()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(thoiDiemSV_ThamGiaBLL.dssinhvien().Select(x => x.HoTen).ToArray());
        }
        void SuggestTxtMssv()
        {
            txtMssv_TS.AutoCompleteCustomSource.AddRange(thoiDiemSV_ThamGiaBLL.dssinhvien().Select(x => x.Mssv).ToArray());
        }
    }
}
