using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ChenYiFan.WeChatOfficialAccountExtension.Services.Params;

namespace ChenYiFan.WeChatOfficialAccountExtension.Services
{
    public interface IWeChatService
    {
        Task<GetAccessToken> GetAccessTokenAsync();

        Task<string> GetServerIpAsync(string accessToken);
    }
}
