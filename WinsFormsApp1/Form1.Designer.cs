namespace WinsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.messageInput = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chatBox
            // 
            this.chatBox.Location = new System.Drawing.Point(12, 12);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(360, 200);
            this.chatBox.TabIndex = 0;
            // 
            // messageInput
            // 
            this.messageInput.Location = new System.Drawing.Point(12, 232);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(279, 20);
            this.messageInput.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(297, 230);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(12, 215);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.connectionStatusLabel.TabIndex = 3;
            this.connectionStatusLabel.Text = "Status:";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.chatBox);
            this.Name = "MainForm";
            this.Text = "Chat WinForms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label connectionStatusLabel;
    }
}
