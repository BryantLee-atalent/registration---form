using demo1.Business;
using demo1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace demo1
{
    public partial class head : System.Web.UI.Page
    {
        public static string AppId { get; set; }

        public static string AppSecretId { get; set; }

        public static string Token { get; set; }

        public static string Signature { get; set; }

        public static string JsApiList { get; set; }

        public static string NonceStr { get; set; }

        public static string Timestamp { get; set; }

        public static WxConfigInfo Wxconfig { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            AppId = "wx171ac361a68d9dfc"; AppSecretId = "30733a2900231f73b13b65a68f8dd937";
            Token = "enQ7uJNF0mAxFk12yT5anRm1GS5ejCB5lW6h7p2erzUOAjFx4o-ZTY7ZxK9BovbQPd1uEwEPvVIT0I-ONf1AKQwttg5mj6V_-OvUkcvvWw8XOLeAIATKH";


            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppId + "&secret=" + AppSecretId);
            //request.Method = "GET";
            //request.ContentType = "text/html;charset=UTF-8";

            //string result = RequestWx(Token);

            //Wxconfig = GetWxConfig();
        }

        private static void GetOpenId() {

            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="+AppId+ "&redirect_uri=http%3a%2f%2fwechat.atalent.com%2fregistration%2f&response_type=code&scope=snsapi_base &state=STATE#wechat_redirect";
        }

        protected static WxConfigInfo GetWxConfig()
        {
            string jsapi_ticket = "HoagFKDcsGMVCIY2vOjf9vgRCZQZQ0kNCDD9wx8Aqr2joExptWlC6RDdgGASjrhIHZ2BebrK93bZ-v6qt-BXrQ";

            string noncestr = "asWeadfgadfgag";
            string timestamp =Convert.ToInt64((DateTime.UtcNow-DateTime.Now).TotalSeconds).ToString();


            string string1 = "jsapi_ticket=" + jsapi_ticket + "&noncestr" + noncestr + "&timestamp" + timestamp + "&url=http://wechat.atalent.com/registration";

            string signature = FormsAuthentication.HashPasswordForStoringInConfigFile(string1, "SHA1");

            string[] jsApiList = new string[] { "onMenuShareTimeline", "onMenuShareAppMessage" };

            Signature = signature;
            NonceStr = noncestr;
            Timestamp = timestamp;


            WxConfigInfo wx = new WxConfigInfo()
            {
                Signature = signature,
                JsApiList = jsApiList,
                NonceStr = noncestr,
                Timestamp = timestamp,
                AppId = AppId,
                Debug = true
            };
            return wx;
        }

        private static string RequestWx(string token)
        {
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token=" + token + "&type=jsapi");
           // HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + AppId + "&secret=" + AppSecretId);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            return retString;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            bool isValid = this.IsValid;
            //customer valid
            if (string.IsNullOrEmpty(this.emailText.Text))
            {
                isValid = false;
                this.RegularExpressionValidator1.ErrorMessage = "The email field must be filled in.";
                this.RegularExpressionValidator1.IsValid = false;
            }
            else
            {
                this.RegularExpressionValidator1.ErrorMessage = "Please enter the correct email !";
            }
            if (this.titleCombo.SelectedValue.Equals("1"))
            {
                isValid = false;
                this.RequiredFieldValidator3.ErrorMessage = "Please select title field.";
                this.RequiredFieldValidator3.IsValid = false;
            }
            if (this.industryCombo.SelectedValue.Equals("1"))
            {
                isValid = false;
                this.RequiredFieldValidator4.ErrorMessage = "Please select industry field.";
                this.RequiredFieldValidator4.IsValid = false;
            }
            if (string.IsNullOrEmpty(this.confirmText.Text))
            {
                isValid = false;
                this.CompareValidator1.ErrorMessage = "The comfirm email field must be filled in.";
                this.CompareValidator1.IsValid = false;
            }
            else
            {
                this.CompareValidator1.ErrorMessage = "Confirmed email address incorrect";
            }


            if (isValid)
            {
                //构造对象
                UserInfo user = new UserInfo()
                {
                    UserName = this.nameText.Text,
                    CompanyName = this.companyText.Text,
                    Email = this.emailText.Text,
                    Industry = this.industryCombo.SelectedValue,
                    Title = this.titleCombo.SelectedValue
                };

                //插入表Or写入缓存
                this.Insert(user);

                //发送邮件
                if (!string.IsNullOrEmpty(user.Email))
                {
                    this.Email(user);
                }

                //return 并切换页面
                this.RegisterSuccessPage(user.Email);

            }
        }

        private void Insert(UserInfo user)
        {
            Session[string.Format("User{0}", user.Email)] = user;
            //调用导出类的方法
            ExportCsv.Export(user);
        }

        /// <summary>
        /// 发送Email 
        /// </summary>
        private void Email(UserInfo user)
        {
            //调用邮箱帮助类
            SendEmailHelper.SendEmail(user);
        }

        /// <summary>
        /// 页面切换
        /// </summary>
        private void RegisterSuccessPage(string email)
        {
            Response.Redirect("SurveyForm.aspx?email=" + email);
            //Response.Redirect("RegistraSuccess.aspx");

            //延时跳转至调查页面
            //System.Timers.Timer time = new System.Timers.Timer();
            //time.Interval = 5000;//5s
            //time.Enabled=true;
            //if (time.Enabled)
            //{
            //    Console.WriteLine();
            //    Response.Redirect("SurveyForm.aspx");
            //}
        }
    }
}