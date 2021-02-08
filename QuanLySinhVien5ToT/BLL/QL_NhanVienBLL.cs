using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QL_NhanVienBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());

        public void Add(NHANVIEN entity)
        {
            unitOfWorkNV.Repository<NHANVIEN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void AddUser(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(NHANVIEN entity)
        {
            unitOfWorkNV.Repository<NHANVIEN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(NHANVIEN entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public NHANVIEN Get(Func<NHANVIEN, bool> predicate)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().Get(predicate);
        }
        public USER GetUser(Func<USER, bool> predicate)
        {
            return unitOfWorkNV.Repository<USER>().Get(predicate);
        }
        public List<NHANVIEN> GetAll(Func<NHANVIEN, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().GetAll(predicate);
        }
        public List<NhanVienDTO> dsnhanvien()
        {
            return nhanVienDAL.getnhanvien();
        }
        public List<RoleDTO> dsRole()
        {
            return roleDAL.getRole();
        }
    }
}
