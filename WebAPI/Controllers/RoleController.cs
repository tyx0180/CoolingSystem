using Microsoft.AspNetCore.Mvc;
using Models.BModels;
using Models.Dto;
using Models.Models;
using Service;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace WebAPI.Controllers
{
    [ApiController,Route("api/[Controller]")]
    public class RoleController : Controller
    {
        private IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }
        [HttpGet]
        [Route("GetRoles/{IsDelete}")]
        public ActionResult<ResponseInfo> GetRoles(int IsDelete)
        {
            List<RoleInfo> roles = roleService.DoGetRoles(IsDelete);

            return new ResponseInfo
            {
                Message = "获取成功",
                Title = "提示",
                Value = roles,
                Status = 1
            };
        }

        [HttpPost, Route("update/{roleId}")]
        public ActionResult<ResponseInfo> Update(int roleId, List<int> menuIds)
        {
            bool isSuccess = roleService.DoUpdateRoles(roleId, menuIds);
            return new ResponseInfo()
            {
                Message = "获取角色列表成功",
                Title = "提示",
                Value = isSuccess,
                Status = 1
            };
        }

        [HttpPost, Route("updaterole")]
        public ActionResult<ResponseInfo> DoUpdate(RoleBO role)
        {
            List<RoleInfo> roles = roleService.DoUpdate(role);
            return new ResponseInfo()
            {
                Message = "获取角色列表成功",
                Title = "提示",
                Value = roles,
                Status = 1
            };
        }

        [HttpPost, Route("IsDelete")]
        public ActionResult<ResponseInfo> DoIsDelete(List<RoleInfo> roles)
        {
            List<RoleInfo> role = roleService.DoIsDelete(roles);
            return new ResponseInfo()
            {
                Message = "获取角色列表成功",
                Title = "提示",
                Value = role,
                Status = 1
            };
        }

        [HttpPost, Route("DeleteRole")]
        public ActionResult<ResponseInfo> DoDeleteRole(List<RoleInfo> roles)
        {
            List<RoleInfo> role = roleService.DoDeleteRole(roles);
            return new ResponseInfo()
            {
                Message = "获取角色列表成功",
                Title = "提示",
                Value = role,
                Status = 1
            };
        }

        [HttpPost, Route("GetRolesByUserId")]
        public ActionResult<ResponseInfo> DoGetRoleByUserId(List<int> roles)
        {
            List<UserRoleInfo> role = roleService.DoGetRolesByUserId(roles);
            return new ResponseInfo()
            {
                Message = "获取角色列表成功",
                Title = "提示",
                Value = role,
                Status = 1
            };
        }
    }
}
