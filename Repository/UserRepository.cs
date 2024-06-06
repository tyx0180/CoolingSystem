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

        public UserInfo login(UserInfoBO user)
        {
            UserInfo res= _Context.UserInfos.Where(x => x.UserPwd == user.UserPwd && x.UserName == user.UserName).FirstOrDefault();
            return res;
        }
    }

    
}
