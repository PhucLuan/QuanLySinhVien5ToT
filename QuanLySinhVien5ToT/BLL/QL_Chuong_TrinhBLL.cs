using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QL_Chuong_TrinhBLL
    {
        private Tieu_ChuanDAL tieu_ChuanDAL = new Tieu_ChuanDAL();
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private Chuong_TrinhDAL Chuong_TrinhDAL = new Chuong_TrinhDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(CHUONG_TRINH entity)
        {
            unitOfWorkNV.Repository<CHUONG_TRINH>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(CHUONG_TRINH entity)
        {
            unitOfWorkNV.Repository<CHUONG_TRINH>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(CHUONG_TRINH entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public CHUONG_TRINH Get(Func<CHUONG_TRINH, bool> predicate)
        {
            return unitOfWorkNV.Repository<CHUONG_TRINH>().Get(predicate);
        }
        public List<CHUONG_TRINH> GetAll(Func<CHUONG_TRINH, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<CHUONG_TRINH>().GetAll(predicate);
        }
        public List<Chuong_TrinhDTO> dschuongtrinh()
        {
            return Chuong_TrinhDAL.getChuongTrinh();
        }
        public List<Don_ViDTO> dsdonvi()
        {
            return don_ViDAL.GetDonVi();
        }
        public List<Tieu_ChuanDTO> dstieuchuan()
        {
            return tieu_ChuanDAL.getTieuChuan();
        }
    }
}
