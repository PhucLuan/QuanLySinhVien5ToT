using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BunifuAnimatorNS;

namespace QuanLySinhVien5ToT.DTO
{
    public class Tieu_ChuanDTO
    {
        public int? MaTieuChuan { get; set; }
        public string TenTieuChuan { get; set; }
        public string TenCapTieuChuan { get; set; }
        public string TenTieuChi { get; set; }
        public string TenLoaiTieuChuan { get; set; }
        public Boolean? QuyDinhGiai { get; set; }
    }
}
