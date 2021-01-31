using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Don_ViDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Don_ViDTO> GetDonVi()
        {
            List<Don_ViDTO> listDV = new List<Don_ViDTO>();
            listDV = (from dv in db.DON_VI
                      select new Don_ViDTO {
                          MaDonVi=dv.MaDonVi,
                          TenDonVi=dv.TenDonVi
                      }).ToList();

            return listDV;
            
        }
        public List<Don_ViDTO> SearchDV(string search)
        {
            List<Don_ViDTO> listDV = new List<Don_ViDTO>();
            listDV = (from dv in db.DON_VI
                      where dv.MaDonVi== search || dv.TenDonVi== search
                      select new Don_ViDTO
                      {
                          MaDonVi = dv.MaDonVi,
                          TenDonVi = dv.TenDonVi
                      }).ToList();

            return listDV;

        }
    }
}
