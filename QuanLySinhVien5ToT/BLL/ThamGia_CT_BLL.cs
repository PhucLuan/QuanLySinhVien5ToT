﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class ThamGia_CT_BLL
    {
        private Sinh_VienDAL sinh_VienDAL = new Sinh_VienDAL();
        private Chuong_TrinhDAL chuong_TrinhDAL = new Chuong_TrinhDAL();
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private Thoi_Gian_XetDAL thoi_Gian_XetDAL = new Thoi_Gian_XetDAL();
        private ThamGia_ChuongtrinhDAL thamGia_ChuongtrinhDAL = new ThamGia_ChuongtrinhDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(THAMGIA_CHUONGTRINH entity)
        {
            unitOfWorkNV.Repository<THAMGIA_CHUONGTRINH>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(THAMGIA_CHUONGTRINH entity)
        {
            unitOfWorkNV.Repository<THAMGIA_CHUONGTRINH>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(THAMGIA_CHUONGTRINH entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public THAMGIA_CHUONGTRINH Get(Func<THAMGIA_CHUONGTRINH, bool> predicate)
        {
            return unitOfWorkNV.Repository<THAMGIA_CHUONGTRINH>().Get(predicate);
        }
        public List<THAMGIA_CHUONGTRINH> GetAll(Func<THAMGIA_CHUONGTRINH, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<THAMGIA_CHUONGTRINH>().GetAll(predicate);
        }
        public List<ThanGia_ChuongtrinhDTO> dsthamgiaCT() 
        {
            return thamGia_ChuongtrinhDAL.getTG_CT();
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
        public List<Chuong_TrinhDTO> dschuongtrinh()
        {
            return chuong_TrinhDAL.getChuongTrinh();
        }
        public List<Don_ViDTO> dsdonvi()
        {
            return don_ViDAL.GetDonVi();
        }
        public List<Sinh_VienDTO> dssinhvien()
        {
            return sinh_VienDAL.Getdssinhvien();
        }
    }
}
