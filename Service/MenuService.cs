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
        public MenuService(IMenuRespository menu)
        {
            _menu = menu;
        }
        public List<MenuInfo> DoGetMenus()
        {
            return _menu.GetMenuInfos();
        }
    }
}
