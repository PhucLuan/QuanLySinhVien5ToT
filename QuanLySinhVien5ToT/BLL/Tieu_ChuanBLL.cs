using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class Tieu_ChuanBLL
    {
        private Tieu_ChuanDAL Tieu_ChuanDAL = new Tieu_ChuanDAL();
        private Cap_Tieu_ChuanDAL cap_Tieu_ChuanDAL = new Cap_Tieu_ChuanDAL();
        private Tieu_ChiDAL Tieu_ChiDAL = new Tieu_ChiDAL();
        private Loai_Tieu_ChuanDAL Loai_Tieu_ChuanDAL = new Loai_Tieu_ChuanDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(TIEU_CHUAN entity)
        {
            unitOfWorkNV.Repository<TIEU_CHUAN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(TIEU_CHUAN entity)
        {
            unitOfWorkNV.Repository<TIEU_CHUAN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(TIEU_CHUAN entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public TIEU_CHUAN Get(Func<TIEU_CHUAN, bool> predicate)
        {
            return unitOfWorkNV.Repository<TIEU_CHUAN>().Get(predicate);
        }
        public List<TIEU_CHUAN> GetAll(Func<TIEU_CHUAN, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<TIEU_CHUAN>().GetAll(predicate);
        }
        public List<Tieu_ChuanDTO> dsTieuChuan()
        {
            return Tieu_ChuanDAL.getTieuChuan();
        }
        public List<Tieu_ChiDTO> dstieuchi()
        {
            return Tieu_ChiDAL.gettieuchi();
        }
        public List<Cap_Tieu_ChuanDTO> dscaptieuchuan()
        {
            return cap_Tieu_ChuanDAL.getcaptieuchuan();
        }
        public List<Loai_Tieu_ChuanDTO> dsloaitieuchuan()
        {
            return Loai_Tieu_ChuanDAL.getloaitieuchuan();
        }
    }
}
