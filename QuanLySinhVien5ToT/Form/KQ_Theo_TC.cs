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
using Microsoft.SqlServer.Server;
using QuanLySinhVien5ToT.DTO;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace QuanLySinhVien5ToT
{
    public partial class KQ_Theo_TC : UserControl
    {
        public KQ_Theo_TC()
        {
            InitializeComponent();
        }
        private int flagDT = 0;
        private int flagLuu = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        KQ_Theo_tcBLL KQ_Theo_TcBLL = new KQ_Theo_tcBLL();
        int pagenumber = 1;
        int numberRecord = 8;
        private void KQ_Theo_TC_Load(object sender, EventArgs e)
        {
            loadcbFillterTG();
            loadcbFillterTC();
            loadcbThoigian_TS();
            loadcbTC_TS();
            loadcbThoiGian_Xem();
            loadcbFiiter_DV();
            TXTSEARCH();
            SuggestTxtMssv();
            loadTDHDK();
            maxlength();
            loadcbDanhGia_TS();
            showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

        }
        void showKQ(List<Kq_Theo_tcDTO> listkq)
        {
            dtgv_KQTTC.DataSource = listkq;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string name = dtgv_KQTTC.Columns[e.ColumnIndex].Name;
            if (name == "XemChiTiet")
            {
                pn_Them_SuaKQ.Visible = false;
                pn_XemChiTiet.Visible = true;
                dtgv_KQTTC.Width = 674;
                btnX_XemChiTiet.Enabled = true;
                txtTenSinhVien.ReadOnly = true;
                txtTDHDK_Xem.ReadOnly = true;
                txtTDBB_Xem.ReadOnly = true;
                cbThoiGian_Xem.Enabled = false;
                txtTieuChi_Xem.ReadOnly = true;

            }
            if (name == "Sua")
            {
                pn_XemChiTiet.Visible = false;
                pn_Them_SuaKQ.Visible = true;
                dtgv_KQTTC.Width = 674;
                btnLuuKQ.Visible = true;
                flagLuu = 1;
                txtMssvThem_Sua.Enabled = false;
                cbTCThem_Sua.Enabled = false;
                cbThoiGianThem_Sua.Enabled = false;

                txtMssvThem_Sua.BorderColor = Color.White;
                txtMssvThem_Sua.PlaceholderText = "";
                txtMssvThem_Sua.PlaceholderForeColor = Color.White;
                txtTDBBThem_Sua.BorderColor = Color.White;
                txtTDBBThem_Sua.PlaceholderText = "";
                txtTDBBThem_Sua.PlaceholderForeColor = Color.White;
                
            }

            DataGridViewRow row = this.dtgv_KQTTC.Rows[e.RowIndex];
            txtMssvThem_Sua.Text = row.Cells["Mssv"].Value.ToString();
            cbTCThem_Sua.Text = row.Cells["TieuChi"].Value.ToString();
            txtTDBBThem_Sua.Text = row.Cells["TienDoHDBB"].Value.ToString();
            cbTDHDKThem_Sua.Text = row.Cells["TienDoHDKhac"].Value.ToString();
            cbThoiGianThem_Sua.SelectedValue = KQ_Theo_TcBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
            cbDanhGia_TS.Text = row.Cells["DanhGia"].Value.ToString();

            txtTenSinhVien.Text = row.Cells["TenSinhVien"].Value.ToString();
            txtTieuChi_Xem.Text = row.Cells["TieuChi"].Value.ToString();
            txtTDBB_Xem.Text = row.Cells["TienDoHDBB"].Value.ToString();
            txtTDHDK_Xem.Text = row.Cells["TienDoHDKhac"].Value.ToString();
            cbThoiGian_Xem.SelectedValue = KQ_Theo_TcBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
            txtDanhGia_Xem.Text = row.Cells["DanhGia"].Value.ToString();
        }

        private void btnX_XemChiTiet_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
        }
        void loadcbFillterTC()
        {
            cbFillterTC.DataSource = KQ_Theo_TcBLL.dstieuchi();
            cbFillterTC.DisplayMember = "TenTieuChi";
            cbFillterTC.ValueMember = "MaTieuChi";
        }

        private void btnThemKQ_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = true;
            dtgv_KQTTC.Width = 674;
            btnLuuKQ.Visible = true;
            flagLuu = 0;
            txtMssvThem_Sua.Text = "";
            txtTDBBThem_Sua.Text = "";
            
            txtMssvThem_Sua.Enabled = true;
            cbThoiGianThem_Sua.Enabled = true;
            cbTCThem_Sua.Enabled = true;

            txtMssvThem_Sua.BorderColor = Color.White;
            txtMssvThem_Sua.PlaceholderText = "";
            txtMssvThem_Sua.PlaceholderForeColor = Color.White;
            txtTDBBThem_Sua.BorderColor = Color.White;
            txtTDBBThem_Sua.PlaceholderText = "";
            txtTDBBThem_Sua.PlaceholderForeColor = Color.White;
            
           
        }

        private void btnLuuKQ_Click(object sender, EventArgs e)
        {
            if (txtMssvThem_Sua.Text == "" ||  txtTDBBThem_Sua.Text == "")
            {
                if (string.IsNullOrEmpty(txtMssvThem_Sua.Text.Trim()))
                {
                    txtMssvThem_Sua.BorderColor = Color.Red;
                    txtMssvThem_Sua.PlaceholderText = "bạn chưa nhập mssv";
                    txtMssvThem_Sua.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtTDBBThem_Sua.Text.Trim()))
                {
                    txtTDBBThem_Sua.BorderColor = Color.Red;
                    txtTDBBThem_Sua.PlaceholderText = "bạn chưa nhập TDHDBB";
                    txtTDBBThem_Sua.PlaceholderForeColor = Color.Red;
                }                
            }
            else
            {
                pn_XemChiTiet.Visible = false;
                pn_Them_SuaKQ.Visible = false;
                dtgv_KQTTC.Width = 981;
                btnLuuKQ.Visible = false;
                if (flagLuu == 0)
                {
                    KQ_THEO_TIEUCHI kq = KQ_Theo_TcBLL.Get(x => x.Mssv.Trim() == txtMssvThem_Sua.Text.Trim() && x.MaTieuChi.Trim() == cbTCThem_Sua.Text.Trim() && x.MaThoiGian == Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue));
                    if (kq == null)
                    {
                        kq = new KQ_THEO_TIEUCHI();
                        if (txtMssvThem_Sua.TextLength < 11 || txtMssvThem_Sua.TextLength > 11)
                        {
                            MessageBox.Show("Mssv phải có 11 số !!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            kq.Mssv = txtMssvThem_Sua.Text;
                            kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                            kq.MaThoiGian = Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());
                            kq.DanhGia = Convert.ToInt32(cbDanhGia_TS.SelectedValue);
                            if (Convert.ToInt32(txtTDBBThem_Sua.Text) > 7)
                            {
                                txtTDBBThem_Sua.Text = "";
                                MessageBox.Show("Số tiến độ không được vượt quá 7");
                            }
                            else
                            {
                                kq.TienDoHDBatBuoc = Convert.ToInt16(txtTDBBThem_Sua.Text);
                                kq.TienDoHDKhac = Convert.ToBoolean(cbTDHDKThem_Sua.Text);
                                KQ_Theo_TcBLL.Add(kq);
                                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
                else
                {
                    try
                    {
                        KQ_THEO_TIEUCHI kq = KQ_Theo_TcBLL.Get(x => x.Mssv.Trim() == txtMssvThem_Sua.Text.Trim() && x.MaTieuChi.Trim() == cbTCThem_Sua.SelectedValue.ToString() && x.MaThoiGian == Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString()));
                        if (Int32.Parse(txtTDBBThem_Sua.Text) > 7)
                        {
                            txtTDBBThem_Sua.Text = "";
                            MessageBox.Show("Số tiến độ không được vượt quá 7");
                        }
                        else
                        {
                            kq.TienDoHDBatBuoc = Convert.ToInt16(txtTDBBThem_Sua.Text);
                            kq.TienDoHDKhac = Convert.ToBoolean(cbTDHDKThem_Sua.Text);
                            kq.DanhGia = Convert.ToInt32(cbDanhGia_TS.SelectedValue);
                            KQ_Theo_TcBLL.Edit(kq);
                            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnXThemKQ_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
            btnLuuKQ.Visible = false;
            showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        void loadcbFillterTG()
        {
            cbFillterThoiGian.DataSource = new BindingSource(KQ_Theo_TcBLL.showTime(), null);
            cbFillterThoiGian.DisplayMember = "Value";
            cbFillterThoiGian.ValueMember = "Key";
        }
        void loadcbDanhGia_TS()
        {
            cbDanhGia_TS.DataSource = new BindingSource(KQ_Theo_TcBLL.ShowDanhGia(), null);
            cbDanhGia_TS.DisplayMember = "Value";
            cbDanhGia_TS.ValueMember = "Key";
        }

        void loadTDHDK()
        {
            cbTDHDKThem_Sua.Items.Clear();
            cbTDHDKThem_Sua.Items.Add("True");
            cbTDHDKThem_Sua.Items.Add("False");
            cbTDHDKThem_Sua.Text = "True";
        }

        private void btnSuaTC_Click(object sender, EventArgs e)
        {
            Edit_Tieu_Chi UC = new Edit_Tieu_Chi();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(170, 48);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<Kq_Theo_tcDTO>();
                    listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.ThoiGian.Contains(cbFillterThoiGian.Text) && x.DonVi.Contains(cbFillter_DV.Text) && x.TenTieuChi.Contains(cbFillterTC.Text)).ToList();
                    dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listfillter = new List<Kq_Theo_tcDTO>();
                    listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.HoTen.Contains(txtSearch.Text)).ToList();
                    dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.KQ_THEO_TIEUCHI.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = KQ_Theo_TcBLL.DsKQ().Where(x => x.ThoiGian.Contains(cbFillterThoiGian.Text) && x.DonVi.Contains(cbFillter_DV.Text) && x.TenTieuChi.Contains(cbFillterTC.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<Kq_Theo_tcDTO>();
                    listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.ThoiGian.Contains(cbFillterThoiGian.Text) && x.DonVi.Contains(cbFillter_DV.Text) && x.TenTieuChi.Contains(cbFillterTC.Text)).ToList();
                    dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 2)
            {
                int totlalrecord = 0;
                totlalrecord = KQ_Theo_TcBLL.DsKQ().Where(x => x.HoTen.Contains(txtSearch.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<Kq_Theo_tcDTO>();
                    listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.HoTen.Contains(txtSearch.Text)).ToList();
                    dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }
        void loadcbThoigian_TS()
        {
            cbThoiGianThem_Sua.DataSource = new BindingSource(KQ_Theo_TcBLL.showTime(), null);
            cbThoiGianThem_Sua.DisplayMember = "Value";
            cbThoiGianThem_Sua.ValueMember = "Key";
        }
        void loadcbThoiGian_Xem()
        {
            cbThoiGian_Xem.DataSource = new BindingSource(KQ_Theo_TcBLL.showTime(), null);
            cbThoiGian_Xem.DisplayMember = "Value";
            cbThoiGian_Xem.ValueMember = "Key";
        }
        void loadcbTC_TS()
        {
            cbTCThem_Sua.DataSource = KQ_Theo_TcBLL.dstieuchi();
            cbTCThem_Sua.DisplayMember = "TenTieuChi";
            cbTCThem_Sua.ValueMember = "MaTieuChi";
        }
        void loadcbFiiter_DV()
        {
            cbFillter_DV.DataSource = KQ_Theo_TcBLL.dsdonvi();
            cbFillter_DV.DisplayMember = "MaDonVi";
            cbFillter_DV.ValueMember = "MaDonVi";
        }
        private void txtMssvThem_Sua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        private void txtTDBBThem_Sua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Bạn chỉ được nhập kí tự số !!!");
            }
        }

        

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listfillter = new List<Kq_Theo_tcDTO>();
            listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.ThoiGian.Contains(cbFillterThoiGian.Text) && x.DonVi.Contains(cbFillter_DV.Text) && x.TenTieuChi.Contains(cbFillterTC.Text)).ToList();
            dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_KQTTC.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listfillter = new List<Kq_Theo_tcDTO>();
                listfillter = KQ_Theo_TcBLL.DsKQ().Where(x => x.HoTen.Contains(txtSearch.Text)).ToList();
                dtgv_KQTTC.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                flagDT = 2;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }           
        }
        void TXTSEARCH()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(KQ_Theo_TcBLL.dssinhvien().Select(x => x.HoTen).ToArray());
        }
        void SuggestTxtMssv()
        {
            txtMssvThem_Sua.AutoCompleteCustomSource.AddRange(KQ_Theo_TcBLL.dssinhvien().Select(x => x.Mssv).ToArray());
        }

        private void btnXKQ_TS_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
            btnLuuKQ.Visible = false;
            showKQ(KQ_Theo_TcBLL.DsKQ().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void maxlength()
        {
            txtMssvThem_Sua.MaxLength = 11;
            txtTDBBThem_Sua.MaxLength = 3;

        }

        private void cbTDHDKThem_Sua_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
