using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class ThucHien_TieuChuanDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<ThucHien_TieuChuanDTO> getTH_TC()
        {
            List<ThucHien_TieuChuanDTO> thucHien_TieuChuanDTOs = new List<ThucHien_TieuChuanDTO>();
            thucHien_TieuChuanDTOs = (from thtc in db.THUCHIEN_TIEUCHUAN
                                       from tg in db.THOIGIAN_XET
                                       from dv in db.DON_VI
                                       from sv in db.SINH_VIEN
                                       from tc in db.TIEU_CHUAN
                                       where thtc.Mssv == sv.Mssv && sv.DonVi == dv.MaDonVi && thtc.MaThoiGian == tg.MaThoiGian && thtc.MaTieuChuan == tc.MaTieuChuan
                                       select new ThucHien_TieuChuanDTO
                                       {
                                           Mssv = thtc.Mssv,
                                           TenSinhVien = sv.HoTen,
                                           DonVi = dv.MaDonVi,
                                           TenTieuChuan=tc.TenTieuChuan,
                                           ThoiGian = string.Concat(
                                                     SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
                                                     SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
                                                     SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
                                                     SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
                                                     SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
                                                     SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
                                       }).ToList();
            return thucHien_TieuChuanDTOs;
        }
    }
}
