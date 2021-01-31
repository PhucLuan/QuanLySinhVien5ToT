using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Sinh_VienDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Sinh_VienDTO> Getdssinhvien(int page,int recordNum)
        {
            List<Sinh_VienDTO> sinh_Viens = new List<Sinh_VienDTO>();
            sinh_Viens = (from sv in db.SINH_VIEN
                          select new Sinh_VienDTO 
                          { 
                             Mssv=sv.Mssv,
                             HoTen=sv.HoTen,
                             NgaySinh=sv.NgaySinh,
                             GioiTinh=sv.GioiTinh,
                             NoiSinh=sv.NoiSinh,
                             SDT=sv.SDT,
                             Lop=sv.Lop,
                             DonVi=sv.DonVi,
                             Khoa=sv.Khoa,
                             Email=sv.Email
                          }).ToList();
            List<Sinh_VienDTO> Loadrecord = new List<Sinh_VienDTO>();
            Loadrecord = sinh_Viens.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return Loadrecord;
        }
        public List<Sinh_VienDTO> Fillter(string DV, string Khoa, string lop, int page, int recordNum)
        {
            List<Sinh_VienDTO> Fillter_SV = new List<Sinh_VienDTO>();
            Fillter_SV = (from sv in db.SINH_VIEN
                          where sv.DonVi==DV 
                          where sv.Khoa==Khoa
                          where sv.Lop==lop
                          select new Sinh_VienDTO
                          {
                              Mssv = sv.Mssv,
                              HoTen = sv.HoTen,
                              NgaySinh = sv.NgaySinh,
                              GioiTinh = sv.GioiTinh,
                              NoiSinh = sv.NoiSinh,
                              SDT = sv.SDT,
                              Lop = sv.Lop,
                              DonVi = sv.DonVi,
                              Khoa = sv.Khoa,
                              Email = sv.Email
                          }).ToList();
            List<Sinh_VienDTO> Loadrecord = new List<Sinh_VienDTO>();
            Loadrecord = Fillter_SV.Skip((page - 1) * recordNum).Take(recordNum).ToList();
            return Loadrecord;
        }
        public List<Sinh_VienDTO> Search_Ten(string Ten)
        {
            List<Sinh_VienDTO> Fillter_Ten = new List<Sinh_VienDTO>();
            Fillter_Ten = (from sv in db.SINH_VIEN
                          where sv.HoTen==Ten
                          select new Sinh_VienDTO
                          {
                              Mssv = sv.Mssv,
                              HoTen = sv.HoTen,
                              NgaySinh = sv.NgaySinh,
                              GioiTinh = sv.GioiTinh,
                              NoiSinh = sv.NoiSinh,
                              SDT = sv.SDT,
                              Lop = sv.Lop,
                              DonVi = sv.DonVi,
                              Khoa = sv.Khoa,
                              Email = sv.Email
                          }).ToList();
            return Fillter_Ten;
        }
    }
}
