using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class Edit_RoleBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        private UserDAL UserDAL = new UserDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(ROLE entity)
        {
            unitOfWorkNV.Repository<ROLE>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(ROLE entity)
        {
            unitOfWorkNV.Repository<ROLE>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(ROLE entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public ROLE Get(Func<ROLE, bool> predicate)
        {
            return unitOfWorkNV.Repository<ROLE>().Get(predicate);
        }
        public List<ROLE> GetAll(Func<ROLE, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<ROLE>().GetAll(predicate);
        }
        public List<RoleDTO> dsrole()
        {
            return roleDAL.getRole();
        }
    }
}
