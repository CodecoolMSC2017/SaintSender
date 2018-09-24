namespace SaintSender
{
    partial class MessageLabel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Emails = new System.Windows.Forms.ListView();
            this.Search = new System.Windows.Forms.TextBox();
            this.ReceiverLabel = new System.Windows.Forms.Label();
            this.ReceiverTxt = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.SubjectTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MessageTxt = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Emails
            // 
            this.Emails.Location = new System.Drawing.Point(12, 48);
            this.Emails.Name = "Emails";
            this.Emails.Size = new System.Drawing.Size(823, 471);
            this.Emails.TabIndex = 0;
            this.Emails.UseCompatibleStateImageBehavior = false;
            this.Emails.DoubleClick += new System.EventHandler(this.Emails_DoubleClick);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(170, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(505, 20);
            this.Search.TabIndex = 1;
            this.Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // ReceiverLabel
            // 
            this.ReceiverLabel.AutoSize = true;
            this.ReceiverLabel.Location = new System.Drawing.Point(1005, 48);
            this.ReceiverLabel.Name = "ReceiverLabel";
            this.ReceiverLabel.Size = new System.Drawing.Size(50, 13);
            this.ReceiverLabel.TabIndex = 2;
            this.ReceiverLabel.Text = "Receiver";
            // 
            // ReceiverTxt
            // 
            this.ReceiverTxt.Location = new System.Drawing.Point(918, 64);
            this.ReceiverTxt.Name = "ReceiverTxt";
            this.ReceiverTxt.Size = new System.Drawing.Size(203, 20);
            this.ReceiverTxt.TabIndex = 3;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(1005, 134);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(43, 13);
            this.SubjectLabel.TabIndex = 4;
            this.SubjectLabel.Text = "Subject";
            // 
            // SubjectTxt
            // 
            this.SubjectTxt.Location = new System.Drawing.Point(918, 150);
            this.SubjectTxt.Name = "SubjectTxt";
            this.SubjectTxt.Size = new System.Drawing.Size(203, 20);
            this.SubjectTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1005, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mesage";
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(918, 237);
            this.MessageTxt.Multiline = true;
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.Size = new System.Drawing.Size(203, 209);
            this.MessageTxt.TabIndex = 7;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(994, 466);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 26);
            this.SendBtn.TabIndex = 8;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // MessageLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 531);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SubjectTxt);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.ReceiverTxt);
            this.Controls.Add(this.ReceiverLabel);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Emails);
            this.Name = "MessageLabel";
            this.Text = "Saint Sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Emails;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Label ReceiverLabel;
        private System.Windows.Forms.TextBox ReceiverTxt;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.TextBox SubjectTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MessageTxt;
        private System.Windows.Forms.Button SendBtn;
    }
}

