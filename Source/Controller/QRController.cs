using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using HH.TiYu.Cloud.BLL;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace HH.TiYu.Cloud.WX
{
    public class QRController : ApiController
    {
        [HttpGet()]
        [Route("qrimg/{wxid}/{sid}",Name="qrImg")]
        public HttpResponseMessage GetQRImg(string wxid, string sid)
        {
            var wx = WXManager.Current[wxid];
            if (wx == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            var s = new StudentBLL(wx.DBConnect).GetByID(sid).QueryObject;
            if (s == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            var temp = string.Format("{0}{1}", !string.IsNullOrEmpty(s.IDNumber) ? s.IDNumber : s.ID.PadLeft(18, ' '), s.Name);
            var base64 = Convert.ToBase64String(System.Text.ASCIIEncoding.UTF8.GetBytes(temp));
            qrEncoder.TryEncode(base64, out qrCode);

            var renderer = new DrawingBrushRenderer(new FixedModuleSize(5, QuietZoneModules.Two));
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormatEnum.JPEG, ms);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(ms.ToArray());
            //Inline是直接显示,attachment作为附件下载
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;
        }


        [HttpGet()]
        [Route("qr/{wxid}/{sid}")]
        public HttpResponseMessage GetQR(string wxid, string sid)
        {
            var wx = WXManager.Current[wxid];
            if (wx == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            var s = new StudentBLL(wx.DBConnect).GetByID(sid).QueryObject;
            if (s == null) return Request.CreateResponse(HttpStatusCode.NotFound);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var html = "<!DOCTYPE html>" + Environment.NewLine;
            html += "<html>" + Environment.NewLine;
            html += "<head>" + Environment.NewLine;
            html += @"<meta charset = ""utf-8"" />" + Environment.NewLine;
            html += @"</head>" + Environment.NewLine;
            html += @"<body>" + Environment.NewLine;
            html += @"<div style=""margin-top:10%;"">" + Environment.NewLine;
            var dic = new Dictionary<string, object>();
            dic.Add("wxid", wxid);
            dic.Add("sid", sid);
            var url = Request.GetUrlHelper().Route("qrImg", dic);
            html += string.Format(@"<img  src = ""{0}""  alt = ""二维码""  style = ""width:80%;display: block; margin:auto; "" />" + Environment.NewLine, url);
            html += @"</div>" + Environment.NewLine;
            html += @"</body>" + Environment.NewLine;
            html += @"</html>" + Environment.NewLine;
            result.Content = new StringContent(html);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return result;
        }
    }
}
