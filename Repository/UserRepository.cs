using Models.BModels;
using Models.Context;
using Models.Models;
using Repository.Interface;

namespace Repository
{
    public class UserRepository:IUserRepository
    {
        private JkidwpdbaseContext _Context;
        public UserRepository(JkidwpdbaseContext context)
        {
            _Context = context;
        }

        public PageModel<UserInfo> GetUsersByFilters(SearchFilter filters)
        {
            List<UserInfo> users = null;
            int totle = 0;
            if (filters.IsDelete == 1)
            {
                users = _Context.UserInfos
                    .Where(m=>m.UserName.Contains(filters.KeyWords)&&m.IsDeleted==1)
                    .Skip((filters.currentPage-1)*filters.pageSize)
                    .Take(filters.pageSize)
                    .Select(x=>x)
                    .ToList();
                totle= _Context.UserInfos
                    .Where(m => m.UserName.Contains(filters.KeyWords) && m.IsDeleted == 1).ToList().Count;
            }
            else
            {
                users = _Context.UserInfos
                    .Where(m => m.UserName.Contains(filters.KeyWords) && m.IsDeleted == 0)
                    .Skip((filters.currentPage - 1) * filters.pageSize)
                    .Take(filters.pageSize)
                    .Select(x => x)
                    .ToList();
                totle = _Context.UserInfos
                    .Where(m => m.UserName.Contains(filters.KeyWords) && m.IsDeleted == 0).ToList().Count;
            }

            return new PageModel<UserInfo>()
            {
                All=totle,
                reslist=users
            };
        }

        public UserInfo login(UserInfoBO user)
        {
            UserInfo res= _Context.UserInfos.Where(x => x.UserPwd == user.UserPwd && x.UserName == user.UserName).FirstOrDefault();
            return res;
        }
    }

    
}
