
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Models.Context;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<JkidwpdbaseContext>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            var secret = builder.Configuration.GetSection("Secret").Value;
            builder.Services.AddAuthentication(options =>
            {
                //指定默认的身份验证方案，在请求接收到后进行身份验证时使用该方案。
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //指定默认的挑战（Challenge）方案，当需要用户进行身份验证时，系统会自动发送一个挑战响应，要求用户提供身份验证凭据
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //指定默认的方案，用于处理未经身份验证的请求。
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //配置JWT Bearer身份验证选项
            .AddJwtBearer(options =>
            {
                //身份验证成功后保存JWT令牌
                options.SaveToken = true;
                //指定JWT令牌的验证参数
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //验证JWT令牌的发行者（Issuer）
                    ValidateIssuer = false,
                    //验证JWT令牌的受众（Audience）
                    ValidateAudience = false,
                    //指定用于验证签名的密钥
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
