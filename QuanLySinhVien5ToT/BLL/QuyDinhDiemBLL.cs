using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QuyDinhDiemBLL
    {
        private QuyDinhDiemDAL QuyDinhDiemDAL = new QuyDinhDiemDAL();
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private Tieu_ChuanDAL tieu_ChuanDAL = new Tieu_ChuanDAL();
        private LoaiDiemDAL loaiDiemDAL = new LoaiDiemDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(QUYDINH_DIEM entity)
        {
            unitOfWorkNV.Repository<QUYDINH_DIEM>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(QUYDINH_DIEM entity)
        {
            unitOfWorkNV.Repository<QUYDINH_DIEM>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(QUYDINH_DIEM entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public QUYDINH_DIEM Get(Func<QUYDINH_DIEM, bool> predicate)
        {
            return unitOfWorkNV.Repository<QUYDINH_DIEM>().Get(predicate);
        }
        public List<QUYDINH_DIEM> GetAll(Func<QUYDINH_DIEM, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<QUYDINH_DIEM>().GetAll(predicate);
        }
        public List<QuyDinhDiemDTO> dsQD()
        {
            return QuyDinhDiemDAL.getQDD();
        }
        public Dictionary<string, string> showTime()
        {
            DicTimeFormatted = new Dictionary<string, string>();
            thoi_Gian_XetDAL.getthoigian()
                .ForEach(x => DicTimeFormatted
                .Add(x.MaThoiGian.ToString(),
                ((DateTime)x.TuNgay).ToString("d/M/yyyy") + "_"
                + ((DateTime)x.DenNgay).ToString("d/M/yyyy")));
            return DicTimeFormatted;
        }

        public string GetIdFormattedDateTime(string value)
        {
            if (DicTimeFormatted != null)
            {
                foreach (var item in DicTimeFormatted)
                {
                    if (item.Value == value)
                    {
                        return item.Key;
                    }
                }
            }
            return null;
        }
        public List<Don_ViDTO> dsdonvi()
        {
            return don_ViDAL.GetDonVi();
        }
        public List<Tieu_ChuanDTO> dstieuchuan()
        {
            return tieu_ChuanDAL.getTieuChuan();
        }
        public List<LoaiDiemDTO> dsloaidiem()
        {
            return loaiDiemDAL.getloaidiem();
        }
    }
}
