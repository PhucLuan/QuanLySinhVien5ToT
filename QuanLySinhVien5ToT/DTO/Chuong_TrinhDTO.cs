using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien5ToT.DTO
{
    public class Chuong_TrinhDTO
    {
        public int MaChuongTrinh { get; set; }
        public string TenChuongTrinh { get; set; }
        public string TenTieuChuan { get; set; }
        public DateTime? ThoiGianDienRa { get; set; }
        public string DonViToChuc { get; set; }
    }
}
