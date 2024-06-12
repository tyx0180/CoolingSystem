using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.BModels;
using Models.Context;
using Models.Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRespository
    {
        private JkidwpdbaseContext context;
        public RoleRepository(JkidwpdbaseContext _context)
        {
            context = _context;
        }

        public List<RoleInfo> DeleteRole(List<RoleInfo> roles)
        {
            foreach (var item in roles)
            {
                context.RoleInfos.Attach(item);
                context.Entry(item).State = EntityState.Deleted;
            }
            context.SaveChanges();
            return context.RoleInfos.Where(m => m.IsDeleted == 0).ToList();
        }

        public List<RoleInfo> GetRoles(int IsDelete)
        {
            return context.RoleInfos.Where(m=>m.IsDeleted==IsDelete).ToList();
        }

        public List<UserRoleInfo> GetRolesByUserId(List<int> UserIds)
        {
            List<UserRoleInfo> roles = new List<UserRoleInfo>();
            foreach (var item in UserIds)
            {
               roles.Add( context.UserRoleInfos.Where(x => x.UserId == item).FirstOrDefault());
            }
            return roles;
        }

        public List<RoleInfo> IsDelete(List<RoleInfo> roles)
        {
            foreach (RoleInfo item in roles)
            {
                context.RoleInfos.Attach(item);
                context.Entry(item).State=EntityState.Modified;
            }
            context.SaveChanges();
            return context.RoleInfos.Where(m => m.IsDeleted == 0).ToList();
        }

        public List<RoleInfo> Update(RoleInfo role)
        {
            if (role.RoleId == 0)
            {
                context.RoleInfos.Attach(role);
                context.Entry(role).State = EntityState.Added;
                context.SaveChanges();
            }
            else
            {
                context.RoleInfos.Attach(role);
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
            return context.RoleInfos.Where(m => m.IsDeleted == 0).ToList();
        }

        public bool UpdateRoles(int roleId, List<int> menuIds)
        {
            //根据roleId找到数据库中当前角色拥有的菜单信息
            var dataIds = (from rmi in context.RoleMenuInfos
                           where rmi.RoleId == roleId
                           select rmi.MenuId).ToList();
            //menuIds是我们自己传递到服务器菜单集合

            //找到数据库中有而menuIds中没有的菜单集合(删除操作)
            List<int> difference = dataIds.Except(menuIds).ToList();
            foreach (int id in difference)
            {
                var find = context.RoleMenuInfos.Where(rm => rm.MenuId == id).FirstOrDefault();
                context.RoleMenuInfos.Remove(find);
            }

            //找到menuIds中有的而数据库中没有的菜单集合(新增)
            List<int> difference2 = menuIds.Except(dataIds).ToList();
            foreach (int id in difference2)
            {
                RoleMenuInfo roleMenuInfo = new RoleMenuInfo()
                {
                    RoleId = roleId,
                    MenuId = id,
                    IsDeleted = 0
                };
                context.RoleMenuInfos.Add(roleMenuInfo);
            }
            int count = context.SaveChanges();

            return count > 0 ? true : false;
        }
    }
}
