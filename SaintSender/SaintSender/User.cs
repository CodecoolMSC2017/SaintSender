using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SaintSender
{

    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public User() { }

        public User(String name, String email, String password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = Password;
        }

        public void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("user.dat",
                 FileMode.Create,
                 FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, this);
            stream.Close();
        }

        public static User Deserialize()
        {
            IFormatter formatter = new BinaryFormatter();

            if (File.Exists("user.dat"))
            {
                Stream stream = new FileStream("user.dat",
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
                User u = (User)formatter.Deserialize(stream);
                stream.Close();
                return u;
            }
            else
            {
                return null;
            }
        }
    }

}
