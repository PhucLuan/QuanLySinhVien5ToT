using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class ThoiDiemSV_ThamGiaBLL
    {
        private Thoi_Gian_XetDAL Thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private ThoiDiemSV_ThamGiaDAL thoiDiemSV_ThamGiaDAL = new ThoiDiemSV_ThamGiaDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(THOIDIEM_SV_THAMGIA entity)
        {
            unitOfWorkNV.Repository<THOIDIEM_SV_THAMGIA>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(THOIDIEM_SV_THAMGIA entity)
        {
            unitOfWorkNV.Repository<THOIDIEM_SV_THAMGIA>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(THOIDIEM_SV_THAMGIA entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public THOIDIEM_SV_THAMGIA Get(Func<THOIDIEM_SV_THAMGIA, bool> predicate)
        {
            return unitOfWorkNV.Repository<THOIDIEM_SV_THAMGIA>().Get(predicate);
        }
        public List<THOIDIEM_SV_THAMGIA> GetAll(Func<THOIDIEM_SV_THAMGIA, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<THOIDIEM_SV_THAMGIA>().GetAll(predicate);
        }
        //public List<ThoiDiemSV_ThamGiaDTO> dssinhvienTG()
        //{
        //   return thoiDiemSV_ThamGiaDAL.getSV_TG();
        //}
        public Dictionary<string, string> showTime()
        {
            DicTimeFormatted = new Dictionary<string, string>();
            Thoi_Gian_XetDAL.getthoigian()
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
    }
}
