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
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT;

namespace QuanLySinhVien5ToT
{
    public partial class QL_DonVi : UserControl
    {
        int pagenumber = 1;
        int numberRecord = 3;
        private int flagLuu = 0;
        public QL_DonVi()
        {
            InitializeComponent();
        }
        private void QL_DonVi_Load(object sender, EventArgs e)
        {
            ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            TXTSEARCH();
            maxlength();
        }
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QL_DV_BLL QL_DV_BLL = new QL_DV_BLL();

        void ShowDonVi(List<Don_ViDTO> listdv)
        {
            dtgv_DV.DataSource = listdv;
        }
        private void btnThemDV_Click(object sender, EventArgs e)
        {
            dtgv_DV.Width = 646;
            pn_ThemSua_DV.Visible = true;
            btnLuuDV.Visible = true;
            lbTieuDe.Text = "Thêm Đơn Vị";
            flagLuu = 0;
            txtTenDV.Text = "";
            txtMaDV.Text = "";
            txtMaDV.Enabled = true;
            dessignbtn();            
        }

        private void dtgv_DV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_DV.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                dtgv_DV.Width = 646;
                pn_ThemSua_DV.Visible = true;
                btnLuuDV.Visible = true;
                lbTieuDe.Text = "Sửa Đơn Vị";
                btnThemDV.Enabled = false;
                txtMaDV.Enabled = false;
                Binding();
                dessignbtn();
                flagLuu = 1;               

            }
            if (name == "Xoa")
            {
                DON_VI nv = Mydb.GetInstance().DON_VI.Where(p => p.MaDonVi == txtMaDV.Text.Trim()).SingleOrDefault();
                ShowDonVi(QL_DV_BLL.dsDonVi());

            }
        }
        void dessignbtn()
        {
            txtMaDV.BorderColor = Color.FromArgb(226, 226, 226);
            txtMaDV.PlaceholderText = "";

            txtTenDV.BorderColor = Color.FromArgb(226, 226, 226);
            txtTenDV.PlaceholderText = "";
        }
        void loadbtnluu()
        {
            dtgv_DV.Width = 985;
            pn_ThemSua_DV.Visible = false;
            btnLuuDV.Visible = false;
        }
        private void btnLuuDV_Click(object sender, EventArgs e)
        {
            if(txtMaDV.Text=="" || txtTenDV.Text == "")
            {
                if (string.IsNullOrEmpty(txtMaDV.Text.Trim()))
                {
                    txtMaDV.BorderColor = Color.Red;
                    txtMaDV.PlaceholderText = "bạn chưa nhập mã đơn vị";
                    txtMaDV.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtTenDV.Text.Trim()))
                {
                    txtTenDV.BorderColor = Color.Red;
                    txtTenDV.PlaceholderText = "bạn chưa nhập tên đơn vị";
                    txtTenDV.PlaceholderForeColor = Color.Red;
                }
            }
            else
            {
                
                if (flagLuu == 0)
                {
                    DON_VI donvi = QL_DV_BLL.Get(x => x.MaDonVi.Trim() == txtMaDV.Text.Trim());
                    if (donvi == null)
                    {
                        donvi = new DON_VI();
                        donvi.MaDonVi = txtMaDV.Text;
                        donvi.TenDonVi = txtTenDV.Text;
                        btnThemDV.Enabled = true;
                        QL_DV_BLL.Add(donvi);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        txtMaDV.ReadOnly = false;
                        loadbtnluu();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemDV.Enabled = true;
                    }
                    
                }
                else
                {
                    try
                    {
                        DON_VI dv = QL_DV_BLL.Get(x => x.MaDonVi.Trim() == txtMaDV.Text.Trim());

                        dv.TenDonVi = txtTenDV.Text.Trim();
                        QL_DV_BLL.Edit(dv);
                        btnThemDV.Enabled = true;
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                        txtMaDV.ReadOnly = false;
                        loadbtnluu();
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemDV.Enabled = true;
                    }
                }
            }
            
        }

        private void btnX_DV_Click(object sender, EventArgs e)
        {
            dtgv_DV.Width = 985;
            pn_ThemSua_DV.Visible = false;
            btnLuuDV.Visible = false;
            btnThemDV.Enabled = true;
            ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        private void txtSearch_DV_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtSearch_DV.Text.Trim()))
            {
                ShowDonVi(QL_DV_BLL.dsDonVi());
            }
            else
            {
                dtgv_DV.DataSource = QL_DV_BLL.searchdv(txtSearch_DV.Text.Trim());
            }
        }
        void Binding()
        {
            txtMaDV.DataBindings.Clear();
            txtMaDV.DataBindings.Add("Text", dtgv_DV.DataSource, "MaDonVi");
            txtTenDV.DataBindings.Clear();
            txtTenDV.DataBindings.Add("Text", dtgv_DV.DataSource, "TenDonVi");
        }

        private void txtMaDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !((e.KeyChar >= 65 && e.KeyChar <= 122) || (e.KeyChar == 8));
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.LOAI_DIEM.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                ShowDonVi(QL_DV_BLL.dsDonVi().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }
        void TXTSEARCH()
        {
            txtSearch_DV.AutoCompleteCustomSource.AddRange(QL_DV_BLL.dsDonVi().Select(x => x.TenDonVi).ToArray());
        }
        void maxlength()
        {
            txtMaDV.MaxLength = 15;
            txtTenDV.MaxLength = 100;
        }

        private void txtMaDV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDV.Text.Trim()))
                txtMaDV.BorderColor = Color.Red;
            else
                txtMaDV.BorderColor = Color.FromArgb(226, 226, 226);
        }

        private void txtTenDV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDV.Text.Trim()))
                txtTenDV.BorderColor = Color.Red;
            else
                txtTenDV.BorderColor = Color.FromArgb(226, 226, 226);
        }
    }
}
