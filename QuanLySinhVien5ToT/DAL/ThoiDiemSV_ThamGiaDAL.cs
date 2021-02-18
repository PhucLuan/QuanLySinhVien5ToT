using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class ThoiDiemSV_ThamGiaDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<ThoiDiemSV_ThamGiaDTO> getSV_TG()
        {
            List<ThoiDiemSV_ThamGiaDTO> thoiDiemSV_ThamGiaDTOs = new List<ThoiDiemSV_ThamGiaDTO>();
            thoiDiemSV_ThamGiaDTOs = (from tdtt in db.THOIDIEM_SV_THAMGIA
                                      from tg in db.THOIGIAN_XET
                                      from dv in db.DON_VI
                                      from sv in db.SINH_VIEN
                                      where tdtt.Mssv == sv.Mssv && sv.DonVi == dv.MaDonVi && tdtt.MaThoiGian == tg.MaThoiGian
                                      select new ThoiDiemSV_ThamGiaDTO
                                      {
                                          Mssv = tdtt.Mssv,
                                          TenSinhVien = sv.HoTen,
                                          Lop = sv.Lop,
                                          DonVi = dv.MaDonVi,
                                          ThoiDiemDK=tdtt.ThoiGian_DK,
                                          ThoiGian = string.Concat(
                                                    SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
                                                    SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
                                      }).ToList();
            return thoiDiemSV_ThamGiaDTOs;
        }
    }
}
