using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class QuyDinhDiemDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<QuyDinhDiemDTO> getQDD()
        {
            List<QuyDinhDiemDTO> quyDinhDiemDTOs = new List<QuyDinhDiemDTO>();
            quyDinhDiemDTOs = (from qd in db.QUYDINH_DIEM
                                      from tg in db.THOIGIAN_XET
                                      from dv in db.DON_VI
                                      from ld in db.LOAI_DIEM
                                      from tc in db.TIEU_CHUAN
                                      where qd.MaLoaiDiem==ld.MaLoaiDiem && qd.MaDonVi == dv.MaDonVi && qd.Mathoigian == tg.MaThoiGian && qd.MaTieuChuan == tc.MaTieuChuan
                                      select new QuyDinhDiemDTO
                                      {
                                          MaQuyDinhDiem=qd.MaQuyDinhDiem,
                                          TenLoaiDiem=ld.TenLoaiDiem,
                                          DiemToiThieu=qd.DiemToiThieu,
                                          DonVi=qd.MaDonVi,
                                          TenTieuChuan=tc.TenTieuChuan,
                                          ThoiGian = string.Concat(
                                                    SqlFunctions.DatePart("day", tg.TuNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("month", tg.TuNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("year", tg.TuNgay).ToString().Trim(), "_",
                                                    SqlFunctions.DatePart("day", tg.DenNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("month", tg.DenNgay).ToString().Trim() + "/" +
                                                    SqlFunctions.DatePart("year", tg.DenNgay).ToString().Trim()),
                                          TrangThai=qd.TrangThai
                                      }).ToList();
            return quyDinhDiemDTOs;
        }
    }
}
