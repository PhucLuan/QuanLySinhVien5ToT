using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Tieu_ChiDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Tieu_ChiDTO> gettieuchi()
        {
            List<Tieu_ChiDTO> tieu_ChiDTOs = new List<Tieu_ChiDTO>();
            tieu_ChiDTOs = (from tc in db.TIEU_CHI
                            select new Tieu_ChiDTO
                            {
                                MaTieuChi=tc.MaTieuChi,
                                TenTieuChi=tc.TenTieuChi,
                                TienDoTong=tc.TienDoTong
                                
                            }).ToList();
            return tieu_ChiDTOs;
        }
    }
}
