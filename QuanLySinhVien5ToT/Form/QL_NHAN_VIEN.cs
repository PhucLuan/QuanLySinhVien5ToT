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
        List<ThongTinPQ_DTO> listPQ_SV = Login.listPQ;
        private void QL_NHAN_VIEN_Load(object sender, EventArgs e)
        {
            loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbRole();
            TXTSEARCH();
            maxlength();
            loadcbDV();
            loadPQ();
        }
        void loadPQ()
        {
            if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
            {
                cbDonVi.Enabled = false;
                dtgv_NV.ReadOnly = true;
                cbDonVi.Text = listPQ_SV.Select(x => x.DonVi).ToArray().First().ToString();
                btnThemNV.Enabled = false;
            }
            else
            {
                btnThemNV.Enabled = true;
                cbDonVi.Enabled = true;
                dtgv_NV.ReadOnly = true;
            }
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
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtXacNhan.Text = "";

            txtUsername.BorderColor = Color.FromArgb(213, 218, 223);
            txtUsername.PlaceholderText = "";

            txtPassword.BorderColor = Color.FromArgb(213, 218, 223);
            txtPassword.PlaceholderText = "";

            txtXacNhan.BorderColor = Color.FromArgb(213, 218, 223);
            txtXacNhan.PlaceholderText = "";

        }
        void laodbtnSua()
        {
            pn_Them_NV.Visible = true;
            btnLuuNV.Visible = true;
            pn_User.Visible = false;
            dtgv_NV.Width = 651;
            lbTD.Text = "Sửa Nhân Viên";
            txtIDnv.Enabled = false;
            
            txtIDnv.Enabled = false;
        }
        private void dtgv_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dtgv_NV.Rows[e.RowIndex];
            string name = dtgv_NV.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {
                if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
                {
                    if (row.Cells["DonVi"].Value.ToString() == listPQ_SV.Select(x => x.DonVi).ToArray().First())
                    {
                        laodbtnSua();
                        flagLuu = 1;
                        binding();
                        DesignbtnTT();
                    }
                    else
                    {
                        MessageBox.Show("bạn không được quyền sửa");
                    }
                }
                else
                {
                    laodbtnSua();
                    flagLuu = 1;
                    binding();
                    DesignbtnTT();
                }
                
                flagLuu = 1;
                
            }
        }
        void DesignbtnTT()
        {
            txtEmail_TS.BorderColor = Color.FromArgb(213, 218, 223);
            txtEmail_TS.PlaceholderText = "";

            txtTenNV_TS.BorderColor = Color.FromArgb(213, 218, 223);
            txtTenNV_TS.PlaceholderText = "";
        }
        private void btnXThemNV_Click(object sender, EventArgs e)
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = false;
            dtgv_NV.Width = 996;
            loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void loadbtnluu()
        {
            pn_Them_NV.Visible = false;
            btnLuuNV.Visible = false;
            pn_User.Visible = false;
            dtgv_NV.Width = 996;
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
            if (flagLuu == 0)
            {
                NHANVIEN nv = QL_NhanVienBLL.Get(x => x.Name==txtTenNV_TS.Text || x.Email==txtEmail_TS.Text);
                if (nv == null)
                {
                    nv = new NHANVIEN();
                    nv.Email = txtEmail_TS.Text.Trim();
                    nv.Name = txtTenNV_TS.Text.Trim();
                    nv.DonVi = cbDonVi.Text;
                    List<USER> us = db.USERs.ToList();
                    int iduser = us.Last().IDuser;
                    nv.IDuser = iduser;
                    QL_NhanVienBLL.Add(nv);
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    loadbtnluu();
                }
                else
                {
                    MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadbtnTT();
                    DesignbtnTT();
                }               
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
                    loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    loadbtnluu();
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadbtnTT();
                    DesignbtnTT();
                }              
            }
        }
        void loadbtnTT()
        {
            pn_Them_NV.Visible = true;
            btnLuuNV.Visible = true;
            pn_User.Visible = false;
            dtgv_NV.Width = 651;
            txtIDnv.Enabled = false;
            txtEmail_TS.Text = "";
            txtTenNV_TS.Text = "";
            lbTD.Text = "Thêm Nhân Viên";
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
                loadbtnTT();
                DesignbtnTT();
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
                        MessageBox.Show("xác nhận mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnThemNV_Click(sender, e);                    
                    }
                }
                else
                {
                    MessageBox.Show("Username hoặc passwwork của bạn đã bị trùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnThemNV_Click(sender, e);
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
            if (flagDT == 0)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                if (pagenumber - 1 > 0)
                {
                    pagenumber--;
                    var listsearch = new List<NhanVienDTO>();
                    listsearch = QL_NhanVienBLL.dsnhanvien().Where(x => x.Name.Contains(txtSearch.Text.Trim())).ToList();
                    dtgv_NV.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.NHANVIENs.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    loadNV(QL_NhanVienBLL.dsnhanvien().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 1)
            {
                int totlalrecord = 0;
                totlalrecord = QL_NhanVienBLL.dsnhanvien().Where(x => x.Name.Contains(txtSearch.Text.Trim())).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listsearch = new List<NhanVienDTO>();
                    listsearch = QL_NhanVienBLL.dsnhanvien().Where(x => x.Name.Contains(txtSearch.Text.Trim())).ToList();
                    dtgv_NV.DataSource = listsearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
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
                flagDT = 1;
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
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

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
                txtUsername.BorderColor = Color.Red;
            else
                txtUsername.BorderColor = Color.FromArgb(226, 226, 226);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                txtPassword.BorderColor = Color.Red;
            else
                txtPassword.BorderColor = Color.FromArgb(226, 226, 226);
        }

        private void txtXacNhan_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtXacNhan.Text.Trim()))
                txtXacNhan.BorderColor = Color.Red;
            else
                txtXacNhan.BorderColor = Color.FromArgb(226, 226, 226);
        }      

        private void txtTenNV_TS_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNV_TS.Text.Trim()))
                txtTenNV_TS.BorderColor = Color.Red;
            else
                txtTenNV_TS.BorderColor = Color.FromArgb(226, 226, 226);
        }

        private void txtEmail_TS_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail_TS.Text.Trim()))
                txtEmail_TS.BorderColor = Color.Red;
            else
                txtEmail_TS.BorderColor = Color.FromArgb(226, 226, 226);
        }
    }
}
