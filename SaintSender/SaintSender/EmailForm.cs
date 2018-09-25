using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActiveUp.Net.Mail;
using Message = ActiveUp.Net.Mail.Message;


namespace SaintSender
{
    public partial class EmailForm : Form
    {
        public EmailForm(Message email)
        {
            InitializeComponent();
            this.EmailContent.Text = email.BodyText.Text;
        }
    }
}
