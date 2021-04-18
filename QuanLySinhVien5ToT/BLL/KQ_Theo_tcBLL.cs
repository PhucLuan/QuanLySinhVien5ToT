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
    public class KQ_Theo_tcBLL
    {
        private Sinh_VienDAL sinh_VienDAL = new Sinh_VienDAL();
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private Thoi_Gian_XetDTO thoi_Gian_XetDTO = new Thoi_Gian_XetDTO();
        private Tieu_ChiDAL tieu_ChiDAL = new Tieu_ChiDAL();
        private Kq_Theo_tcDAL kq_Theo_TcDAL = new Kq_Theo_tcDAL();
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private check_IP_mssv check_IP_Mssv = new check_IP_mssv();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;
        private Dictionary<int, string> DicDanhGia;

        public void Add(KQ_THEO_TIEUCHI entity)
        {
            unitOfWorkNV.Repository<KQ_THEO_TIEUCHI>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(KQ_THEO_TIEUCHI entity)
        {
            unitOfWorkNV.Repository<KQ_THEO_TIEUCHI>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(KQ_THEO_TIEUCHI entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public KQ_THEO_TIEUCHI Get(Func<KQ_THEO_TIEUCHI, bool> predicate)
        {
            return unitOfWorkNV.Repository<KQ_THEO_TIEUCHI>().Get(predicate);
        }
        public List<KQ_THEO_TIEUCHI> GetAll(Func<KQ_THEO_TIEUCHI, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<KQ_THEO_TIEUCHI>().GetAll(predicate);
        }
        public List<Thoi_Gian_XetDTO> dsthoigian()
        {
            return thoi_Gian_XetDAL.getthoigian();
        }
        public List<Kq_Theo_tcDTO> DsKQ()
        {
            return kq_Theo_TcDAL.getKQ();
        }
        public List<Tieu_ChiDTO> dstieuchi()
        {
            return tieu_ChiDAL.gettieuchi();
        }
        public Dictionary<string,string> showTime()
        {
            DicTimeFormatted = new Dictionary<string,string>();
            thoi_Gian_XetDAL.getthoigian()
                .ForEach(x => DicTimeFormatted
                .Add(x.MaThoiGian.ToString(),
                ((DateTime)x.TuNgay).ToString("d/M/yyyy") + "_" 
                + ((DateTime)x.DenNgay).ToString("d/M/yyyy")));
            return DicTimeFormatted;
        }
        public Dictionary<int,string> ShowDanhGia()
        {
            DicDanhGia = new Dictionary<int, string>()
            {
                { 0,"Không Đạt"},{ 1,"Cấp Trường"},{ 2,"Cấp Khoa"}
            };
            return DicDanhGia;
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
