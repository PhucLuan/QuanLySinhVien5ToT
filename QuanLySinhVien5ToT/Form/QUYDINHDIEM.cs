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
    public partial class QUYDINHDIEM : UserControl
    {
        public QUYDINHDIEM()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 8;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QuyDinhDiemBLL quyDinhDiemBLL = new QuyDinhDiemBLL();
        private void QUYDINHDIEM_Load(object sender, EventArgs e)
        {
            loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbThoiGian_TS();
            loadcbDV_TS();
            laodcbLD_TS();
            loadcbTC_TS();
            loadcbTrangThai();
            loadcbFillter_TG();
            loadcbFillter_DV();
            loadcbFillter_LD();
        }
        void loadQDD (List<QuyDinhDiemDTO> listQD)
        {
            dtgvQuyDinh.DataSource = listQD;
            flagDT = 0;
        }
        private void btnThemQuyDinh_Click(object sender, EventArgs e)
        {
            
            pn_ThemQuyDinh.Visible = true;
            btnLuuQuyDinh.Visible = true;
            pn_Sort.Visible = false;
            flagLuu = 0;
            txtMaQuyDinh_TS.Enabled = false;
            cbTrangThai.Enabled = false;            
            cbDonVi_TS.Enabled = true;
            cbLoaiDiem_TS.Enabled = true;
            cbTieuChuan_TS.Enabled = true;
            cbThoiGian_TS.Enabled = true;
            txtDiemToiThieu.Text = "";
            txtDiemToiThieu.BorderColor = Color.FromArgb(213, 218, 223);
            txtDiemToiThieu.PlaceholderText = "";
            txtDiemToiThieu.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
        }

        private void dtgvQuyDinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvQuyDinh.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {               
                pn_ThemQuyDinh.Visible = true;
                btnLuuQuyDinh.Visible = true;
                pn_Sort.Visible = false;
                flagLuu = 1;
                txtMaQuyDinh_TS.Enabled = false;
                cbDonVi_TS.Enabled = false;
                cbLoaiDiem_TS.Enabled = false;
                cbTieuChuan_TS.Enabled = false;
                cbThoiGian_TS.Enabled = false;
                cbTrangThai.Enabled = true;

                txtDiemToiThieu.BorderColor = Color.FromArgb(213, 218, 223);
                txtDiemToiThieu.PlaceholderText = "";
                txtDiemToiThieu.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
            }
            
            DataGridViewRow row = this.dtgvQuyDinh.Rows[e.RowIndex];
            txtMaQuyDinh_TS.Text = row.Cells["MaQuyDinhDiem"].Value.ToString();
            cbTieuChuan_TS.Text = row.Cells["TenTieuChuan"].Value.ToString();
            txtDiemToiThieu.Text = row.Cells["DiemToiThieu"].Value.ToString();
            cbDonVi_TS.Text= row.Cells["DonVi"].Value.ToString();
            cbLoaiDiem_TS.Text= row.Cells["TenLoaiDiem"].Value.ToString();
            cbTrangThai.Text= row.Cells["TrangThai"].Value.ToString();
            cbThoiGian_TS.SelectedValue = quyDinhDiemBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
        }

        private void btnXHocKy_Click(object sender, EventArgs e)
        {
           
            pn_ThemQuyDinh.Visible = false;
            btnLuuQuyDinh.Visible = false;
            pn_Sort.Visible = true;
        }

        private void btnLuuQuyDinh_Click(object sender, EventArgs e)
        {
            if (txtDiemToiThieu.Text == "")
            {
                txtDiemToiThieu.BorderColor = Color.Red;
                txtDiemToiThieu.PlaceholderText = "bạn chưa nhập Điểm Tối Thiểu";
                txtDiemToiThieu.PlaceholderForeColor = Color.Red;
            }
            else
            {
                string cbLoaiDiem = cbLoaiDiem_TS.Text;
                pn_ThemQuyDinh.Visible = false;
                btnLuuQuyDinh.Visible = false;
                pn_Sort.Visible = true;
                if (flagLuu == 0)
                {
                    QUYDINH_DIEM qd = quyDinhDiemBLL.Get(x => x.MaLoaiDiem == Convert.ToInt32(cbLoaiDiem_TS.SelectedValue.ToString())
                    && x.MaDonVi.Trim() == cbDonVi_TS.Text
                    && x.Mathoigian == Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString())
                    && x.MaTieuChuan == Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString()));
                    if (qd == null)
                    {
                        qd = new QUYDINH_DIEM();
                        qd.MaLoaiDiem = Convert.ToInt32(cbLoaiDiem_TS.SelectedValue.ToString());
                        if (cbLoaiDiem == "Điểm rèn luyện")
                        {
                            if (Convert.ToInt32(txtDiemToiThieu.Text) <= 100 && Convert.ToInt32(txtDiemToiThieu.Text) >= 50)
                            {
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                qd.MaDonVi = cbDonVi_TS.Text;
                                qd.MaTieuChuan = Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString());
                                qd.Mathoigian = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                quyDinhDiemBLL.Add(qd);
                                MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                pn_ThemQuyDinh.Visible = true;
                                btnLuuQuyDinh.Visible = true;
                                pn_Sort.Visible = false;
                                txtDiemToiThieu.Text = "";
                                MessageBox.Show("Điểm rèn luyện phải >=50 và <=100");

                            }
                        }
                        if (cbLoaiDiem == "Điểm học tập" || cbLoaiDiem == "Điểm Kỹ năng mềm")
                        {
                            if (Convert.ToInt32(txtDiemToiThieu.Text) > 0 && Convert.ToInt32(txtDiemToiThieu.Text) <= 10)
                            {
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                qd.MaDonVi = cbDonVi_TS.Text;
                                qd.MaTieuChuan = Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString());
                                qd.Mathoigian = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                quyDinhDiemBLL.Add(qd);
                                MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                pn_ThemQuyDinh.Visible = true;
                                btnLuuQuyDinh.Visible = true;
                                pn_Sort.Visible = false;
                                txtDiemToiThieu.Text = "";
                                MessageBox.Show("Điểm học tập không dược >10");

                            }
                        }
                        if (cbLoaiDiem == "Điểm xếp loại đoàn viên")
                        {
                            if (Convert.ToInt32(txtDiemToiThieu.Text) >= 75)
                            {
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                qd.MaDonVi = cbDonVi_TS.Text;
                                qd.MaTieuChuan = Convert.ToInt32(cbTieuChuan_TS.SelectedValue.ToString());
                                qd.Mathoigian = Convert.ToInt32(cbThoiGian_TS.SelectedValue.ToString());
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                quyDinhDiemBLL.Add(qd);
                                MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                pn_ThemQuyDinh.Visible = true;
                                btnLuuQuyDinh.Visible = true;
                                pn_Sort.Visible = false;
                                txtDiemToiThieu.Text = "";
                                MessageBox.Show("Điểm xếp loại đoàn viên phải >=75");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("dữ liệu đã bị trùng !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
                else
                {
                    QUYDINH_DIEM qd = quyDinhDiemBLL.Get(x => x.MaQuyDinhDiem == Convert.ToInt32(txtMaQuyDinh_TS.Text));
                    if (cbLoaiDiem == "Điểm rèn luyện")
                    {
                        if (Convert.ToInt32(txtDiemToiThieu.Text) <= 100 && Convert.ToInt32(txtDiemToiThieu.Text) >= 50)
                        {
                            if (cbTrangThai.Text == "True")
                            {
                                QUYDINH_DIEM qdd = quyDinhDiemBLL.Get(x => x.TrangThai == Convert.ToBoolean("True") && x.MaDonVi == cbDonVi_TS.Text && x.MaLoaiDiem==Convert.ToInt32(cbLoaiDiem_TS.SelectedValue));
                                qdd.TrangThai = Convert.ToBoolean("False");
                                quyDinhDiemBLL.Edit(qdd);
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                        
                        }
                        else
                        {
                            pn_ThemQuyDinh.Visible = true;
                            btnLuuQuyDinh.Visible = true;
                            pn_Sort.Visible = false;
                            txtDiemToiThieu.Text = "";
                            MessageBox.Show("Điểm rèn luyện phải >=50 và <=100");

                        }
                    }
                    if (cbLoaiDiem == "Điểm học tập" || cbLoaiDiem == "Điểm Kỹ năng mềm")
                    {
                        if (Convert.ToInt32(txtDiemToiThieu.Text) > 0 && Convert.ToInt32(txtDiemToiThieu.Text) <= 10)
                        {
                            if (cbTrangThai.Text == "True")
                            {
                                QUYDINH_DIEM qdd = quyDinhDiemBLL.Get(x => x.TrangThai == Convert.ToBoolean("True") && x.MaDonVi == cbDonVi_TS.Text && x.MaLoaiDiem == Convert.ToInt32(cbLoaiDiem_TS.SelectedValue));
                                qdd.TrangThai = Convert.ToBoolean("False");
                                quyDinhDiemBLL.Edit(qdd);
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            pn_ThemQuyDinh.Visible = true;
                            btnLuuQuyDinh.Visible = true;
                            pn_Sort.Visible = false;
                            txtDiemToiThieu.Text = "";
                            MessageBox.Show("Điểm học tập không dược >10");

                        }
                    }
                    if (cbLoaiDiem == "Điểm xếp loại đoàn viên")
                    {
                        if (Convert.ToInt32(txtDiemToiThieu.Text) >= 75)
                        {
                            if (cbTrangThai.Text == "True")
                            {
                                QUYDINH_DIEM qdd = quyDinhDiemBLL.Get(x => x.TrangThai == Convert.ToBoolean("True") && x.MaDonVi == cbDonVi_TS.Text && x.MaLoaiDiem == Convert.ToInt32(cbLoaiDiem_TS.SelectedValue));
                                qdd.TrangThai = Convert.ToBoolean("False");
                                quyDinhDiemBLL.Edit(qdd);
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                qd.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                                qd.DiemToiThieu = Convert.ToInt32(txtDiemToiThieu.Text);
                                quyDinhDiemBLL.Edit(qd);
                                MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            pn_ThemQuyDinh.Visible = true;
                            btnLuuQuyDinh.Visible = true;
                            pn_Sort.Visible = false;
                            txtDiemToiThieu.Text = "";
                            MessageBox.Show("Điểm xếp loại đoàn viên phải >=75");
                        }
                    }

                    loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
            }
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            pn_ThemQuyDinh.Visible = false;
            btnLuuQuyDinh.Visible = false;
            pn_Sort.Visible = true;
        }

        private void btnSuaTC_Click(object sender, EventArgs e)
        {
            Edit_LoaiDiem UC = new Edit_LoaiDiem();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(170, 48);
            this.dtgvQuyDinh.Enabled = false;
            this.btnSuaLD.Enabled = false;
            this.btnThemQuyDinh.Enabled = false;
            UC.Enabled = true;          
        }
        void loadcbThoiGian_TS()
        {
            cbThoiGian_TS.DataSource = new BindingSource(quyDinhDiemBLL.showTime(), null);
            cbThoiGian_TS.DisplayMember = "Value";
            cbThoiGian_TS.ValueMember = "Key";
        }
        void loadcbDV_TS()
        {
            cbDonVi_TS.DataSource = quyDinhDiemBLL.dsdonvi();
            cbDonVi_TS.DisplayMember = "MaDonVi";
            cbDonVi_TS.ValueMember = "MaDonVi";
        }
        void laodcbLD_TS()
        {
            cbLoaiDiem_TS.DataSource = quyDinhDiemBLL.dsloaidiem();
            cbLoaiDiem_TS.DisplayMember = "TenLoaiDiem";
            cbLoaiDiem_TS.ValueMember = "MaLoaiDiem";
        }
        void loadcbTC_TS()
        {
            cbTieuChuan_TS.DataSource = quyDinhDiemBLL.dstieuchuan();
            cbTieuChuan_TS.DisplayMember = "TenTieuChuan";
            cbTieuChuan_TS.ValueMember = "MaTieuChuan";
        }
        void loadcbTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("True");
            cbTrangThai.Items.Add("False");
            cbTrangThai.Text = "False";
        }
        void loadcbFillter_TG()
        {
            cbFillter_TG.DataSource = new BindingSource(quyDinhDiemBLL.showTime(), null);
            cbFillter_TG.DisplayMember = "Value";
            cbFillter_TG.ValueMember = "Key";
        }
        void loadcbFillter_DV()
        {
            cbFillter_DV.DataSource = quyDinhDiemBLL.dsdonvi();
            cbFillter_DV.DisplayMember = "MaDonVi";
            cbFillter_DV.ValueMember = "MaDonVi";
        }
        void loadcbFillter_LD()
        {
            cbFillter_LD.DataSource = quyDinhDiemBLL.dsloaidiem();
            cbFillter_LD.DisplayMember = "TenLoaiDiem";
            cbFillter_LD.ValueMember = "MaLoaiDiem";
        }

        private void txtDiemToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listFIllter = new List<QuyDinhDiemDTO>();
            listFIllter = quyDinhDiemBLL.dsQD().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text) && x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
            dtgvQuyDinh.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgvQuyDinh.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                if (flagDT == 0)
                {
                    loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
                else if (flagDT == 1)
                {
                    var listFIllter = new List<QuyDinhDiemDTO>();
                    listFIllter = quyDinhDiemBLL.dsQD().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text) && x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
                    dtgvQuyDinh.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.QUYDINH_DIEM.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    loadQDD(quyDinhDiemBLL.dsQD().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = quyDinhDiemBLL.dsQD().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text) && x.ThoiGian.Contains(cbFillter_TG.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listFIllter = new List<QuyDinhDiemDTO>();
                    listFIllter = quyDinhDiemBLL.dsQD().Where(x => x.DonVi.Contains(cbFillter_DV.Text) && x.TenLoaiDiem.Contains(cbFillter_LD.Text) && x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
                    dtgvQuyDinh.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();               
                }
            }
        }
    }
}
