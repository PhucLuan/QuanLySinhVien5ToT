using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class EditLoaiDiemBLL
    {
        private LoaiDiemDAL loaiDiemDAL = new LoaiDiemDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());

        public void Add(LOAI_DIEM entity)
        {
            unitOfWorkNV.Repository<LOAI_DIEM>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(LOAI_DIEM entity)
        {
            unitOfWorkNV.Repository<LOAI_DIEM>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(LOAI_DIEM entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public LOAI_DIEM Get(Func<LOAI_DIEM, bool> predicate)
        {
            return unitOfWorkNV.Repository<LOAI_DIEM>().Get(predicate);
        }
        public List<LOAI_DIEM> GetAll(Func<LOAI_DIEM, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<LOAI_DIEM>().GetAll(predicate);
        }
        public List<LoaiDiemDTO> dsloaidiem()
        {
            return loaiDiemDAL.getloaidiem();
        }
    }
}
