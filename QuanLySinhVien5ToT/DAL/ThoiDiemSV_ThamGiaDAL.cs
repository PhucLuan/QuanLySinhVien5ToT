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
        //DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        //public List<ThoiDiemSV_ThamGiaDTO> getTG_CT()
        //{
        //    List<ThoiDiemSV_ThamGiaDTO> thanGia_ChuongtrinhDTOs = new List<ThoiDiemSV_ThamGiaDTO>();
        //    thanGia_ChuongtrinhDTOs = (from tdtt in 
        //                               from tg in db.THOIGIAN_XET
        //                               from dv in db.DON_VI
        //                               from sv in db.SINH_VIEN
                                       
        //                               where tgct.Mssv == sv.Mssv && sv.DonVi == dv.MaDonVi && tgct.MaThoiGian == tg.MaThoiGian && tgct.MaChuongTrinh == ct.MaChuongTrinh
        //                               select new ThoiDiemSV_ThamGiaDTO
        //                               {
        //                                   Mssv = tgct.Mssv,
        //                                   TenSinhVien = sv.HoTen,
        //                                   DonVi = dv.MaDonVi,
        //                                   TenChuongTrinh = ct.TenChuongTrinh,
        //                                   Giai = tgct.Giai,
        //                                   ThoiGian = string.Concat(
        //                                             SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
        //                                             SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
        //                                             SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
        //                                             SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
        //                                             SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
        //                                             SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
        //                               }).ToList();
        //    return thanGia_ChuongtrinhDTOs;
        //}
    }
}
