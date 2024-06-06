using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Models.BModels;
using Models.Dto;
using Models.Models;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _configuration;
        public UserController(IUserService userService,IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [HttpPost,Route("login")]
        public ActionResult<ResponseInfo> login(UserInfoBO user)
        {
            UserInfo res = _userService.Dologin(user);
            if (res != null)
            {
                res.UserRealPwd = "";
                res.UserPwd = "";

                //获取token签名的密匙
                var key = _configuration.GetSection("Secret").Value.ToString();
                //创建JWT令牌的声明集合（token的负载）
                var authClaims = new[] {
                     new Claim("name",res.UserName),   //主题
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),   //JWT令牌的唯一标识
                };
                //显示详细的身份验证和授权错误信息
                IdentityModelEventSource.ShowPII = true;
                //签名秘钥 可以放到json文件中
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                //创建了JWT令牌
                var token = new JwtSecurityToken(
                        //指定JWT令牌的过期时间
                        expires: DateTime.Now.AddHours(24),
                        //指定JWT令牌的声明集合
                        claims: authClaims,
                        //指定JWT令牌的签名凭证，设定加密算法(对称加密)
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return new ResponseInfo
                {
                    Message = "登录成功",
                    Title = "提示",
                    Value = new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        User = res
                    },
                    Status = 1
                };
            }
            return new ResponseInfo
            {
                Message = "登录失败",
                Title = "提示",
                Value = null,
                Status = 1
            };
        }
            
    }
}
