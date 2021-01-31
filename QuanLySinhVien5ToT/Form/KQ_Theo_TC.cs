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
            }
            if (name == "Sua")
            {
                pn_XemChiTiet.Visible = false;
                pn_Them_SuaKQ.Visible = true;
                dtgv_KQTTC.Width = 674;
                btnLuuKQ.Visible = true;
                flagLuu = 1;
                binding();
            }

            MessageBox.Show(KQ_Theo_TcBLL
                .GetIdFormattedDateTime(dtgv_KQTTC.Rows[e.RowIndex].Cells[8].Value.ToString()));

            //DataGridViewRow row = this.dtgv_KQTTC.Rows[e.RowIndex];
            //txtMssvThem_Sua.Text = row.Cells["Mssv"].Value.ToString();
            //cbTCThem_Sua.Text= row.Cells["TieuChi"].Value.ToString();
            //cbThoiGianThem_Sua.Text= row.Cells["MaThoiGian"].Selected.ToString();
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
        }

        private void btnLuuKQ_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
            btnLuuKQ.Visible = false;
            if (flagLuu == 0)
            {
                KQ_THEO_TIEUCHI kq = KQ_Theo_TcBLL.Get(x => x.Mssv.Trim() == txtMssvThem_Sua.Text.Trim() && x.MaTieuChi.Trim()==cbTCThem_Sua.Text.Trim() && x.MaThoiGian==Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue));
                if (kq == null)
                {
                    kq = new KQ_THEO_TIEUCHI();
                    kq.Mssv = txtMssvThem_Sua.Text;
                    kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                    kq.MaThoiGian =Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());
                    if (txtMssvThem_Sua.Text.Trim() == "" || cbTCThem_Sua.Text.Trim() == "" || cbThoiGianThem_Sua.Text.Trim() == "")
                    {
                        MessageBox.Show("không được để trống dữ liệu");
                    }
                    else
                    {
                        kq.Mssv = txtMssvThem_Sua.Text;
                        kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                        kq.TienDoHDBatBuoc =Convert.ToInt16(txtTDBBThem_Sua.Text);
                        kq.TienDoHDKhac = Convert.ToBoolean(txtTDHDKThem_Sua.Text);
                        kq.MaThoiGian= Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());



                        KQ_Theo_TcBLL.Add(kq);
                        MessageBox.Show("Lưu Thành Công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã Số Sinh Viên Không Được Trùng!!!!!");
                }
                showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
            }
            else
            {
                
                KQ_THEO_TIEUCHI kq = KQ_Theo_TcBLL.Get(x => x.Mssv.Trim() == txtMssvThem_Sua.Text.Trim() && x.MaTieuChi.Trim() == cbTCThem_Sua.SelectedValue.ToString());
                //kq.Mssv = txtMssvThem_Sua.Text;
                //kq.MaTieuChi = cbTCThem_Sua.SelectedValue.ToString();
                kq.TienDoHDBatBuoc = Convert.ToInt16(txtTDBBThem_Sua.Text);
                kq.TienDoHDKhac = Convert.ToBoolean(txtTDHDKThem_Sua.Text);
                //kq.MaThoiGian = Convert.ToInt32(cbThoiGianThem_Sua.SelectedValue.ToString());

                KQ_Theo_TcBLL.Edit(kq);
                MessageBox.Show("Sửa Thành Công");
                showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
            }
        }

        private void btnXThemKQ_Click(object sender, EventArgs e)
        {
            pn_XemChiTiet.Visible = false;
            pn_Them_SuaKQ.Visible = false;
            dtgv_KQTTC.Width = 981;
            btnLuuKQ.Visible = false;
        }

        void loadcbFillterTG()
        {
            cbFillterThoiGian.DataSource = new BindingSource(KQ_Theo_TcBLL.showTime(),null);
            cbFillterThoiGian.DisplayMember="Value";
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
            totlalrecord = db.TIEU_CHUAN.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                showKQ(KQ_Theo_TcBLL.DsKQ(pagenumber, numberRecord));
            }
        }
        void loadcbThoigian_TS()
        {
            cbThoiGianThem_Sua.DataSource = KQ_Theo_TcBLL.dsthoigian();
            cbThoiGianThem_Sua.DisplayMember = "FullTime";
            cbThoiGianThem_Sua.ValueMember = "MaThoiGian";
        }
        void loadcbTC_TS()
        {
            cbTCThem_Sua.DataSource = KQ_Theo_TcBLL.dstieuchi();
            cbTCThem_Sua.DisplayMember = "TenTieuChi";
            cbTCThem_Sua.ValueMember = "MaTieuChi";
        }   
        void binding()
        {
            txtMssvThem_Sua.DataBindings.Clear();
            txtMssvThem_Sua.DataBindings.Add("Text", dtgv_KQTTC.DataSource, "Mssv");
            cbTCThem_Sua.DataBindings.Clear();
            cbTCThem_Sua.DataBindings.Add("Text", dtgv_KQTTC.DataSource, "TenTieuChi");
            txtTDBBThem_Sua.DataBindings.Clear();
            txtTDBBThem_Sua.DataBindings.Add("Text", dtgv_KQTTC.DataSource, "TienDoHDBatBuoc");
            txtTDHDKThem_Sua.DataBindings.Clear();
            txtTDHDKThem_Sua.DataBindings.Add("Text", dtgv_KQTTC.DataSource, "TienDoHDKhac");
            cbThoiGianThem_Sua.DataBindings.Clear();
            cbThoiGianThem_Sua.DataBindings.Add("Text", dtgv_KQTTC.DataSource, "ThoiGian");
        }
        
        

        
    }
}
