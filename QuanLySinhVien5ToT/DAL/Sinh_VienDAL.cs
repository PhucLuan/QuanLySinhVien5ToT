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
        public List<Sinh_VienDTO> Getdssinhvien()
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
            return sinh_Viens ;
        }
        
    }
}
