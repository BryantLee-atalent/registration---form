using demo1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace demo1.Business
{
    public class ExportCsv
    {
        public static void Export(UserInfo user)
        {
            string path = "C:\\Registration";
            string filePath = string.Format("C:\\Registration\\Registration(" + user.UserName + "-" + user.Email + ").csv");
            //判断目录里面是否存在文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //是否存在文件
            bool isCreate = !File.Exists(filePath);
            FileStream file = new FileStream(filePath, isCreate ? FileMode.Create : FileMode.Append);

            StreamWriter sw = new StreamWriter(new BufferedStream(file), System.Text.Encoding.UTF8);
            DataTable table = FillDataTable(user);

            if (isCreate)
                sw.WriteLine("Name,Title,Industry,Company,Email,Question 1,Question 2,Question 3,Question 4");


            StringBuilder sb = new StringBuilder();
            foreach (DataRow item in table.Rows)
            {
                if (!string.IsNullOrEmpty(item["UserName"].ToString()))
                    sb.Append(item["UserName"] + ",");

                if (!string.IsNullOrEmpty(item["Title"].ToString()))
                    sb.Append(item["Title"] + ",");

                if (!string.IsNullOrEmpty(item["Industry"].ToString()))
                    sb.Append(item["Industry"] + ",");

                if (!string.IsNullOrEmpty(item["CompanyName"].ToString()))
                    sb.Append(item["CompanyName"] + ",");

                if (!string.IsNullOrEmpty(item["Email"].ToString()))
                    sb.Append(item["Email"]);

            }
            //写datatable的一行
            sw.WriteLine(sb.ToString());

            sw.Close();
            file.Close();
        }

        private static DataTable FillDataTable(UserInfo user)
        {
            //创建一个datatable
            DataTable dt = new DataTable(typeof(UserInfo).Name);

            PropertyInfo[] info = typeof(UserInfo).GetProperties();
            foreach (var item in info)
            {
                dt.Columns.Add(item.Name, item.PropertyType);

                //写入值
                DataRow dr = dt.NewRow();
                dr[item.Name] = item.GetValue(user);

                dt.Rows.Add(dr);
            }

            return dt;
        }

        //使用csv文件
        public static void UseCsv(UserInfo user,SurveyInfo survey) {
          //  string filePath = string.Format("C:\\Registration\\Registration(" + user.UserName + "-" + user.Email + "-" + DateTime.Now.ToString() + ").csv");
            string filePath = string.Format("C:\\Registration\\Registration(" + user.UserName + "-" + user.Email + ").csv");
            FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            try
            {   
                DataTable dt = GetDt(fs);
                fs.Close();

                fs = new FileStream(filePath, System.IO.FileMode.Truncate, System.IO.FileAccess.ReadWrite);
                fs.Close();

                fs = new FileStream(filePath, System.IO.FileMode.Append);
                //重新写入数据
                StreamWriter sw = new StreamWriter(new BufferedStream(fs), System.Text.Encoding.UTF8);
                sw.WriteLine("Name,Title,Industry,Company,Email,Question 1,Question 2,Question 3,Question 4");
                foreach (DataRow item in dt.Rows)
                {
                    StringBuilder sb = new StringBuilder();
                    //数据是否相等(全匹配则写入调研的数据)
                    if (item["Name"].Equals(user.UserName)&& item["Title"].Equals(user.Title)&& item["Industry"].Equals(user.Industry) && item["Company"].Equals(user.CompanyName) && item["Email"].Equals(user.Email))
                    {
                        item["Question 1"] = survey.OneQuestion;
                        item["Question 2"] = survey.TwoQuestion;
                        item["Question 3"] = survey.ThreeQuestion;
                        item["Question 4"] = survey.FourQuestion;
                    }

                    if (!string.IsNullOrEmpty(item["Name"].ToString()))
                        sb.Append(item["Name"] + ",");

                    if (!string.IsNullOrEmpty(item["Title"].ToString()))
                        sb.Append(item["Title"] + ",");

                    if (!string.IsNullOrEmpty(item["Industry"].ToString()))
                        sb.Append(item["Industry"] + ",");

                    if (!string.IsNullOrEmpty(item["Company"].ToString()))
                        sb.Append(item["Company"] + ",");

                    if (!string.IsNullOrEmpty(item["Email"].ToString()))
                        sb.Append(item["Email"] + ",");

                    if (!string.IsNullOrEmpty(item["Question 1"].ToString()))
                        sb.Append(item["Question 1"] + ",");

                    if (!string.IsNullOrEmpty(item["Question 2"].ToString()))
                        sb.Append(item["Question 2"] + ",");

                    if (!string.IsNullOrEmpty(item["Question 3"].ToString()))
                        sb.Append(item["Question 3"]+",");

                    if (!string.IsNullOrEmpty(item["Question 4"].ToString()))
                        sb.Append(item["Question 4"]+",");

                    sw.WriteLine(sb.ToString().TrimEnd(',')); 
                }

                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                fs.Close();
                throw ex;
            }
        }

        //读取csv到DataTable中
        private static DataTable GetDt(FileStream fs) {
            DataTable dt = new DataTable();

            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        tableHead[i] = tableHead[i].Replace("\"", "");
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    aryLine = strLine.Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < aryLine.Length; j++)
                    {
                        dr[j] = aryLine[j].Replace("\"", "");
                    }
                    dt.Rows.Add(dr);
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[2] + " " + "DESC";
            }
            sr.Close();
            
            return dt;
        }
    }
}