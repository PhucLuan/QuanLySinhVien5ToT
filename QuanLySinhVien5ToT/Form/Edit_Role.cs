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
    public partial class Edit_Role : UserControl
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        Edit_RoleBLL Edit_RoleBLL = new Edit_RoleBLL();
        int pagenumber = 1;
        int numberRecord = 5;
        private int flagLuu = 0;
        public Edit_Role()
        {
            InitializeComponent();
        }
        private void Edit_Role_Load(object sender, EventArgs e)
        {
            loadRole(Edit_RoleBLL.dsrole().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
            txtRole.MaxLength = 30;
        }
        void loadRole(List<RoleDTO> listRole)
        {
            dtgv_Role.DataSource = listRole;
        }

        private void btnThemRole_Click(object sender, EventArgs e)
        {
            pn_Them_Role.Visible = true;
            btnLuuRole.Visible = true;
            dtgv_Role.Width = 322;
            lbTD.Text = "Thêm Role";
            flagLuu = 0;
            txtID.Text = "";
            txtRole.Text = "";
            txtID.Enabled = false;
            txtRole.BorderColor = Color.FromArgb(213, 218, 223);
            txtRole.PlaceholderText = "";
        }

        private void dtgv_Role_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dtgv_Role.Columns[e.ColumnIndex].Name;
            if (name == "Sua")
            {

                pn_Them_Role.Visible = true;
                btnLuuRole.Visible = true;
                dtgv_Role.Width = 322;
                lbTD.Text = "Sửa Role";
                binding();
                flagLuu = 1;
                txtID.Enabled = false;
                btnThemRole.Enabled = false;

                txtRole.BorderColor = Color.FromArgb(213, 218, 223);
                txtRole.PlaceholderText = "";
            }
        }

        private void btnXRole_Click(object sender, EventArgs e)
        {
            pn_Them_Role.Visible = false;
            btnLuuRole.Visible = false;
            dtgv_Role.Width = 572;
            btnThemRole.Enabled = true;
            loadRole(Edit_RoleBLL.dsrole().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
        }
        void loadbtnluu()
        {
            pn_Them_Role.Visible = false;
            btnLuuRole.Visible = false;
            dtgv_Role.Width = 572;
        }
        private void btnLuuRole_Click(object sender, EventArgs e)
        {
            if (txtRole.Text == "")
            {
                txtRole.BorderColor = Color.Red;
                txtRole.PlaceholderText = "bạn chưa nhập Role mới";
                txtRole.PlaceholderForeColor = Color.Red;
            }
            else
            {
                if (flagLuu == 0)
                {

                    ROLE role = Edit_RoleBLL.Get(x => x.IDrole.ToString() == txtID.Text.Trim());
                    if (role == null)
                    {
                        role = new ROLE();
                        role.Role1 = txtRole.Text;
                        Edit_RoleBLL.Add(role);
                        MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadRole(Edit_RoleBLL.dsrole());
                        btnThemRole.Enabled = true;
                        loadbtnluu();
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    try
                    {
                        ROLE role = Edit_RoleBLL.Get(x => x.IDrole.ToString() == txtID.Text.Trim());
                        role.Role1 = txtRole.Text;
                        Edit_RoleBLL.Edit(role);
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadRole(Edit_RoleBLL.dsrole());
                        btnThemRole.Enabled = true;
                        loadbtnluu();
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Sửa thất bại!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }

        private void btnXRole_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void binding()
        {
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text", dtgv_Role.DataSource, "IDrole");
            txtRole.DataBindings.Clear();
            txtRole.DataBindings.Add("Text", dtgv_Role.DataSource, "Role");
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            if (pagenumber - 1 > 0)
            {
                pagenumber--;
                loadRole(Edit_RoleBLL.dsrole().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
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
                loadRole(Edit_RoleBLL.dsrole().Skip((pagenumber - 1) * numberRecord).Take(numberRecord).ToList());
                int Number = pagenumber;
                lbNumber.Text = Number.ToString();
            }
        }

        private void txtRole_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRole.Text.Trim()))
                txtRole.BorderColor = Color.Red;
            else
                txtRole.BorderColor = Color.FromArgb(226, 226, 226);
        }
    }
}
