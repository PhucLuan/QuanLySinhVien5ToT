using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien5ToT.DTO
{
    public class QuyDinhDiemDTO
    {
        public int MaQuyDinhDiem { get; set; }
        public string TenLoaiDiem { get; set; }
        public int? DiemToiThieu { get; set; }
        public string DonVi { get; set; }
        public string TenTieuChuan { get; set; }
        public string ThoiGian { get; set; }
        public Boolean? TrangThai { get; set; } 
    }
}
