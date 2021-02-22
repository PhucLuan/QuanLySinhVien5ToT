using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using QuanLySinhVien5ToT.BLL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT
{
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        User_RoleBLL User_RoleBLL = new User_RoleBLL();
        LoginBLL loginBLL = new LoginBLL();
        public static List<ThongTinPQ_DTO> listPQ = new List<ThongTinPQ_DTO>();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="" || txtPassword.Text == "")
            {
                if (txtUsername.Text == "")
                {
                    txtUsername.BorderColor = Color.Red;
                    txtUsername.PlaceholderText = "bạn chưa nhập username";
                    txtUsername.PlaceholderForeColor = Color.Red;
                }
                if (txtPassword.Text == "")
                {
                    txtPassword.BorderColor = Color.Red;
                    txtPassword.PlaceholderText = "bạn chưa nhập username";
                    txtPassword.PlaceholderForeColor = Color.Red;
                }
            }
            else
            {
                txtPassword.Text = loginBLL.Mahoa(txtPassword.Text);
                USER us = User_RoleBLL.Get(x => x.Username == txtUsername.Text.Trim() && x.Password == txtPassword.Text.Trim());
                if (us != null)
                {
                    this.Hide();
                    //Trang_Chu TC = new Trang_Chu();
                    //TC.Show();
                    MessageBox.Show("Đăng nhập thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listPQ = loginBLL.dsPQ(txtUsername.Text, txtPassword.Text);
                    //MessageBox.Show("role của bạn là" + listPQ.Select(x => x.Role).ToString());
                }
                else
                {
                    USER uss = User_RoleBLL.Get(x => x.Username == txtUsername.Text.Trim() && x.Password == txtPassword.Text.Trim());
                    if (uss == null)
                    {                       
                        USER us1 = User_RoleBLL.Get(x => x.Username == txtUsername.Text.Trim());
                        USER us2 = User_RoleBLL.Get(x => x.Password == txtPassword.Text.Trim());
                        if (us1 == null)
                        {
                            MessageBox.Show("Username của bạn đã bị sai!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (us2 == null)
                        {
                            MessageBox.Show("PassWord của bạn đã bị sai!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username và password của bạn đã bị sai!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
        }
    }
}
