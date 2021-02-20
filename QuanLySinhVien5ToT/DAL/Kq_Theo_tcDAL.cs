using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Kq_Theo_tcDAL
    {
        
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public Dictionary<int, string> DicDanhGia = new Dictionary<int, string>()
        {
            {0,"Không Đạt"},{1,"Cấp Trường"},{2,"Cấp Khoa"}
        };
        public List<Kq_Theo_tcDTO> getKQ() 
        {
            List<Kq_Theo_tcDTO> kq_Theo_TcDTOs = new List<Kq_Theo_tcDTO>();
            var listKQ = (from kq in db.KQ_THEO_TIEUCHI
                              from sv in db.SINH_VIEN
                              from tc in db.TIEU_CHI
                              from tg in db.THOIGIAN_XET
                              from dv in db.DON_VI
                              where kq.Mssv == sv.Mssv && kq.MaTieuChi == tc.MaTieuChi && kq.MaThoiGian == tg.MaThoiGian && sv.DonVi==dv.MaDonVi
                              select new 
                              {
                                  kq.Mssv,
                                  sv.HoTen,
                                  dv.MaDonVi,
                                  tc.TenTieuChi,
                                  DanhGia= (int)kq.DanhGia,
                                  kq.TienDoHDBatBuoc,
                                  kq.TienDoHDKhac,
                                  ThoiGian = string.Concat(
                                      SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim()+"/"+ 
                                      SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" + 
                                      SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_", 
                                      SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" + 
                                      SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" + 
                                      SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
                              }).ToList();
            kq_Theo_TcDTOs = listKQ.Select(x => new Kq_Theo_tcDTO()
            {
                Mssv = x.Mssv,
                HoTen = x.HoTen,
                DonVi = x.MaDonVi,
                TenTieuChi = x.TenTieuChi,
                DanhGia = DicDanhGia[x.DanhGia],
                TienDoHDBatBuoc=x.TienDoHDBatBuoc,
                TienDoHDKhac=x.TienDoHDKhac,
                ThoiGian = x.ThoiGian
            }).ToList();
            return kq_Theo_TcDTOs;
        }
    }
}
