using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QL_DV_BLL
    {
        private Don_ViDAL Don_ViDAL = new Don_ViDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());

        public void Add(DON_VI entity)
        {
            unitOfWorkNV.Repository<DON_VI>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(DON_VI entity)
        {
            unitOfWorkNV.Repository<DON_VI>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(DON_VI entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public DON_VI Get(Func<DON_VI, bool> predicate)
        {
            return unitOfWorkNV.Repository<DON_VI>().Get(predicate);
        }
        public List<DON_VI> GetAll(Func<DON_VI, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<DON_VI>().GetAll(predicate);
        }
        public List<DON_VI> GetAlDonVi(Func<DON_VI, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<DON_VI>().GetAll(predicate);
        }
        public List<Don_ViDTO> dsDonVi()
        {
            return Don_ViDAL.GetDonVi();
        }
        public List<Don_ViDTO> searchdv(string search)
        {
            return Don_ViDAL.SearchDV(search);
        }
    }
}
