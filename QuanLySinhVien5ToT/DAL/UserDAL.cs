using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class UserDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<UserDTO> Getdsuser()
        {
            List<UserDTO> UserDTO = new List<UserDTO>();
            UserDTO = (from us in db.USERs
                          from role in db.ROLEs
                          where us.IDrole==role.IDrole
                          select new UserDTO
                          {
                              IDuser=us.IDuser,
                              Username=us.Username,
                              Password=us.Password,
                              Role=role.Role1
                          }).ToList();            
            return UserDTO;
        }
    }
}
