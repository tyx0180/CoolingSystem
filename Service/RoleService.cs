using Models.BModels;
using Models.Models;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoleService : IRoleService
    {
        private IRoleRespository roleRespository;
        public RoleService(IRoleRespository _roleRespository) { 
            roleRespository = _roleRespository;
        }

        public List<RoleInfo> DoDeleteRole(List<RoleInfo> roles)
        {
            return roleRespository.DeleteRole(roles);
        }

        public List<RoleInfo> DoGetRoles(int IsDelete)
        {
            return roleRespository.GetRoles(IsDelete);
        }

        public List<UserRoleInfo> DoGetRolesByUserId(List<int> UserIds)
        {
            return roleRespository.GetRolesByUserId(UserIds);
        }

        public List<RoleInfo> DoIsDelete(List<RoleInfo> roles)
        {
            return roleRespository.IsDelete(roles);
        }

        public List<RoleInfo> DoUpdate(RoleBO role)
        {
            RoleInfo roleInfo = new RoleInfo() { 
                RoleId=role.RoleId,
                RoleName=role.RoleName,
                Remark=role.Remark,
                IsAdmin=role.IsAdmin,
                IsDeleted=role.IsDeleted,
                CreateTime=role.CreateTime,
            };

            return roleRespository.Update(roleInfo);
        }

        public bool DoUpdateRoles(int roleId, List<int> menuIds)
        {
            //如果是超级管理员，返回所有菜单，不需要做修改
            List<RoleInfo> roleInfo = roleRespository.GetRoles(roleId);
            foreach (var item in roleInfo)
            {
                if (item.IsAdmin)
                {
                    return true;
                }
            }
           

            //如果不是管理员，再修改角色菜单
            return roleRespository.UpdateRoles(roleId, menuIds);
        }


    }
}
