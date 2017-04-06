using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using demo1.Models;
using System.Text;

namespace demo1.Business
{
    public class SendEmailHelper
    {
        public static SmtpClient GetSmtp() {
            //写死发送方
            string smtpServer = "smtp.office365.com";
            string mailForm = "hi@atalent.com";
            string pwd = "Better2017!";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailForm, pwd);//用户名和密码
            smtpClient.Port = 587;//端口号
            smtpClient.EnableSsl = true;//加密传输

            return smtpClient;
        }

        public static void SendEmail(UserInfo user)
        {

            SmtpClient smtpClient = GetSmtp();

            //MailAddress mailsend = new MailAddress("hi@atalent.com","Hi @ aTalent");

            ////发送
            //MailMessage email = new MailMessage(mailsend, new MailAddress(user.Email));
            //string emailTitle = "Thanks for your registration for our event";
            //email.Subject = emailTitle;

            //string emailContent = string.Format("Hi {0},<br /><br />", user.UserName);
            //emailContent += "Thanks for your registration for our event, you will receive a confirmation within the next two days!<br /><br />";
            //emailContent += "Regards,<br /><br /><br />";
            //emailContent += "aTalent & Maximum Team<br /><br />";

            //email.Body = emailContent;
            //email.BodyEncoding = Encoding.UTF8;
            //email.IsBodyHtml = true;//设置为HTML格式
            //email.Priority = MailPriority.Normal;

            SendRegister(smtpClient, "hi@atalent.com", user,false,null);
            try
            {
              //  smtpClient.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //传递注册信息
        public static void SendRegister(SmtpClient smtp,string mailForm,UserInfo user,bool isSurvey,SurveyInfo info)
        {
            MailMessage emailClient = new MailMessage(mailForm, "wengang@atalent.com");
            string subject = isSurvey ? "Survey Submitted!" : "User Registered!";
            emailClient.Subject = subject; 
            emailClient.Body = string.Format("Time: {0}<br />Name: {1}<br />Title: {2}<br />Industry: {3}<br />Company: {4}<br />Email: {5}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),user.UserName,user.Title,user.Industry,user.CompanyName,user.Email);
            if (isSurvey)
            {
                emailClient.Body += string.Format("<br /><br />Question 1: {0}<br />Question 2: {1}<br />Question 3: {2}<br />Question 4: {3}", info.OneQuestion,info.TwoQuestion,info.ThreeQuestion,info.FourQuestion);
            }
            emailClient.BodyEncoding = Encoding.UTF8;
            emailClient.IsBodyHtml = true;//设置为HTML格式
            emailClient.Priority = MailPriority.Normal;

            emailClient.CC.Add("bryant.lee@atalent.com");
            emailClient.CC.Add("kevin.xia@atalent.com");
            emailClient.CC.Add("xinyi.huang@maximum.com");
            emailClient.CC.Add("emile.macgillavry@maximum.com");

            try
            {
                smtp.Send(emailClient);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}