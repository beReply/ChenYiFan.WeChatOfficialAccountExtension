using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChenYiFan.WeChatOfficialAccountExtension.Services.Params
{
    /// <summary>
    /// 用于接收解析微信参数
    /// </summary>
    public class ReceiveMessage
    {

        #region 必有参数

        [DisplayName("开发者微信号")]
        public string ToUserName { get; set; }

        [DisplayName("发送方帐号，一个OpenID")]
        public string FromUserName { get; set; }

        [DisplayName("消息创建时间")]
        public string CreateTime { get; set; }

        [DisplayName("消息类型")]
        public string MsgType { get; set; }

        [DisplayName("消息Id")]
        public string MsgId { get; set; }


        #endregion

        #region 文本消息

        public string Content { get; set; }

        #endregion

        #region 媒体

        // 媒体id
        public string MediaId { get; set; }

        // 图片链接
        public string PicUrl { get; set; }

        // 语音格式
        public string Format { get; set; }

        // 视频，小视频消息
        public string ThumbMediaId { get; set; }

        #endregion

        #region 地理位置

        public double Location_X { get; set; }

        public double Location_Y { get; set; }

        public double Scale { get; set; }

        public string Label { get; set; }

        #endregion

        #region 链接消息

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        #endregion

    }
}
