using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Cap_Tieu_ChuanDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Cap_Tieu_ChuanDTO> getcaptieuchuan()
        {
            
            List<Cap_Tieu_ChuanDTO> cap_Tieu_ChuanDTOs = new List<Cap_Tieu_ChuanDTO>();
            cap_Tieu_ChuanDTOs = (from ctc in db.CAP_TIEU_CHUAN
                            select new Cap_Tieu_ChuanDTO
                            {
                                MaCapTieuChuan=ctc.MaCapTieuChuan,
                                TenCapTieuChuan=ctc.TenCapTieuChuan
                            }).ToList();
            return cap_Tieu_ChuanDTOs;
        }
    }
}
