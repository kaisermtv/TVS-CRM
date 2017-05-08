using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;


public class TVSEmail
{
    #region method TVSEmail
    public TVSEmail()
    {
    } 
    #endregion

    #region method FormAddress
    public static String FormAddress
    {
        get
        {
            SmtpSection cfg = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            return cfg.Network.UserName;
        }
    }
    #endregion

    #region method SendMail
    public static bool SendMail(string subject, string body, string to, bool isHtml, bool isSSL)
    {
        bool sent = false;
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(FormAddress, "MOBIFONE 6");
                mail.To.Add(to);
                mail.CC.Add("khoanait@gmail.com");
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;
                SmtpClient client = new SmtpClient();
                client.EnableSsl = isSSL;
                client.Send(mail);
                sent = true;
            }
        }
        catch
        {
            sent = false;
        }
        return sent;
    }
    #endregion

    #region method SendMailCC
    public bool SendMailCC(string subject, string body, string to, bool isHtml, bool isSSL, string listEmail)
    {
        bool sent = false;
        try
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(FormAddress, "CÔNG TY CP PHẦN MỀM TRUNG VIỆT");
                mail.To.Add(to);
                if (listEmail.Trim() != "")
                {
                    string[] tmpList = listEmail.Split(';');
                    foreach (string emailAddredd in tmpList)
                    {
                        if (emailAddredd.Trim() != "")
                        {
                            mail.CC.Add(emailAddredd.Trim());
                        }
                    }
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = isHtml;
                SmtpClient client = new SmtpClient();
                client.EnableSsl = isSSL;
                client.Send(mail);
                sent = true;
            }
        }
        catch
        {
            sent = false;
        }
        return sent;
    }
    #endregion

    public static void SendEmail1(string toEmail, string subject, string message)
    {
        try
        {
            string fromEmail = System.Configuration.ConfigurationManager.ConnectionStrings["FROMEMAIL"].ConnectionString;
            string emailAccount = System.Configuration.ConfigurationManager.ConnectionStrings["ACC"].ConnectionString;
            string emailPass = System.Configuration.ConfigurationManager.ConnectionStrings["PWD"].ConnectionString;
            using (MailMessage mm = new MailMessage(fromEmail, toEmail))
            {
                mm.Subject = subject;
                mm.Body = message;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(emailAccount, emailPass);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
        catch
        {

        }
    }

}