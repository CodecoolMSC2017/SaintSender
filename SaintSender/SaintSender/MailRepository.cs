using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveUp.Net.Mail;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SaintSender
{
    [Serializable]
    class MailRepository
    {
        private Imap4Client client;
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

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("emails.dat",
                 FileMode.Create,
                 FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static MailRepository Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();

            if (File.Exists("emails.dat"))
            {
                Stream stream = new FileStream("emails.dat",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                MailRepository m = (MailRepository)formatter.Deserialize(stream);
                stream.Close();
                return m;
            }
            else
            {
                return null;
            }
        }
    }
}
