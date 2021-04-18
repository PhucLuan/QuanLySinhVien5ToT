using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using QuanLySinhVien5ToT.DTO;
using QuanLySinhVien5ToT.BLL;

namespace QuanLySinhVien5ToT.Services
{
    public class check_IP_mssv
    {        
        private SinhVienBLL sinhVienBLL = new SinhVienBLL();
        public void check_Input_Mssv(Guna2TextBox textBox)
        {
            List<ThongTinPQ_DTO> listPQ_SV = Login.listPQ;
            if (textBox.Text==""||textBox.TextLength < 11)
            {
                textBox.Text = "";
                textBox.BorderColor = Color.Red;
                textBox.PlaceholderText = "chưa nhập đủ 11 kí tự";
                textBox.PlaceholderForeColor = Color.Red;
            }
            if (textBox.TextLength == 11)
            {
                var listSV_THEO_DV = sinhVienBLL.DsSinhVien().Where(x => x.DonVi == listPQ_SV.Select(y => y.DonVi).ToList().First()).ToList();
                if (listPQ_SV.Select(x => x.Role).ToArray().First() == "admin")
                {
                    if (!listSV_THEO_DV.Any(x => x.Mssv.Contains(textBox.Text)))
                    {
                        textBox.Text = "";
                        textBox.BorderColor = Color.Red;
                        textBox.PlaceholderText = "Mssv không tồn tại";
                        textBox.PlaceholderForeColor = Color.Red;
                    }
                    else
                    {
                        textBox.BorderColor = Color.FromArgb(226, 226, 226);
                    }
                }
                else
                {
                    var listsv = sinhVienBLL.DsSinhVien().Where(x => x.Mssv == textBox.Text).ToList();
                    if (!listsv.Any())
                    {
                        textBox.Text = "";
                        textBox.BorderColor = Color.Red;
                        textBox.PlaceholderText = "Mssv không tồn tại";
                        textBox.PlaceholderForeColor = Color.Red;
                    }
                    else
                    {
                        textBox.BorderColor = Color.FromArgb(226, 226, 226);
                    }
                }
            }
        }
    }
}
