using System;
using System.IO;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;

namespace IDS
{
    public partial class sms : System.Web.UI.Page
    {
        //item class representing contact items
        private class Item
        {
            public string firstName { get; set; }
            public int id { get; set; }
            public string lastName { get; set; }
            public string mobile { get; set; }
            public int status { get; set; }
            public DateTime? time { get; set; }
            public string Otp { get; set; }
            public string verified { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceHolder1.Controls.Add(new Literal { Text = "<h2>WELCOME !</h2>" });
        }

        //this method reads the contactInfo.json file and appends the html table to the placeholder 
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"contactInfo.json"))
            {
                string json = sr.ReadToEnd();
                dynamic items = JsonConvert.DeserializeObject(json);
                StringBuilder html = new StringBuilder();
                html.Append("<thead class='text-danger'>");
                html.Append("<tr>");
                html.Append("<th class='text-center'>"); html.Append("FirstName"); html.Append("</th>");
                html.Append("<th class='text-center'>"); html.Append("LastName"); html.Append("</th>");
                html.Append("<th class='text-center'>"); html.Append("Verified"); html.Append("</th>");
                html.Append("<th></th>");
                html.Append("</tr>");
                html.Append("</thead>");
                html.Append("<tbody>");
                foreach(var item in items)
                {
                    html.Append("<tr>");
                    html.Append("<td>"); html.Append(item.firstName); html.Append("</td>");
                    html.Append("<td>"); html.Append(item.lastName); html.Append("</td>");
                    if (item.verified == "Yes")
                    { html.Append("<td class='text text-info'>"); html.Append(item.verified); html.Append("</td>"); }
                    else
                    { html.Append("<td class='text text-danger'>"); html.Append(item.verified); html.Append("</td>"); }
                    html.Append("<td>"); html.Append("<a href='/info.aspx?id="+item.id+"&name="+item.firstName +" "+ item.lastName+"&contact="+item.mobile+"' target='_blank' class='btn btn-success btn-sm'>View Info</a>"); html.Append("</td>");
                    html.Append("</tr>");
                }
                html.Append("</tbody>");
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }

        }

        //this method sorts the contacts list according to date-time and looks for contacts with status = 1
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"contactInfo.json"))
            {
                string json = sr.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                items.Sort((x, y) => DateTime.Compare(y.time ?? DateTime.MaxValue , x.time ?? DateTime.MaxValue)); //for null handling
                StringBuilder html = new StringBuilder();
                html.Append("<thead class='text-danger'>");
                html.Append("<tr>");
                html.Append("<th class='text-center'>"); html.Append("Name"); html.Append("</th>");
                html.Append("<th class='text-center'>"); html.Append("Time"); html.Append("</th>");
                html.Append("<th class='text-center'>"); html.Append("OTP"); html.Append("</th>");
                html.Append("</tr>");
                html.Append("</thead>");html.Append("<tbody>");
                foreach (var item in items)
                {
                    if(item.status == 1)
                    {
                        html.Append("<tr>");
                        html.Append("<td>"); html.Append(item.firstName + " " + item.lastName); html.Append("</td>");
                        html.Append("<td>"); html.Append(item.time); html.Append("</td>");
                        html.Append("<td>"); html.Append(item.Otp); html.Append("</td>");
                        html.Append("</tr>");
                    }               
                }
                html.Append("</tbody>");
                PlaceHolder1.Controls.Clear();
                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            }
        }
    }

    
}
