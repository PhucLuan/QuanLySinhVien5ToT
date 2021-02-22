using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien5ToT.DAL;
using QuanLySinhVien5ToT.DTO;

namespace QuanLySinhVien5ToT.BLL
{
    public class QL_NhanVienBLL
    {
        private Don_ViDAL don_ViDAL = new Don_ViDAL();
        private RoleDAL roleDAL = new RoleDAL();
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());

        public void Add(NHANVIEN entity)
        {
            unitOfWorkNV.Repository<NHANVIEN>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void AddUser(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(NHANVIEN entity)
        {
            unitOfWorkNV.Repository<NHANVIEN>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(NHANVIEN entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public NHANVIEN Get(Func<NHANVIEN, bool> predicate)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().Get(predicate);
        }
        public USER GetUser(Func<USER, bool> predicate)
        {
            return unitOfWorkNV.Repository<USER>().Get(predicate);
        }
        public List<NHANVIEN> GetAll(Func<NHANVIEN, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<NHANVIEN>().GetAll(predicate);
        }
        public List<NhanVienDTO> dsnhanvien()
        {
            return nhanVienDAL.getnhanvien();
        }
        public List<RoleDTO> dsRole()
        {
            return roleDAL.getRole();
        }
        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {


            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));


            var sBuilder = new StringBuilder();


            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }


            return sBuilder.ToString();
        }
        public string MyHashMD5(string _input)
        {
            char[] char_input = _input.ToCharArray();
            var input_withIndex = char_input.Select((val, ind) => new { val, ind }).ToArray();
            var char_input_encripted = input_withIndex.Select(c => c.val + c.ind + (input_withIndex.Length > c.ind + 1 ?
                                       input_withIndex[c.ind + 1].val % 2 : 0)).Select(c => (char)c).ToArray();

            string resval = new string(char_input_encripted);
            return resval;
        }
        public string Mahoa(string _input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetHash(md5Hash, _input);
                return MyHashMD5(hash);
            }
        }
        public List<Don_ViDTO> dsdonvi()
        {
            return don_ViDAL.GetDonVi();
        }
    }
}
