using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveUp.Net.Mail;
using System.Net.Mail;

namespace SaintSender
{
    
    class MailRepository
    {
        private static Imap4Client client;
        IEnumerable<Message> emailList;

        public MailRepository(string mailServer, int port, bool ssl, string login, string password)
        {
            if (ssl)
                Client.ConnectSsl(mailServer, port);
            else
                Client.Connect(mailServer, port);
            Client.Login(login, password);
            emailList = GetAllMails("inbox");
        }

        public MailRepository(IEnumerable<Message> emailList)
        {
            this.emailList = emailList;
        }

        public MailRepository() { }

        public IEnumerable<Message> GetAllMails(string mailBox)
        {
            return GetMails(mailBox, "ALL").Cast<Message>();
        }

        public IEnumerable<Message> GetUnreadMails(string mailBox)
        {
            return GetMails(mailBox, "UNSEEN").Cast<Message>();
        }

        protected Imap4Client Client
        {
            get { return client ?? (client = new Imap4Client()); }
        }

        private MessageCollection GetMails(string mailBox, string searchPhrase)
        {
            Mailbox mails = Client.SelectMailbox(mailBox);
            MessageCollection messages = mails.SearchParse(searchPhrase);
            return messages;
        }

        

        public static void QuickSend(string from, string to, string subject, string body, string email, string password)
        {


            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(email, password);

            MailMessage mm = new MailMessage(from, to,subject,body);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);


        }
    }
}
