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
    class User_RoleBLL
    {
        private RoleDAL roleDAL = new RoleDAL();
        private UserDAL UserDAL = new UserDAL();
        private GenericUnitOfWork unitOfWorkNV = new GenericUnitOfWork(Mydb.GetInstance());
        public void Add(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Add(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Delete(USER entity)
        {
            unitOfWorkNV.Repository<USER>().Delete(entity);
            unitOfWorkNV.SaveChanges();
        }
        public void Edit(USER entity)
        {
            unitOfWorkNV.SaveChanges();
        }
        public USER Get(Func<USER, bool> predicate)
        {
            return unitOfWorkNV.Repository<USER>().Get(predicate);
        }
        public List<USER> GetAll(Func<USER, bool> predicate = null)
        {
            return unitOfWorkNV.Repository<USER>().GetAll(predicate);
        }
        public List<UserDTO> dsusser()
        {
            return UserDAL.Getdsuser();
        }
        public List<RoleDTO> dsrole()
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
        
    }
}
