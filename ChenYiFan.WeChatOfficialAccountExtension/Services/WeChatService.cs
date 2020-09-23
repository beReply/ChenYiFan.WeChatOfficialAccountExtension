using ChenYiFan.WeChatOfficialAccountExtension.Configuration;
using ChenYiFan.WeChatOfficialAccountExtension.Extensions;
using ChenYiFan.WeChatOfficialAccountExtension.Services.Params;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace ChenYiFan.WeChatOfficialAccountExtension.Services
{
    public class WeChatService : IWeChatService
    {
        private readonly IOptionsMonitor<WeChatConf> _weChatParam;


        public WeChatService(IOptionsMonitor<WeChatConf> weChatParam)
        {
            _weChatParam = weChatParam;
        }

        #region 基础支持

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public async Task<GetAccessToken> GetAccessTokenAsync()
        {
            var path = _weChatParam.CurrentValue.Url + "/token";

            var body = new Dictionary<string, string>
            {
                {"grant_type", "client_credential"},
                {"appid", _weChatParam.CurrentValue.AppId},
                {"secret", _weChatParam.CurrentValue.AppSecret}
            };

            var res = JsonConvert.DeserializeObject<GetAccessToken>(await GetAsync(path, body));

            _weChatParam.CurrentValue.AccessToken = res.access_token;

            return res;
        }

        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<string> GetServerIpAsync(string accessToken)
        {
            var path = _weChatParam.CurrentValue.Url + "/getcallbackip";
            var body = new Dictionary<string, string>
            {
                {"access_token", accessToken}
            };

            return await GetAsync(path, body);
        }

        #endregion

        #region 接收消息

        public void ReceiveMessageProcessing(string xmlMessage)
        {
            var receiveMessage = xmlMessage.XmlToObj<ReceiveMessage>();
        }

        #endregion

        #region 请求工具

        private async Task<string> SendAsync(HttpMethod httpMethod, string path, string body)
        {
            Console.WriteLine(path);
            Console.WriteLine(body);

            var client = new HttpClient();
            var content = new StringContent(body, Encoding.UTF8);
            var request = new HttpRequestMessage(httpMethod, path) { Content = content };
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }


        private async Task<string> GetAsync(string url, Dictionary<string, string> bodyDic)
        {
            var path = url + "?";
            foreach (var body in bodyDic)
            {
                path += $"{body.Key}={body.Value}&";
            }

            Console.WriteLine($"请求路径:{path}");
            var client = new HttpClient();
            var response = await client.GetAsync(path);

            return await response.Content.ReadAsStringAsync();

        }

        #endregion
    }
}
