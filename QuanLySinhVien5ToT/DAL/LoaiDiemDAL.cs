using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class LoaiDiemDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<LoaiDiemDTO> getloaidiem()
        {

            List<LoaiDiemDTO> loaiDiemDTOs = new List<LoaiDiemDTO>();
            loaiDiemDTOs = (from ld in db.LOAI_DIEM
                                  select new LoaiDiemDTO
                                  {
                                      MaLoaiDiem=ld.MaLoaiDiem,
                                      TenLoaiDiem=ld.TenLoaiDiem
                                  }).ToList();
            return loaiDiemDTOs;
        }
    }
}
