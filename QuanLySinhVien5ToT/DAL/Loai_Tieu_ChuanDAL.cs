using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Loai_Tieu_ChuanDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Loai_Tieu_ChuanDTO> getloaitieuchuan()
        {

            List<Loai_Tieu_ChuanDTO> loai_Tieu_ChuanDTOs = new List<Loai_Tieu_ChuanDTO>();
            loai_Tieu_ChuanDTOs = (from ltc in db.LOAI_TIEU_CHUAN
                                  select new Loai_Tieu_ChuanDTO
                                  {
                                      MaLoaiTieuChuan= ltc.MaLoaiTieuChuan,
                                      TenLoaiTieuChuan=ltc.TenLoaiTieuChuan
                                  }).ToList();
            return loai_Tieu_ChuanDTOs;
        }
    }
}
