using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien5ToT.DTO
{
    public class ThanGia_ChuongtrinhDTO
    {
        public enum EnumGiai
        {
            Không,
            Giải_Nhất,
            Giải_Nhì,
            Giải_Ba,
        }
        public string Mssv { get; set; }
        public string TenSinhVien { get; set; }
        public string DonVi { get; set; }
        public string TenChuongTrinh { get; set; }
        public  int? Giai { get; set; }
        public string ThoiGian { get; set; }
        
    }
}
