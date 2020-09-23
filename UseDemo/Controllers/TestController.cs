using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChenYiFan.WeChatOfficialAccountExtension.Services;
using ChenYiFan.WeChatOfficialAccountExtension.Services.Params;
using Microsoft.AspNetCore.Mvc;

namespace UseDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly IWeChatService _weChatService;

        public TestController(IWeChatService weChatService)
        {
            _weChatService = weChatService;
        }

        [HttpPost("/Test/GetAccessToken")]
        public async Task<GetAccessToken> GetAccessTokenAsync()
        {
            var res = await _weChatService.GetAccessTokenAsync();

            return res;
        }
    }
}
