using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaintSender
{
    public partial class UserManagerForm : Form
    {
        User user;
        public UserManagerForm()
        {
            InitializeComponent();
            user = User.Deserialize();
            if(user != null)
            {
                EmailTxt.Text = user.Email;
                PasswordTxt.Text = user.Password;
            }else
            {
                user = new User();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(EmailTxt.Text == "" || PasswordTxt.Text == "")
            {
                MessageBox.Show("Please fill the text areas!", "Error");
                return;
            }
            user.Email = EmailTxt.Text;
            user.Password = PasswordTxt.Text;
            user.Serialize();
            MessageLabel main = new MessageLabel(user);
            Hide();
            main.ShowDialog();
            Close();
        }
    }
}
