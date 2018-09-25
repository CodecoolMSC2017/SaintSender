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
using System.Runtime;
using System.Threading;
using Message = ActiveUp.Net.Mail.Message;

namespace SaintSender
{
    public partial class MessageLabel : Form
    {
        MailRepository mailRepository;
        IEnumerable<Message> emailList;
        MailBox mailbox;
        User user;
        private BackgroundWorker _worker;

        public MessageLabel(User user)
        {
            this.user = user;
            InitializeComponent();
            try
            {
                mailRepository = new MailRepository(
                "imap.gmail.com",
                993,
                true,
                user.Email,
                user.Password
            );

                emailList = mailRepository.GetAllMails("inbox");
                mailbox = new MailBox(emailList);
                mailbox.Serialize();
            }
            catch (System.Net.Sockets.SocketException)
            {
                mailbox = MailBox.Deserialize();
                emailList = mailbox.emailList;
            }


            ListViewInit();
            PopulateListView(emailList);
            InitWorker();
            timer1.Enabled = true;


        }

        private void InitWorker()
        {
            if (_worker != null)
            {
                _worker.Dispose();
            }

            _worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _worker.DoWork += DoWork;
            _worker.RunWorkerCompleted += RunWorkerCompleted;
            _worker.RunWorkerAsync();
        }

        void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                emailList = mailRepository.GetAllMails("inbox");
                mailbox = new MailBox(emailList);
            }
            catch (System.Net.Sockets.SocketException)
            {
                mailbox = MailBox.Deserialize();
                emailList = mailbox.emailList;
            }
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            mailbox.Serialize();
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
                    if (email.From.ToString().Contains(Search.Text) || email.BodyText.ToString().Contains(Search.Text) || email.Subject.ToString().Contains(Search.Text))
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

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (ReceiverTxt.Text == "" || SubjectTxt.Text == "" || MessageTxt.Text == "")
            {
                MessageBox.Show("Please fill the text areas!", "Error");
                return;
            }
            string to = ReceiverTxt.Text;
            string subject = SubjectTxt.Text;
            string body = MessageTxt.Text;
            MailRepository.QuickSend(user.Email, to, subject, body, user.Email, user.Password);
            ReceiverTxt.Text = "";
            SubjectTxt.Text = "";
            MessageTxt.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            InitWorker();
        }
    }
}