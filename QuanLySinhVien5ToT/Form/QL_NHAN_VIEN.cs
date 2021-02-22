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
    public partial class QL_NHAN_VIEN : UserControl
    {
        public QL_NHAN_VIEN()
        {
            InitializeComponent();
        }
        int pagenumber = 1;
        int numberRecord = 8;
        private int flagLuu = 0;
        private int flagDT = 0;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        QL_NhanVienBLL QL_NhanVienBLL = new QL_NhanVienBLL();
        private void QL_NHAN_VIEN_Load(object sender, EventArgs e)
        {
            loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbRole();
            TXTSEARCH();
            maxlength();
            loadcbDV();
        }
        void loadNV(List<NhanVienDTO> listNV)
        {
            dtgv_NV.DataSource = listNV;
            flagDT = 0;
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = true;
            dtgv_NV.Width = 651;
            flagLuu = 0;
            txtIDnv.Enabled = true ;

            txtUsername.BorderColor = Color.White;
            txtUsername.PlaceholderText = "";
            txtUsername.PlaceholderForeColor = Color.White;

            txtPassword.BorderColor = Color.White;
            txtPassword.PlaceholderText = "";
            txtPassword.PlaceholderForeColor = Color.White;

            txtXacNhan.BorderColor = Color.White;
            txtXacNhan.PlaceholderText = "";
            txtXacNhan.PlaceholderForeColor = Color.White;
        }

        private void dtgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_NV.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                pn_Them_NV.Visible = true;
                btnLuuNV.Visible = true;
                pn_User.Visible = false;
                dtgv_NV.Width = 651;
                lbTD.Text = "Sửa Nhân Viên";
                txtIDnv.Enabled = false;
                binding();
                flagLuu = 1;
                txtIDnv.Enabled = false;

                txtEmail_TS.BorderColor = Color.White;
                txtEmail_TS.PlaceholderText = "";
                txtEmail_TS.PlaceholderForeColor = Color.White;

                txtTenNV_TS.BorderColor = Color.White;
                txtTenNV_TS.PlaceholderText = "";
                txtTenNV_TS.PlaceholderForeColor = Color.White;
            }
        }

        private void btnXThemNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = false;
            dtgv_NV.Width = 996;
            loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            if(txtEmail_TS.Text=="" || txtTenNV_TS.Text == "")
            {
                if (string.IsNullOrEmpty(txtEmail_TS.Text.Trim()))
                {
                    txtEmail_TS.BorderColor = Color.Red;
                    txtEmail_TS.PlaceholderText = "bạn chưa nhập email";
                    txtEmail_TS.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtTenNV_TS.Text.Trim()))
                {
                    txtTenNV_TS.BorderColor = Color.Red;
                    txtTenNV_TS.PlaceholderText = "bạn chưa nhập tên";
                    txtTenNV_TS.PlaceholderForeColor = Color.Red;
                }
            }
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = false;
            dtgv_NV.Width = 996;
            if (flagLuu == 0)
            {
                NHANVIEN nv = QL_NhanVienBLL.Get(x => x.IDnv.ToString() == txtIDnv.Text.Trim());
                if (nv == null)
                {
                    nv = new NHANVIEN();
                    nv.Email = txtEmail_TS.Text;
                    nv.Name = txtTenNV_TS.Text;
                    nv.DonVi = cbDonVi.Text;
                    List<USER> us = db.USERs.ToList();
                    int iduser = us.Last().IDuser;
                    nv.IDuser = iduser;
                    QL_NhanVienBLL.Add(nv);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }
            else
            {
                try
                {
                    NHANVIEN nv = QL_NhanVienBLL.Get(x => x.IDnv.ToString() == txtIDnv.Text.Trim());

                    nv.Email = txtEmail_TS.Text;
                    nv.Name = txtTenNV_TS.Text;
                    nv.DonVi = cbDonVi.Text;

                    QL_NhanVienBLL.Edit(nv);
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            }
        }

        private void btnTiepTheo_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtXacNhan.Text == "")
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                {
                    txtUsername.BorderColor = Color.Red;
                    txtUsername.PlaceholderText = "bạn chưa nhập username";
                    txtUsername.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                {
                    txtPassword.BorderColor = Color.Red;
                    txtPassword.PlaceholderText = "bạn chưa nhập password";
                    txtPassword.PlaceholderForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(txtXacNhan.Text.Trim()))
                {
                    txtXacNhan.BorderColor = Color.Red;
                    txtXacNhan.PlaceholderText = "bạn chưa xác nhận password";
                    txtXacNhan.PlaceholderForeColor = Color.Red;
                }
            }
            else
            {
                pn_Them_NV.Visible = true;
                btnLuuNV.Visible = true;
                pn_User.Visible = false;
                dtgv_NV.Width = 651;
                txtIDnv.Enabled = false;
                lbTD.Text = "Thêm Nhân Viên";

                txtEmail_TS.BorderColor = Color.White;
                txtEmail_TS.PlaceholderText = "";
                txtEmail_TS.PlaceholderForeColor = Color.White;

                txtTenNV_TS.BorderColor = Color.White;
                txtTenNV_TS.PlaceholderText = "";
                txtTenNV_TS.PlaceholderForeColor = Color.White;

                USER us = QL_NhanVienBLL.GetUser(x => x.Username.Trim() == txtUsername.Text.Trim() || x.Password.Trim() == txtPassword.Text.Trim());
                if (us == null)
                {
                    
                    us = new USER();                    
                    if (txtPassword.Text == txtXacNhan.Text)
                    {
                        us.Username = txtUsername.Text;
                        us.Password = QL_NhanVienBLL.Mahoa(txtPassword.Text);
                        us.IDrole = Convert.ToInt32(cbRole.SelectedValue.ToString());
                        QL_NhanVienBLL.AddUser(us);
                        MessageBox.Show("Thêm User thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        pn_Them_NV.Visible = false;
                        btnLuuNV.Visible = false;
                        pn_User.Visible = true;
                        dtgv_NV.Width = 651;
                        cbRole.Enabled = false;
                        MessageBox.Show("xác nhận mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtXacNhan.Text = "";                     
                    }
                }
                else
                {
                    MessageBox.Show("Username hoặc passwwork của bạn đã bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pn_Them_NV.Visible = false;
                    btnLuuNV.Visible = false;
                    pn_User.Visible = true;
                    dtgv_NV.Width = 651;
                    txtIDnv.Enabled = true;
                }

            }
        }

        private void btnXUser_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = false;
            dtgv_NV.Width = 996;
        }
        void loadcbRole()
        {
            cbRole.DataSource = QL_NhanVienBLL.dsRole();
            cbRole.DisplayMember = "Role";
            cbRole.ValueMember = "IDrole";
            cbRole.Text = "user";
        }
        void loadcbDV()
        {
            cbDonVi.DataSource = QL_NhanVienBLL.dsdonvi();
            cbDonVi.DisplayMember = "MaDonVi";
            cbDonVi.ValueMember = "MaDonVi";
        }
        void binding()
        {
            txtIDnv.DataBindings.Clear();
            txtIDnv.DataBindings.Add("Text", dtgv_NV.DataSource, "IDnv");
            txtEmail_TS.DataBindings.Clear();
            txtEmail_TS.DataBindings.Add("Text", dtgv_NV.DataSource, "Email");
            txtTenNV_TS.DataBindings.Clear();
            txtTenNV_TS.DataBindings.Add("Text", dtgv_NV.DataSource, "Name");
            cbDonVi.DataBindings.Clear();
            cbDonVi.DataBindings.Add("Text", dtgv_NV.DataSource, "DonVi");

        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int totlalrecord = 0;
            totlalrecord = db.NHANVIENs.Count();
            if (pagenumber - 1 < totlalrecord / numberRecord)
            {
                pagenumber++;
                loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listsearch = new List<NhanVienDTO>();
                listsearch = QL_NhanVienBLL.dsnhanvien().Where(x => x.Name.Contains(txtSearch.Text.Trim())).ToList();
                dtgv_NV.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            }
        }

        void TXTSEARCH()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(QL_NhanVienBLL.dsnhanvien().Select(x => x.Name).ToArray());
        }
        void maxlength()
        {
            txtUsername.MaxLength = 50;
            txtPassword.MaxLength = 50;
            txtEmail_TS.MaxLength = 100;
            txtTenNV_TS.MaxLength = 100;
            txtXacNhan.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(QL_NhanVienBLL.Mahoa(txtPassword.Text));
        }
    }
}
