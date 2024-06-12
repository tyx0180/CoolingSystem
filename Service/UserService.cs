using Models.BModels;
using Models.Models;
using Repository.Interface;
using Service.Interface;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository _Repository;
        public UserService(IUserRepository repository)
        {
            _Repository = repository;
        }

        public PageModel<UserInfo> DoGetUsersByFilters(SearchFilter filters)
        {
            return _Repository.GetUsersByFilters(filters);
        }

        public UserInfo Dologin(UserInfoBO user)
        {
            return _Repository.login(user);
        }
    }
}
