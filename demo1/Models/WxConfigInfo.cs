using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models
{
    public class WxConfigInfo
    {
        public bool Debug { get; set; }

        public string AppId { get; set; }

        public string Timestamp { get; set; }

        public string NonceStr { get; set; }

        public string Signature { get; set; }

        public string[] JsApiList { get; set; }

        public WxConfigInfo() { }
    }
}