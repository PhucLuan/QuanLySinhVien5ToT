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
    public partial class User_Role : UserControl
    {
        public User_Role()
        {
            InitializeComponent();
        }
        private int flagLuu = 0;
        private int flagDT = 0;
        int pagenumber = 1;
        int numberRecord = 8;
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        User_RoleBLL User_RoleBLL = new User_RoleBLL();
        private void User_Role_Load(object sender, EventArgs e)
        {
            loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            loadcbRole();
            loadcbFillterRole();
            maxlength();
            SuggestTxtSearch();
        }

        void loaddsuser(List<UserDTO> listuser)
        {
            dtgv_User.DataSource = listuser;
        }
        private void btnThemUser_Click(object sender, EventArgs e)
        {
            pn_Them_User.Visible = true;
            btnLuuUser.Visible = true;
            dtgv_User.Width = 650;
            lbTD.Text = "Thêm User";
            flagLuu = 0;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUserID.Text = "";
            txtUserID.Enabled = false;
            txtUsername.BorderColor = Color.White;
            txtUsername.PlaceholderText = "";
            txtUsername.PlaceholderForeColor = Color.White;
            txtPassword.BorderColor = Color.White;
            txtPassword.PlaceholderText = "";
            txtPassword.PlaceholderForeColor = Color.White;
        }

        private void dtgv_User_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_User.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {

                pn_Them_User.Visible = true;
                btnLuuUser.Visible = true;
                dtgv_User.Width = 650;
                txtUserID.Enabled = false;
                lbTD.Text = "Sửa Thông Tin User";
                flagLuu = 1;
                btnThemUser.Enabled = false;
                binding();
            }
        }

        private void btnLuuUser_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text=="" || txtPassword.Text=="")
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
            }
            else
            {
                pn_Them_User.Visible = false;
                btnLuuUser.Visible = false;
                dtgv_User.Width = 1011;
                if (flagLuu == 0)
                {

                    USER us = User_RoleBLL.Get(x => x.IDuser.ToString() == txtUserID.Text.Trim());
                    if (us == null)
                    {
                        us = new USER();
                        us.Username = txtUsername.Text;
                        us.Password = txtPassword.Text;
                        us.IDrole = Convert.ToInt32(cbRole.SelectedValue.ToString());
                        User_RoleBLL.Add(us);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    btnThemUser.Enabled = true;
                }
                else
                {
                    try
                    {
                        USER us = User_RoleBLL.Get(x => x.IDuser.ToString() == txtUserID.Text.Trim());

                        us.IDuser = Convert.ToInt32(txtUserID.Text);
                        us.Username = txtUsername.Text;
                        us.Password = txtPassword.Text;
                        us.IDrole = Convert.ToInt32(cbRole.SelectedValue.ToString());
                        User_RoleBLL.Edit(us);
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    btnThemUser.Enabled = true;
                }
            }
            
        }

        private void btnXUser_Click(object sender, EventArgs e)
        {
            pn_Them_User.Visible = false;
            btnLuuUser.Visible = false;
            dtgv_User.Width = 1011;
            btnThemUser.Enabled = true;
            loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }

       

        private void btnSuaRole_Click(object sender, EventArgs e)
        {
            Edit_Role UC = new Edit_Role();
            this.Controls.Add(UC);
            UC.BringToFront();
            UC.Location = new Point(170, 48);
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                if (flagDT == 0)
                {
                    loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
                else if (flagDT == 1)
                {
                    var listfillter = new List<UserDTO>();
                    listfillter = User_RoleBLL.dsusser().Where(x => x.Username.Contains(txtsearch.Text)).ToList();
                    dtgv_User.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
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
                totlalrecord = db.QUYDINH_DIEM.Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
            if (flagDT == 0)
            {
                int totlalrecord = 0;
                totlalrecord = User_RoleBLL.dsusser().Where(x => x.Username.Contains(txtsearch.Text)).Count();
                if (pagenumber - 1 < totlalrecord / numberRecord)
                {
                    pagenumber++;
                    var listfillter = new List<UserDTO>();
                    listfillter = User_RoleBLL.dsusser().Where(x => x.Username.Contains(txtsearch.Text)).ToList();
                    dtgv_User.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
                    int Number = pagenumber;
                    lbNumber.Text = Number.ToString();
                }
            }
        }
        void loadcbRole()
        {
            cbRole.DataSource = User_RoleBLL.dsrole();
            cbRole.DisplayMember = "Role";
            cbRole.ValueMember = "IDrole";
        }
        void loadcbFillterRole()
        {
            cbFillterRole.DataSource = User_RoleBLL.dsrole();
            cbFillterRole.DisplayMember = "Role";
            cbFillterRole.ValueMember = "IDrole";
        }
        void binding()
        {
            txtUserID.DataBindings.Clear();
            txtUserID.DataBindings.Add("Text", dtgv_User.DataSource, "IDuser");
            txtUsername.DataBindings.Clear();
            txtUsername.DataBindings.Add("Text", dtgv_User.DataSource, "Username");
            txtPassword.DataBindings.Clear();
            txtPassword.DataBindings.Add("Text", dtgv_User.DataSource, "Password");
            cbRole.DataBindings.Clear();
            cbRole.DataBindings.Add("Text", dtgv_User.DataSource, "Role");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtsearch.Text.Trim()))
            {
                loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
            else
            {
                var listSearch = new List<UserDTO>();
                listSearch = User_RoleBLL.dsusser().Where(x => x.Username.Contains(txtsearch.Text)).ToList();
                dtgv_User.DataSource = listSearch.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();                
                pagenumber = 1;
                lbNumber.Text = pagenumber.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            pagenumber = 1;
            var listfillter = new List<UserDTO>();
            listfillter = User_RoleBLL.dsusser().Where(x => x.Role.Contains(cbFillterRole.Text)).ToList();
            dtgv_User.DataSource = listfillter.Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList();
            flagDT = 1;
            lbNumber.Text = pagenumber.ToString();
            if (dtgv_User.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddsuser(User_RoleBLL.dsusser().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                flagDT = 0;
            }
        }
        void maxlength()
        {
            txtUsername.MaxLength = 50;
            txtPassword.MaxLength = 50;
        }
        void SuggestTxtSearch()
        {
            txtsearch.AutoCompleteCustomSource.AddRange(User_RoleBLL.dsusser().Select(x => x.Username).ToArray());
        }
    }
}
