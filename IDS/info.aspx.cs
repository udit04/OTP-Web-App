using System;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IDS
{
    public partial class info : System.Web.UI.Page
    {
        string name, contact, id;
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the user directly opens or makes a get request without query string
            if (Request.QueryString.HasKeys() == false)
                Response.Redirect("sms.aspx");
            else
            {
                name = Request.QueryString["name"];
                contact = Request.QueryString["contact"];
                id = Request.QueryString["id"];
                namePlc.Controls.Add(new Literal { Text = name });
                contactPlc.Controls.Add(new Literal { Text = contact });
            }
        }

        //sid and toke ntaken from config manager - app settings
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string json;
            // Your Account SID from twilio.com/console
            var accountSid = ConfigurationManager.AppSettings["sid"];
            // Your Auth Token from twilio.com/console
            var authToken = ConfigurationManager.AppSettings["token"];

            TwilioClient.Init(accountSid, authToken);
            string pno = "+91" + contact;
            try
            {
                using (StreamReader sr = new StreamReader(Server.MapPath("~/") + @"contactInfo.json"))
                {
                    json = sr.ReadToEnd();
                    dynamic items = JsonConvert.DeserializeObject(json);
                    foreach (var item in items)
                    {
                        //if only the id matches the query string    
                        if (item.id == id)
                        {
                            // if only the status is != 1 i.e message has not been sent already
                            if (item.status != 1)
                            {
                                var message = MessageResource.Create(
                                to: new PhoneNumber(pno),
                                from: new PhoneNumber("+13343103071"),
                                body: "Hi.Your OTP is: " + txtOtp.Text);
                                item.OTP = txtOtp.Text;
                                item.time = DateTime.Now;
                                item.status = 1;
                                json = JsonConvert.SerializeObject(items, Formatting.Indented);
                                flag = 1;
                                Response.Write("<script>alert('Message Sent Successfully');</script>"); 
                            }
                            else
                                Response.Write("<script>alert('Message Sent Already');</script>");

                            break;
                        }                   
                    }
                }
                if (flag == 1)
                    File.WriteAllText(Server.MapPath("~/") + @"contactInfo.json", json);
            }
            //catching any error and displaying alert on user end
            catch(Exception ex)
            {
                    Response.Write("<script>alert('Error in Sending Message');</script>");
            }
            
        }
    }
}