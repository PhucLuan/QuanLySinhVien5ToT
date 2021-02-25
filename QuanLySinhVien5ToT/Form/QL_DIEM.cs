using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.BLL;

namespace QuanLySinhVien5ToT
{
    public partial class QL_DIEM : UserControl
    {
        public QL_DIEM()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 3;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QL_DiemBLL QL_DiemBLL = new QL_DiemBLL();
        private void QL_DIEM_Load(object sender, EventArgs e)
        {
            loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbFillter_TG();
            loadcbFIllter_LD();
            loadcbThoiGian_TS();
            loadcbLoaiDiem_TS();
            loadcbThoiGian_Xem();
            loadcbFillter_DV();
            SuggestTxtMssv();
            SuggestTxtSearch();
        }
        void loadDiem(List<DiemDTO> listdiem)
        {
            dtgv_Diem.DataSource = listdiem;
            flagDT = 0;
        }
        private void btnThemDiem_Click(object sender, EventArgs e)
        {
            pn_Them_Sua.Visible = true;
            btnLuuDiem.Visible = true;
            pn_ThongTinDiem.Visible = false;
            dtgv_Diem.Width = 730;
            lebal_Them_Sua.Text = "Thêm Thông Tin Điểm";
            flagLuu = 0;
            txtMssv_TS.Text = "";
            txtDiem_TS.Text = "";
            txtMssv_TS.ReadOnly = false;
            cbThoiGian_TS.Enabled = true;
            cbLoaiDiem_TS.Enabled = true;
            cbLoaiDiem_TS.FillColor = Color.White;
            cbThoiGian_TS.FillColor = Color.White;

            designbtn();
        }
        void designbtn()
        {
            txtMssv_TS.BorderColor = Color.FromArgb(213, 218, 223);
            txtMssv_TS.PlaceholderText = "";           
            txtDiem_TS.BorderColor = Color.FromArgb(213, 218, 223);
            txtDiem_TS.PlaceholderText = "";            
        }
        void loadbtnluu()
        {
            pn_Them_Sua.Visible = false;
            btnLuuDiem.Visible = false;
            pn_ThongTinDiem.Visible = false;
            dtgv_Diem.Width = 971;
        }
        private void btnLuuDiem_Click(object sender, EventArgs e)
        {
            
            if (txtMssv_TS.Text == "" || txtDiem_TS.Text == "")
            {
                if (string.IsNullOrEmpty(txtMssv_TS.Text.Trim()))
                {
                    txtMssv_TS.BorderColor = Color.Red;
                    txtMssv_TS.PlaceholderText = "bạn chưa nhập Mssv";
                    txtMssv_TS.PlaceholderForeColor = Color.Red;
                }
                txtDiem_TS_Leave(sender, e);
            }
            else
            {
                if (flagLuu == 0)
                {
                    DIEM diem = QL_DiemBLL.Get(x => x.Mssv.Trim() == txtMssv_TS.Text.Trim() && x.MaLoaiDiem == Convert.ToInt32(cbLoaiDiem_TS.SelectedValue.ToString()) && x.MaHocKy == Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString()));
                    if (diem == null)
                    {
                        diem = new DIEM();
                        diem.Mssv = txtMssv_TS.Text;
                        diem.MaLoaiDiem = Convert.ToInt32(cbLoaiDiem_TS.SelectedValue.ToString());
                        diem.Diem1 = Convert.ToInt32(txtDiem_TS.Text);
                        diem.MaHocKy = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                        QL_DiemBLL.Add(diem);
                        MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();

                    }
                    else
                    {
                        MessageBox.Show("Dữ Liệu Đã Bị Trùng!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemDiem_Click(sender, e);
                    }
                }
                else
                {
                    try
                    {
                        DIEM diem = QL_DiemBLL.Get(x => x.Mssv.Trim() == txtMssv_TS.Text.Trim() && x.MaLoaiDiem == Convert.ToInt32(cbLoaiDiem_TS.SelectedValue.ToString()) && x.MaHocKy == Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString()));
                        diem.Diem1 = Convert.ToInt32(txtDiem_TS.Text);
                        QL_DiemBLL.Edit(diem);
                        MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemDiem_Click(sender, e);
                    }                      
                }
            }
            
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
                txtTenSV_Xem.Enabled = false;
                txtLD_Xem.Enabled = false;
                txtDiem_Xem.Enabled = false;
                cbThoiGian_Xem.Enabled = false;
                cbThoiGian_Xem.FillColor = Color.FromArgb(226, 226, 226);
            }
            if (name == "Sua")
            {
                pn_Them_Sua.Visible = true;
                pn_ThongTinDiem.Visible = false;
                btnLuuDiem.Visible = true;
                dtgv_Diem.Width = 730;
                lebal_Them_Sua.Text = "Sửa Thông Tin Điểm";
                txtMssv_TS.ReadOnly = true;
                cbThoiGian_TS.Enabled = false;
                cbLoaiDiem_TS.Enabled = false;
                flagLuu = 1;
                cbLoaiDiem_TS.FillColor = Color.FromArgb(226, 226, 226);
                cbThoiGian_TS.FillColor = Color.FromArgb(226, 226, 226);
                designbtn();
            }
            DataGridViewRow row = this.dtgv_Diem.Rows[e.RowIndex];
            txtMssv_TS.Text = row.Cells["Mssv"].Value.ToString();
            cbLoaiDiem_TS.Text = row.Cells["TenLoaiDiem"].Value.ToString();
            txtDiem_TS.Text= row.Cells["Diem"].Value.ToString();
            cbThoiGian_TS.SelectedValue = QL_DiemBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());

            txtTenSV_Xem.Text = row.Cells["TenSinhVien"].Value.ToString();
            txtLD_Xem.Text = row.Cells["TenLoaiDiem"].Value.ToString();
            txtDiem_Xem.Text = row.Cells["Diem"].Value.ToString();
            cbThoiGian_Xem.SelectedValue = QL_DiemBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
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

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<DiemDTO>();
                    listfillter = QL_DiemBLL.dsdiem().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.HocKy.Contains(cbFIllter_TG.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
                    dtgv_Diem.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listSearch = new List<DiemDTO>();
                    listSearch = QL_DiemBLL.dsdiem().Where(x => x.TenSinhVien.Contains(txtSearch.Text) || x.Mssv.Contains(txtSearch.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
                    dtgv_Diem.DataSource = listSearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                    loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = QL_DiemBLL.dsdiem().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.HocKy.Contains(cbFIllter_TG.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<DiemDTO>();
                    listfillter = QL_DiemBLL.dsdiem().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.HocKy.Contains(cbFIllter_TG.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
                    dtgv_Diem.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                int totlalrecord = 0;
                totlalrecord = QL_DiemBLL.dsdiem().Where(x => x.TenSinhVien.Contains(txtSearch.Text) || x.Mssv.Contains(txtSearch.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listSearch = new List<DiemDTO>();
                    listSearch = QL_DiemBLL.dsdiem().Where(x => x.TenSinhVien.Contains(txtSearch.Text) || x.Mssv.Contains(txtSearch.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
                    dtgv_Diem.DataSource = listSearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }
        void loadcbFillter_TG()
        {
            cbFIllter_TG.DataSource = new BindingSource(QL_DiemBLL.showTime(), null);
            cbFIllter_TG.DisplayMember = "Value";
            cbFIllter_TG.ValueMember = "Key";
        }
        void loadcbFIllter_LD()
        {
            cbFillter_LD.DataSource = QL_DiemBLL.dsloaidiem();
            cbFillter_LD.DisplayMember = "TenLoaiDiem";
            cbFillter_LD.ValueMember = "MaLoaiDiem";
        }
        void loadcbThoiGian_TS()
        {
            cbThoiGian_TS.DataSource = new BindingSource(QL_DiemBLL.showTime(), null);
            cbThoiGian_TS.DisplayMember = "Value";
            cbThoiGian_TS.ValueMember = "Key";
        }
        void loadcbLoaiDiem_TS()
        {
            cbLoaiDiem_TS.DataSource = QL_DiemBLL.dsloaidiem();
            cbLoaiDiem_TS.DisplayMember = "TenLoaiDiem";
            cbLoaiDiem_TS.ValueMember = "MaLoaiDiem";
        }
        void loadcbThoiGian_Xem()
        {
            cbThoiGian_Xem.DataSource = new BindingSource(QL_DiemBLL.showTime(), null);
            cbThoiGian_Xem.DisplayMember = "Value";
            cbThoiGian_Xem.ValueMember = "Key";
        }
        void loadcbFillter_DV()
        {
            cbFillter_DV.DataSource = QL_DiemBLL.dsdonvi();
            cbFillter_DV.DisplayMember = "MaDonVi";
            cbFillter_DV.ValueMember = "MaDonVi";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listfillter = new List<DiemDTO>();
            listfillter = QL_DiemBLL.dsdiem().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.HocKy.Contains(cbFIllter_TG.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
            dtgv_Diem.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_Diem.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            
        }

        private void txtMssv_TS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void txtDiem_TS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                loadDiem(QL_DiemBLL.dsdiem().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listSearch = new List<DiemDTO>();
                listSearch = QL_DiemBLL.dsdiem().Where(x => x.TenSinhVien.Contains(txtSearch.Text) || x.Mssv.Contains(txtSearch.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text)).ToList();
                dtgv_Diem.DataSource = listSearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }            
        }
        void SuggestTxtMssv()
        {
            txtMssv_TS.AutoCompleteCustomSource.AddRange(QL_DiemBLL.dssinhvien().Select(x => x.Mssv).ToArray());
        }
        void SuggestTxtSearch()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(QL_DiemBLL.dssinhvien().Select(x => x.HoTen).ToArray());
        }
        void QDdiemtoithieu()
        {
            txtDiem_TS.Text = "";
            //MessageBox.Show("Điểm sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtDiem_TS.BorderColor = Color.Red;
            txtDiem_TS.PlaceholderForeColor = Color.Red;

        }
        private void txtDiem_TS_Leave(object sender, EventArgs e)
        {
            string cbLoaiDiem = cbLoaiDiem_TS.Text;
            if (cbLoaiDiem == "Điểm rèn luyện")
            {
                if (txtDiem_TS.Text == "" || Convert.ToInt32(txtDiem_TS.Text) > 100 || Convert.ToInt32(txtDiem_TS.Text) < 50)
                {
                    QDdiemtoithieu();
                    txtDiem_TS.PlaceholderText = "Điểm phải >=50 và <=100";
                }
                else
                {
                    txtDiem_TS.BorderColor = Color.FromArgb(226, 226, 226);
                }
            }
            if (cbLoaiDiem == "Điểm học tập" || cbLoaiDiem == "Điểm Kỹ năng mềm")
            {
                if (txtDiem_TS.Text == "" || Convert.ToInt32(txtDiem_TS.Text) == 0 || Convert.ToInt32(txtDiem_TS.Text) > 10)
                {
                    QDdiemtoithieu();
                    txtDiem_TS.PlaceholderText = "Điểm phải >0 và <=10";
                }
                else
                {
                    txtDiem_TS.BorderColor = Color.FromArgb(226, 226, 226);
                }
                if (cbLoaiDiem == "Điểm xếp loại đoàn viên")
                {
                    if (txtDiem_TS.Text == "" || Convert.ToInt32(txtDiem_TS.Text) < 75 || Convert.ToInt32(txtDiem_TS.Text) > 100)
                    {
                        QDdiemtoithieu();
                        txtDiem_TS.PlaceholderText = "Điểm phải >=75 và <=100";
                    }
                    else
                    {
                        txtDiem_TS.BorderColor = Color.FromArgb(226, 226, 226);
                    }
                }
            }
        }
        void checkdiem()
        {
            
        }

        private void txtMssv_TS_Leave(object sender, EventArgs e)
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
    }
}
