﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QL_DiemBLL
    {
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private LoaiDiemDAL loaiDiemDAL = new LoaiDiemDAL();
        private HocKy_XetDiemDAL hocKy_XetDiemDAL = new HocKy_XetDiemDAL();
        private DiemDAL diemDAL = new DiemDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        private Dictionary<string, string> DicTimeFormatted;

        public void Add(DIEM entity)
        {
            unitOfWorkNV.Repository<DIEM>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(DIEM entity)
        {
            unitOfWorkNV.Repository<DIEM>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(DIEM entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public DIEM Get(Func<DIEM, bool> predicate)
        {
            return unitOfWorkNV.Repository<DIEM>().Get(predicate);
        }
        public List<DIEM> GetAll(Func<DIEM, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<DIEM>().GetAll(predicate);
        }
        public List<DiemDTO> dsdiem()
        {
            return diemDAL.getDiem();
        }
        public Dictionary<string, string> showTime()
        {
            DicTimeFormatted = new Dictionary<string, string>();
            hocKy_XetDiemDAL.getTime2()
                .ForEach(x => DicTimeFormatted
                .Add(x.MaHocKy.ToString(),
                x.HocKy+" - "+x.Nam));
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
        public List<LoaiDiemDTO> dsloaidiem()
        {
            return loaiDiemDAL.getloaidiem();
        }
        public List<Don_ViDTO> dsdonvi() 
        {
            return don_ViDAL.GetDonVi();
        }
    }
}
