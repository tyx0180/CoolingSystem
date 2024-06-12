using Microsoft.EntityFrameworkCore;
using Models.BModels;
using Models.Context;
using Models.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class MenuRepository : IMenuRespository
    {
        private JkidwpdbaseContext _Context;
        public MenuRepository(JkidwpdbaseContext context)
        {
            _Context = context;
        }

        public PageModel<ViewMenuInfo> DeleteMenu(DeleteModel<MenuInfo> DeleteList)
        {
            for(int a=0;a< DeleteList.DeleteList.Count;a++)
            {
                _Context.MenuInfos.Attach(DeleteList.DeleteList[a]);
                _Context.Entry(DeleteList.DeleteList[a]).State = EntityState.Deleted;
            }
            _Context.SaveChanges();
            List<ViewMenuInfo> viewMenuInfos = _Context.ViewMenuInfos
                    .Where(m => m.IsDeleted == 0)
                    .OrderBy(m => m.Morder)
                    .Skip((DeleteList.currentPage - 1) * DeleteList.pageSize)
                    .Take(DeleteList.pageSize)
                   .Select(m => m)
                    .ToList();
            int totle = _Context.ViewMenuInfos
                .Where(x => x.IsDeleted == 0).Count();
            return new PageModel<ViewMenuInfo>
            {
                All = totle,
                reslist = viewMenuInfos
            };
        }

        public List<MenuInfo> GetMenuInfos()
        {
            return _Context.MenuInfos.ToList();
        }

        public PageModel<ViewMenuInfo> GetMenuInfosByFilter(SearchFilter menuFilters)
        {
            List<ViewMenuInfo> Menus = null;
            int totle = 0;
            if (menuFilters.IsDelete == 1)
            {
                Menus = _Context.ViewMenuInfos.Where(m => m.MenuName.Contains(menuFilters.KeyWords) && m.IsDeleted == 1)
                    .OrderBy(m => m.Morder)
                    .Skip((menuFilters.currentPage - 1) * menuFilters.pageSize)
                    .Take(menuFilters.pageSize)
                    .Select(m => m)
                    .ToList();
                totle = _Context.ViewMenuInfos.Where(m => m.MenuName.Contains(menuFilters.KeyWords) && m.IsDeleted == 1).ToList().Count;
            }
            else
            {
                Menus = _Context.ViewMenuInfos
                    .Where(m => m.MenuName.Contains(menuFilters.KeyWords) && m.IsDeleted == 0)
                    .OrderBy(m => m.Morder)
                    .Skip((menuFilters.currentPage - 1) * menuFilters.pageSize)
                    .Take(menuFilters.pageSize)
                    
                   .Select(m => m)
                    .ToList();
                totle = _Context.ViewMenuInfos.Where(m => m.MenuName.Contains(menuFilters.KeyWords) && m.IsDeleted == 0).ToList().Count;
            }
            return new PageModel<ViewMenuInfo>
            {
                All = totle,
                reslist = Menus
            };
        }

        public List<RoleInfo> GetMenusByUserId(int userId)
        {
            var find = (from user in _Context.UserRoleInfos
                        join role in _Context.RoleInfos
                        on user.RoleId equals role.RoleId
                        where user.UserId == userId
                        select role).ToList();
            return find;
        }

        public PageModel<ViewMenuInfo> ModifyMenu(MenuInfoBO menu)
        {
            _Context.MenuInfos.Attach(menu.menu);
            if (menu.menu.MenuId == 0)
            {
                _Context.Entry(menu.menu).State = EntityState.Added;
            }
            else
            {
                _Context.Entry(menu.menu).State = EntityState.Modified;
            }
            _Context.SaveChanges();
            List<ViewMenuInfo> viewMenuInfos = _Context.ViewMenuInfos
                    .Where(m =>  m.IsDeleted == 0)
                    .OrderBy(m => m.Morder)
                    .Skip((menu.currentPage - 1) * menu.pageSize)
                    .Take(menu.pageSize)
                   .Select(m => m)
                    .ToList();
            int totle = _Context.ViewMenuInfos
                .Where(x => x.IsDeleted == 0).Count();
            return new PageModel<ViewMenuInfo>
            {
                All = totle,
                reslist = viewMenuInfos
            };
        }

        
    }
}
