using Models.BModels;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoleService
    {
        public List<RoleInfo> DoGetRoles(int IsDelete);
        public List<UserRoleInfo> DoGetRolesByUserId(List<int> UserIds);
        public bool DoUpdateRoles(int roleId, List<int> menuIds);
        public List<RoleInfo> DoUpdate(RoleBO role);
        public List<RoleInfo> DoIsDelete(List<RoleInfo> roles);
        public List<RoleInfo> DoDeleteRole(List<RoleInfo> roles);
    }
}
