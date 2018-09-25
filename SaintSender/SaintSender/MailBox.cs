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
    class MailBox
    {
        public List<Message> emailList { get; set; }

        public MailBox(IEnumerable<Message> emailList)
        {
            this.emailList = emailList.ToList();
        }

        public MailBox() { }

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("emails.dat",
                 FileMode.Create,
                 FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static MailBox Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();

            if (File.Exists("emails.dat"))
            {
                Stream stream = new FileStream("emails.dat",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                MailBox m = (MailBox)formatter.Deserialize(stream);
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
