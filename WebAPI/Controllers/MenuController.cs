using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        }
    }

