using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class NhanVienDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<NhanVienDTO> getnhanvien()
        {
            List<NhanVienDTO> nhanVienDTOs = new List<NhanVienDTO>();
            nhanVienDTOs = (from nv in db.NHANVIENs
                            select new NhanVienDTO
                            {
                                IDnv=nv.IDnv,
                                Email=nv.Email,
                                Name=nv.Name,                              
                            }).ToList();
            return nhanVienDTOs;
        }
    }
}
