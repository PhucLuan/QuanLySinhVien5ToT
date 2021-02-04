using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    
    public class Chuong_TrinhDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Chuong_TrinhDTO> getchuongtrinh(int page, int recordNum)
        {
            List<Chuong_TrinhDTO> chuong_TrinhDTOs = new List<Chuong_TrinhDTO>();
            chuong_TrinhDTOs = (from ct in db.CHUONG_TRINH
                                from tc in db.TIEU_CHUAN
                                where ct.MaTieuChuan == tc.MaTieuChuan
                                select new Chuong_TrinhDTO 
                                { 
                                    MaChuongTrinh=ct.MaChuongTrinh,
                                    TenChuongTrinh=ct.TenChuongTrinh,
                                    TenTieuChuan=tc.TenTieuChuan,
                                    ThoiGianDienRa=ct.ThoiGianDienRa,
                                    DonViToChuc=ct.DonViToChuc
                                }).ToList();
            List<Chuong_TrinhDTO> Loadrecord = new List<Chuong_TrinhDTO>();
            Loadrecord= chuong_TrinhDTOs.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return Loadrecord;
        }
        public List<Chuong_TrinhDTO> getChuongTrinh()
        {
            List<Chuong_TrinhDTO> chuong_TrinhDTOs = new List<Chuong_TrinhDTO>();
            chuong_TrinhDTOs = (from ct in db.CHUONG_TRINH
                                from tc in db.TIEU_CHUAN
                                where ct.MaTieuChuan == tc.MaTieuChuan
                                select new Chuong_TrinhDTO
                                {
                                    MaChuongTrinh = ct.MaChuongTrinh,
                                    TenChuongTrinh = ct.TenChuongTrinh,
                                    TenTieuChuan = tc.TenTieuChuan,
                                    ThoiGianDienRa = ct.ThoiGianDienRa,
                                    DonViToChuc = ct.DonViToChuc
                                }).ToList();           
            return chuong_TrinhDTOs;
        }
    }
}
