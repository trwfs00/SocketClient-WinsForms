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
        private bool joinedRoom = false;  // Track if the user has joined a room

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

            string message;
            if (e.IsBinary)
            {
                using (var stream = new MemoryStream(e.RawData))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    message = await reader.ReadToEndAsync();
                }
            }
            else
            {
                message = e.Data;  // Handle text messages directly
            }

            // Log received message for debugging
            Console.WriteLine($"Received message: {message}");

            // Handle and display the message
            AppendMessage(message);
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
            else if (message.StartsWith("System:"))
            {
                chatBox.SelectionAlignment = HorizontalAlignment.Center;
                chatBox.AppendText($"{message}\n");
            }
            else
            {
                // In case message does not match expected prefixes, align left by default
                chatBox.SelectionAlignment = HorizontalAlignment.Left;
                chatBox.AppendText($"{message}\n");
            }

            // Ensure the chat box scrolls to the latest message
            chatBox.SelectionStart = chatBox.Text.Length;
            chatBox.ScrollToCaret();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!joinedRoom)
            {
                // Display a message instructing the user to join a room first
                var warningMessage = "System: Please join a room first.";
                AppendMessage(warningMessage);
                return;
            }

            if (ws.ReadyState == WebSocketState.Open && !string.IsNullOrWhiteSpace(messageInput.Text))
            {
                var message = $"WinForms: {messageInput.Text}";
                var blob = Encoding.UTF8.GetBytes(message);

                // Send the message to the WebSocket server
                ws.Send(blob);

                // Display the sent message in the chat box immediately
                AppendMessage(message);

                // Log sent message for debugging
                Console.WriteLine($"Sent message: {message}");

                // Clear the input box after sending the message
                messageInput.Clear();
            }
        }

        private void joinRoomButton_Click(object sender, EventArgs e)
        {
            if (ws.ReadyState == WebSocketState.Open && !string.IsNullOrWhiteSpace(roomInput.Text))
            {
                var roomName = roomInput.Text.Trim();
                var message = $"{{\"action\": \"join\", \"room\": \"{roomName}\"}}";
                ws.Send(Encoding.UTF8.GetBytes(message));

                // Display a message in the chat area about the successful room join
                var joinMessage = $"System: Joined room '{roomName}'";
                AppendMessage(joinMessage);

                // Update the state to indicate the user has joined a room
                joinedRoom = true;
                sendButton.Enabled = true;  // Enable the send button

                // Log room join message for debugging
                Console.WriteLine($"Joined room: {roomName}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sendButton.Enabled = false;  // Disable send button until a room is joined
        }
    }
}
