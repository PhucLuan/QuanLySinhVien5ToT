//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySinhVien5ToT
{
    using System;
    using System.Collections.Generic;
    
    public partial class THAMGIA_CHUONGTRINH
    {
        public string Mssv { get; set; }
        public int MaChuongTrinh { get; set; }
        public string Giai { get; set; }
        public Nullable<int> MaThoiGian { get; set; }
    
        public virtual CHUONG_TRINH CHUONG_TRINH { get; set; }
        public virtual SINH_VIEN SINH_VIEN { get; set; }
        public virtual THOIGIAN_XET THOIGIAN_XET { get; set; }
    }
}
