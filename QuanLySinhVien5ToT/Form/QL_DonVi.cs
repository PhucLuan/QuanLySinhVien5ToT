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
                Binding();
                flagLuu = 1;

            }
            if (name == "Xoa")
            {
                DON_VI nv = Mydb.GetInstance().DON_VI.Where(p => p.MaDonVi == txtMaDV.Text.Trim()).SingleOrDefault();
                ShowDonVi(QL_DV_BLL.dsDonVi());

            }
        }

        private void btnLuuDV_Click(object sender, EventArgs e)
        {
            dtgv_DV.Width = 985;
            pn_ThemSua_DV.Visible = false;
            btnLuuDV.Visible = false;
            if (flagLuu == 0)
            {
                DON_VI donvi = QL_DV_BLL.Get(x => x.MaDonVi.Trim() == txtMaDV.Text.Trim());
                if (donvi == null)
                {
                    donvi = new DON_VI();
                    donvi.MaDonVi = txtMaDV.Text;
                    if (txtMaDV.Text.Trim() == "")
                    {
                        MessageBox.Show("Mã Số Sinh Viên Không được để trống");
                    }
                    else
                    {
                        donvi.MaDonVi = txtMaDV.Text;
                        donvi.TenDonVi = txtTenDV.Text;


                        QL_DV_BLL.Add(donvi);
                        MessageBox.Show("Lưu Thành Công");
                    }
                }
                else
                {
                    MessageBox.Show("Mã Số Sinh Viên Không Được Trùng!!!!!");
                }
                ShowDonVi(QL_DV_BLL.dsDonVi());
            }
            else 
            {
                DON_VI dv = QL_DV_BLL.Get(x => x.MaDonVi.Trim() == txtMaDV.Text.Trim());

                dv.TenDonVi = txtTenDV.Text.Trim();
                QL_DV_BLL.Edit(dv);

                MessageBox.Show("Sửa Thành Công");
                ShowDonVi(QL_DV_BLL.dsDonVi());
            }
        }

        private void btnX_DV_Click(object sender, EventArgs e)
        {
            dtgv_DV.Width = 985;
            pn_ThemSua_DV.Visible = false;
            btnLuuDV.Visible = false;
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
    }
}
