using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT
{
    public partial class Trang_Chu : Form
    {
        public  Trang_Chu()
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
            if (btnTD_SV_TG.Checked) 
            {
                
            } 
        }

        private void guna2Button2_CheckedChanged(object sender, EventArgs e)
        {

            if (btnTieuChuan.Checked)
            {
                
            }
        }

        private void Visible_pn()
        {
            pn_Diem_SubMenu.Visible = false;
           
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
            
        }
        
        private void showMenu(Panel Submenu)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("Bạn phải đăng nhập trước");
            }
            else
            {
                if (Submenu.Visible == false)
                {
                    HideSubMenu();
                    Submenu.Visible = true;
                }
                else
                    Submenu.Visible = false;
            }
            
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

        

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            showDangNhap();            
                      
        }
        private void showDangNhap()
        {
            if (pn_DangNhap.Visible == false )
            {

                pn_DangNhap.BringToFront();
                btn_DangNhap.BringToFront();
                btn_DangXuat.BringToFront();
                pn_DangNhap.Visible = true;                               
            }
            else
            {               
                pn_DangNhap.Visible = false;               
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

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Location = new Point(375, 51);
            pn_control.Controls.Add(lg);
            lg.BringToFront();
        }

        private void Trang_Chu_Activated(object sender, EventArgs e)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                lbName.Visible = true;
                btn_Information.Visible = false;
                btn_DangNhap.Visible = true;
                btn_DangXuat.Visible = false;
            }
            else
            {
                btn_Information.Visible = true;
                btn_DangNhap.Visible = false;
                btn_DangXuat.Visible = true;
                lbName.Visible = true;
                lbName.Text = listPQ_TC.Select(x => x.Name).ToArray().First().ToString();
                lbDonVi.Text = listPQ_TC.Select(x => x.DonVi).ToArray().First().ToString();
                lbRole.Text = listPQ_TC.Select(x => x.Role).ToArray().First().ToString();
            }
        }
        public void LoadPQ()
        {
            this.Refresh();
        }
        private void pn_control_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_TTSV_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THONGTIN_SINHVIEN SV = new THONGTIN_SINHVIEN();
            SV.Location = new Point(0, 0);
            pn_control.Controls.Add(SV);
            HideSubMenu();
        }
        private void btnThamGia_CT_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THAMGIA_CT TGCT = new THAMGIA_CT();
            TGCT.Location = new Point(0, 0);
            pn_control.Controls.Add(TGCT);
            HideSubMenu();
        }

        private void btnThucHen_TC_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            THUCHIENTIEUCHUAN THTC = new THUCHIENTIEUCHUAN();
            THTC.Location = new Point(0, 0);
            pn_control.Controls.Add(THTC);
            HideSubMenu();
        }

        private void btnKQ_Theo_TC_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            KQ_Theo_TC KQ = new KQ_Theo_TC();
            KQ.Location = new Point(0, 0);
            pn_control.Controls.Add(KQ);
            HideSubMenu();
        }

        private void btnTD_SV_TG_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_TGX TGX = new QL_TGX();
            TGX.Location = new Point(0, 0);
            pn_control.Controls.Add(TGX);
            HideSubMenu();
        }

        private void btnTieuChuan_Click(object sender, EventArgs e)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("bạn phải đăng nhập trước");
            }
            else
            {
                if (listPQ_TC.Select(x => x.Role).ToArray().First() == "admin")
                {
                    MessageBox.Show("bạn không có quyền vào chức năng này");
                }
                else
                {
                    pn_control.Controls.Clear();
                    QL_TIEUCHUAN QLTieuChuan = new QL_TIEUCHUAN();
                    QLTieuChuan.Location = new Point(0, 0);
                    pn_control.Controls.Add(QLTieuChuan);
                    HideSubMenu();
                }
            }
            
        }

        private void btnChuongTrinh_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_CT QLCT = new QL_CT();
            QLCT.Location = new Point(0, 0);
            pn_control.Controls.Add(QLCT);
            HideSubMenu();
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QL_DIEM Diem = new QL_DIEM();
            Diem.Location = new Point(0, 0);
            pn_control.Controls.Add(Diem);
            HideSubMenu();
        }

        private void btnHK_Xet_Diem_Click_1(object sender, EventArgs e)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("bạn phải đăng nhập trước");
            }
            else
            {
                if (listPQ_TC.Select(x => x.Role).ToArray().First() == "admin")
                {
                    MessageBox.Show("bạn không có quyền vào chức năng này");
                }
                else
                {
                    pn_control.Controls.Clear();
                    HOCKYXETDIEM HK = new HOCKYXETDIEM();
                    HK.Location = new Point(0, 0);
                    pn_control.Controls.Add(HK);
                    HideSubMenu();
                }

            }
            
        }

        private void btnQD_Diem_Click(object sender, EventArgs e)
        {
            pn_control.Controls.Clear();
            QUYDINHDIEM QDĐ = new QUYDINHDIEM();
            QDĐ.Location = new Point(0, 0);
            pn_control.Controls.Add(QDĐ);
            HideSubMenu();
        }

        private void btnDonVi_Click(object sender, EventArgs e)
        { 
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("bạn phải đăng nhập trước");
            }
            else
            {
                if (listPQ_TC.Select(x => x.Role).ToArray().First() == "admin")
                {
                    MessageBox.Show("bạn không có quyền vào chức năng này");
                }
                else
                {
                    pn_control.Controls.Clear();
                    QL_DonVi QV = new QL_DonVi();
                    QV.Location = new Point(0, 0);
                    pn_control.Controls.Add(QV);
                    HideSubMenu();
                }               
            }            
        }

        private void btnQL_NhanVien_Click(object sender, EventArgs e)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("bạn phải đăng nhập trước");
            }
            else
            {
                pn_control.Controls.Clear();
                QL_NHAN_VIEN QLNV = new QL_NHAN_VIEN();
                QLNV.Location = new Point(0, 0);
                pn_control.Controls.Add(QLNV);
                HideSubMenu();
            }           
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            List<ThongTinPQ_DTO> listPQ_TC = Login.listPQ;
            if (!listPQ_TC.Any())
            {
                MessageBox.Show("bạn phải đăng nhập trước");
            }
            else
            {
                if (listPQ_TC.Select(x => x.Role).ToArray().First() == "admin")
                {
                    MessageBox.Show("bạn không có quyền vào chức năng này");
                }
                else
                {
                    pn_control.Controls.Clear();
                    User_Role US = new User_Role();
                    US.Location = new Point(0, 0);
                    pn_control.Controls.Add(US);
                    HideSubMenu();
                }
                
            }
            
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
