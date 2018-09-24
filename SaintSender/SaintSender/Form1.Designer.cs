namespace SaintSender
{
    partial class MainForm
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
            this.SuspendLayout();
            // 
            // Emails
            // 
            this.Emails.Location = new System.Drawing.Point(164, 48);
            this.Emails.Name = "Emails";
            this.Emails.Size = new System.Drawing.Size(823, 471);
            this.Emails.TabIndex = 0;
            this.Emails.UseCompatibleStateImageBehavior = false;
            this.Emails.DoubleClick += new System.EventHandler(this.Emails_DoubleClick);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(326, 12);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(505, 20);
            this.Search.TabIndex = 1;
            this.Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 531);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.Emails);
            this.Name = "MainForm";
            this.Text = "Saint Sender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView Emails;
        private System.Windows.Forms.TextBox Search;
    }
}

