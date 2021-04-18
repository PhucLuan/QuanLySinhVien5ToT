using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class HocKy_XetDiemDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        //public List<HocKy_XetDiemDTO> getTime(int page, int recordNum)
        //{
        //    List<HocKy_XetDiemDTO> hocKy_XetDiemDTOs = new List<HocKy_XetDiemDTO>();
        //    hocKy_XetDiemDTOs = (from hk in db.HOCKY_XETDIEM
        //                         from tg in db.THOIGIAN_XET
        //                         where hk.MaThoiGianXetDiem==tg.MaThoiGian
                              
        //                      select new HocKy_XetDiemDTO
        //                      {
        //                          MaHocKy=hk.MaHocKy,
        //                          HocKy=hk.HocKy,
        //                          Nam=hk.Nam,
        //                          ThoiGian = string.Concat(
        //                              SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
        //                              SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
        //                              SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
        //                              SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
        //                              SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
        //                              SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
        //                      }).ToList();
        //    List<HocKy_XetDiemDTO> Loadrecord = new List<HocKy_XetDiemDTO>();
        //    Loadrecord = hocKy_XetDiemDTOs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
        //    return Loadrecord;
        //}
        public List<HocKy_XetDiemDTO> getTime2()
        {
            List<HocKy_XetDiemDTO> hocKy_XetDiemDTOs = new List<HocKy_XetDiemDTO>();
            hocKy_XetDiemDTOs = (from hk in db.HOCKY_XETDIEM
                                 from tg in db.THOIGIAN_XET
                                 where hk.MaThoiGianXetDiem == tg.MaThoiGian

                                 select new HocKy_XetDiemDTO
                                 {
                                     MaHocKy = hk.MaHocKy,
                                     HocKy = hk.HocKy,
                                     Nam = hk.Nam,
                                     ThoiGian = string.Concat(
                                         SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
                                         SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
                                         SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
                                         SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
                                         SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
                                         SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim())
                                 }).ToList();

            return hocKy_XetDiemDTOs;
        }

    }
}
