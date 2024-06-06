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

                //��ȡtokenǩ�����ܳ�
                var key = _configuration.GetSection("Secret").Value.ToString();
                //����JWT���Ƶ��������ϣ�token�ĸ��أ�
                var authClaims = new[] {
                     new Claim("name",res.UserName),   //����
                     new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),   //JWT���Ƶ�Ψһ��ʶ
                };
                //��ʾ��ϸ�������֤����Ȩ������Ϣ
                IdentityModelEventSource.ShowPII = true;
                //ǩ����Կ ���Էŵ�json�ļ���
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                //������JWT����
                var token = new JwtSecurityToken(
                        //ָ��JWT���ƵĹ���ʱ��
                        expires: DateTime.Now.AddHours(24),
                        //ָ��JWT���Ƶ���������
                        claims: authClaims,
                        //ָ��JWT���Ƶ�ǩ��ƾ֤���趨�����㷨(�ԳƼ���)
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                return new ResponseInfo
                {
                    Message = "��¼�ɹ�",
                    Title = "��ʾ",
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
                Message = "��¼ʧ��",
                Title = "��ʾ",
                Value = null,
                Status = 1
            };
        }
            
    }
}
