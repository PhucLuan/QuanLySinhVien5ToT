﻿using System;
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
    public partial class Edit_TGX : UserControl
    {
        public Edit_TGX()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 5;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        ThoiGianXetBLL thoiGianXetBLL = new ThoiGianXetBLL();
        private void Edit_TGX_Load(object sender, EventArgs e)
        {
            loadthoigian(thoiGianXetBLL.dsthoigian().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void loadthoigian (List<Thoi_Gian_XetDTO> listtime)
        {
            dtgvTG.DataSource = listtime;
            loadcbTrangThai();
        }
        private void btnThemTG_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = true;
            btnLuuTime.Visible = true;
            lbTieuDe.Text = "Thêm Thời Gian Xét";
            dtgvTG.Width = 449;
            flagLuu=0;
            txtMaTG.Text = "";
            dtpkTu.Value = DateTime.Now;
            dtpkDen.Value = DateTime.Now;
            cbTrangThai.Enabled = false;
            txtMaTG.Enabled = false;
        }

        private void dtgvTG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgvTG.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_ThemXoaSua.Visible = true;
                btnLuuTime.Visible = true;
                lbTieuDe.Text = "Sửa Thời Gian Xét";
                dtgvTG.Width = 449;
                flagLuu = 1;
                binding();
                txtMaTG.Enabled = false;
                cbTrangThai.Enabled = true;
            }
        }

        private void btnLuuTime_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = false;
            dtgvTG.Width = 746;
            if (flagLuu == 0)
            {
                THOIGIAN_XET tg = thoiGianXetBLL.Get(x => x.MaThoiGian.ToString() ==txtMaTG.Text.Trim());
                if (tg == null)
                {                  
                    tg = new THOIGIAN_XET();
                    //tg.MaThoiGian = Convert.ToInt32(txtMaTG.Text);
                    tg.TuNgay = dtpkTu.Value;
                    tg.DenNgay = dtpkDen.Value;
                    tg.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                    thoiGianXetBLL.Add(tg);
                }
                else
                {
                    MessageBox.Show("dữ liệu thêm bị trùng!!!");
                }
                loadthoigian(thoiGianXetBLL.dsthoigian().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }
            else
            {
                THOIGIAN_XET tg = thoiGianXetBLL.Get(x => x.MaThoiGian == Convert.ToInt32(txtMaTG.Text.Trim()));

                tg.TuNgay = dtpkTu.Value;
                tg.DenNgay = dtpkDen.Value;
                if (cbTrangThai.Text == "True")
                {
                    THOIGIAN_XET tgx = thoiGianXetBLL.Get(x => x.TrangThai == Convert.ToBoolean("True"));
                    tgx.TrangThai = Convert.ToBoolean("False");
                    thoiGianXetBLL.Edit(tgx);
                    tg.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                    thoiGianXetBLL.Edit(tg);
                }
                else
                {
                    tg.TrangThai = Convert.ToBoolean(cbTrangThai.Text);
                    thoiGianXetBLL.Edit(tg);
                }
                

                MessageBox.Show("Sửa Thành Công");
                loadthoigian(thoiGianXetBLL.dsthoigian().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }

        }

        private void btnXTime_Click(object sender, EventArgs e)
        {
            pn_ThemXoaSua.Visible = false;
            dtgvTG.Width = 746;
        }

        private void btnXEdit_TG_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void loadcbTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("True");
            cbTrangThai.Items.Add("False");
            cbTrangThai.Text = "False";
        }
        void binding()
        {
            txtMaTG.DataBindings.Clear();
            txtMaTG.DataBindings.Add("Text", dtgvTG.DataSource, "MaThoiGian");
            dtpkTu.DataBindings.Clear();
            dtpkTu.DataBindings.Add("Text", dtgvTG.DataSource, "TuNgay");
            dtpkDen.DataBindings.Clear();
            dtpkDen.DataBindings.Add("Text", dtgvTG.DataSource, "DenNgay");
            cbTrangThai.DataBindings.Clear();
            cbTrangThai.DataBindings.Add("Text", dtgvTG.DataSource, "TrangThai");
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                loadthoigian(thoiGianXetBLL.dsthoigian().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.THOIGIAN_XET.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                loadthoigian(thoiGianXetBLL.dsthoigian().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }

        
    }
}
