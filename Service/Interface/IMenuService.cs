using Models.BModels;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IMenuService
    {
        public List<MenuInfo> DoGetMenus();
        public List<MenuInfo> DoGetMenusByRoleId(int UserId);
        public List<MenuInfo> GetMenusByUserId(int userId);
        public PageModel<ViewMenuInfo> DoGetMenuInfosByFilter(SearchFilter menuFilters);
        public PageModel<ViewMenuInfo> ModifyMenu(MenuInfoBO menu);
        public PageModel<ViewMenuInfo> DeleteMenu(DeleteModel<MenuInfo> menuId);
    }
}
