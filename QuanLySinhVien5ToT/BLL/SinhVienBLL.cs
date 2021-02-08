using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class SinhVienBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        private Sinh_VienDAL Sinh_VienDAL = new Sinh_VienDAL();
        private Don_ViDAL Don_ViDAL = new Don_ViDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(SINH_VIEN entity)
        {
            unitOfWorkNV.Repository<SINH_VIEN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void AddUser(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(SINH_VIEN entity)
        {
            unitOfWorkNV.Repository<SINH_VIEN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(SINH_VIEN entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public SINH_VIEN Get(Func<SINH_VIEN, bool> predicate)
        {
            return unitOfWorkNV.Repository<SINH_VIEN>().Get(predicate);
        }
        public USER GetUser(Func<USER, bool> predicate)
        {
            return unitOfWorkNV.Repository<USER>().Get(predicate);
        }
        public List<SINH_VIEN> GetAll(Func<SINH_VIEN,bool> predicate = null)
        {
            return unitOfWorkNV.Repository<SINH_VIEN>().GetAll(predicate);
        }
        public List<DON_VI> GetAlDonVi(Func<DON_VI, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<DON_VI>().GetAll(predicate);
        }
        public IEnumerable<SINH_VIEN> Search(string keyvalue)
        {
            return unitOfWorkNV.Repository<SINH_VIEN>().GetAll(x => x.HoTen.Contains(keyvalue));
        }
        public List<Sinh_VienDTO> DsSinhVien()
        {
            return Sinh_VienDAL.Getdssinhvien();
        }
        //public List<Sinh_VienDTO> Search_Ten(string Ten)
        //{
        //    return Sinh_VienDAL.Search_Ten(Ten);
        //}
        public List<Don_ViDTO> dsDonVi()
        {
            return Don_ViDAL.GetDonVi();
        }
        public List<RoleDTO> dsrole()
        {
            return roleDAL.getRole();
        }
    }
}