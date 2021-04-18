using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class EditTieuChiBLL
    {
        private Tieu_ChiDAL tieu_ChiDAL = new Tieu_ChiDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());

        public void Add(TIEU_CHI entity)
        {
            unitOfWorkNV.Repository<TIEU_CHI>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(TIEU_CHI entity)
        {
            unitOfWorkNV.Repository<TIEU_CHI>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(TIEU_CHI entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public TIEU_CHI Get(Func<TIEU_CHI, bool> predicate)
        {
            return unitOfWorkNV.Repository<TIEU_CHI>().Get(predicate);
        }
        public List<TIEU_CHI> GetAll(Func<TIEU_CHI, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<TIEU_CHI>().GetAll(predicate);
        }
        public List<Tieu_ChiDTO> dstieuchi()
        {
            return tieu_ChiDAL.gettieuchi();
        }
    }
}
