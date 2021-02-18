using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Tieu_ChuanDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        
        public List<Tieu_ChuanDTO> getTieuChuan()
        {
            List<Tieu_ChuanDTO> tieu_ChuanDTOs = new List<Tieu_ChuanDTO>();
            tieu_ChuanDTOs = (from tc in db.TIEU_CHUAN
                              from ctc in db.CAP_TIEU_CHUAN
                              from tieuchi in db.TIEU_CHI
                              from ltc in db.LOAI_TIEU_CHUAN
                              where tc.MaTieuChi == tieuchi.MaTieuChi
                              where tc.MaLoaiTieuChuan == ltc.MaLoaiTieuChuan
                              where tc.Cap == ctc.MaCapTieuChuan
                              select new Tieu_ChuanDTO
                              {
                                  MaTieuChuan = tc.MaTieuChuan,
                                  TenTieuChuan = tc.TenTieuChuan,
                                  TenCapTieuChuan = ctc.TenCapTieuChuan,
                                  TenTieuChi = tieuchi.TenTieuChi,
                                  TenLoaiTieuChuan = ltc.TenLoaiTieuChuan,
                                  QuyDinhGiai=tc.QuyDinhGiai
                              }).ToList();
            return tieu_ChuanDTOs;
        }
        public List<Tieu_ChuanDTO> getTieuChuanDiem()
        {
            List<Tieu_ChuanDTO> tieu_ChuanDTOs = new List<Tieu_ChuanDTO>();
            tieu_ChuanDTOs = (from tc in db.TIEU_CHUAN
                              from qdd in db.QUYDINH_DIEM                             
                              where tc.MaTieuChuan == qdd.MaTieuChuan && qdd.Mathoigian == 3
                              select new Tieu_ChuanDTO
                              {
                                  MaTieuChuan=qdd.MaTieuChuan,
                                  TenTieuChuan=tc.TenTieuChuan
                              }).ToList();
            return tieu_ChuanDTOs;
        }
    }
}
