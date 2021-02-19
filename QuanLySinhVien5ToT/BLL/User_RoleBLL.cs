using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    class User_RoleBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        private UserDAL UserDAL = new UserDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(USER entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public USER Get(Func<USER, bool> predicate)
        {
            return unitOfWorkNV.Repository<USER>().Get(predicate);
        }
        public List<USER> GetAll(Func<USER, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<USER>().GetAll(predicate);
        }
        public List<UserDTO> dsusser()
        {
            return UserDAL.Getdsuser();
        }
        public List<RoleDTO> dsrole()
        {
            return roleDAL.getRole();
        }
    }
}
