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
    public interface IRoleRespository
    {

        public List<RoleInfo> GetRoles(int IsDelete);
        public List<UserRoleInfo> GetRolesByUserId(List<int> UserId);
        public bool UpdateRoles(int roleId, List<int> menuIds);

        public List<RoleInfo> Update(RoleInfo role);
        public List<RoleInfo> IsDelete(List<RoleInfo> role);
        public List<RoleInfo> DeleteRole(List<RoleInfo> roles);


    }
}
