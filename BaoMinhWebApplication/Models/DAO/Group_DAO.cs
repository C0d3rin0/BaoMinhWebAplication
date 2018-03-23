using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaoMinhWebApplication.Models.DAO
{
    public static class Help {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }

    public class Group_DAO
    {
        public static void search()
        {

        }

        public static void create(GroupApiModel ViewModel)
        {
            var Entity = new Entities();

            //Tạo nhóm
            var _Nhom = new Nhom
            {
                Ten = ViewModel.name
            };

            //Set thông tin nhóm
            set(_Nhom, ViewModel, Entity);

            //Thêm nhóm
            Entity.Nhoms.Add(_Nhom);
            Entity.SaveChanges();
        }

        public static void update(GroupUpdateApiModel ViewModel)
        {
            Entities entities = new Entities();
            var group = entities
                .Nhoms
                .Where(g => g.id == ViewModel.Id).First();

            //Tên
            group.Ten = ViewModel.name;

            //Tài khoản
            List<TaiKhoan> users = new List<TaiKhoan>();
            foreach (int userID in ViewModel.SelectedUsersId)
            {
                TaiKhoan user = entities.TaiKhoan.Where(u => u.id == userID).First();
                users.Add(user);
            }

            group.TaiKhoan = users;


            //Quyền

            foreach (_AffiliationPermisionModel AffiliationPermision in ViewModel.affiliationWithPermision.OrEmptyIfNull())
            {
                NhomThuocChiNhanh affiliationInGroup = new NhomThuocChiNhanh();
                affiliationInGroup.Nhom = group;
                affiliationInGroup.MaChiNhanh = AffiliationPermision.Id;

                //Với mỗi down permision
                foreach (int permisionId in AffiliationPermision.downPermision.OrEmptyIfNull())
                {
                    QuyenTai_NhomThuocChiNhanh downPermision = new QuyenTai_NhomThuocChiNhanh
                    {
                        Quyen = permisionId
                    };

                    affiliationInGroup.QuyenTai_NhomThuocChiNhanh.Add(downPermision);
                }

                //Với mỗi search permision
                foreach (int permisionId in AffiliationPermision.searchPermision.OrEmptyIfNull())
                {
                    QuyenXem_NhomThuocChiNhanh searchPermision = new QuyenXem_NhomThuocChiNhanh
                    {
                        Quyen = permisionId
                    };

                    affiliationInGroup.QuyenXem_NhomThuocChiNhanh.Add(searchPermision);
                }

                group.NhomThuocChiNhanh.Add(affiliationInGroup);
            }
        
    }

        public static dynamic[] getNext(string name, string keyNext, int Num)
        {
            Entities entities = new Entities();
            var Groups = entities.Nhoms.Select(u=>u);


            if (keyNext != null)
            {
                int Next = int.Parse(keyNext);
                Groups = Groups.Where(u => u.id > Next);
            }


            return Groups
                .OrderBy(u => u.id)
                .Take(Num)
                .Select(u => new {
                    Name = u.Ten,
                    Id = u.id,
                    State = u.TrangThai
                })
                .ToArray();
        }

        public static dynamic[] getPrev(string name, string keyPrev, int num)
        {
            Entities entities = new Entities();
            var Groups = entities.Nhoms.Select(u => u);

            if (keyPrev != null)
            {
                int Prev = int.Parse(keyPrev);
                Groups = Groups.Where(u => u.id < Prev);
            }


            return Groups
                .OrderByDescending(u => u.id)
                .Reverse()
                .Take(num)
                .Select(u =>  new
                {
                    Name = u.Ten,
                    Id = u.id,
                    State = u.TrangThai
                })
                .ToArray();
        }

        public static IEnumerable<Nhom> getByName(string name)
        {
            Entities entities = new Entities();
            return entities.Nhoms.Where(g => g.Ten.Contains(name));
        }

        public static bool update(int Id,GroupApiModel ViewModel)
        {
            Entities entities = new Entities();

            //Tìm nhóm có Id
            Nhom nhom = entities.Nhoms.Where(p => p.id == Id).First();
            if (nhom == null)
                return false;

            set(nhom, ViewModel,entities);

            //Bắt đầu update
            entities.SaveChanges();
            return true;
        }

        public static void set(Nhom _Nhom,GroupApiModel ViewModel,Entities Entity)
        {
            //Với mỗi user
            _Nhom.TaiKhoan =
                Entity.TaiKhoan.Where(p => ViewModel.usersId.Contains(p.id)).ToArray();

            //Với mỗi chi nhánh

            foreach (AffiliationPermisionModel AffiliationPermision in ViewModel.affiliationsWithPermision.OrEmptyIfNull())
            {
                NhomThuocChiNhanh nhomThuocChiNhanh = new NhomThuocChiNhanh();
                nhomThuocChiNhanh.Nhom = _Nhom;
                nhomThuocChiNhanh.MaChiNhanh = AffiliationPermision.id;

                //Với mỗi down permision
                foreach (int permisionId in AffiliationPermision.downPermision.OrEmptyIfNull())
                {
                    QuyenTai_NhomThuocChiNhanh quyenTai = new QuyenTai_NhomThuocChiNhanh
                    {
                        Quyen = permisionId
                    };

                    nhomThuocChiNhanh.QuyenTai_NhomThuocChiNhanh.Add(quyenTai);
                }

                //Với mỗi search permision
                foreach (int permisionId in AffiliationPermision.searchPermision.OrEmptyIfNull())
                {
                    QuyenXem_NhomThuocChiNhanh quyenXem = new QuyenXem_NhomThuocChiNhanh
                    {
                        Quyen = permisionId
                    };

                    nhomThuocChiNhanh.QuyenXem_NhomThuocChiNhanh.Add(quyenXem);
                }

                _Nhom.NhomThuocChiNhanh.Add(nhomThuocChiNhanh);
            }  
        }
    }
}