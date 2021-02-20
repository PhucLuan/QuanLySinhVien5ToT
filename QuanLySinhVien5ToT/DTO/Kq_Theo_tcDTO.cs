using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DTO
{
    public class Kq_Theo_tcDTO
    {
        private Thoi_Gian_XetDTO thoi_Gian_XetDTO = new Thoi_Gian_XetDTO();
        public string Mssv { get; set; }
        public string HoTen { get; set; }
        public string DonVi { get; set; }
        public string TenTieuChi { get; set; }
        public string DanhGia { get; set; }
        public short? TienDoHDBatBuoc { get; set; }
        public bool? TienDoHDKhac { get; set; }
        public string ThoiGian { get; set; }
    }
}
