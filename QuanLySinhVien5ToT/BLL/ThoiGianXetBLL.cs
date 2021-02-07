using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class ThoiGianXetBLL
    {
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(THOIGIAN_XET entity)
        {
            unitOfWorkNV.Repository<THOIGIAN_XET>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(THOIGIAN_XET entity)
        {
            unitOfWorkNV.Repository<THOIGIAN_XET>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(THOIGIAN_XET entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public THOIGIAN_XET Get(Func<THOIGIAN_XET, bool> predicate)
        {
            return unitOfWorkNV.Repository<THOIGIAN_XET>().Get(predicate);
        }
        public List<THOIGIAN_XET> GetAll(Func<THOIGIAN_XET, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<THOIGIAN_XET>().GetAll(predicate);
        }
        public List<Thoi_Gian_XetDTO> dsthoigian()
        {
            return thoi_Gian_XetDAL.getthoigian();
        }
    }
}
