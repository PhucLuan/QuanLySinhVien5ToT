using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLySinhVien5ToT
{
    public partial class Trang_Chu : Form
    {
        public Trang_Chu()
        {
            InitializeComponent();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {
            Visible_pn();
            showTrangChu();
            pn_Menu.Width = 60;
        }

        

       
        private bool enumExpended = false;

        private void DetectMouse_Tick(object sender, EventArgs e)
        {
            if (!guna2Transition1.IsCompleted) return;
            if (pn_Menu.ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
                if (!enumExpended)
                {
                    enumExpended = true;
                    pn_Menu.Width = 255;
                    pn_Menu.BringToFront();
                    //pn_logo.BringToFront();
                    
                }
            }
            else
            {
                if (enumExpended)
                {
                    enumExpended = false;
                   
                    pn_Menu.Visible = true;
                    HideSubMenu();
                    guna2Transition1.Show(pn_Menu); 
                    pn_Menu.Width = 60;


                }
            }
        }
        private void guna2Button8_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2Button8.Checked) 
            {
                
            } 
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {

            if (guna2Button2.Checked)
            {
                
            }
        }

        private void Visible_pn()
        {
            pn_Diem_SubMenu.Visible = false;
            pn_QD_SubMenu.Visible = false;
            pn_SinhVienSubmenu.Visible = false;
            pn_TCvsCT_SubMenu.Visible = false;
        }
        private void HideSubMenu()
        {
            if (pn_SinhVienSubmenu.Visible == true)
                pn_SinhVienSubmenu.Visible = false;
            if (pn_TCvsCT_SubMenu.Visible == true)
                pn_TCvsCT_SubMenu.Visible = false;
            if (pn_Diem_SubMenu.Visible == true)
                pn_Diem_SubMenu.Visible = false;
            if (pn_QD_SubMenu.Visible == true)
                pn_QD_SubMenu.Visible = false;
        }
        private void showMenu(Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                HideSubMenu();
                Submenu.Visible = true;
            }
            else
                Submenu.Visible = false;
        }

       

        
        private void btn_TTSV_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THONGTIN_SINHVIEN SV = new THONGTIN_SINHVIEN();
            SV.Location = new Point(0, 0);
            pn_control.Controls.Add(SV);
            HideSubMenu();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THAMGIA_CT TGCT = new THAMGIA_CT();
            TGCT.Location = new Point(0, 0);
            pn_control.Controls.Add(TGCT);
            HideSubMenu();
        }

        private void guna2Button10_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THUCHIENTIEUCHUAN THTC = new THUCHIENTIEUCHUAN();
            THTC.Location = new Point(0, 0);
            pn_control.Controls.Add(THTC);
            HideSubMenu();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            KQ_Theo_TC KQ = new KQ_Theo_TC();
            KQ.Location = new Point(0, 0);
            pn_control.Controls.Add(KQ);
            HideSubMenu();
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_TGX TGX = new QL_TGX();
            TGX.Location = new Point(0, 0);
            pn_control.Controls.Add(TGX);
            HideSubMenu();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_TIEUCHUAN QLTieuChuan = new QL_TIEUCHUAN();
            QLTieuChuan.Location = new Point(0, 0);
            pn_control.Controls.Add(QLTieuChuan);
            HideSubMenu();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_CT QLCT = new QL_CT();
            QLCT.Location = new Point(0, 0);
            pn_control.Controls.Add(QLCT);
            HideSubMenu();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_DIEM Diem = new QL_DIEM();
            Diem.Location = new Point(0, 0);
            pn_control.Controls.Add(Diem);
            HideSubMenu();
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            HOCKYXETDIEM HK = new HOCKYXETDIEM();
            HK.Location = new Point(0, 0);
            pn_control.Controls.Add(HK);
            HideSubMenu();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QUYDINHDIEM QDĐ = new QUYDINHDIEM();
            QDĐ.Location = new Point(0, 0);
            pn_control.Controls.Add(QDĐ);
            HideSubMenu();
        }

        private void guna2Button11_Click_1(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QUYDINH_GIAI QDG = new QUYDINH_GIAI();
            QDG.Location = new Point(0, 0);
            pn_control.Controls.Add(QDG);
            HideSubMenu();
        }
        private void guna2Button12_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_DonVi QV = new QL_DonVi();
            QV.Location = new Point(0, 0);
            pn_control.Controls.Add(QV);
            HideSubMenu();
        }
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_NHAN_VIEN QLNV= new QL_NHAN_VIEN();
            QLNV.Location = new Point(0, 0);
            pn_control.Controls.Add(QLNV);
            HideSubMenu();
        }
        private void btn_TD_SV_Click(object sender, EventArgs e)
        {
            showMenu(pn_SinhVienSubmenu);
        }

        private void btn_TD_CT_Click(object sender, EventArgs e)
        {
            showMenu(pn_TCvsCT_SubMenu);
        }

        private void btn__TD_DiemSV_Click(object sender, EventArgs e)
        {
            showMenu(pn_Diem_SubMenu);
        }

        private void btn_TD_QD_Click(object sender, EventArgs e)
        {
            showMenu(pn_QD_SubMenu);
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            showDangNhap();
            //pn_DangNhap.Location = new Point(860, 23);
            //pn_control.Controls.Add(pn_DangNhap);
        }
        private void showDangNhap()
        {
            if (pn_DangNhap.Visible == false && pictureBox_Arrow.Visible==false)
            {
                //pn_DangNhap.Location = new Point(860, 23);
                //pn_control.Controls.Add(pn_DangNhap);
                //pn_DangNhap.BringToFront();
                pn_DangNhap.Visible = true;
                pictureBox_Arrow.Visible = true;
                btn_DangNhap.Visible = true;
                btn_DangXuat.Visible = true;
            }
            else
            {
                pn_DangNhap.Visible = false;
                pictureBox_Arrow.Visible = false;
                btn_DangNhap.Visible = false;
                btn_DangXuat.Visible = false;
            }
               
        }
        private void showTrangChu()
        {
            pn_control.Controls.Clear();
            BG_TrangChu BG = new BG_TrangChu();
            BG.Location = new Point(0, 0);
            pn_control.Controls.Add(BG);
            HideSubMenu();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            showTrangChu();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            User_Role US = new User_Role();
            US.Location = new Point(0, 0);
            pn_control.Controls.Add(US);
            HideSubMenu();
        }
    }
}
