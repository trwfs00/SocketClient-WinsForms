using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;

namespace WinsFormsApp1
{
    public partial class Form1 : Form
    {
        private WebSocket ws;

        public Form1()
        {
            InitializeComponent();
            ws = new WebSocket("ws://localhost:8080");
            ws.OnMessage += (sender, e) => OnMessageReceived(e);
            ws.OnOpen += (sender, e) => SetConnectionStatus("Connected");
            ws.OnClose += (sender, e) => SetConnectionStatus("Disconnected");
            ws.OnError += (sender, e) => SetConnectionStatus("Error");
            ws.Connect();
        }

        private void SetConnectionStatus(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetConnectionStatus), status);
                return;
            }
            connectionStatusLabel.Text = $"Status: {status}";
        }

        private async void OnMessageReceived(MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<MessageEventArgs>(OnMessageReceived), e);
                return;
            }

            if (e.IsBinary)
            {
                using (var stream = new MemoryStream(e.RawData))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var message = await reader.ReadToEndAsync();
                    AppendMessage(message);
                }
            }
            else
            {
                AppendMessage("Received non-binary message");
            }
        }

        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), message);
                return;
            }

            if (message.StartsWith("React:"))
            {
                chatBox.SelectionAlignment = HorizontalAlignment.Left;
                chatBox.AppendText($"{message}\n");
            }
            else if (message.StartsWith("WinForms:"))
            {
                chatBox.SelectionAlignment = HorizontalAlignment.Right;
                chatBox.AppendText($"{message}\n");
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (ws.ReadyState == WebSocketState.Open && !string.IsNullOrWhiteSpace(messageInput.Text))
            {
                var message = $"WinForms: {messageInput.Text}";
                var blob = Encoding.UTF8.GetBytes(message);
                ws.Send(blob);
                messageInput.Clear();
            }
        }
    }
}
