using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.Models
{
    public class UserInfo
    {
        public string UserName { get; set; }

        public string Title { get; set; }

        public string Industry { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public UserInfo() { }

        public UserInfo(UserInfo data){
            this.UserName = data.UserName;
            this.Title = data.Title;
            this.Industry = data.Industry;
            this.CompanyName = data.CompanyName;
            this.Email = data.Email;
        }
    }
}