using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class ThongTinPQ_DAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<ThongTinPQ_DTO> getPQ(string username, string password)
        {
            List<ThongTinPQ_DTO> thongTinPQ_DTOs = new List<ThongTinPQ_DTO>();
            thongTinPQ_DTOs = (from nv in db.NHANVIENs
                               from us in db.USERs
                               from role in db.ROLEs
                               where nv.IDuser == us.IDuser && us.IDrole==role.IDrole && us.Username==username && us.Password==password
                               select new ThongTinPQ_DTO
                               {
                                   IDuser=us.IDuser,
                                   Role=role.Role1,
                                   DonVi=nv.DonVi,
                                   Name=nv.Name
                               }).ToList();
            return thongTinPQ_DTOs;
        }
    }
}
