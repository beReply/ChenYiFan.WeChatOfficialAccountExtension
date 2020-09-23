using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using ChenYiFan.WeChatOfficialAccountExtension.Configuration;
using Microsoft.Extensions.Configuration;
using ChenYiFan.WeChatOfficialAccountExtension.Services;

namespace ChenYiFan.WeChatOfficialAccountExtension
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddWeChatOfficialAccountExtension(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<WeChatConf>(configuration.GetSection("WeChat"));

            service.AddTransient<IWeChatService, WeChatService>();

            return service;
        }
    }
}
