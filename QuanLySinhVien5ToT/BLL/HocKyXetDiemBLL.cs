using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class HocKyXetDiemBLL
    {
        private HocKy_XetDiemDAL HocKy_XetDiemDAL = new HocKy_XetDiemDAL();
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(HOCKY_XETDIEM entity)
        {
            unitOfWorkNV.Repository<HOCKY_XETDIEM>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(HOCKY_XETDIEM entity)
        {
            unitOfWorkNV.Repository<HOCKY_XETDIEM>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(HOCKY_XETDIEM entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public HOCKY_XETDIEM Get(Func<HOCKY_XETDIEM, bool> predicate)
        {
            return unitOfWorkNV.Repository<HOCKY_XETDIEM>().Get(predicate);
        }
        public List<HOCKY_XETDIEM> GetAll(Func<HOCKY_XETDIEM, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<HOCKY_XETDIEM>().GetAll(predicate);
        }
        public List<HocKy_XetDiemDTO> dsHK()
        {
            return HocKy_XetDiemDAL.getTime2();
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
    }
}
