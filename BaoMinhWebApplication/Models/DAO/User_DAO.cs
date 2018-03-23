using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace BaoMinhWebApplication.Models.DAO
{
    public class User_DAO
    {
        



        public static object update(int id,updateUserViewModel ViewModel)
        {
            var entities = new Entities();
            var User = entities
                .TaiKhoan
                .Where(u => u.id == id).First();

            User.Ten = ViewModel.HoTen;
            User.TenDangNhap = ViewModel.Email;
            List<Nhom> nhoms = new List<Nhom>();
            foreach (int MaNhom in ViewModel.MaNhom.OrEmptyIfNull())
            {
                Nhom nhom = entities.Nhoms.Where(p => p.id == MaNhom).First();
                nhoms.Add(nhom);
                
            }

            User.Nhom = nhoms;
            entities.SaveChanges();
            return new {
                Fullname = User.Ten,
                Email = User.TenDangNhap,
                Id = User.id,
                State = User.TrangThai
            };
        }

        public static void changePassword(int id,string Password)
        {
            var Entity = new Entities();
            var User = Entity
                .TaiKhoan
                .Where(u => u.id == id).First();

            if (User == null)
                return;

            User.MatKhau = SecurePasswordHasher.Hash(Password);
            Entity.SaveChanges();
        }

        public static IQueryable<TaiKhoan> searchUser(string Email)
        {
            var Entity = new Entities();
            var Users = Entity
                .TaiKhoan
                .Where(u=>u.TenDangNhap.Contains(Email));
            return Users;
        }

        public static IEnumerable<TaiKhoan> getUser(string Email)
        {
            IEnumerable<TaiKhoan> Users;
            if (!string.IsNullOrEmpty(Email))
                Users = searchUser(Email);
            else
            {
                Entities entities = new Entities();
                Users = entities.TaiKhoan.Select(u => u);
            }

            return Users;
        }

        public static AccountResultSearchViewModel[] getNext(string Email, string keyNext,int Num)
        {
            IEnumerable<TaiKhoan> Users = getUser(Email);
                

            if(keyNext !=null)
            {
                int Next = int.Parse(keyNext);
                Users = Users.Where(u => u.id > Next);
            }


            return Users
                .OrderBy(u=>u.id)
                .Take(Num)
                .Select(u => new AccountResultSearchViewModel { Email = u.TenDangNhap, Fullname = u.Ten, Id = u.id, State = u.TrangThai, LaAdmin = u.LaAdmin })
                .ToArray();
        }

        public static AccountResultSearchViewModel[] getPrev(string Email, string keyPrev,int num)
        {
            IEnumerable<TaiKhoan> Users = getUser(Email);

            if (keyPrev != null)
            {
                int Prev = int.Parse(keyPrev);
                Users = Users.Where(u => u.id < Prev);
            }


            return Users
                .OrderByDescending(u => u.id)
                .Reverse()
                .Take(num)
                .Select(u => new AccountResultSearchViewModel { Email = u.TenDangNhap, Fullname = u.Ten, Id = u.id, State = u.TrangThai } )
                .ToArray();
        }


        public static string[] searchName(string Name)
        {
            var Entity = new Entities();
            var Names = Entity
                .TaiKhoan
                .Where(u => u.Ten.Contains(Name))
                .Select(u => u.Ten).Take(10)
                .ToArray();

            return Names;
        }

        public static string[] searchEmail(string Email)
        {
            var Entity = new Entities();
            var Emails = Entity
                .TaiKhoan
                .Where(u => u.TenDangNhap.Contains(Email))
                .Select(u => u.TenDangNhap).Take(10)
                .ToArray();

            return Emails;
        }
    }


    public sealed class SecurePasswordHasher
    {
        /// <summary>
        /// Size of salt
        /// </summary>
        private const int SaltSize = 16;

        /// <summary>
        /// Size of hash
        /// </summary>
        private const int HashSize = 20;

        /// <summary>
        /// Creates a hash from a password
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="iterations">number of iterations</param>
        /// <returns>the hash</returns>
        public static string Hash(string password, int iterations)
        {
            //create salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            //create hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            //combine salt and hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            //convert to base64
            var base64Hash = Convert.ToBase64String(hashBytes);

            //format hash with extra information
            return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
        }
        /// <summary>
        /// Creates a hash from a password with 10000 iterations
        /// </summary>
        /// <param name="password">the password</param>
        /// <returns>the hash</returns>
        public static string Hash(string password)
        {
            return Hash(password, 10000);
        }

        /// <summary>
        /// Check if hash is supported
        /// </summary>
        /// <param name="hashString">the hash</param>
        /// <returns>is supported?</returns>
        public static bool IsHashSupported(string hashString)
        {
            return hashString.Contains("$MYHASH$V1$");
        }

        /// <summary>
        /// verify a password against a hash
        /// </summary>
        /// <param name="password">the password</param>
        /// <param name="hashedPassword">the hash</param>
        /// <returns>could be verified?</returns>
        public static bool Verify(string password, string hashedPassword)
        {
            //check hash
            if (!IsHashSupported(hashedPassword))
            {
                throw new NotSupportedException("The hashtype is not supported");
            }

            //extract iteration and Base64 string
            var splittedHashString = hashedPassword.Replace("$MYHASH$V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            //get hashbytes
            var hashBytes = Convert.FromBase64String(base64Hash);

            //get salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            //create hash with given salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            //get result
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

    }
}

