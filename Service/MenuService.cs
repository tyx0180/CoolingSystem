using Models.BModels;
using Models.Context;
using Models.Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MenuService : IMenuService
    {
        IMenuRespository _menu;
        JkidwpdbaseContext _context;
        public MenuService(IMenuRespository menu, JkidwpdbaseContext context)
        {
            _menu = menu;
            _context = context;
        }

        public PageModel<ViewMenuInfo> DeleteMenu(DeleteModel<MenuInfo> menuId)
        {
            return _menu.DeleteMenu(menuId);
        }

        public PageModel<ViewMenuInfo> DoGetMenuInfosByFilter(SearchFilter menuFilters)
        {
            return _menu.GetMenuInfosByFilter(menuFilters);
        }

        public List<MenuInfo> DoGetMenus()
        {
            return _menu.GetMenuInfos();
        }

        public List<MenuInfo> DoGetMenusByRoleId(int RoleId)
        {
           
            if (RoleId == 1001)
            {
                return DoGetMenus();
            };
            var menus = (from menu in _context.MenuInfos
                         join rm in _context.RoleMenuInfos
                         on menu.MenuId equals rm.MenuId
                         where rm.RoleId == RoleId
                         select menu).ToList();
            return menus;
        }

        public List<MenuInfo> GetMenusByUserId(int userId)
        {
            List<RoleInfo> roles = _menu.GetMenusByUserId(userId);
            if (roles[0].RoleId == 1001)
            {
                return DoGetMenus();
            };
            var menus = (from menu in _context.MenuInfos
                         join rm in _context.RoleMenuInfos
                         on menu.MenuId equals rm.MenuId
                         where rm.RoleId == roles[0].RoleId
                         select menu).ToList();
            return menus;
        }

        public PageModel<ViewMenuInfo> ModifyMenu(MenuInfoBO menu)
        {
            return _menu.ModifyMenu(menu);
        }
    }
}
