using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien5ToT.Services
{
    public class ReviewScroreService
    {
        public static void ReviewScrore(DT_QL_SV5TOT_5Entities2 db, DIEM diemSV)
        {
            var hocKy = db.HOCKY_XETDIEM.FirstOrDefault(x => x.MaHocKy == diemSV.MaHocKy);
            var tgianXet = db.THOIGIAN_XET.FirstOrDefault(x => x.MaThoiGian == hocKy.MaThoiGianXetDiem);
            //db.DIEMs.Add(diemSV);
            //Điểm được add vào phải trong thời gian xét
            if (tgianXet.TrangThai == true)
            {
                var sinhVien = db.SINH_VIEN.FirstOrDefault(x => x.Mssv == diemSV.Mssv);
                var LoaiDiem = db.LOAI_DIEM.FirstOrDefault(x => x.MaLoaiDiem == diemSV.MaLoaiDiem);
                var ListMaHocky = db.HOCKY_XETDIEM
                    .Where(x => x.MaThoiGianXetDiem == tgianXet.MaThoiGian)
                    .Select(x => x.MaHocKy).ToList();

                var QDdiemToiThieu_Truong = db.QUYDINH_DIEM
                        .Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem &&
                            x.MaDonVi == "HSVT" &&
                            x.Mathoigian == tgianXet.MaThoiGian)
                        .FirstOrDefault();

                var QDdiemToiThieu_Donvi = db.QUYDINH_DIEM
                    .Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem &&
                        x.MaDonVi == sinhVien.DonVi &&
                        x.Mathoigian ==tgianXet.MaThoiGian)
                    .FirstOrDefault();

                if (LoaiDiem.TenLoaiDiem == "Điểm Kỹ năng mềm")
                {
                    AddTieuChuanDiemKNM(db, diemSV, QDdiemToiThieu_Truong, QDdiemToiThieu_Donvi, tgianXet.MaThoiGian);
                    db.SaveChanges();
                    return;
                }
                //Nếu sinh viên chưa có điểm ở kỳ trước đó thì chỉ cần insert ko cần xét đạt tiêu chuẩn hay ko --> đến khi có điểm của cả 2 kỳ mới xét
                if (db.DIEMs.Where(x => x.Mssv == diemSV.Mssv &&
                    x.MaLoaiDiem == diemSV.MaLoaiDiem && ListMaHocky.Contains((int)x.MaHocKy) ).ToList().Count() == 1)
                {
                    var DiemHocKyTruoc = db.DIEMs.Where(x => x.MaLoaiDiem == diemSV.MaLoaiDiem && x.Mssv == diemSV.Mssv)
                        .Select(x => x.Diem1).FirstOrDefault();

                    

                    if (LoaiDiem.TenLoaiDiem == "Điểm rèn luyện")
                    {
                        AddTieuChuanDiemRenLuyen(db, diemSV, QDdiemToiThieu_Truong, QDdiemToiThieu_Donvi, (int)DiemHocKyTruoc, tgianXet.MaThoiGian);
                    }
                    else
                    {
                        AddTieuChuanDiemKhac(db, diemSV, QDdiemToiThieu_Truong, QDdiemToiThieu_Donvi, (int)DiemHocKyTruoc, tgianXet.MaThoiGian);
                    }

                }

                db.SaveChanges();
            }
            else
                throw new Exception("Điểm được thêm phải nằm trong thời gian xét");
        }
        //Xét đạt tiêu chuẩn cho Loại điểm là Điểm rèn luyện
        //Nếu điểm từng kỳ lớn hơn điểm tối thiểu thì đạt
        //Nếu lớn hơn điểm tối thiểu trường thì đạt cấp trường, khoa thì đạt cấp khoa, trường hợp nhỏ hơn ko làm gì cả
        private static void AddTieuChuanDiemRenLuyen(DT_QL_SV5TOT_5Entities2 db, DIEM diemSV,
            QUYDINH_DIEM QDdiemToiThieu_Truong,
            QUYDINH_DIEM QDdiemToiThieu_Donvi,
            int DiemHocKyTruoc, int maTGianXet)
        {
            if (DiemHocKyTruoc >= ((int)QDdiemToiThieu_Truong.DiemToiThieu) && (int)diemSV.Diem1 >= ((int)QDdiemToiThieu_Truong.DiemToiThieu))
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Truong.MaTieuChuan,
                    MaThoiGian = maTGianXet
                });
            }
            else if (DiemHocKyTruoc >= ((int)QDdiemToiThieu_Donvi.DiemToiThieu) && (int)diemSV.Diem1 >= ((int)QDdiemToiThieu_Donvi.DiemToiThieu))
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Donvi.MaTieuChuan,
                    MaThoiGian = maTGianXet
                });
            }
        }
        //Xét đạt tiêu chuẩn cho loại điểm khác
        //Nếu điểm trung bình 2 kỳ xét lớn hơn quy định tối thiểu thì đạt
        //Nếu lớn hơn điểm tối thiểu trường thì đạt cấp trường, khoa thì đạt cấp khoa, trường hợp nhỏ hơn ko làm gì cả
        private static void AddTieuChuanDiemKhac(DT_QL_SV5TOT_5Entities2 db, DIEM diemSV,
            QUYDINH_DIEM QDdiemToiThieu_Truong,
            QUYDINH_DIEM QDdiemToiThieu_Donvi,
            int DiemHocKyTruoc, int maTGianXet)
        {
            if (((int)DiemHocKyTruoc + (int)diemSV.Diem1) / 2 >= (int)QDdiemToiThieu_Truong.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Truong.MaTieuChuan,
                    MaThoiGian = maTGianXet
                });
            }
            else if (((int)DiemHocKyTruoc + (int)diemSV.Diem1) / 2 >= (int)QDdiemToiThieu_Donvi.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Donvi.MaTieuChuan,
                    MaThoiGian = maTGianXet
                });
            }
        }


        private static void AddTieuChuanDiemKNM(DT_QL_SV5TOT_5Entities2 db, DIEM diemSV,
            QUYDINH_DIEM QDdiemToiThieu_Truong,
            QUYDINH_DIEM QDdiemToiThieu_Donvi, int maTGianXet)
        {
            if (diemSV.Diem1 >= QDdiemToiThieu_Truong.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Truong.MaTieuChuan,
                    MaThoiGian = maTGianXet
                });
            }
            else if (diemSV.Diem1 >= QDdiemToiThieu_Donvi.DiemToiThieu)
            {
                db.THUCHIEN_TIEUCHUAN.Add(new THUCHIEN_TIEUCHUAN
                {
                    Mssv = diemSV.Mssv,
                    MaTieuChuan = (int)QDdiemToiThieu_Donvi.MaTieuChuan,
                    MaThoiGian =  maTGianXet
                });
            }
        }
    }
}
