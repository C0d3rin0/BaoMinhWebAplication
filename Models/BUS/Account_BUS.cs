using System;
using System.Collections.Generic;
using System.Linq;
using BaoMinhWebApplication.Models.DAO;

namespace BaoMinhWebApplication.Models.BUS
{
    public class Account_BUS
    {
        public static UserSearchModel getNext(
            string keyNextBoundary,
            int numDisplayItem,
            string Email = null)
        {
            UserSearchModel ViewModel = new UserSearchModel();
            AccountResultSearchViewModel[] dt = User_DAO.getNext(Email, keyNextBoundary, numDisplayItem + 1);

            int rowCount = dt.Count();
            ViewModel.isFirstPage = String.IsNullOrEmpty(keyNextBoundary) ? true : false;


            // Lấy hơn một dòng để kiểm tra phía trước còn dòng nào
            ViewModel.isLastPage = rowCount <= numDisplayItem ? true : false;

            ViewModel.data = dt;

            //Tính toán để duy chuyển
            if (rowCount > numDisplayItem)
            {
                ViewModel.data = ViewModel.data.Skip(1).ToArray(); // dòng cuối là dummy
                ViewModel.keyPrevBoundary = ViewModel.data[0].Id.ToString();
                ViewModel.keyNextBoundary = ViewModel.data[rowCount - 2].Id.ToString();
            }
            else if (rowCount > 0)
            {
                ViewModel.keyPrevBoundary = ViewModel.data[0].Id.ToString();
                ViewModel.keyNextBoundary = ViewModel.data[rowCount - 1].Id.ToString();
            }
            else // không tìm thấy thông tin nào trùng vào bộ lọc
            {
                ViewModel.isEmpty = true;
            }


            return ViewModel;
        }

        public static UserSearchModel getPrev(
            string keyPrevBoundary,
            int numDisplayItem,
            string Email = null
            )
        {
            UserSearchModel ViewModel = new UserSearchModel();
            AccountResultSearchViewModel[] dt = User_DAO.getPrev(Email, keyPrevBoundary, numDisplayItem + 1);

            int rowCount = dt.Count();
            ViewModel.isLastPage = false;


            // Lấy hơn một dòng để kiểm tra phía trước còn dòng nào
            ViewModel.isFirstPage = rowCount <= numDisplayItem ? true : false;

            ViewModel.data = dt;

            if (rowCount < numDisplayItem && rowCount > 0)
            {
                int numGetMore = numDisplayItem - rowCount;
                AccountResultSearchViewModel[] dtMerge = User_DAO.getPrev(
                    Email,
                    dt[rowCount - 1].Id.ToString(),
                    numGetMore);

                ViewModel.data = ViewModel.data.Concat(dtMerge).ToArray();
            }

            //Tính toán để duy chuyển
            if (rowCount > numDisplayItem)
            {
                ViewModel.data = ViewModel.data.Skip(1).ToArray(); // dòng cuối là dummy
                ViewModel.keyPrevBoundary = ViewModel.data[0].Id.ToString();
                ViewModel.keyNextBoundary = ViewModel.data[rowCount - 2].Id.ToString();
            }
            else if (rowCount > 0)
            {
                ViewModel.keyPrevBoundary = ViewModel.data[0].Id.ToString();
                ViewModel.keyNextBoundary = ViewModel.data[rowCount - 1].Id.ToString();
            }
            else // không tìm thấy thông tin nào trùng vào bộ lọc
            {
                ViewModel.isEmpty = true;
            }
            return ViewModel;
        }
    }
}
