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
    public partial class Edit_Tieu_Chi : UserControl
    {

        public Edit_Tieu_Chi()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 5;
        private int flagLuu = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        EditTieuChiBLL editTieuChiBLL = new EditTieuChiBLL();
        private void Edit_Tieu_Chi_Load(object sender, EventArgs e)
        {
            loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void loadTC(List<Tieu_ChiDTO> listTC)
        {
            dtgv_TC.DataSource = listTC;
            flagLuu = 0;
        }

        private void btnThemTC_Click(object sender, EventArgs e)
        {
            pn_ThemTieuChi.Visible = true;
            btnLuuTC.Visible = true;
            dtgv_TC.Width = 352;
            lbTC.Text = "Thêm Tiêu Chí";
            txtMaTieuChi.Text = "";
            txtTenTC.Text = "";
            btnThemTC.Enabled = true;
            txtMaTieuChi.BorderColor = Color.FromArgb(213, 218, 223);
            txtMaTieuChi.PlaceholderText = "";
            txtMaTieuChi.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
            txtTenTC.BorderColor = Color.FromArgb(213, 218, 223);
            txtTenTC.PlaceholderText = "";
            txtTenTC.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
        }

        private void dtgv_TC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_TC.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_ThemTieuChi.Visible = true;
                btnLuuTC.Visible = true;
                dtgv_TC.Width = 352;
                lbTC.Text = "Sửa Tiêu Chí";
                txtMaTieuChi.Enabled = false;
                btnThemTC.Enabled = false;
                binding();
                flagLuu = 1;

                txtMaTieuChi.BorderColor = Color.FromArgb(213, 218, 223);
                txtMaTieuChi.PlaceholderText = "";
                txtMaTieuChi.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
                txtTenTC.BorderColor = Color.FromArgb(213, 218, 223);
                txtTenTC.PlaceholderText = "";
                txtTenTC.PlaceholderForeColor = Color.FromArgb(213, 218, 223);
            }
        }

        private void btnX_TC_Click(object sender, EventArgs e)
        {
            pn_ThemTieuChi.Visible = false;
            btnLuuTC.Visible = false;
            dtgv_TC.Width = 659;
            btnThemTC.Enabled = true;
            loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        private void btnLuuTC_Click(object sender, EventArgs e)
        {
            
            if (txtMaTieuChi.Text == "" || txtTenTC.Text=="")
            {
                if (string.IsNullOrEmpty(txtMaTieuChi.Text.Trim()))
                {
                    txtMaTieuChi.BorderColor = Color.Red;
                    txtMaTieuChi.PlaceholderText = "bạn chưa nhập mã tiêu chí";
                    txtMaTieuChi.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtTenTC.Text.Trim()))
                {
                    txtTenTC.BorderColor = Color.Red;
                    txtTenTC.PlaceholderText = "bạn chưa nhập tên tiêu chí";
                    txtTenTC.PlaceholderForeColor = Color.Red;
                }
            }
            else
            {
                pn_ThemTieuChi.Visible = false;
                btnLuuTC.Visible = false;
                dtgv_TC.Width = 659;
                if (flagLuu == 0)
                {

                    TIEU_CHI tc = editTieuChiBLL.Get(x => x.MaTieuChi.ToString() == txtMaTieuChi.Text.Trim());
                    if (tc == null)
                    {
                        tc = new TIEU_CHI();
                        tc.MaTieuChi = txtMaTieuChi.Text;
                        tc.TenTieuChi = txtTenTC.Text;
                        btnThemTC.Enabled = true;
                        editTieuChiBLL.Add(tc);
                        MessageBox.Show("Thêm Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                        btnThemTC.Enabled = true;
                    }
                    loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
                else
                {
                    try
                    {
                        TIEU_CHI tc = editTieuChiBLL.Get(x => x.MaTieuChi.ToString() == txtMaTieuChi.Text.Trim());

                        tc.TenTieuChi = txtTenTC.Text;
                        btnThemTC.Enabled = true;
                        editTieuChiBLL.Edit(tc);
                        MessageBox.Show("Sửa Thành Công");
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại");
                        btnThemTC.Enabled = true;
                    }
                    loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                }
            }
        }

        private void btnXForm_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        void binding()
        {
            txtMaTieuChi.DataBindings.Clear();
            txtMaTieuChi.DataBindings.Add("Text", dtgv_TC.DataSource, "MaTieuChi");
            txtTenTC.DataBindings.Clear();
            txtTenTC.DataBindings.Add("Text", dtgv_TC.DataSource, "TenTieuChi");
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.TIEU_CHI.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                loadTC(editTieuChiBLL.dstieuchi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());

            }
        }
    }
}
