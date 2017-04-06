using demo1.Business;
using demo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace demo1
{
    public partial class SurveyForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            SurveyInfo survey = new SurveyInfo()
            {
                OneQuestion = this.oneRadio.SelectedValue,
                TwoQuestion = this.twoRadio.SelectedValue,
                ThreeQuestion = this.threeRadio.SelectedValue,
                FourQuestion = this.fourRadio.SelectedValue
            };

            if (!string.IsNullOrEmpty(survey.OneQuestion)&& !string.IsNullOrEmpty(survey.TwoQuestion)&&!string.IsNullOrEmpty(survey.ThreeQuestion)&& !string.IsNullOrEmpty(survey.FourQuestion))
            {
                string email = Request.QueryString["email"];

                UserInfo user = (UserInfo)Session[string.Format("User{0}", email)];

                //调用导出类的方法
                ExportCsv.UseCsv(user, survey);

                //使用完之后销毁Session
                Session.Remove(string.Format("User{0}", email));

                //发送email
                SendEmail(user, survey);
                Response.Redirect("RegistraSuccess.aspx");
            }
        }

        private static void SendEmail(UserInfo user, SurveyInfo survey) {
            string mailForm = "hi@atalent.com";
            SendEmailHelper.SendRegister(SendEmailHelper.GetSmtp(), mailForm, user, true, survey);
        }
    }
}