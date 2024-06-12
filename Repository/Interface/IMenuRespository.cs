using Models.BModels;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IMenuRespository
    {

        public List<MenuInfo> GetMenuInfos();
        public List<RoleInfo> GetMenusByUserId(int userId);
        public PageModel<ViewMenuInfo> GetMenuInfosByFilter(SearchFilter menuFilters);
        public PageModel<ViewMenuInfo> ModifyMenu(MenuInfoBO  menu);
        public PageModel<ViewMenuInfo> DeleteMenu(DeleteModel<MenuInfo> menid);
    }
}
