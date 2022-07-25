using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace commonlayer.Model
{
    public class MsmqModel
    {
        MessageQueue msqQueue = new MessageQueue();

        public void MsmqSend(string token)
        {
            msqQueue.Path = @".\private$\Token";  // windows msmq path
            if (!MessageQueue.Exists(msqQueue.Path))
            {
                MessageQueue.Create(msqQueue.Path);
            }

            msqQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            msqQueue.ReceiveCompleted += MsqQueue_ReceiveCompleted;
            msqQueue.Send(token);
            msqQueue.BeginReceive();
            msqQueue.Close();

        }

        private void MsqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = msqQueue.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();

            string subject = "Fundoo Notes password reset";
            string body = token;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials=false,
                Credentials = new NetworkCredential("gorenitya123@gmail.com", "iqjjtbivxlfkpnpe"),
                EnableSsl = true
            };

            smtpClient.Send("gorenitya123@gmail.com", "gorenitya123@gmail.com", subject, body);
            msqQueue.BeginReceive();

        }
    }
}
