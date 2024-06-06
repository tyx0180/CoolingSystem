
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
                //ָ��Ĭ�ϵ������֤��������������յ�����������֤ʱʹ�ø÷�����
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //ָ��Ĭ�ϵ���ս��Challenge������������Ҫ�û����������֤ʱ��ϵͳ���Զ�����һ����ս��Ӧ��Ҫ���û��ṩ�����֤ƾ��
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //ָ��Ĭ�ϵķ��������ڴ���δ�������֤������
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //����JWT Bearer�����֤ѡ��
            .AddJwtBearer(options =>
            {
                //�����֤�ɹ��󱣴�JWT����
                options.SaveToken = true;
                //ָ��JWT���Ƶ���֤����
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    //��֤JWT���Ƶķ����ߣ�Issuer��
                    ValidateIssuer = false,
                    //��֤JWT���Ƶ����ڣ�Audience��
                    ValidateAudience = false,
                    //ָ��������֤ǩ������Կ
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
