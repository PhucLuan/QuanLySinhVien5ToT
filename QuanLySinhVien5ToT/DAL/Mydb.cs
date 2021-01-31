namespace QuanLySinhVien5ToT
{
    public class Mydb
    {
        private static DT_QL_SV5TOT_5Entities2 dbContext { get; set; }
        public static DT_QL_SV5TOT_5Entities2 GetInstance()
        {
            if (dbContext == null)
            {
                dbContext = new DT_QL_SV5TOT_5Entities2();
            }

            return dbContext;
        }
    }
}
