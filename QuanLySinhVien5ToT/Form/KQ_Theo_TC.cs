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
            showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));

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
                pn_XemChiTiet.Enabled = false;
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
                txtTDHDKThem_Sua.BorderColor = Color.White;
                txtTDHDKThem_Sua.PlaceholderText = "";
                txtTDHDKThem_Sua.PlaceholderForeColor = Color.White;
            }

            DataGridViewRow row = this.dtgv_KQTTC.Rows[e.RowIndex];
            txtMssvThem_Sua.Text = row.Cells["Mssv"].Value.ToString();
            cbTCThem_Sua.Text = row.Cells["TieuChi"].Value.ToString();
            txtTDBBThem_Sua.Text = row.Cells["TienDoHDBB"].Value.ToString();
            txtTDHDKThem_Sua.Text = row.Cells["TienDoHDKhac"].Value.ToString();
            cbThoiGianThem_Sua.SelectedValue = KQ_Theo_TcBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());

            txtTenSinhVien.Text = row.Cells["TenSinhVien"].Value.ToString();
            txtTieuChi_Xem.Text = row.Cells["TieuChi"].Value.ToString();
            txtTDBB_Xem.Text = row.Cells["TienDoHDBB"].Value.ToString();
            txtTDHDK_Xem.Text = row.Cells["TienDoHDKhac"].Value.ToString();
            cbThoiGian_Xem.SelectedValue = KQ_Theo_TcBLL.GetIdFormattedDateTime(row.Cells["ThoiGian"].Value.ToString());
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
            txtTDHDKThem_Sua.Text = "";
            txtMssvThem_Sua.Enabled = true;
            cbThoiGianThem_Sua.Enabled = true;
            cbTCThem_Sua.Enabled = true;

            txtMssvThem_Sua.BorderColor = Color.White;
            txtMssvThem_Sua.PlaceholderText = "";
            txtMssvThem_Sua.PlaceholderForeColor = Color.White;
            txtTDBBThem_Sua.BorderColor = Color.White;
            txtTDBBThem_Sua.PlaceholderText = "";
            txtTDBBThem_Sua.PlaceholderForeColor = Color.White;
            txtTDHDKThem_Sua.BorderColor = Color.White;
            txtTDHDKThem_Sua.PlaceholderText = "";
            txtTDHDKThem_Sua.PlaceholderForeColor = Color.White;
        }

        private void btnLuuKQ_Click(object sender, EventArgs e)
        {
            if (txtMssvThem_Sua.Text == "" || txtTDHDKThem_Sua.Text == "" || txtTDBBThem_Sua.Text == "")
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
                if (string.IsNullOrEmpty(txtTDHDKThem_Sua.Text.Trim()))
                {
                    txtTDHDKThem_Sua.BorderColor = Color.Red;
                    txtTDHDKThem_Sua.PlaceholderText = "bạn chưa nhập TDHDK";
                    txtTDHDKThem_Sua.PlaceholderForeColor = Color.Red;
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
                        kq.Mssv = txtMssvThem_Sua.Text;
                        kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                        kq.MaThoiGian = Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());
                        //kq.Mssv = txtMssvThem_Sua.Text;
                        //kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                        if (Convert.ToInt32(txtTDBBThem_Sua.Text) > 7)
                        {
                            txtTDBBThem_Sua.Text = "";
                            MessageBox.Show("Số tiến độ không được vượt quá 7");
                        }
                        else
                        {
                            kq.TienDoHDBatBuoc = Convert.ToInt16(txtTDBBThem_Sua.Text);
                            kq.TienDoHDKhac = Convert.ToBoolean(txtTDHDKThem_Sua.Text);
                            //kq.MaThoiGian = Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());
                            KQ_Theo_TcBLL.Add(kq);
                            MessageBox.Show("Lưu Thành Công");
                        }

                    }
                    else
                    {
                        MessageBox.Show("dữ liệu thêm đã bị trùng");
                    }
                    showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
                }
                else
                {

                    KQ_THEO_TIEUCHI kq = KQ_Theo_TcBLL.Get(x => x.Mssv.Trim() == txtMssvThem_Sua.Text.Trim() && x.MaTieuChi.Trim() == cbTCThem_Sua.SelectedValue.ToString() && x.MaThoiGian == Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString()));
                    //kq.Mssv = txtMssvThem_Sua.Text;
                    //kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                    if (Int32.Parse(txtTDBBThem_Sua.Text) > 7)
                    {
                        txtTDBBThem_Sua.Text = "";
                        MessageBox.Show("Số tiến độ không được vượt quá 7");
                    }
                    else
                    {
                        kq.TienDoHDBatBuoc = Convert.ToInt16(txtTDBBThem_Sua.Text);
                        kq.TienDoHDKhac = Convert.ToBoolean(txtTDHDKThem_Sua.Text);
                        //kq.MaThoiGian = Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());

                        KQ_Theo_TcBLL.Edit(kq);
                        MessageBox.Show("Sửa Thành Công");
                    }

                    showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
                }
            }

        }

        private void btnXThemKQ_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
            btnLuuKQ.Visible = false;
            showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
        }

        void loadcbFillterTG()
        {
            cbFillterThoiGian.DataSource = new BindingSource(KQ_Theo_TcBLL.showTime(), null);
            cbFillterThoiGian.DisplayMember = "Value";
            cbFillterThoiGian.ValueMember = "Key";
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
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.KQ_THEO_TIEUCHI.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
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
    }
}
