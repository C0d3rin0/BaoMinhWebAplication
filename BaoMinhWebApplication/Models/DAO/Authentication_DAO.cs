using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoMinhWebApplication.Models.DAO
{
    static public class Authentication_DAO
    {
        public static bool KiemTraEmailTonTai(string Email)
        {
            Entities entities = new Entities();
            bool KetQua = entities.TaiKhoan.Where(TaiKhoan => TaiKhoan.TenDangNhap == Email).Any();
            return KetQua;
        }

        public static bool TaoTaiKhoan(createUserViewModel vm)
        {
            if (KiemTraEmailTonTai(vm.Email))
                return false;

            Entities entities = new Entities();
            TaiKhoan TaiKhoan = new TaiKhoan();
            TaiKhoan.Ten = vm.HoTen;
            TaiKhoan.TenDangNhap = vm.Email;
            TaiKhoan.MatKhau = SecurePasswordHasher.Hash(vm.MatKhau);
            
            foreach(int MaNhom in vm.MaNhom.OrEmptyIfNull())
            {
                Nhom nhom = entities.Nhoms.Where(p => p.id == MaNhom).First();
                TaiKhoan.Nhom.Add(nhom);
            }

            entities.TaiKhoan.Add(TaiKhoan);
            entities.SaveChanges();

            return true;
        }



        public static TaiKhoan layTaiKhoan(string Email,string Password)
        {
            string MatKhau = SecurePasswordHasher.Hash(Password);

            Entities entities = new Entities();
            var TaiKhoans = entities.
                TaiKhoan.
                Where(
                TaiKhoan => 
                TaiKhoan.TenDangNhap == Email).
                ToList();

            if (TaiKhoans.Count < 1)
                return null;

            TaiKhoan user = TaiKhoans.First();
            if (SecurePasswordHasher.Verify(Password, user.MatKhau ))
                return user;

            else return null;

        }
    }
}