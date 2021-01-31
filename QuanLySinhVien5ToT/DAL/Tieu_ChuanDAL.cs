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
        public List<Tieu_ChuanDTO> getTieuChuanRecord(int page, int recordNum)
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
                                  MaTieuChuan=tc.MaTieuChuan,
                                  TenTieuChuan=tc.TenTieuChuan,
                                  TenCapTieuChuan=ctc.TenCapTieuChuan,
                                  TenTieuChi=tieuchi.TenTieuChi,
                                  TenLoaiTieuChuan=ltc.TenLoaiTieuChuan
                              }).ToList();
            List<Tieu_ChuanDTO> loadrecord = new List<Tieu_ChuanDTO>();
            loadrecord = tieu_ChuanDTOs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return loadrecord;
        }
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
                                  TenLoaiTieuChuan = ltc.TenLoaiTieuChuan
                              }).ToList();
            return tieu_ChuanDTOs;
        }
        }
}
