using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.DAL
{
    public class Thoi_Gian_XetDAL
    {
        DT_QL_SV5TOT_5Entities2 db = Mydb.GetInstance();
        public List<Thoi_Gian_XetDTO> getthoigian()
        {
            List<Thoi_Gian_XetDTO> thoi_Gian_XetDTOs = new List<Thoi_Gian_XetDTO>();
            thoi_Gian_XetDTOs = (from tg in db.THOIGIAN_XET                            
                                 select new Thoi_Gian_XetDTO 
                                 { 
                                     MaThoiGian=tg.MaThoiGian,
                                     TuNgay=tg.TuNgay,
                                     DenNgay=tg.DenNgay,
                                     TrangThai=tg.TrangThai
                                 }).ToList();
            return thoi_Gian_XetDTOs;
        }
    }
}
