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
    public partial class HOCKYXETDIEM : UserControl
    {
        public HOCKYXETDIEM()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 5;
        private int flagDT = 0;
        private int flagLuu = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        HocKyXetDiemBLL hocKyXetDiemBLL = new HocKyXetDiemBLL();
        private void HOCKY_XETDIEM_Load(object sender, EventArgs e)
        {
            loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbFillter_TG();
            loadcbThoiGian();
            loadcbHK();
            txtNam.MaxLength = 4;
        }
        void loadHK(List<HocKy_XetDiemDTO> listHK)
        {
            dtgvHocKy.DataSource = listHK;
            flagLuu = 0;
        }
        private void btnThemHocKy_Click(object sender, EventArgs e)
        {
            dtgvHocKy.Width = 666;
            pn_ThemHocKy.Visible = true;
            btnLuuHocKy.Visible = true;
            lbTieuDe.Text = "Thêm Học Kỳ Xét";
            txtMaHK.Enabled = false;
            txtMaHK.Text = "";
            txtNam.Text = "";
            designbtn();
        }
        void designbtn()
        {
            txtNam.BorderColor = Color.FromArgb(213, 218, 223);
            txtNam.PlaceholderText = "";
        }
        private void btnXHocKy_Click(object sender, EventArgs e)
        {
            dtgvHocKy.Width = 1010;
            pn_ThemHocKy.Visible = false;
            btnLuuHocKy.Visible = false;
        }
        void loadbtnluu()
        {
            dtgvHocKy.Width = 1010;
            pn_ThemHocKy.Visible = false;
            btnLuuHocKy.Visible = false;
        }
        private void btnLuuHocKy_Click(object sender, EventArgs e)
        {
            if (txtNam.Text == "")
            {
                txtNam.BorderColor = Color.Red;
                txtNam.PlaceholderText = "bạn chưa nhập năm";
                txtNam.PlaceholderForeColor = Color.Red;
            }
            else
            {
                
                if (flagLuu == 0)
                {

                    HOCKY_XETDIEM hk = hocKyXetDiemBLL.Get(x => x.HocKy==cbHK.Text && x.Nam.ToString()==txtNam.Text && x.MaThoiGianXetDiem==Convert.ToInt32(cbThoiGian.SelectedValue));
                    if (hk == null)
                    {
                        hk = new HOCKY_XETDIEM();
                        hk.HocKy = cbHK.Text;
                        hk.Nam = Convert.ToInt32(txtNam.Text);
                        hk.MaThoiGianXetDiem = Convert.ToInt32(cbThoiGian.SelectedValue.ToString());
                        hocKyXetDiemBLL.Add(hk);
                        MessageBox.Show("Thêm Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        loadbtnluu();
                    }
                    else
                    {
                        MessageBox.Show("dữ liệu đã bị trùng !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemHocKy_Click(sender, e);
                        btnThemHocKy.Enabled = true;
                    }
                    
                }
                else
                {
                    try
                    {
                        HOCKY_XETDIEM hk = hocKyXetDiemBLL.Get(x => x.MaHocKy.ToString() == txtMaHK.Text.Trim() && x.HocKy == cbHK.Text && x.Nam == Convert.ToInt32(txtNam.Text.Trim()) && x.MaThoiGianXetDiem == Convert.ToInt32(cbThoiGian.SelectedValue.ToString()));
                        if (hk == null)
                        {
                            hk.HocKy = cbHK.Text;
                            hk.Nam = Convert.ToInt32(txtNam.Text);
                            hk.MaThoiGianXetDiem = Convert.ToInt32(cbThoiGian.SelectedValue.ToString());
                            btnThemHocKy.Enabled = true;
                            hocKyXetDiemBLL.Edit(hk);
                            MessageBox.Show("Sửa Thành Công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                            loadbtnluu();
                        }
                        else
                        {
                            MessageBox.Show("dữ liệu đã bị trùng !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnThemHocKy.Enabled = true;
                        }
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemHocKy_Click(sender, e); 
                        btnThemHocKy.Enabled = true;
                    }                
                }
            }
            
        }

        private void dtgvHocKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvHocKy.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                dtgvHocKy.Width = 666;
                pn_ThemHocKy.Visible = true;
                btnLuuHocKy.Visible = true;
                lbTieuDe.Text = "Sửa Học Kỳ Xét";
                flagLuu = 1;
                txtMaHK.Enabled = false;

                designbtn();
            }
            DataGridViewRow row = this.dtgvHocKy.Rows[e.RowIndex];
            txtMaHK.Text = row.Cells["MaHocKy"].Value.ToString();
            cbHK.Text = row.Cells["HocKy"].Value.ToString();
            txtNam.Text = row.Cells["Nam"].Value.ToString();
            cbThoiGian.SelectedValue = hocKyXetDiemBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
        }
        void loadcbFillter_TG()
        {
            cbFillter_TG.DataSource = new BindingSource(hocKyXetDiemBLL.showTime(), null);
            cbFillter_TG.DisplayMember = "Value";
            cbFillter_TG.ValueMember = "Key";
        }
        void loadcbThoiGian()
        {
            cbThoiGian.DataSource = new BindingSource(hocKyXetDiemBLL.showTime(), null);
            cbThoiGian.DisplayMember = "Value";
            cbThoiGian.ValueMember = "Key";
        }
        void loadcbHK()
        {
            cbHK.Items.Clear();
            cbHK.Items.Add("Cuối");
            cbHK.Items.Add("Đầu");
            cbHK.Text = "Cuối";
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listFIllter = new List<HocKy_XetDiemDTO>();
            listFIllter = hocKyXetDiemBLL.dsHK().Where(x => x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
            dtgvHocKy.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgvHocKy.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listFIllter = new List<HocKy_XetDiemDTO>();
                    listFIllter = hocKyXetDiemBLL.dsHK().Where(x => x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
                    dtgvHocKy.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.HOCKY_XETDIEM.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    loadHK(hocKyXetDiemBLL.dsHK().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = hocKyXetDiemBLL.dsHK().Where(x => x.ThoiGian.Contains(cbFillter_TG.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listFIllter = new List<HocKy_XetDiemDTO>();
                    listFIllter = hocKyXetDiemBLL.dsHK().Where(x => x.ThoiGian.Contains(cbFillter_TG.Text)).ToList();
                    dtgvHocKy.DataSource = listFIllter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }

        private void txtNam_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNam.Text.Trim()))
                txtNam.BorderColor = Color.Red;
            else
                txtNam.BorderColor = Color.FromArgb(226, 226, 226);
        }

        private void txtMaHK_Leave(object sender, EventArgs e)
        {

        }
    }
}
