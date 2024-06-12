using Models.BModels;
using Models.Context;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
      
        public UserInfo login(UserInfoBO user);
        public PageModel<UserInfo> GetUsersByFilters(SearchFilter filters);
    }
}
