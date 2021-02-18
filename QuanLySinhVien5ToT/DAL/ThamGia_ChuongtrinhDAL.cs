using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class ThamGia_ChuongtrinhDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<ThanGia_ChuongtrinhDTO> getTG_CT()
        {
            List<ThanGia_ChuongtrinhDTO> thanGia_ChuongtrinhDTOs = new List<ThanGia_ChuongtrinhDTO>();
            thanGia_ChuongtrinhDTOs = (from tgct in db.THAMGIA_CHUONGTRINH
                        from tg in db.THOIGIAN_XET
                        from dv in db.DON_VI
                        from sv in db.SINH_VIEN
                        from ct in db.CHUONG_TRINH
                        where tgct.Mssv==sv.Mssv && 
                        sv.DonVi==dv.MaDonVi && 
                        tgct.MaThoiGian==tg.MaThoiGian &&
                        tgct.MaChuongTrinh==ct.MaChuongTrinh                        
                        select new ThanGia_ChuongtrinhDTO
                        {
                            Mssv=tgct.Mssv,
                            TenSinhVien=sv.HoTen,
                            DonVi=dv.MaDonVi,
                            TenChuongTrinh=ct.TenChuongTrinh,
                            Giai=tgct.Giai,
                            ThoiGian = string.Concat(
                                      SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
                                      SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
                                      SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
                                      SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
                                      SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
                                      SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
                        }).ToList();
            return thanGia_ChuongtrinhDTOs;
        }
    }
}
