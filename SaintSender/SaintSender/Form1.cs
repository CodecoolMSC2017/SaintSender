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
    public partial class MainForm : Form
    {
        MailRepository mailRepository;
        IEnumerable<Message> emailList;
        public MainForm()
        {
            InitializeComponent();
            mailRepository = new MailRepository(
                        "imap.gmail.com",
                        993,
                        true,
                        "lendahandcontact@gmail.com",
                        "Jancsika13"
                    );

            emailList = mailRepository.GetAllMails("inbox");
            ListViewInit();
            PopulateListView(emailList);
        }

        private void ListViewInit()
        {
            Emails.View = View.Details;

            Emails.Columns.Add("From");
            Emails.Columns.Add("Subject");
            Emails.Columns.Add("Date");
            Emails.Columns.Add("Attachments");


            Emails.GridLines = true;
            Emails.FullRowSelect = true;
            Emails.Columns[0].Width = 250;
            Emails.Columns[1].Width = 280;
            Emails.Columns[2].Width = 170;
            Emails.Columns[3].Width = 118;
        }

        private void PopulateListView(IEnumerable<Message> emailList)
        {
            Emails.Items.Clear();
            foreach (Message email in emailList)
            {
                bool attachments = false;
                if (email.Attachments.Count > 0)
                {
                    attachments = true;
                }
                string from = email.From.ToString().Split('<')[0];
                Emails.Items.Add(new ListViewItem(new string[] { from, email.Subject.ToString(), email.Date.ToString(), attachments.ToString() }));
            }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                List<Message> newList = new List<Message>();
                foreach (Message email in emailList)
                {
                    if(email.From.ToString().Contains(Search.Text) || email.BodyText.ToString().Contains(Search.Text) || email.Subject.ToString().Contains(Search.Text))
                    {
                        newList.Add(email);
                    }
                }
                PopulateListView(newList);
            }

        }

        private void Emails_DoubleClick(object sender, EventArgs e)
        {
            var date = Emails.SelectedItems[0].SubItems[2].Text;
            ShowEmailByDate(date);
        }

        private void ShowEmailByDate(String date)
        {
            foreach (Message email in emailList)
            {
                if (email.Date.ToString().Equals(date))
                {
                    EmailForm form = new EmailForm(email);
                    form.ShowDialog();
                    break;
                }
            }
        }
    }
}
