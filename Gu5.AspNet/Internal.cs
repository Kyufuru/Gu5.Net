using System.Text;

using Gu5.AspNet.Abstracts;

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Gu5.AspNet
{
    public static class Internal
    {
        /// <summary>
        /// 扫描注入相关实例
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static IServiceCollection AddGu5(this IServiceCollection @this)
        {
            var rs = @this.Scan(x => x
                .FromApplicationDependencies()
                    .AddClasses(c => c
                        .AssignableTo<ISingleton>())
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
                .FromApplicationDependencies()
                    .AddClasses(c => c
                        .AssignableTo<IScoped>())
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                .FromApplicationDependencies()
                    .AddClasses(c => c
                        .AssignableTo<ITransient>())
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return rs;
        }

        /// <summary>
        /// JWT 认证
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static AuthenticationBuilder AddJwt(this IServiceCollection @this, ConfigurationManager cfg)
        {
            var key = Encoding.UTF8.GetBytes($"{cfg["Jwt:Key"]}");
            var opt = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = cfg["Jwt:Issuer"],

                ValidateAudience = true,
                ValidAudience = cfg["Jwt:Audience"],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),

                RequireExpirationTime = true,
            };

            return @this
                .AddAuthentication("Bearer")
                .AddJwtBearer(x => x.TokenValidationParameters = opt);
        }
    }
}
