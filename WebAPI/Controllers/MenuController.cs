using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BModels;
using Models.Dto;
using Models.Models;
using Service.Interface;

namespace WebAPI.Controllers
{
    
        [ApiController, Route("api/[Controller]")]
        public class MenuController : ControllerBase
        {
            private IMenuService _menuService;
            public MenuController(IMenuService menuService)
            {
                _menuService = menuService;
            }

        /// <summary>
        /// 获取全部菜单
        /// </summary>
            [HttpGet, Route("list")]
            [Authorize]
            public ActionResult<ResponseInfo> Index()
            {
                List<MenuInfo> menus = _menuService.DoGetMenus();
                return new ResponseInfo()
                {
                    Message = "获取菜单列表成功",
                    Title = "提示",
                    Value = menus,
                    Status = 1
                };
            }
        /// <summary>
        /// 根据RoleId的菜单
        /// </summary>
        [HttpGet]
        [Route("GetMenuByUserId/{userId}")]
        public ActionResult<ResponseInfo> GetMenuByUserId(int userId)
        {
            List<MenuInfo> menus= _menuService.GetMenusByUserId(userId);

            return  new ResponseInfo()
            {
                Message = "获取菜单列表成功",
                Title = "提示",
                Value = menus,
                Status = 1
            }; ;
        }

        [HttpGet]
        [Route("GetMenuByRoleId/{roleId}")]
        public ActionResult<ResponseInfo> GetMenuByRoleId(int roleId)
        {
            List<MenuInfo> menus = _menuService.DoGetMenusByRoleId(roleId);

            return new ResponseInfo()
            {
                Message = "获取菜单列表成功",
                Title = "提示",
                Value = menus,
                Status = 1
            }; ;
        }

        [HttpPost]
        [Route("GetMenuByFilter")]
        public ActionResult<ResponseInfo> GetMenuByFilter(SearchFilter searchFilter)
        {
            PageModel<ViewMenuInfo> menus = _menuService.DoGetMenuInfosByFilter(searchFilter);

            return new ResponseInfo()
            {
                Message = "获取菜单列表成功",
                Title = "提示",
                Value = menus,
                Status = 1
            }; 
        }

        [HttpPost]
        [Route("ModifyMenu")]
        public ActionResult<ResponseInfo> ModifyMenu(MenuInfoBO infoBO)
        {
            PageModel<ViewMenuInfo> menus = _menuService.ModifyMenu(infoBO);

            return new ResponseInfo()
            {
                Message = "获取菜单列表成功",
                Title = "提示",
                Value = menus,
                Status = 1
            };
        }

        [HttpPost]
        [Route("DeleteMenu")]
        public ActionResult<ResponseInfo> DeleteMenu(DeleteModel<MenuInfo> infoBO)
        {
            PageModel<ViewMenuInfo> menus = _menuService.DeleteMenu(infoBO);

            return new ResponseInfo()
            {
                Message = "获取菜单列表成功",
                Title = "提示",
                Value = menus,
                Status = 1
            };
        }
    }
}

