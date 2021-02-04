using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien5ToT.DAL
{
    public class DiemDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<DiemDTO> getDiem()
        {
            List<DiemDTO> diemDTOs = new List<DiemDTO>();
            diemDTOs = (from diem in db.DIEMs
                        from sv in db.SINH_VIEN
                        from hk in db.HOCKY_XETDIEM
                        from ld in db.LOAI_DIEM
                        from dv in db.DON_VI
                        where diem.Mssv == sv.Mssv && diem.MaHocKy == hk.MaHocKy && diem.MaLoaiDiem == ld.MaLoaiDiem && dv.MaDonVi == sv.DonVi
                        select new DiemDTO
                        {
                            Mssv = diem.Mssv,
                            TenSinhVien = sv.HoTen,
                            DonVi = dv.MaDonVi,
                            TenLoaiDiem = ld.TenLoaiDiem,
                            Diem = diem.Diem1,
                            HocKy = string.Concat(hk.HocKy, " - ", hk.Nam)
                        }).ToList();
            return diemDTOs;
        }
    }
}
