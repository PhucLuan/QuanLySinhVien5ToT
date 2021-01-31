using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class RoleDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<RoleDTO> getRole()
        {

            List<RoleDTO> roleDTOs = new List<RoleDTO>();
            roleDTOs = (from role in db.ROLEs
                                  select new RoleDTO
                                  {
                                      IDrole=role.IDrole,
                                      Role=role.Role1
                                  }).ToList();
            return roleDTOs;
        }
    }
}
