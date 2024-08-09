namespace WinsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controls for Room Joining and Chatting
        private System.Windows.Forms.TextBox roomInput;
        private System.Windows.Forms.Button joinRoomButton;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label connectionStatusLabel;

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
            // Room Input
            this.roomInput = new System.Windows.Forms.TextBox();
            this.roomInput.Location = new System.Drawing.Point(12, 12);
            this.roomInput.Name = "roomInput";
            this.roomInput.Size = new System.Drawing.Size(279, 20);
            this.roomInput.TabIndex = 4;
            this.roomInput.Text = "default-room"; // Default room

            // Join Room Button
            this.joinRoomButton = new System.Windows.Forms.Button();
            this.joinRoomButton.Location = new System.Drawing.Point(297, 10);
            this.joinRoomButton.Name = "joinRoomButton";
            this.joinRoomButton.Size = new System.Drawing.Size(75, 23);
            this.joinRoomButton.TabIndex = 5;
            this.joinRoomButton.Text = "Join Room";
            this.joinRoomButton.UseVisualStyleBackColor = true;
            this.joinRoomButton.Click += new System.EventHandler(this.joinRoomButton_Click);

            // Chat Box
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.chatBox.Location = new System.Drawing.Point(12, 50);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(360, 200);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            this.chatBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            // Message Input
            this.messageInput = new System.Windows.Forms.TextBox();
            this.messageInput.Location = new System.Drawing.Point(12, 270);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(279, 20);
            this.messageInput.TabIndex = 1;

            // Send Button
            this.sendButton = new System.Windows.Forms.Button();
            this.sendButton.Location = new System.Drawing.Point(297, 268);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);

            // Connection Status Label
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(12, 240);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(40, 13);
            this.connectionStatusLabel.TabIndex = 3;
            this.connectionStatusLabel.Text = "Status:";

            // MainForm
            this.ClientSize = new System.Drawing.Size(384, 311);
            this.Controls.Add(this.roomInput);
            this.Controls.Add(this.joinRoomButton);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.sendButton);
            this.Name = "MainForm";
            this.Text = "Chat WinForms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
