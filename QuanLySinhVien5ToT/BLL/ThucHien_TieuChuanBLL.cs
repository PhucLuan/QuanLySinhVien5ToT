using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guna.UI2.WinForms;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;
using QuanLySinhVien5ToT.Services;

namespace QuanLySinhVien5ToT.BLL
{
    public class ThucHien_TieuChuanBLL
    {
        private Sinh_VienDAL sinh_VienDAL = new Sinh_VienDAL();
        private Tieu_ChuanDAL Tieu_ChuanDAL = new Tieu_ChuanDAL();
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private ThucHien_TieuChuanDAL thucHien_TieuChuanDAL = new ThucHien_TieuChuanDAL();
        private check_IP_mssv check_IP_Mssv = new check_IP_mssv();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(THUCHIEN_TIEUCHUAN entity)
        {
            unitOfWorkNV.Repository<THUCHIEN_TIEUCHUAN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(THUCHIEN_TIEUCHUAN entity)
        {
            unitOfWorkNV.Repository<THUCHIEN_TIEUCHUAN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(THUCHIEN_TIEUCHUAN entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public THUCHIEN_TIEUCHUAN Get(Func<THUCHIEN_TIEUCHUAN, bool> predicate)
        {
            return unitOfWorkNV.Repository<THUCHIEN_TIEUCHUAN>().Get(predicate);
        }
        public List<THUCHIEN_TIEUCHUAN> GetAll(Func<THUCHIEN_TIEUCHUAN, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<THUCHIEN_TIEUCHUAN>().GetAll(predicate);
        }
        public List<ThucHien_TieuChuanDTO> dsthuchienTC()
        {
            return thucHien_TieuChuanDAL.getTH_TC();
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
        public List<Tieu_ChuanDTO> dstieuchuan()
        {
            return Tieu_ChuanDAL.getTieuChuanDiem();
        }
        public List<Don_ViDTO> dsdonvi()
        {
            return don_ViDAL.GetDonVi();
        }
        public List<Sinh_VienDTO> dssinhvien()
        {
            return sinh_VienDAL.Getdssinhvien();
        }
        public void check_input_mssv(Guna2TextBox textBox)
        {
            check_IP_Mssv.check_Input_Mssv(textBox);
        }
    }
}
